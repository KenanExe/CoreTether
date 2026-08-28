namespace CoreTether
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            sysTrayIcon = new NotifyIcon(components);
            trayContextMenuStrip = new ContextMenuStrip(components);
            exitToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            grpServerProfiles = new GroupBox();
            chkDemo = new CheckBox();
            btnStart = new Button();
            btnConnect = new Button();
            btnClear = new Button();
            txtPassword = new TextBox();
            lblPassword = new Label();
            txtUserName = new TextBox();
            lblUserName = new Label();
            lblIPAdress = new Label();
            txtIPAddress = new TextBox();
            grpWatchingSettings = new GroupBox();
            chkWifiUsage = new CheckBox();
            chkCpuLoad = new CheckBox();
            chkRamUsage = new CheckBox();
            lblCalues = new Label();
            chkDiskUsage = new CheckBox();
            lblCheckFrequency = new Label();
            tbWatchInterval = new TrackBar();
            chkCpuTemperature = new CheckBox();
            grpCriticalAlert = new GroupBox();
            tbAlertRamUsage = new TrackBar();
            tbAlertCpuUsage = new TrackBar();
            chkAlertRamUsage = new CheckBox();
            chkAlertTemperature = new CheckBox();
            tbAlertTemperature = new TrackBar();
            chkAlertCpuUsage = new CheckBox();
            statusStrip = new StatusStrip();
            trayContextMenuStrip.SuspendLayout();
            grpServerProfiles.SuspendLayout();
            grpWatchingSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbWatchInterval).BeginInit();
            grpCriticalAlert.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbAlertRamUsage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAlertCpuUsage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAlertTemperature).BeginInit();
            SuspendLayout();
            // 
            // sysTrayIcon
            // 
            sysTrayIcon.ContextMenuStrip = trayContextMenuStrip;
            sysTrayIcon.Icon = (Icon)resources.GetObject("sysTrayIcon.Icon");
            sysTrayIcon.Text = "CoreTether";
            sysTrayIcon.Visible = true;
            sysTrayIcon.Click += settingsToolStripMenuItem_Click;
            // 
            // trayContextMenuStrip
            // 
            trayContextMenuStrip.ImageScalingSize = new Size(20, 20);
            trayContextMenuStrip.Items.AddRange(new ToolStripItem[] { exitToolStripMenuItem, settingsToolStripMenuItem });
            trayContextMenuStrip.Name = "trayContextMenuStrip";
            trayContextMenuStrip.Size = new Size(132, 52);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(131, 24);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(131, 24);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // grpServerProfiles
            // 
            grpServerProfiles.Controls.Add(chkDemo);
            grpServerProfiles.Controls.Add(btnStart);
            grpServerProfiles.Controls.Add(btnConnect);
            grpServerProfiles.Controls.Add(btnClear);
            grpServerProfiles.Controls.Add(txtPassword);
            grpServerProfiles.Controls.Add(lblPassword);
            grpServerProfiles.Controls.Add(txtUserName);
            grpServerProfiles.Controls.Add(lblUserName);
            grpServerProfiles.Controls.Add(lblIPAdress);
            grpServerProfiles.Controls.Add(txtIPAddress);
            grpServerProfiles.Location = new Point(12, 12);
            grpServerProfiles.Name = "grpServerProfiles";
            grpServerProfiles.Size = new Size(250, 299);
            grpServerProfiles.TabIndex = 1;
            grpServerProfiles.TabStop = false;
            grpServerProfiles.Text = "Server Profiles";
            // 
            // chkDemo
            // 
            chkDemo.AutoSize = true;
            chkDemo.Location = new Point(6, 225);
            chkDemo.Name = "chkDemo";
            chkDemo.Size = new Size(115, 24);
            chkDemo.TabIndex = 8;
            chkDemo.Text = "Demo Mode";
            chkDemo.UseVisualStyleBackColor = true;
            chkDemo.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // btnStart
            // 
            btnStart.Enabled = false;
            btnStart.Location = new Point(6, 190);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(238, 29);
            btnStart.TabIndex = 11;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnConnect
            // 
            btnConnect.Enabled = false;
            btnConnect.Location = new Point(134, 155);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(110, 29);
            btnConnect.TabIndex = 10;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(6, 155);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(110, 29);
            btnClear.TabIndex = 9;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(97, 115);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(147, 27);
            txtPassword.TabIndex = 8;
            txtPassword.TextChanged += textchange;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(6, 118);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(73, 20);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Password:";
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(97, 77);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(147, 27);
            txtUserName.TabIndex = 7;
            txtUserName.TextChanged += textchange;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Location = new Point(6, 80);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(85, 20);
            lblUserName.TabIndex = 3;
            lblUserName.Text = "User Name:";
            // 
            // lblIPAdress
            // 
            lblIPAdress.AutoSize = true;
            lblIPAdress.Location = new Point(6, 42);
            lblIPAdress.Name = "lblIPAdress";
            lblIPAdress.Size = new Size(72, 20);
            lblIPAdress.TabIndex = 2;
            lblIPAdress.Text = "IP Adress:";
            // 
            // txtIPAddress
            // 
            txtIPAddress.Location = new Point(97, 39);
            txtIPAddress.Name = "txtIPAddress";
            txtIPAddress.Size = new Size(147, 27);
            txtIPAddress.TabIndex = 6;
            txtIPAddress.TextChanged += textchange;
            // 
            // grpWatchingSettings
            // 
            grpWatchingSettings.Controls.Add(chkWifiUsage);
            grpWatchingSettings.Controls.Add(chkCpuLoad);
            grpWatchingSettings.Controls.Add(chkRamUsage);
            grpWatchingSettings.Controls.Add(lblCalues);
            grpWatchingSettings.Controls.Add(chkDiskUsage);
            grpWatchingSettings.Controls.Add(lblCheckFrequency);
            grpWatchingSettings.Controls.Add(tbWatchInterval);
            grpWatchingSettings.Controls.Add(chkCpuTemperature);
            grpWatchingSettings.Location = new Point(268, 12);
            grpWatchingSettings.Name = "grpWatchingSettings";
            grpWatchingSettings.Size = new Size(250, 299);
            grpWatchingSettings.TabIndex = 2;
            grpWatchingSettings.TabStop = false;
            grpWatchingSettings.Text = "Watching Settings";
            // 
            // chkWifiUsage
            // 
            chkWifiUsage.AutoSize = true;
            chkWifiUsage.Location = new Point(6, 267);
            chkWifiUsage.Name = "chkWifiUsage";
            chkWifiUsage.Size = new Size(129, 24);
            chkWifiUsage.TabIndex = 7;
            chkWifiUsage.Text = "Wifi Usage (%)";
            chkWifiUsage.UseVisualStyleBackColor = true;
            chkWifiUsage.CheckedChanged += chkWifiUsage_CheckedChanged;
            // 
            // chkCpuLoad
            // 
            chkCpuLoad.AutoSize = true;
            chkCpuLoad.Location = new Point(6, 148);
            chkCpuLoad.Name = "chkCpuLoad";
            chkCpuLoad.Size = new Size(120, 24);
            chkCpuLoad.TabIndex = 3;
            chkCpuLoad.Text = "Cpu Load (%)";
            chkCpuLoad.UseVisualStyleBackColor = true;
            chkCpuLoad.CheckedChanged += chkCpuLoad_CheckedChanged;
            // 
            // chkRamUsage
            // 
            chkRamUsage.AutoSize = true;
            chkRamUsage.Location = new Point(6, 178);
            chkRamUsage.Name = "chkRamUsage";
            chkRamUsage.Size = new Size(132, 24);
            chkRamUsage.TabIndex = 4;
            chkRamUsage.Text = "Ram Usage (%)";
            chkRamUsage.UseVisualStyleBackColor = true;
            chkRamUsage.CheckedChanged += chkRamUsage_CheckedChanged;
            // 
            // lblCalues
            // 
            lblCalues.AutoSize = true;
            lblCalues.Location = new Point(6, 113);
            lblCalues.Name = "lblCalues";
            lblCalues.Size = new Size(130, 20);
            lblCalues.TabIndex = 2;
            lblCalues.Text = "Calues to Monitor:";
            // 
            // chkDiskUsage
            // 
            chkDiskUsage.AutoSize = true;
            chkDiskUsage.Location = new Point(6, 238);
            chkDiskUsage.Name = "chkDiskUsage";
            chkDiskUsage.Size = new Size(130, 24);
            chkDiskUsage.TabIndex = 6;
            chkDiskUsage.Text = "Disk Usage (%)";
            chkDiskUsage.UseVisualStyleBackColor = true;
            chkDiskUsage.CheckedChanged += chkDiskUsage_CheckedChanged;
            // 
            // lblCheckFrequency
            // 
            lblCheckFrequency.AutoSize = true;
            lblCheckFrequency.Location = new Point(6, 33);
            lblCheckFrequency.Name = "lblCheckFrequency";
            lblCheckFrequency.Size = new Size(206, 20);
            lblCheckFrequency.TabIndex = 1;
            lblCheckFrequency.Text = "Check Frequency (Speeds): [1]";
            // 
            // tbWatchInterval
            // 
            tbWatchInterval.LargeChange = 2;
            tbWatchInterval.Location = new Point(6, 61);
            tbWatchInterval.Minimum = 1;
            tbWatchInterval.Name = "tbWatchInterval";
            tbWatchInterval.Size = new Size(238, 56);
            tbWatchInterval.TabIndex = 0;
            tbWatchInterval.Value = 1;
            tbWatchInterval.Scroll += tbWatchInterval_Scroll;
            // 
            // chkCpuTemperature
            // 
            chkCpuTemperature.AutoSize = true;
            chkCpuTemperature.Location = new Point(6, 208);
            chkCpuTemperature.Name = "chkCpuTemperature";
            chkCpuTemperature.Size = new Size(174, 24);
            chkCpuTemperature.TabIndex = 5;
            chkCpuTemperature.Text = "Cpu Temperature (°C)";
            chkCpuTemperature.UseVisualStyleBackColor = true;
            chkCpuTemperature.CheckedChanged += chkCpuTemperature_CheckedChanged;
            // 
            // grpCriticalAlert
            // 
            grpCriticalAlert.Controls.Add(tbAlertRamUsage);
            grpCriticalAlert.Controls.Add(tbAlertCpuUsage);
            grpCriticalAlert.Controls.Add(chkAlertRamUsage);
            grpCriticalAlert.Controls.Add(chkAlertTemperature);
            grpCriticalAlert.Controls.Add(tbAlertTemperature);
            grpCriticalAlert.Controls.Add(chkAlertCpuUsage);
            grpCriticalAlert.Location = new Point(524, 12);
            grpCriticalAlert.Name = "grpCriticalAlert";
            grpCriticalAlert.Size = new Size(250, 299);
            grpCriticalAlert.TabIndex = 3;
            grpCriticalAlert.TabStop = false;
            grpCriticalAlert.Text = "Critical Alert Thresholds";
            // 
            // tbAlertRamUsage
            // 
            tbAlertRamUsage.Location = new Point(6, 235);
            tbAlertRamUsage.Maximum = 100;
            tbAlertRamUsage.Name = "tbAlertRamUsage";
            tbAlertRamUsage.Size = new Size(238, 56);
            tbAlertRamUsage.TabIndex = 5;
            tbAlertRamUsage.Scroll += TbChanges;
            // 
            // tbAlertCpuUsage
            // 
            tbAlertCpuUsage.Location = new Point(6, 146);
            tbAlertCpuUsage.Maximum = 100;
            tbAlertCpuUsage.Name = "tbAlertCpuUsage";
            tbAlertCpuUsage.Size = new Size(238, 56);
            tbAlertCpuUsage.TabIndex = 4;
            tbAlertCpuUsage.Scroll += TbChanges;
            // 
            // chkAlertRamUsage
            // 
            chkAlertRamUsage.AutoSize = true;
            chkAlertRamUsage.Location = new Point(6, 205);
            chkAlertRamUsage.Name = "chkAlertRamUsage";
            chkAlertRamUsage.Size = new Size(207, 24);
            chkAlertRamUsage.TabIndex = 2;
            chkAlertRamUsage.Text = "Critical Ram Usage (%): [0]";
            chkAlertRamUsage.UseVisualStyleBackColor = true;
            chkAlertRamUsage.CheckedChanged += ChkChanges;
            // 
            // chkAlertTemperature
            // 
            chkAlertTemperature.AutoSize = true;
            chkAlertTemperature.Location = new Point(6, 33);
            chkAlertTemperature.Name = "chkAlertTemperature";
            chkAlertTemperature.Size = new Size(213, 24);
            chkAlertTemperature.TabIndex = 0;
            chkAlertTemperature.Text = "Critical Temperature (C): [0]";
            chkAlertTemperature.UseVisualStyleBackColor = true;
            chkAlertTemperature.CheckedChanged += ChkChanges;
            // 
            // tbAlertTemperature
            // 
            tbAlertTemperature.Location = new Point(6, 63);
            tbAlertTemperature.Maximum = 100;
            tbAlertTemperature.Name = "tbAlertTemperature";
            tbAlertTemperature.Size = new Size(238, 56);
            tbAlertTemperature.TabIndex = 3;
            tbAlertTemperature.Scroll += TbChanges;
            // 
            // chkAlertCpuUsage
            // 
            chkAlertCpuUsage.AutoSize = true;
            chkAlertCpuUsage.Location = new Point(6, 116);
            chkAlertCpuUsage.Name = "chkAlertCpuUsage";
            chkAlertCpuUsage.Size = new Size(203, 24);
            chkAlertCpuUsage.TabIndex = 1;
            chkAlertCpuUsage.Text = "Critical Cpu Usage (%): [0]";
            chkAlertCpuUsage.UseVisualStyleBackColor = true;
            chkAlertCpuUsage.CheckedChanged += ChkChanges;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Location = new Point(0, 319);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(782, 22);
            statusStrip.TabIndex = 4;
            statusStrip.Text = "Ready";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 341);
            Controls.Add(statusStrip);
            Controls.Add(grpCriticalAlert);
            Controls.Add(grpWatchingSettings);
            Controls.Add(grpServerProfiles);
            Name = "Form1";
            ShowInTaskbar = false;
            Text = "CoreTether";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            trayContextMenuStrip.ResumeLayout(false);
            grpServerProfiles.ResumeLayout(false);
            grpServerProfiles.PerformLayout();
            grpWatchingSettings.ResumeLayout(false);
            grpWatchingSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbWatchInterval).EndInit();
            grpCriticalAlert.ResumeLayout(false);
            grpCriticalAlert.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbAlertRamUsage).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAlertCpuUsage).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAlertTemperature).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ContextMenuStrip trayContextMenuStrip;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private GroupBox grpServerProfiles;
        private Label lblPassword;
        private Label lblUserName;
        private Label lblIPAdress;
        private GroupBox grpWatchingSettings;
        private GroupBox grpCriticalAlert;
        private TextBox txtPassword;
        private TextBox txtUserName;
        private TextBox txtIPAddress;
        private Button btnConnect;
        private Button btnClear;
        private CheckBox chkCpuLoad;
        private CheckBox chkRamUsage;
        private Label lblCalues;
        private CheckBox chkDiskUsage;
        private Label lblCheckFrequency;
        private TrackBar tbWatchInterval;
        private CheckBox chkCpuTemperature;
        private TrackBar tbAlertRamUsage;
        private TrackBar tbAlertCpuUsage;
        private CheckBox chkAlertRamUsage;
        private CheckBox chkAlertTemperature;
        private TrackBar tbAlertTemperature;
        private CheckBox chkAlertCpuUsage;
        private StatusStrip statusStrip;
        private Button btnStart;
        private CheckBox chkWifiUsage;
        private CheckBox chkDemo;
        private static NotifyIcon sysTrayIcon;
    }
}