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

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Hide();
            Timer timer = new Timer();
            var values = new SshNetService();
            //SshNetService.SetSshCredentials("test.rebex.net", "demo", "password");
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
            //ToDo: Make this async
            bool status = SshNetService.ConnectSsh();
        }
        private void Timer_Tick(object Sender, EventArgs e)
        {
            var values = new SshNetService();
            values.GetValues();

            sysTrayIcon.Text = "Sistem Info\n" +
                               "Cpu  " + values.Cpu + "%\n" +
                               "Ram  " + values.Ram + "%\n" +
                               "Disc " + values.Disc + "%\n" +
                               "Wifi " + values.Wifi + "%";
            /*
            Console.Clear();
            Console.WriteLine("Sistem Info");
            Console.WriteLine("Cpu: " + values.Cpu + "%");
            Console.WriteLine("Ram: " + values.Ram + "%");
            Console.WriteLine("Disc: " + values.Disc + "%");
            Console.WriteLine("Wifi: " + values.Wifi + "%");
            */
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
