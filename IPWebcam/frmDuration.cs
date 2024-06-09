using System;
using System.Windows.Forms;

namespace IPWebcam
{
    public partial class frmDuration : Form
    {
        public frmDuration()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTimeSpan.Text != string.Empty)
            {
                int val = Convert.ToInt32(txtTimeSpan.Text);
                int dur = val * 1000;//convert interval to seconds
                Properties.Settings.Default.picInterval = dur;
                Properties.Settings.Default.Save();
                AlertNotification.ShowAlertMessage("Screenshots interval saved successfully.", AlertNotification.AlertType.SUCCESS);
                Close();
            }
            else
            {
                AlertNotification.ShowAlertMessage("Please enter screenshots interval.", AlertNotification.AlertType.WARNING);
                txtTimeSpan.Focus();
                return;
            }

        }

        private void txtTimeSpan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                //AcceptButton backspace
            }
            else if ((e.KeyChar < 48) || (e.KeyChar > 57)) //Accept 0-9
            {
                e.Handled = true;
            }
        }
    }
}
