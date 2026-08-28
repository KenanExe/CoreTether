using DomainChecker;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Timer = System.Windows.Forms.Timer;
namespace CoreTether
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.BringToFront();
            this.Activate();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //*

        private Timer timer;
        private async void Form1_Load(object sender, EventArgs e)
        {
            this.Hide();
            timer = new Timer();
            for (int i = 0; i < 5; i++)
                statusStrip.Items.Add("");
        }
        async void StartLoop()
        {
            timer.Interval = CheckFrequency * 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
            bool status = await SshNetService.ConnectSsh();
        }
        private async void Timer_Tick(object Sender, EventArgs e)
        {
            timer.Stop();
            try
            {
                await SshNetService.GetValues();
                await WarningSystem.CheckWarningsAsync();

                sysTrayIcon.Text = "Sistem Info\n" +
                                   "Cpu  " + SshNetService.Cpu + "%\n" +
                                   "Ram  " + SshNetService.Ram + "%\n" +
                                   "Disc " + SshNetService.Disc + "%\n" +
                                   "CpuTemp:" + SshNetService.CpuTemp + "\u00B0C\n" +
                                   "Wifi \u2193" + SshNetService.Wifi + "\u2191 KB/s";


                #region system info console output
                /*
                Console.Clear();
                Console.WriteLine("Sistem Info");
                Console.WriteLine("Cpu: " + values.Cpu + "%");
                Console.WriteLine("Ram: " + values.Ram + "%");
                Console.WriteLine("Disc: " + values.Disc + "%");
                Console.WriteLine("Wifi: " + values.Wifi + "%");
                */
                #endregion

                statusStrip.Items[0].Text = $"Cpu: {SshNetService.Cpu}%";
                statusStrip.Items[1].Text = $"Ram: {SshNetService.Ram}%";
                statusStrip.Items[2].Text = $"Disc: {SshNetService.Disc}%";
                statusStrip.Items[3].Text = $"CpuTemp: {SshNetService.CpuTemp}°C";
                statusStrip.Items[4].Text = $"Wifi: \u2193{SshNetService.Wifi}\u2191 KB/s";
            }
            finally
            {
                timer.Interval = CheckFrequency * 1000;
                timer.Start();
            }
        }

        public bool StartStatus { get; set; }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!StartStatus)
            {
                StartStatus = true;
                StartLoop();
                btnStart.Text = "Stop";
            }
            else
            {
                StartStatus = false;
                timer.Stop();
                btnStart.Text = "Start";
            }
        }

        //*

        private void TbChanges(object Sender, EventArgs e)
        {
            chkAlertTemperature.Text = $"Critical Temperature (C): [{tbAlertTemperature.Value}]";
            chkAlertCpuUsage.Text = $"Critical Cpu Usage (%): [{tbAlertCpuUsage.Value}]";
            chkAlertRamUsage.Text = $"Critical Ram Usage (%): [{tbAlertRamUsage.Value}]";
            WarningSystem.SetFrequency(tbAlertTemperature.Value, tbAlertCpuUsage.Value, tbAlertRamUsage.Value);
        }
        private void ChkChanges(object Sender, EventArgs e)
        {
            WarningSystem.SetChecked(chkAlertTemperature.Checked, chkAlertCpuUsage.Checked, chkAlertRamUsage.Checked);
        }



        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }
        public static void WarningTriggered(string warningType, float currentValue, float maxValue)
        {
            string message = $"{warningType} has exceeded the maximum value!\nCurrent Value: {currentValue}\nMax Value: {maxValue}";

            sysTrayIcon.BalloonTipTitle = "Warning";
            sysTrayIcon.BalloonTipText = message;
            sysTrayIcon.BalloonTipIcon = ToolTipIcon.Warning;
            sysTrayIcon.ShowBalloonTip(3000);
        }
        public static int CheckFrequency { get; private set; } = 1;

        private void tbWatchInterval_Scroll(object sender, EventArgs e)
        {
            lblCheckFrequency.Text = $"Check Frequency (s): [{tbWatchInterval.Value}]";
            CheckFrequency = tbWatchInterval.Value;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtIPAddress.Text = "";
            txtPassword.Text = "";
            txtUserName.Text = "";

        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            SshNetService.SetSshCredentials(txtIPAddress.Text, txtUserName.Text, txtPassword.Text);
            textchange(sender,e);
        }

        private void chkCpuLoad_CheckedChanged(object sender, EventArgs e)
        {
            SshNetService.CanGetCpu = chkCpuLoad.Checked;
        }

        private void chkRamUsage_CheckedChanged(object sender, EventArgs e)
        {
            SshNetService.CanGetRam = chkRamUsage.Checked;
        }

        private void chkCpuTemperature_CheckedChanged(object sender, EventArgs e)
        {
            SshNetService.CanGetCpuTemp = chkCpuTemperature.Checked;
        }

        private void chkDiskUsage_CheckedChanged(object sender, EventArgs e)
        {
            SshNetService.CanGetDisc = chkDiskUsage.Checked;
        }

        private void chkWifiUsage_CheckedChanged(object sender, EventArgs e)
        {
            SshNetService.CanGetWifi = chkWifiUsage.Checked;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            SshNetService.demo = chkDemo.Checked;
            if (chkDemo.Checked)
            {
                txtIPAddress.Text = "test.rebex.net";
                txtUserName.Text = "demo";
                txtPassword.Text = "password";
            }
            else
            {

                txtIPAddress.Text = string.Empty;
                txtUserName.Text = string.Empty;
                txtPassword.Text =  string.Empty;
            }
        }
        void textchange(object sender, EventArgs e)
        {
            btnConnect.Enabled = canBeConnect();
            btnStart.Enabled = SshNetService.HasConnectionInfo();
        }
        bool canBeConnect()
        {
            return !string.IsNullOrWhiteSpace(txtIPAddress.Text)
                && !string.IsNullOrWhiteSpace(txtPassword.Text)
                && !string.IsNullOrWhiteSpace(txtUserName.Text);
        }
    }
}
