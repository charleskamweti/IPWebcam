using IPWebcam.RawFramesDecoding.FFmpeg;
using IPWebcam.RawFramesDecoding;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using RtspClientSharp.RawFrames.Video;
using RtspClientSharp.RawFrames;
using RtspClientSharp.Rtsp;
using RtspClientSharp;
using System.Drawing.Imaging;
using System.Net;

namespace IPWebcam
{
    public partial class VideoPlayer : UserControl
    {
        private readonly Dictionary<FFmpegVideoCodecId, FFmpegVideoDecoder> _videoDecodersMap = new Dictionary<FFmpegVideoCodecId, FFmpegVideoDecoder>();
        private Bitmap bmp;
        private CancellationTokenSource _cancellationTokenSource;
        private static string overlayText;
        private static string fontName;
        private static float fontSize;
        private static Color textColor;
        private static int xPos;
        private static int yPos;
        private DateTime lastFrameReceivedTime = DateTime.MinValue;
        public bool videoRecording = false;
        public List<Bitmap> recordedFrames = new List<Bitmap>();
        private int frameCount = 0;
        private DateTime lastFpsCalculationTime = DateTime.Now;
        public DateTime recordingStartTime;
        public double currentFps = 0;
        public bool isRecording = false;
        public List<Bitmap> frameBuffer = new List<Bitmap>();
        private Bitmap displayBitmap;

        public VideoPlayer()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.Paint += VideoControl_Paint;
        }

        private void AddTextOverlay(Bitmap bitmap, string text, string fName, float fSize, Color fColor, int X, int Y)
        {
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                // Specify font and brush for the text
                using (Font font = new Font(fName, fSize))
                using (SolidBrush brush = new SolidBrush(fColor)) // Adjust color as needed
                {
                    // Specify the position to place the text
                    Point position = new Point(X, Y); // Adjust coordinates as needed

                    // Draw the text onto the bitmap
                    graphics.DrawString(text, font, brush, position);
                }
            }
        }

        public void Stop()
        {
            _cancellationTokenSource?.Cancel();
            bmp?.Dispose();
            bmp = null;
            this.Invalidate();
            lblFPS.Text = $"FPS: {0.00:F2}";
        }

        private void VideoControl_Paint(object sender, PaintEventArgs e)
        {
            if (displayBitmap != null)
            {
                e.Graphics.DrawImageUnscaled(displayBitmap, Point.Empty);
            }
        }

        private void VideoPlayer_SizeChanged(object sender, EventArgs e)
        {
            Width = 1280;
            Height = 720;
        }

        public async void StartPlay(string url, string userID, string Password, string textOverlay, string fName, float fSize, Color fColor, int X, int Y)
        {
            // Assign overlay values
            overlayText = textOverlay;
            fontName = fName;
            fontSize = fSize;
            textColor = fColor;
            xPos = X;
            yPos = Y;

            var serverUri = new Uri(url);
            var credentials = new NetworkCredential(userID, Password);
            var connectionParameters = new ConnectionParameters(serverUri, credentials)
            {
                RtpTransport = RtpTransportProtocol.TCP,
                ConnectTimeout = TimeSpan.FromMilliseconds(30000)
            };

            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = new CancellationTokenSource();
            TimeSpan delay = TimeSpan.FromSeconds(1);

            using (var rtspClient = new RtspClient(connectionParameters))
            {
                rtspClient.FrameReceived += RtspClient_FrameReceived;
                while (true)
                {
                    try
                    {
                        await rtspClient.ConnectAsync(_cancellationTokenSource.Token);
                        await rtspClient.ReceiveAsync(_cancellationTokenSource.Token);
                    }
                    catch (OperationCanceledException)
                    {
                        return;
                    }
                    catch (RtspClientException)
                    {
                        await Task.Delay(delay);
                    }

                    TimeSpan timeSinceLastFrame = DateTime.Now - lastFrameReceivedTime;
                    if (timeSinceLastFrame > TimeSpan.FromSeconds(5))
                    {
                        AlertNotification.ShowAlertMessage("Stream has stopped.", AlertNotification.AlertType.INFO);
                    }
                }
            }
        }

        private void RtspClient_FrameReceived(object sender, RawFrame e)
        {
            frameCount++;
            TimeSpan timeElapsed = DateTime.Now - lastFpsCalculationTime;
            if (timeElapsed.TotalSeconds >= 1)
            {
                currentFps = frameCount / timeElapsed.TotalSeconds;
                frameCount = 0;
                lastFpsCalculationTime = DateTime.Now;

                // Update the FPS label
                if (lblFPS.InvokeRequired)
                {
                    lblFPS.Invoke(new Action(() => lblFPS.Text = $"FPS: {currentFps:F2}"));
                }
                else
                {
                    lblFPS.Text = $"FPS: {currentFps:F2}";
                }
            }

            if (_cancellationTokenSource == null || _cancellationTokenSource.IsCancellationRequested)
            {
                return;
            }

            if (!(e is RawVideoFrame rawVideoFrame))
            {
                return;
            }

            var codecId = DetectCodecId(rawVideoFrame);
            if (!_videoDecodersMap.TryGetValue(codecId, out FFmpegVideoDecoder decoder))
            {
                decoder = FFmpegVideoDecoder.CreateDecoder(codecId);
                _videoDecodersMap.Add(codecId, decoder);
            }

            var decodedVideoFrame = decoder.TryDecode(rawVideoFrame);
            if (decodedVideoFrame != null)
            {
                var newBitmap = new Bitmap(1280, 720, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                var transformParameters = new TransformParameters(RectangleF.Empty, new Size(1280, 720), ScalingPolicy.Stretch, RawFramesDecoding.PixelFormat.Bgra32, ScalingQuality.FastBilinear);

                Rectangle newClientRect = new Rectangle(0, 0, 1280, 720);
                var bmpData = newBitmap.LockBits(newClientRect, ImageLockMode.ReadWrite, newBitmap.PixelFormat);

                IntPtr ptr = bmpData.Scan0;
                decodedVideoFrame.TransformTo(ptr, bmpData.Stride, transformParameters);

                newBitmap.UnlockBits(bmpData);

                AddTextOverlay(newBitmap, overlayText, fontName, fontSize, textColor, xPos, yPos);

                var oldBitmap = displayBitmap;
                displayBitmap = newBitmap;
                oldBitmap?.Dispose();

                this.Invalidate();
            }
        }   

        private FFmpegVideoCodecId DetectCodecId(RawVideoFrame videoFrame)
        {
            if (videoFrame is RawJpegFrame)
                return FFmpegVideoCodecId.MJPEG;
            if (videoFrame is RawH264Frame)
                return FFmpegVideoCodecId.H264;

            throw new ArgumentOutOfRangeException(nameof(videoFrame));
        }
    }
}
