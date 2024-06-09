using RtspClientSharp.Rtsp;
using RtspClientSharp;
using System;
using System.Drawing;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.IO;
using Ookii.Dialogs;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Web;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic;

namespace IPWebcam
{
    public partial class frmWeb : Form
    {
        const int WS_MINIMIZEBOX = 0x20000;
        const int CS_DBCLKS = 0x8;
        private string filePath = "";
        private string screenshotPath = "";
        private string fontName = "Cambria";
        private float fontSize = 16;
        private Color textColor = Color.White;
        private string fileName;
        private string fullPath;
        private TimeSpan elapsedTime = TimeSpan.Zero;
        private CancellationTokenSource _cancellationTokenSource;
        private Process ffmpegProcess;
        private int screenshotCounter = 0;

        public frmWeb()
        {
            InitializeComponent();
            LoadWebcam();
            txtIPAddress.Select();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= WS_MINIMIZEBOX;
                cp.ClassStyle |= CS_DBCLKS;
                return cp;
            }
        }

        private void LoadWebcam()
        {
            try
            {
                if (!String.IsNullOrEmpty(Properties.Settings.Default.streamPath))
                {
                    filePath = Properties.Settings.Default.streamPath;
                }
                else
                {
                    AlertNotification.ShowAlertMessage("Please set file storage path.", AlertNotification.AlertType.WARNING);
                }

                if (!String.IsNullOrEmpty(Properties.Settings.Default.picLocation))
                {
                    screenshotPath = Properties.Settings.Default.picLocation;
                }
                else
                {
                    AlertNotification.ShowAlertMessage("Please select screenshots folder.", AlertNotification.AlertType.WARNING);
                }

                MaximizedBounds = Screen.GetWorkingArea(this);
                WindowState = FormWindowState.Maximized;
                tPicInterval.Interval = Properties.Settings.Default.picInterval;
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                MessageBox.Show($"Error loading settings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string FormatElapsedTime(TimeSpan timeSpan)
        {
            // Format the elapsed time to include hours, minutes, and seconds
            return timeSpan.ToString(@"hh\:mm\:ss");
        }

        static Bitmap CaptureControlScreenshot(Control control)
        {
            Bitmap screenshot = new Bitmap(1280, 720);
            control.Invoke((MethodInvoker)delegate { control.DrawToBitmap(screenshot, new Rectangle(0, 0, 1280, 720)); });
            return screenshot;
        }

        static double CalculateColorPercentage(Bitmap image, Color color)
        {
            int totalPixels = image.Width * image.Height;
            int colorPixels = 0;

            // Lock the bitmap's bits.  
            Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);
            BitmapData bmpData =
                image.LockBits(rect, ImageLockMode.ReadWrite,
                image.PixelFormat);

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            // Declare an array to hold the bytes of the bitmap.
            int bytes = Math.Abs(bmpData.Stride) * image.Height;
            byte[] rgbValues = new byte[bytes];

            // Copy the RGB values into the array.
            Marshal.Copy(ptr, rgbValues, 0, bytes);

            // Check color in every 4 bytes (RGBA)
            for (int i = 0; i < rgbValues.Length; i += 4)
            {
                if (rgbValues[i] == color.B && rgbValues[i + 1] == color.G && rgbValues[i + 2] == color.R)
                {
                    colorPixels++;
                }
            }

            // Unlock the bits.
            image.UnlockBits(bmpData);

            // Calculate the percentage of pixels with the specified color
            double colorPercentage = (double)colorPixels / totalPixels * 100;
            return colorPercentage;
        }

        static double CalculateBlackPercentage(Bitmap image)
        {
            Color black = Color.FromArgb(0, 0, 0);
            return CalculateColorPercentage(image, black);
        }

        static double CalculateGrayPercentage(Bitmap image)
        {
            Color gray = Color.FromArgb(128, 128, 128); // Adjust as needed
            return CalculateColorPercentage(image, gray);
        }

        static double CalculateLightGrayPercentage(Bitmap image)
        {
            Color lightGray = Color.FromArgb(192, 192, 192); // Adjust as needed
            return CalculateColorPercentage(image, lightGray);
        }

        static double CalculateDarkGrayPercentage(Bitmap image)
        {
            Color darkGray = Color.FromArgb(64, 64, 64); // Adjust as needed
            return CalculateColorPercentage(image, darkGray);
        }

        private async Task StartColorPixelMonitoringTask()
        {
            await Task.Run(async () =>
            {
                while (true)
                {
                    if (videoPlayer1 != null)
                    {
                        // Capture the screenshot from the control
                        Bitmap screenshot = null;
                        videoPlayer1.Invoke((MethodInvoker)delegate
                        {
                            screenshot = CaptureControlScreenshot(videoPlayer1);
                        });

                        if (screenshot != null)
                        {
                            // Check if the stream contains significant percentages of black, gray, light gray, and dark gray pixels
                            double blackPercentage = CalculateBlackPercentage(screenshot);
                            double grayPercentage = CalculateGrayPercentage(screenshot);
                            double lightGrayPercentage = CalculateLightGrayPercentage(screenshot);
                            double darkGrayPercentage = CalculateDarkGrayPercentage(screenshot);

                            // Set the thresholds to 98% for each color
                            double threshold = 98.0;

                            if (blackPercentage >= threshold || grayPercentage >= threshold || lightGrayPercentage >= threshold || darkGrayPercentage >= threshold)
                            {
                                // Show alert message
                                videoPlayer1.Invoke((MethodInvoker)delegate
                                {
                                    AlertNotification.ShowAlertMessage("The stream contains mostly black, gray, light gray, or dark gray. Objects may not be visible.", AlertNotification.AlertType.ERROR);
                                });
                            }
                        }
                    }

                    // Wait for 6 second before checking again
                    await Task.Delay(6000);
                }
            });
        }

        private async Task<bool> ISRTSPCameraAvailable(ConnectionParameters cparam)
        {
            using (var client = new RtspClient(cparam))
            {
                try
                {
                    await client.ConnectAsync(_cancellationTokenSource.Token);
                    return true;
                }
                catch (RtspClientException)
                {
                    return false;
                }
            }
        }

        private async Task<bool> CameraAvailable()
        {
            try
            {
                var serverUri = new Uri(txtIPAddress.Text.Trim());//rtsp//192.168.55.240:8080/h264_ulaw.sdp
                var credentials = new NetworkCredential(txtUsername.Text.Trim(), txtPassword.Text.Trim());
                var connectionParameters = new ConnectionParameters(serverUri, credentials) // connect IP Webcam using url, username and passwrd
                {
                    RtpTransport = RtpTransportProtocol.TCP, //use tcp ransfer protocol
                    ConnectTimeout = TimeSpan.FromMilliseconds(30000) //timeout connection after 30 secs
                };
                if (_cancellationTokenSource != null)
                {
                    _cancellationTokenSource.Dispose();
                    _cancellationTokenSource = null;
                }
                _cancellationTokenSource = new CancellationTokenSource();
                TimeSpan delay = TimeSpan.FromSeconds(1);

                using (var client = new RtspClient(connectionParameters))
                {
                    try
                    {
                        await client.ConnectAsync(_cancellationTokenSource.Token);
                        return true;
                    }
                    catch (RtspClientException re)
                    {
                        AlertNotification.ShowAlertMessage($"{re.Message}", AlertNotification.AlertType.ERROR);
                        await Task.Delay(delay);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                AlertNotification.ShowAlertMessage(ex.Message, AlertNotification.AlertType.ERROR);
                return false;
            }
        }

        private void AppendOutput(string text)
        {
            if (txtOutput.InvokeRequired)
            {
                txtOutput.Invoke(new Action<string>(AppendOutput), text);
            }
            else
            {
                txtOutput.AppendText(text + Environment.NewLine);
            }
        }

        private string GetNextFileName(string directory, string baseFileName, string extension)
        {
            var files = Directory.GetFiles(directory, $"{baseFileName}*.{extension}");
            int maxNumber = 0;

            foreach (var file in files)
            {
                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file);
                var numberPart = fileNameWithoutExtension.Replace(baseFileName, "");

                if (int.TryParse(numberPart, out int number))
                {
                    if (number > maxNumber)
                    {
                        maxNumber = number;
                    }
                }
            }

            int nextNumber = maxNumber + 1;
            return $"{baseFileName}{nextNumber:D4}.{extension}";
        }

        static string EncodePasswordIfNeeded(string url)
        {
            // Split the URL to extract username and password part
            Uri uri = new Uri(url);
            string userInfo = uri.UserInfo;

            // Check if password contains '@' character
            if (userInfo.Contains("@"))
            {
                // Split the userInfo to separate username and password
                string[] userInfoParts = userInfo.Split(':');
                if (userInfoParts.Length == 2)
                {
                    // URL-encode the password
                    string encodedPassword = HttpUtility.UrlEncode(userInfoParts[1]);

                    // Construct the new userInfo with encoded password
                    userInfo = userInfoParts[0] + ":" + encodedPassword;

                    // Construct the new URL with encoded password
                    url = url.Replace(uri.UserInfo, userInfo);
                }
            }

            return url;
        }

        private void InitializeScreenshotCounter()
        {
            string[] existingFiles = Directory.GetFiles(screenshotPath, $"Screenshot_{DateTime.Now.ToString("yyyy-MM-dd")}*.jpg");
            foreach (string file in existingFiles)
            {
                string fileName = Path.GetFileNameWithoutExtension(file);
                string numberPart = fileName.Substring(fileName.Length - 6);
                if (int.TryParse(numberPart, out int currentNumber))
                {
                    if (currentNumber > screenshotCounter)
                    {
                        screenshotCounter = currentNumber;
                    }
                }
            }
        }

        private async void btnTest_Click(object sender, EventArgs e)
        {
            if (txtIPAddress.Text != string.Empty && txtUsername.Text != string.Empty && txtPassword.Text != string.Empty)
            {
                if (await CameraAvailable())
                {
                    AlertNotification.ShowAlertMessage("Camera is Available.", AlertNotification.AlertType.SUCCESS);
                }
                else
                {
                    AlertNotification.ShowAlertMessage("Camera NOT Available.", AlertNotification.AlertType.ERROR);
                }
            }
            else
            {
                AlertNotification.ShowAlertMessage("Please enter url, username and pasword for stream.", AlertNotification.AlertType.ERROR);
                return;
            }
        }

        private async void btnStartStream_Click(object sender, EventArgs e)
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                if (filePath != string.Empty)
                {
                    if (txtIPAddress.Text != string.Empty && txtUsername.Text != string.Empty && txtPassword.Text != string.Empty && txtOverlay.Text != string.Empty && txtX.Text != string.Empty && txtY.Text != string.Empty)
                    {
                        int xLoc = Convert.ToInt32(txtX.Text.ToString());
                        int yLoc = Convert.ToInt32(txtY.Text.ToString());

                        // IP webcam stream URL (replace with your actual URL)
                        string webcamUrl = txtIPAddress.Text.Trim();
                        string userName = txtUsername.Text.Trim();
                        string password = txtPassword.Text.Trim();

                        try
                        {
                            var serverUri = new Uri(webcamUrl);
                            var credentials = new NetworkCredential(userName, password);
                            var connectionParameters = new ConnectionParameters(serverUri, credentials) // connect IP Webcam using url, username and passwrd
                            {
                                RtpTransport = RtpTransportProtocol.UDP, //use tcp ransfer protocol
                                ConnectTimeout = TimeSpan.FromMilliseconds(30000) //timeout connection after 30 secs
                            };
                            if (_cancellationTokenSource != null)
                            {
                                _cancellationTokenSource.Dispose();
                                _cancellationTokenSource = null;
                            }
                            _cancellationTokenSource = new CancellationTokenSource();
                            TimeSpan delay = TimeSpan.FromSeconds(1);

                            if (await ISRTSPCameraAvailable(connectionParameters))
                            {
                                this.videoPlayer1.StartPlay(webcamUrl, userName, password, txtOverlay.Text, fontName, fontSize, textColor, xLoc, yLoc);
                                btnStartStream.Enabled = false;
                                btnTest.Enabled = false;
                                btnStopStream.Enabled = true;
                                btnStartRec.Enabled = true;
                                await StartColorPixelMonitoringTask();
                            }
                            else
                            {
                                AlertNotification.ShowAlertMessage("Could not connect to the stream.", AlertNotification.AlertType.ERROR);
                                return;
                            }
                        }
                        catch (RtspClientException ex)
                        {
                            MessageBox.Show("Error: Camera is not available. Exception" + ex.Message, Application.ProductName);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An unexpected error occurred: {ex.Message}", Application.ProductName);
                        }
                    }
                    else AlertNotification.ShowAlertMessage("Please fill all fields.", AlertNotification.AlertType.ERROR);
                }
                else
                {
                    AlertNotification.ShowAlertMessage("Please set file storage path.", AlertNotification.AlertType.ERROR);
                }
            }
            else { AlertNotification.ShowAlertMessage("PC not Conneted to Nework.", AlertNotification.AlertType.ERROR); }
        }

        private void btnStopStream_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnStopRec.Enabled == true)
                {
                    btnStopRec.PerformClick();
                }
                this.videoPlayer1.Stop();
                btnTest.Enabled = true;
                btnStopStream.Enabled = false;
                btnStartStream.Enabled = true;
                btnStartRec.Enabled = false;
                tPixels.Enabled = false;
            }
            catch (Exception ex)
            {
                AlertNotification.ShowAlertMessage(ex.Message, AlertNotification.AlertType.ERROR);
            }
        }

        private async void btnStartRec_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(Properties.Settings.Default.streamPath))
                {
                    if (Properties.Settings.Default.picInterval > 0)
                    {
                        string fileName = GetNextFileName(filePath, "Recording", "mp4");
                        string fullPath = Path.Combine(filePath, fileName);

                        // Change backslashes to forward slashes and remove the 'C:' prefix
                        string fullPathWithForwardSlashes = "\"" + fullPath.Replace(@"C:\", @"/").Replace(@"\", @"/") + "\"";
                        string fontFilePathWithForwardSlashes = @"/Windows/Fonts/arial.ttf";

                        int xLoc = Convert.ToInt32(txtX.Text);
                        int yLoc = Convert.ToInt32(txtY.Text);

                        string urlocator = txtIPAddress.Text.Trim();
                        string webcamUrl = urlocator.Replace("rtsp://", "").Trim();
                        string userName = txtUsername.Text.Trim();
                        string password = txtPassword.Text.Trim();
                        string oText = txtOverlay.Text.Trim();

                        // Enclose oText in double quotes and update the drawtext filter
                        string drawtextFilter = $"drawtext=text='{oText}':fontfile='{fontFilePathWithForwardSlashes}':fontcolor=white:fontsize={fontSize}:x={xLoc}:y={yLoc}";
                        string ffmpegCommand = $"-i rtsp://{userName}:{password}@{webcamUrl} -vf {drawtextFilter} -c:v libx264 -c:a aac {fullPathWithForwardSlashes}";

                        elapsedTime = TimeSpan.Zero;
                        lblRecording.Text = FormatElapsedTime(elapsedTime);
                        tRec.Start();
                        btnStartRec.Enabled = false;
                        btnStopRec.Enabled = true;
                        tPicInterval.Enabled = true;

                        ProcessStartInfo processStartInfo = new ProcessStartInfo
                        {
                            FileName = @"C:\RTSP\FFMPEG\bin\ffmpeg.exe",
                            Arguments = ffmpegCommand,
                            RedirectStandardOutput = true,
                            RedirectStandardError = true,
                            RedirectStandardInput = true,
                            UseShellExecute = false,
                            CreateNoWindow = true
                        };

                        await Task.Run(() =>
                        {
                            ffmpegProcess = new Process();
                            ffmpegProcess.StartInfo = processStartInfo;
                            ffmpegProcess.OutputDataReceived += (s, ev) => { if (ev.Data != null) AppendOutput(ev.Data); };
                            ffmpegProcess.ErrorDataReceived += (s, ev) => { if (ev.Data != null) AppendOutput(ev.Data); };

                            ffmpegProcess.Start();
                            ffmpegProcess.BeginOutputReadLine();
                            ffmpegProcess.BeginErrorReadLine();

                            ffmpegProcess.WaitForExit();
                        });
                    }
                    else
                    {
                        AlertNotification.ShowAlertMessage("Please set screenshot interval first.", AlertNotification.AlertType.ERROR);
                    }
                }
                else
                {
                    AlertNotification.ShowAlertMessage("Please set both screenshots & recordings storage location first.", AlertNotification.AlertType.ERROR);
                }
            }
            catch (Exception ex)
            {
                AlertNotification.ShowAlertMessage(ex.Message, AlertNotification.AlertType.ERROR);
            }
        }

        private async void btnStopRec_Click(object sender, EventArgs e)
        {
            tRec.Stop();
            btnStartRec.Enabled = true;
            btnStopRec.Enabled = false;
            tPicInterval.Enabled = false;

            if (ffmpegProcess != null && !ffmpegProcess.HasExited)
            {
                try
                {
                    await Task.Run(() =>
                    {
                        // Send 'q' command to gracefully stop FFmpeg
                        ffmpegProcess.StandardInput.Write('q');
                        ffmpegProcess.StandardInput.Close();

                        ffmpegProcess.WaitForExit();
                        ffmpegProcess.CancelOutputRead();
                        ffmpegProcess.CancelErrorRead();

                        AppendOutput("Recording Stopped.");
                    });
                }
                catch (ObjectDisposedException ex)
                {
                    AppendOutput($"Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    AppendOutput($"Unexpected error: {ex.Message}");
                }
                finally
                {
                    ffmpegProcess?.Dispose();
                }
            }
        }

        private void btnRecordings_Click(object sender, EventArgs e)
        {
            using (VistaFolderBrowserDialog fold = new VistaFolderBrowserDialog())
            {
                if (fold.ShowDialog() == DialogResult.OK)
                {
                    filePath = fold.SelectedPath;
                    Properties.Settings.Default.streamPath = filePath;
                    Properties.Settings.Default.rememberPath = true;
                    Properties.Settings.Default.Save();
                    AlertNotification.ShowAlertMessage("Recordings storage folder set successfully.", AlertNotification.AlertType.SUCCESS);
                }
            }
        }

        private void btnScreenshots_Click(object sender, EventArgs e)
        {
            using (VistaFolderBrowserDialog fold = new VistaFolderBrowserDialog())
            {
                if (fold.ShowDialog() == DialogResult.OK)
                {
                    screenshotPath = fold.SelectedPath;
                    Properties.Settings.Default.picLocation = screenshotPath;
                    Properties.Settings.Default.rememberPath = true;
                    Properties.Settings.Default.Save();
                    AlertNotification.ShowAlertMessage("Screenshots storage folder set successfully.", AlertNotification.AlertType.SUCCESS);
                }
            }
        }

        private void btnInterval_Click(object sender, EventArgs e)
        {
            frmDuration frm = new frmDuration();
            frm.ShowDialog();
        }

        private void tnFont_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                fontName = fd.Font.Name;
                fontSize = fd.Font.Size;
            }
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                textColor = cd.Color;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (btnStartRec.Enabled == false && btnStopRec.Enabled == true)
            {
                if (MessageBox.Show("Stream recording on progress. Stop recording and close application?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    btnStartRec.PerformClick();
                    Application.Exit();
                }
                else return;
            }
            else
            {
                Application.Exit();
            }
        }

        private async void tPicInterval_Tick(object sender, EventArgs e)
        {
            tPicInterval.Stop(); // Stop the timer to prevent reentrancy
            try
            {
                await Task.Run(() =>
                {
                    screenshotCounter++;
                    string picName = $"Screenshot_{DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")}.jpg";
                    Bitmap screenshot = CaptureControlScreenshot(videoPlayer1);
                    string screenshotStorage = Path.Combine(screenshotPath, picName);
                    // Save the screenshot as an image
                    screenshot.Save(screenshotStorage, ImageFormat.Jpeg);
                });
            }
            catch (Exception ex)
            {
                AppendOutput($"Screenshot error: {ex.Message}");
            }
            finally
            {
                tPicInterval.Start(); // Restart the timer
            }

            //tPicInterval.Stop(); // Stop the timer to prevent reentrancy
            //await Task.Run(() =>
            //{
            //    screenshotCounter++;
            //    string picName = $"Screenshot_{DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")}.jpg";
            //    Bitmap screenshot = CaptureControlScreenshot(videoPlayer1);
            //    string screenshotStorage = Path.Combine(screenshotPath, picName);
            //    // Save the screenshot as an image
            //    screenshot.Save(screenshotStorage, ImageFormat.Jpeg);
            //});
            //tPicInterval.Start(); // Restart the timer
        }

        private async void tPixels_Tick(object sender, EventArgs e)
        {
            if (videoPlayer1 != null)
            {
                await Task.Run(() =>
                {
                    // Capture the screenshot from the control
                    Bitmap screenshot = CaptureControlScreenshot(videoPlayer1);

                    // Check if the stream contains significant percentages of black, gray, light gray, and dark gray pixels
                    double blackPercentage = CalculateBlackPercentage(screenshot);
                    double grayPercentage = CalculateGrayPercentage(screenshot);
                    double lightGrayPercentage = CalculateLightGrayPercentage(screenshot);
                    double darkGrayPercentage = CalculateDarkGrayPercentage(screenshot);

                    // Set the thresholds to 98% for each color
                    double threshold = 98.0;

                    if (blackPercentage >= threshold || grayPercentage >= threshold || lightGrayPercentage >= threshold || darkGrayPercentage >= threshold)
                    {
                        AlertNotification.ShowAlertMessage("The stream contains mostly black, gray, light gray, or dark gray. Objects may not be visible.", AlertNotification.AlertType.ERROR);
                    }
                });
            }
        }

        private void txtX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {

            }
            else if ((e.KeyChar < 48) || (e.KeyChar > 57))
            {
                e.Handled = true;
            }
        }

        private async void tRec_Tick(object sender, EventArgs e)
        {
            try
            {
                await Task.Run(() =>
                {
                    elapsedTime = elapsedTime.Add(TimeSpan.FromSeconds(1));
                    string formattedTime = FormatElapsedTime(elapsedTime);

                    // Marshal the update back to the UI thread
                    lblRecording.Invoke(new Action(() =>
                    {
                        lblRecording.Text = formattedTime;
                    }));
                });
            }
            catch (Exception ex)
            {
                AppendOutput($"Error updating recording time: {ex.Message}");
            }

            //await Task.Run(() =>
            //{
            //    elapsedTime = elapsedTime.Add(TimeSpan.FromSeconds(1));
            //    string formattedTime = FormatElapsedTime(elapsedTime);

            //    // Marshal the update back to the UI thread
            //    lblRecording.Invoke(new Action(() =>
            //    {
            //        lblRecording.Text = formattedTime;
            //    }));
            //});
        }
    }
}
