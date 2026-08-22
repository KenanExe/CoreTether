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
        private Timer timer;
        private async void Form1_Load(object sender, EventArgs e)
        {
            this.Hide();
            timer = new Timer();
            SshNetService.SetSshCredentials("test.rebex.net", "demo", "password");
            for (int i = 0; i < 4; i++)
                statusStrip.Items.Add("loading");
            timer.Interval = CheckFrequency*1000; // ToDo: fix this later, make it dynamic
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
                                   "Wifi " + SshNetService.Wifi + "%";

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
                statusStrip.Items[3].Text = $"Wifi: {SshNetService.Wifi}%";
            }
            finally
            {
                timer.Start();
            }
        }

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
    }
}
