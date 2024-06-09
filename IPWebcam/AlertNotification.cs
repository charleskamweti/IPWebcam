using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace IPWebcam
{
    public partial class AlertNotification : Form
    {
        private static List<AlertNotification> OpenForms = new List<AlertNotification>();
        Action action;
        private static Queue<(string message, AlertType type)> messageQueue = new Queue<(string, AlertType)>();
        private static bool isShowingAlert = false;

        public enum AlertType
        {
            SUCCESS,
            WARNING,
            ERROR,
            INFO
        }

        enum Action
        {
            WAIT,
            START,
            CLOSE
        }
        public event EventHandler AlertClosed;

        public AlertNotification(string message, AlertType type)
        {
            InitializeComponent();
            string fname;
            Opacity = 0;
            StartPosition = FormStartPosition.Manual;

            // Find a unique name for the alert form
            for (int i = 1; i <= 10; i++)
            {
                fname = "alert" + i;
                var alert = OpenForms.FirstOrDefault((forms) => forms.Name == fname);
                if (alert == null)
                {
                    Name = fname;
                    x = Screen.PrimaryScreen.WorkingArea.Width - Width + 15;
                    y = Screen.PrimaryScreen.WorkingArea.Height - Height * i - 5 * i;
                    Location = new Point(x, y);
                    OpenForms.Add(this);
                    break;
                }
            }

            // Set position for next alert
            x = Screen.PrimaryScreen.WorkingArea.Width - Width - 5;

            // Set icon and colors based on alert type
            switch (type)
            {
                case AlertType.SUCCESS:
                    pbIcon.Image = Properties.Resources.check;
                    pnlColor.FillColor = Color.FromArgb(29, 146, 37);
                    pnlColor.FillColor2 = Color.FromArgb(54, 203, 113);
                    break;
                case AlertType.WARNING:
                    pbIcon.Image = Properties.Resources.error_white;
                    pnlColor.FillColor = Color.Orange;
                    pnlColor.FillColor2 = Color.FromArgb(217, 167, 17);
                    break;
                case AlertType.ERROR:
                    pbIcon.Image = Properties.Resources.error_white;
                    pnlColor.FillColor = Color.FromArgb(255, 70, 70);
                    pnlColor.FillColor2 = Color.FromArgb(253, 96, 66);
                    break;
                case AlertType.INFO:
                    pbIcon.Image = Properties.Resources.info;
                    pnlColor.FillColor = Color.FromArgb(71, 169, 248);
                    pnlColor.FillColor2 = Color.FromArgb(47, 112, 165);
                    break;
            }
            lblMessage.Text = message;

            // Initialize and start the timer for visibility check
            tVisibility.Start();
        }

        int x, y;

        public static void ShowAlertMessage(string message, AlertType type)
        {
            messageQueue.Enqueue((message, type));
            if (!isShowingAlert)
            {
                ShowNextAlert();
            }
        }

        private static void ShowNextAlert()
        {
            if (messageQueue.Count > 0)
            {
                var (message, type) = messageQueue.Dequeue();
                var alert = new AlertNotification(message, type);
                alert.AlertClosed += (sender, e) => ShowNextAlert();
                alert.showAlert();
                isShowingAlert = true;
            }
            else
            {
                isShowingAlert = false;
            }
        }

        public void showAlert()
        {
            action = Action.START;
            TopMost = true;
            Show();
            tDisplay.Start();
        }
        private void tDisplay_Tick(object sender, EventArgs e)
        {
            switch (action)
            {
                case Action.START:
                    tDisplay.Interval = 1;
                    Opacity += 0.1;
                    if (x < Location.X)
                    {
                        Left -= 1;
                    }
                    else
                    {
                        if (Opacity == 1)
                        {
                            action = Action.WAIT;
                        }
                    }
                    break;
                case Action.WAIT:
                    tDisplay.Interval = 3000;
                    action = Action.CLOSE;
                    break;
                case Action.CLOSE:
                    tDisplay.Interval = 1;
                    Opacity -= 0.1;
                    Left += 1;
                    if (Opacity == 0)
                    {
                        OpenForms.Remove(this);
                        Dispose();
                        AlertClosed?.Invoke(this, EventArgs.Empty);
                    }
                    break;

            }
        }

        private void tVisibility_Tick(object sender, EventArgs e)
        {
            // Check if the form is visible and adjust opacity accordingly
            if (Visible)
            {
                if (Opacity < 1)
                {
                    Opacity += 0.1;
                }
            }
            else
            {
                if (Opacity > 0)
                {
                    Opacity -= 0.1;
                }
            }
        }
    }
}
