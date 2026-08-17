using Renci.SshNet;
using System;
using System.Globalization;

namespace CoreTether
{
    internal class SshNetService
    {
        bool demo = false;
        #region Connection Settings

        private static string UserName { get; set; }
        private static string Host { get; set; }
        private static string Password { get; set; }
        private static int Port { get; set; }


        public static void SetSshCredentials(string host, string username, string password, int port = 22)
        {
            Host = host;
            UserName = username;
            Password = password;
            Port = port;
        }
        #endregion


        public static bool ConnectSsh()
        {
            Console.WriteLine("Connection starting...");
            using var client = new SshClient(Host, Port, UserName, Password);
            try
            {
                client.Connect();
                Console.WriteLine("OK");

                var command = client.RunCommand("whoami");
                Console.WriteLine($"Results: {command.Result.Trim()}");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SSH Error: {ex.Message}");
                return false;
            }
            finally
            {
                if (client.IsConnected)
                    client.Disconnect();
            }
        }

        private string RunSshCommand(string commandText)
        {
            using var client = new SshClient(Host, Port, UserName, Password);
            try
            {
                client.Connect();
                var command = client.RunCommand(commandText);
                return command.Result.Trim();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SSH Error: {ex.Message}");
                return null;
            }
            finally
            {
                if (client.IsConnected)
                    client.Disconnect();
            }
        }



        #region Values
        public float Cpu { get; private set; }
        public float Ram { get; private set; }
        public float Disc { get; private set; }
        public float Wifi { get; private set; }
        private float RamSize { get; set; }
        private float CpuThreads { get; set; }




        private void SetValues(float? Cpu = null, float? Ram = null, float? Disc = null, float? Wifi = null)
        {
            if (Cpu.HasValue) this.Cpu = Cpu.Value;
            if (Ram.HasValue) this.Ram = Ram.Value;
            if (Disc.HasValue) this.Disc = Disc.Value;
            if (Wifi.HasValue) this.Wifi = Wifi.Value;
        }
        private void SetImportedValues(float? RamSize = null, float? CpuThreads = null)
        {
            if (RamSize.HasValue) this.RamSize = RamSize.Value;
            if (CpuThreads.HasValue) this.CpuThreads = CpuThreads.Value;
        }

        private void GetImportedValues()
        {
            if (demo)
            {
                Random random = new Random();
                SetImportedValues(
                          (float)Math.Round(random.NextDouble() * 64000),
                          (float)Math.Round(random.NextDouble() * 24)
                           );
                Console.WriteLine($"Imported Values: RamSize={RamSize}, CpuThreads={CpuThreads}");
            }
            else
            {
                //  I will add the code to get the values from the SSH connection here in the future
            }
        }


        public void GetValues()
        {
            GetImportedValues();
            if (demo)
            {

                if (RamSize >= 16000 || CpuThreads >= 6) // If the system has more than 16GB of RAM or more than 6 CPU threads,
                                                         // generate float values with 2 decimal places.
                                                         // Since this is a more powerful server,
                                                         // showing more precise values provides better detail.
                {
                    Random random = new Random();
                    SetValues(
                              (float)Math.Round(random.NextDouble() * 100, 2),
                              (float)Math.Round(random.NextDouble() * 100, 2),
                              (float)Math.Round(random.NextDouble() * 100, 2),
                              (float)Math.Round(random.NextDouble() * 100, 2)
                               );
                }
                else
                {
                    Random random = new Random();
                    SetValues(
                              (float)Math.Round(random.NextDouble() * 100),
                              (float)Math.Round(random.NextDouble() * 100),
                              (float)Math.Round(random.NextDouble() * 100),
                              (float)Math.Round(random.NextDouble() * 100)
                               );
                }
            }
            else
            {
                SetValues(
                ParseValue(RunSshCommand("LANG=C top -bn1 | grep \"Cpu(s)\" | awk '{print 100 - $8}'")), // This command work abnormally.
                ParseValue(RunSshCommand("free | grep Mem | awk '{print int($3/$2 * 100)}'")),
                ParseValue(RunSshCommand("df / | tail -1 | awk '{print $5}' | tr -d '%'")),
                ParseValue(RunSshCommand("awk 'NR==3 {print int($3*100/70)}' /proc/net/wireless"))
                //I will change this command to more optimized one in the future, but for now it works fine.
            );
            }
        }
        private float ParseValue(string raw)
        {
            return float.TryParse(raw?.Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out var val)
                ? val
                : 0f;
        }
        #endregion
    }
}

