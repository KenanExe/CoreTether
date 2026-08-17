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

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Hide();
            var values = new SshNetService();
            SshNetService.SetSshCredentials("test.rebex.net", "demo", "password");

            values.GetValues();

            notifyIcon1.Text = "Sistem Info\n" +
                               "Cpu  "+ values.Cpu  +"%\n"  +
                               "Ram  "+ values.Ram  +"%\n"  +
                               "Disc "+ values.Disc +"%\n"  +
                               "Wifi "+ values.Wifi +"%";
            //ToDo: Add a timer to update the values every 5 seconds
            bool status = SshNetService.ConnectSsh();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }
    }
}
