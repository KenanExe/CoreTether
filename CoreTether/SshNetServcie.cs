using Renci.SshNet;
using System;
using System.Globalization;

namespace CoreTether
{
    internal static class SshNetService
    {
        static bool demo = true;
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


        public static Task<bool> ConnectSsh()
        {
            Console.WriteLine("Connection starting...");
            using var client = new SshClient(Host, Port, UserName, Password);
            try
            {
                client.Connect();
                Console.WriteLine("OK");

                var command = client.RunCommand("whoami");
                Console.WriteLine($"Results: {command.Result.Trim()}");
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SSH Error: {ex.Message}");
                return Task.FromResult(false);
            }
            finally
            {
                if (client.IsConnected)
                    client.Disconnect();
            }
        }

        private static Task<string> RunSshCommand(string commandText)
        {
            using var client = new SshClient(Host, Port, UserName, Password);
            try
            {
                client.Connect();
                var command = client.RunCommand(commandText);
                return Task.FromResult(command.Result.Trim());
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
        public static float Cpu { get; private set; }
        public static float Ram { get; private set; }
        public static float Disc { get; private set; }
        public static float Wifi { get; private set; }
        
        private static float RamSize { get; set; }
        private static float CpuThreads { get; set; }

        public static float CpuTemp { get; private set; }




        private static void SetValues(float? cpu = null, float? ram = null, float? disc = null, float? wifi = null)
        {
            if (cpu.HasValue) Cpu = cpu.Value;
            if (ram.HasValue) Ram = ram.Value;
            if (disc.HasValue) Disc = disc.Value;
            if (wifi.HasValue) Wifi = wifi.Value;
        }
        private static void SetImportedValues(float? ramSize = null, float? cpuThreads = null)
        {
            if (ramSize.HasValue) RamSize = ramSize.Value;
            if (cpuThreads.HasValue) CpuThreads = cpuThreads.Value;
        }

        private static void GetImportedValues()
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

        private static bool first { get; set; } = true;
        public static async Task GetValues()
        {
            if (first)
            {
                GetImportedValues();
                first = false;
            }
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
                    ParseValue(await RunSshCommand("top -bn2 -d 1 | grep \"Cpu(s)\" | tail -1 | awk -F'id,' '{split($1,a,\",\"); v=a[length(a)]; gsub(/[^0-9.]/,\"\",v); print 100-v}'")),
                    ParseValue(await RunSshCommand("free | grep Mem | awk '{print int($3/$2 * 100)}'")),
                    ParseValue(await RunSshCommand("df / | tail -1 | awk '{print $5}' | tr -d '%'")),
                    ParseValue(await RunSshCommand("nmcli -t -f active,signal dev wifi | grep '^yes:' | cut -d: -f2"))
                );
            }
        }
        private static float ParseValue(string raw)
        {
            return float.TryParse(raw?.Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out var val)
                ? val
                : 0f;
        }
        #endregion
    }
}

