namespace IPWebcam
{
    partial class frmWeb
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                tRec.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWeb));
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.txtOutput = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtUsername = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtIPAddress = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnInterval = new Guna.UI2.WinForms.Guna2Button();
            this.btnScreenshots = new Guna.UI2.WinForms.Guna2Button();
            this.btnRecordings = new Guna.UI2.WinForms.Guna2Button();
            this.btnStopRec = new Guna.UI2.WinForms.Guna2Button();
            this.btnStopStream = new Guna.UI2.WinForms.Guna2Button();
            this.btnStartRec = new Guna.UI2.WinForms.Guna2Button();
            this.btnStartStream = new Guna.UI2.WinForms.Guna2Button();
            this.btnTest = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblRecording = new System.Windows.Forms.Label();
            this.btnColor = new Guna.UI2.WinForms.Guna2Button();
            this.tnFont = new Guna.UI2.WinForms.Guna2Button();
            this.txtY = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnClose = new Guna.UI2.WinForms.Guna2PictureBox();
            this.txtX = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.txtOverlay = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.videoPlayer1 = new IPWebcam.VideoPlayer();
            this.guna2ResizeBox1 = new Guna.UI2.WinForms.Guna2ResizeBox();
            this.tFrameRate = new System.Windows.Forms.Timer(this.components);
            this.tPicInterval = new System.Windows.Forms.Timer(this.components);
            this.tPixels = new System.Windows.Forms.Timer(this.components);
            this.tRec = new System.Windows.Forms.Timer(this.components);
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2ResizeForm1 = new Guna.UI2.WinForms.Guna2ResizeForm(this.components);
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.panel1.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(18)))), ((int)(((byte)(36)))));
            this.guna2Panel1.Controls.Add(this.txtOutput);
            this.guna2Panel1.Controls.Add(this.txtPassword);
            this.guna2Panel1.Controls.Add(this.txtUsername);
            this.guna2Panel1.Controls.Add(this.txtIPAddress);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Controls.Add(this.btnInterval);
            this.guna2Panel1.Controls.Add(this.btnScreenshots);
            this.guna2Panel1.Controls.Add(this.btnRecordings);
            this.guna2Panel1.Controls.Add(this.btnStopRec);
            this.guna2Panel1.Controls.Add(this.btnStopStream);
            this.guna2Panel1.Controls.Add(this.btnStartRec);
            this.guna2Panel1.Controls.Add(this.btnStartStream);
            this.guna2Panel1.Controls.Add(this.btnTest);
            resources.ApplyResources(this.guna2Panel1, "guna2Panel1");
            this.guna2Panel1.Name = "guna2Panel1";
            // 
            // txtOutput
            // 
            resources.ApplyResources(this.txtOutput, "txtOutput");
            this.txtOutput.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOutput.DefaultText = "";
            this.txtOutput.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtOutput.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtOutput.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtOutput.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtOutput.FillColor = System.Drawing.Color.Transparent;
            this.txtOutput.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtOutput.ForeColor = System.Drawing.Color.White;
            this.txtOutput.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.PasswordChar = '\0';
            this.txtOutput.PlaceholderText = "";
            this.txtOutput.SelectedText = "";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(88)))), ((int)(((byte)(152)))));
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.DefaultText = "";
            this.txtPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(14)))), ((int)(((byte)(31)))));
            this.txtPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this.txtPassword, "txtPassword");
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(246)))), ((int)(((byte)(195)))));
            this.txtPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '\0';
            this.txtPassword.PlaceholderText = "Password";
            this.txtPassword.SelectedText = "";
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.Transparent;
            this.txtUsername.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(88)))), ((int)(((byte)(152)))));
            this.txtUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUsername.DefaultText = "";
            this.txtUsername.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUsername.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtUsername.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUsername.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUsername.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(14)))), ((int)(((byte)(31)))));
            this.txtUsername.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this.txtUsername, "txtUsername");
            this.txtUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(246)))), ((int)(((byte)(195)))));
            this.txtUsername.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PasswordChar = '\0';
            this.txtUsername.PlaceholderText = "Username";
            this.txtUsername.SelectedText = "";
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.BackColor = System.Drawing.Color.Transparent;
            this.txtIPAddress.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(88)))), ((int)(((byte)(152)))));
            this.txtIPAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtIPAddress.DefaultText = "";
            this.txtIPAddress.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtIPAddress.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtIPAddress.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtIPAddress.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtIPAddress.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(14)))), ((int)(((byte)(31)))));
            this.txtIPAddress.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this.txtIPAddress, "txtIPAddress");
            this.txtIPAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(246)))), ((int)(((byte)(195)))));
            this.txtIPAddress.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.PasswordChar = '\0';
            this.txtIPAddress.PlaceholderText = "IP Address";
            this.txtIPAddress.SelectedText = "";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(246)))), ((int)(((byte)(195)))));
            this.label1.Name = "label1";
            // 
            // btnInterval
            // 
            this.btnInterval.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(180)))), ((int)(((byte)(251)))));
            this.btnInterval.CheckedState.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInterval.CheckedState.ForeColor = System.Drawing.Color.Black;
            this.btnInterval.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInterval.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnInterval.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnInterval.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnInterval.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnInterval.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(34)))), ((int)(((byte)(51)))));
            resources.ApplyResources(this.btnInterval, "btnInterval");
            this.btnInterval.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(246)))), ((int)(((byte)(195)))));
            this.btnInterval.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(43)))), ((int)(((byte)(104)))));
            this.btnInterval.HoverState.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInterval.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnInterval.Image = global::IPWebcam.Properties.Resources.Timer;
            this.btnInterval.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnInterval.IndicateFocus = true;
            this.btnInterval.Name = "btnInterval";
            this.btnInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnInterval.Click += new System.EventHandler(this.btnInterval_Click);
            // 
            // btnScreenshots
            // 
            this.btnScreenshots.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(180)))), ((int)(((byte)(251)))));
            this.btnScreenshots.CheckedState.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScreenshots.CheckedState.ForeColor = System.Drawing.Color.Black;
            this.btnScreenshots.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnScreenshots.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnScreenshots.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnScreenshots.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnScreenshots.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnScreenshots.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(34)))), ((int)(((byte)(51)))));
            resources.ApplyResources(this.btnScreenshots, "btnScreenshots");
            this.btnScreenshots.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(246)))), ((int)(((byte)(195)))));
            this.btnScreenshots.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(43)))), ((int)(((byte)(104)))));
            this.btnScreenshots.HoverState.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScreenshots.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnScreenshots.Image = global::IPWebcam.Properties.Resources.ScreenshotPaths;
            this.btnScreenshots.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnScreenshots.IndicateFocus = true;
            this.btnScreenshots.Name = "btnScreenshots";
            this.btnScreenshots.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnScreenshots.Click += new System.EventHandler(this.btnScreenshots_Click);
            // 
            // btnRecordings
            // 
            this.btnRecordings.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(180)))), ((int)(((byte)(251)))));
            this.btnRecordings.CheckedState.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecordings.CheckedState.ForeColor = System.Drawing.Color.Black;
            this.btnRecordings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRecordings.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRecordings.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRecordings.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRecordings.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRecordings.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(34)))), ((int)(((byte)(51)))));
            resources.ApplyResources(this.btnRecordings, "btnRecordings");
            this.btnRecordings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(246)))), ((int)(((byte)(195)))));
            this.btnRecordings.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(43)))), ((int)(((byte)(104)))));
            this.btnRecordings.HoverState.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecordings.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnRecordings.Image = global::IPWebcam.Properties.Resources.Videopaths;
            this.btnRecordings.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnRecordings.IndicateFocus = true;
            this.btnRecordings.Name = "btnRecordings";
            this.btnRecordings.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnRecordings.Click += new System.EventHandler(this.btnRecordings_Click);
            // 
            // btnStopRec
            // 
            this.btnStopRec.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(180)))), ((int)(((byte)(251)))));
            this.btnStopRec.CheckedState.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStopRec.CheckedState.ForeColor = System.Drawing.Color.Black;
            this.btnStopRec.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStopRec.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnStopRec.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnStopRec.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnStopRec.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            resources.ApplyResources(this.btnStopRec, "btnStopRec");
            this.btnStopRec.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(34)))), ((int)(((byte)(51)))));
            this.btnStopRec.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(246)))), ((int)(((byte)(195)))));
            this.btnStopRec.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(43)))), ((int)(((byte)(104)))));
            this.btnStopRec.HoverState.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStopRec.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnStopRec.Image = global::IPWebcam.Properties.Resources.StopRecoring;
            this.btnStopRec.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnStopRec.IndicateFocus = true;
            this.btnStopRec.Name = "btnStopRec";
            this.btnStopRec.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnStopRec.Click += new System.EventHandler(this.btnStopRec_Click);
            // 
            // btnStopStream
            // 
            this.btnStopStream.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(180)))), ((int)(((byte)(251)))));
            this.btnStopStream.CheckedState.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStopStream.CheckedState.ForeColor = System.Drawing.Color.Black;
            this.btnStopStream.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStopStream.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnStopStream.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnStopStream.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnStopStream.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            resources.ApplyResources(this.btnStopStream, "btnStopStream");
            this.btnStopStream.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(34)))), ((int)(((byte)(51)))));
            this.btnStopStream.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(246)))), ((int)(((byte)(195)))));
            this.btnStopStream.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(43)))), ((int)(((byte)(104)))));
            this.btnStopStream.HoverState.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStopStream.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnStopStream.Image = global::IPWebcam.Properties.Resources.StopStream;
            this.btnStopStream.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnStopStream.IndicateFocus = true;
            this.btnStopStream.Name = "btnStopStream";
            this.btnStopStream.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnStopStream.Click += new System.EventHandler(this.btnStopStream_Click);
            // 
            // btnStartRec
            // 
            this.btnStartRec.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(180)))), ((int)(((byte)(251)))));
            this.btnStartRec.CheckedState.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartRec.CheckedState.ForeColor = System.Drawing.Color.Black;
            this.btnStartRec.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStartRec.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnStartRec.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnStartRec.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnStartRec.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            resources.ApplyResources(this.btnStartRec, "btnStartRec");
            this.btnStartRec.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(34)))), ((int)(((byte)(51)))));
            this.btnStartRec.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(246)))), ((int)(((byte)(195)))));
            this.btnStartRec.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(43)))), ((int)(((byte)(104)))));
            this.btnStartRec.HoverState.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartRec.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnStartRec.Image = global::IPWebcam.Properties.Resources.StartRecording;
            this.btnStartRec.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnStartRec.IndicateFocus = true;
            this.btnStartRec.Name = "btnStartRec";
            this.btnStartRec.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnStartRec.Click += new System.EventHandler(this.btnStartRec_Click);
            // 
            // btnStartStream
            // 
            this.btnStartStream.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(180)))), ((int)(((byte)(251)))));
            this.btnStartStream.CheckedState.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartStream.CheckedState.ForeColor = System.Drawing.Color.Black;
            this.btnStartStream.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStartStream.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnStartStream.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnStartStream.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnStartStream.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnStartStream.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(34)))), ((int)(((byte)(51)))));
            resources.ApplyResources(this.btnStartStream, "btnStartStream");
            this.btnStartStream.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(246)))), ((int)(((byte)(195)))));
            this.btnStartStream.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(43)))), ((int)(((byte)(104)))));
            this.btnStartStream.HoverState.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartStream.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnStartStream.Image = global::IPWebcam.Properties.Resources.StartStream;
            this.btnStartStream.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnStartStream.IndicateFocus = true;
            this.btnStartStream.Name = "btnStartStream";
            this.btnStartStream.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnStartStream.Click += new System.EventHandler(this.btnStartStream_Click);
            // 
            // btnTest
            // 
            this.btnTest.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(180)))), ((int)(((byte)(251)))));
            this.btnTest.CheckedState.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTest.CheckedState.ForeColor = System.Drawing.Color.Black;
            this.btnTest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTest.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTest.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTest.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTest.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTest.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(34)))), ((int)(((byte)(51)))));
            resources.ApplyResources(this.btnTest, "btnTest");
            this.btnTest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(246)))), ((int)(((byte)(195)))));
            this.btnTest.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(43)))), ((int)(((byte)(104)))));
            this.btnTest.HoverState.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTest.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnTest.Image = global::IPWebcam.Properties.Resources.TestConnection;
            this.btnTest.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTest.IndicateFocus = true;
            this.btnTest.Name = "btnTest";
            this.btnTest.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(18)))), ((int)(((byte)(36)))));
            this.guna2Panel2.Controls.Add(this.lblRecording);
            this.guna2Panel2.Controls.Add(this.btnColor);
            this.guna2Panel2.Controls.Add(this.tnFont);
            this.guna2Panel2.Controls.Add(this.txtY);
            this.guna2Panel2.Controls.Add(this.btnClose);
            this.guna2Panel2.Controls.Add(this.txtX);
            this.guna2Panel2.Controls.Add(this.guna2ControlBox2);
            this.guna2Panel2.Controls.Add(this.txtOverlay);
            this.guna2Panel2.Controls.Add(this.guna2ControlBox1);
            resources.ApplyResources(this.guna2Panel2, "guna2Panel2");
            this.guna2Panel2.ForeColor = System.Drawing.Color.White;
            this.guna2Panel2.Name = "guna2Panel2";
            // 
            // lblRecording
            // 
            resources.ApplyResources(this.lblRecording, "lblRecording");
            this.lblRecording.BackColor = System.Drawing.Color.Transparent;
            this.lblRecording.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(246)))), ((int)(((byte)(195)))));
            this.lblRecording.Name = "lblRecording";
            // 
            // btnColor
            // 
            this.btnColor.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(180)))), ((int)(((byte)(251)))));
            this.btnColor.CheckedState.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColor.CheckedState.ForeColor = System.Drawing.Color.Black;
            this.btnColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnColor.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnColor.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnColor.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnColor.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnColor.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(34)))), ((int)(((byte)(51)))));
            resources.ApplyResources(this.btnColor, "btnColor");
            this.btnColor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(246)))), ((int)(((byte)(195)))));
            this.btnColor.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(43)))), ((int)(((byte)(104)))));
            this.btnColor.HoverState.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColor.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnColor.Image = global::IPWebcam.Properties.Resources.ColorPicker;
            this.btnColor.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnColor.IndicateFocus = true;
            this.btnColor.Name = "btnColor";
            this.btnColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // tnFont
            // 
            this.tnFont.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(180)))), ((int)(((byte)(251)))));
            this.tnFont.CheckedState.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tnFont.CheckedState.ForeColor = System.Drawing.Color.Black;
            this.tnFont.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tnFont.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.tnFont.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.tnFont.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.tnFont.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.tnFont.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(34)))), ((int)(((byte)(51)))));
            resources.ApplyResources(this.tnFont, "tnFont");
            this.tnFont.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(246)))), ((int)(((byte)(195)))));
            this.tnFont.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(43)))), ((int)(((byte)(104)))));
            this.tnFont.HoverState.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tnFont.HoverState.ForeColor = System.Drawing.Color.White;
            this.tnFont.Image = global::IPWebcam.Properties.Resources.Fonts;
            this.tnFont.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tnFont.IndicateFocus = true;
            this.tnFont.Name = "tnFont";
            this.tnFont.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tnFont.Click += new System.EventHandler(this.tnFont_Click);
            // 
            // txtY
            // 
            this.txtY.BackColor = System.Drawing.Color.Transparent;
            this.txtY.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(88)))), ((int)(((byte)(152)))));
            this.txtY.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtY.DefaultText = "";
            this.txtY.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtY.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtY.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtY.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtY.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(14)))), ((int)(((byte)(31)))));
            this.txtY.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this.txtY, "txtY");
            this.txtY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(246)))), ((int)(((byte)(195)))));
            this.txtY.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtY.Name = "txtY";
            this.txtY.PasswordChar = '\0';
            this.txtY.PlaceholderText = "Y";
            this.txtY.SelectedText = "";
            this.txtY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtX_KeyPress);
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ImageRotate = 0F;
            this.btnClose.Name = "btnClose";
            this.btnClose.TabStop = false;
            this.btnClose.UseTransparentBackground = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtX
            // 
            this.txtX.BackColor = System.Drawing.Color.Transparent;
            this.txtX.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(88)))), ((int)(((byte)(152)))));
            this.txtX.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtX.DefaultText = "";
            this.txtX.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtX.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtX.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtX.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtX.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(14)))), ((int)(((byte)(31)))));
            this.txtX.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this.txtX, "txtX");
            this.txtX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(246)))), ((int)(((byte)(195)))));
            this.txtX.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtX.Name = "txtX";
            this.txtX.PasswordChar = '\0';
            this.txtX.PlaceholderText = "X";
            this.txtX.SelectedText = "";
            this.txtX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtX_KeyPress);
            // 
            // guna2ControlBox2
            // 
            resources.ApplyResources(this.guna2ControlBox2, "guna2ControlBox2");
            this.guna2ControlBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
            this.guna2ControlBox2.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(246)))), ((int)(((byte)(195)))));
            this.guna2ControlBox2.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox2.Name = "guna2ControlBox2";
            // 
            // txtOverlay
            // 
            this.txtOverlay.BackColor = System.Drawing.Color.Transparent;
            this.txtOverlay.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(88)))), ((int)(((byte)(152)))));
            this.txtOverlay.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOverlay.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOverlay.DefaultText = "";
            this.txtOverlay.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtOverlay.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtOverlay.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtOverlay.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtOverlay.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(14)))), ((int)(((byte)(31)))));
            this.txtOverlay.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this.txtOverlay, "txtOverlay");
            this.txtOverlay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(246)))), ((int)(((byte)(195)))));
            this.txtOverlay.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtOverlay.Name = "txtOverlay";
            this.txtOverlay.PasswordChar = '\0';
            this.txtOverlay.PlaceholderText = "Overlay Text";
            this.txtOverlay.SelectedText = "";
            // 
            // guna2ControlBox1
            // 
            resources.ApplyResources(this.guna2ControlBox1, "guna2ControlBox1");
            this.guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(246)))), ((int)(((byte)(195)))));
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(18)))), ((int)(((byte)(36)))));
            this.panel1.Controls.Add(this.guna2Panel3);
            this.panel1.Controls.Add(this.guna2ResizeBox1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.Controls.Add(this.videoPlayer1);
            resources.ApplyResources(this.guna2Panel3, "guna2Panel3");
            this.guna2Panel3.Name = "guna2Panel3";
            // 
            // videoPlayer1
            // 
            this.videoPlayer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(197)))), ((int)(((byte)(224)))));
            resources.ApplyResources(this.videoPlayer1, "videoPlayer1");
            this.videoPlayer1.Name = "videoPlayer1";
            // 
            // guna2ResizeBox1
            // 
            resources.ApplyResources(this.guna2ResizeBox1, "guna2ResizeBox1");
            this.guna2ResizeBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ResizeBox1.ForeColor = System.Drawing.Color.Black;
            this.guna2ResizeBox1.Name = "guna2ResizeBox1";
            this.guna2ResizeBox1.TargetControl = this;
            this.guna2ResizeBox1.UseTransparentBackground = true;
            // 
            // tFrameRate
            // 
            this.tFrameRate.Interval = 8;
            // 
            // tPicInterval
            // 
            this.tPicInterval.Tick += new System.EventHandler(this.tPicInterval_Tick);
            // 
            // tPixels
            // 
            this.tPixels.Interval = 2000;
            this.tPixels.Tick += new System.EventHandler(this.tPixels_Tick);
            // 
            // tRec
            // 
            this.tRec.Interval = 1000;
            this.tRec.Tick += new System.EventHandler(this.tRec_Tick);
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.guna2Panel2;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // guna2ResizeForm1
            // 
            this.guna2ResizeForm1.TargetForm = this;
            // 
            // guna2AnimateWindow1
            // 
            this.guna2AnimateWindow1.AnimationType = Guna.UI2.WinForms.Guna2AnimateWindow.AnimateWindowType.AW_HOR_POSITIVE;
            // 
            // frmWeb
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmWeb";
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.panel1.ResumeLayout(false);
            this.guna2Panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Button btnTest;
        private Guna.UI2.WinForms.Guna2Button btnInterval;
        private Guna.UI2.WinForms.Guna2Button btnScreenshots;
        private Guna.UI2.WinForms.Guna2Button btnRecordings;
        private Guna.UI2.WinForms.Guna2Button btnStopRec;
        private Guna.UI2.WinForms.Guna2Button btnStopStream;
        private Guna.UI2.WinForms.Guna2Button btnStartRec;
        private Guna.UI2.WinForms.Guna2Button btnStartStream;
        private Guna.UI2.WinForms.Guna2PictureBox btnClose;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button tnFont;
        private Guna.UI2.WinForms.Guna2TextBox txtY;
        private Guna.UI2.WinForms.Guna2TextBox txtX;
        private Guna.UI2.WinForms.Guna2TextBox txtOverlay;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtUsername;
        private Guna.UI2.WinForms.Guna2TextBox txtIPAddress;
        private Guna.UI2.WinForms.Guna2Button btnColor;
        private System.Windows.Forms.Timer tFrameRate;
        private System.Windows.Forms.Timer tPicInterval;
        private System.Windows.Forms.Timer tPixels;
        private System.Windows.Forms.Timer tRec;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2ResizeForm guna2ResizeForm1;
        private Guna.UI2.WinForms.Guna2ResizeBox guna2ResizeBox1;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private VideoPlayer videoPlayer1;
        private System.Windows.Forms.Label lblRecording;
        private Guna.UI2.WinForms.Guna2TextBox txtOutput;
    }
}

