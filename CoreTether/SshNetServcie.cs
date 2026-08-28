using Renci.SshNet;
using System;
using System.Globalization;

namespace CoreTether
{
    internal static class SshNetService
    {
        public static bool demo { get; set; } = false;
        #region Connection Settings
        public static bool HasConnectionInfo()
        {
            return !string.IsNullOrWhiteSpace(UserName)
                && !string.IsNullOrWhiteSpace(Host)
                && !string.IsNullOrWhiteSpace(Password);
        }
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


        public static async Task<bool> ConnectSsh()
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

        private static async Task<string> RunSshCommand(string commandText)
        {
            return await Task.Run(() =>
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
            });
        }



        #region Values
        public static float Cpu { get; private set; }
        public static float Ram { get; private set; }
        public static float Disc { get; private set; }
        public static string Wifi { get; private set; }

        private static float RamSize { get; set; }
        private static float CpuThreads { get; set; }

        public static float CpuTemp { get; private set; }

        public static bool CanGetCpu { get; set; }
        public static bool CanGetRam { get; set; }
        public static bool CanGetDisc { get; set; }
        public static bool CanGetWifi { get; set; }
        public static bool CanGetCpuTemp { get; set; }


        private static void SetValues(float? cpu = null, float? ram = null, float? disc = null, string? wifi = null, float? cpuTemp = null)
        {
            if (cpu.HasValue) Cpu = cpu.Value;
            if (ram.HasValue) Ram = ram.Value;
            if (disc.HasValue) Disc = disc.Value;
            if (!string.IsNullOrWhiteSpace(wifi)) Wifi = wifi;
            if (cpuTemp.HasValue) CpuTemp = cpuTemp.Value;
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
                          (float)Math.Round(random.NextDouble() * 32000),
                          (float)Math.Round(random.NextDouble() * 12)
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
                    if (CanGetCpu)
                        SetValues((float)Math.Round(random.NextDouble() * 100, 2)); //cpu
                    else
                        SetValues(0); //cpu

                    if (CanGetRam)
                        SetValues(null, (float)Math.Round(random.NextDouble() * 100, 2)); // ram
                    else
                        SetValues(null, 0); // ram
                    if (CanGetDisc)
                        SetValues(null, null, (float)Math.Round(random.NextDouble() * 100, 2)); //disc
                    else
                        SetValues(null, null, 0); //disc
                    if (CanGetWifi)
                        SetValues(null, null, null, Convert.ToString((float)Math.Round(random.NextDouble() * 100) +" "+ (float)Math.Round(random.NextDouble() * 100))); //wifi
                    else
                        SetValues(null, null, null, "0 0"); //wifi
                    if (CanGetCpuTemp)
                        SetValues(null, null, null, null, (float)Math.Round(random.NextDouble() * 100, 2)); //cpuTemp
                    else
                        SetValues(null, null, null, null, 0); //cpuTemp
                }
                else
                {
                    Random random = new Random();
                    if (CanGetCpu)
                        SetValues((float)Math.Round(random.NextDouble() * 100)); //cpu
                    else
                        SetValues(0); //cpu

                    if (CanGetRam)
                        SetValues(null, (float)Math.Round(random.NextDouble() * 100)); // ram
                    else
                        SetValues(null, 0); // ram
                    if (CanGetDisc)
                        SetValues(null, null, (float)Math.Round(random.NextDouble() * 100)); //disc
                    else
                        SetValues(null, null, 0); //disc
                    if (CanGetWifi)
                        SetValues(null, null, null, Convert.ToString((float)Math.Round(random.NextDouble() * 100) + " " + (float)Math.Round(random.NextDouble() * 100))); //wifi
                    else
                        SetValues(null, null, null, "0 0"); //wifi
                    if (CanGetCpuTemp)
                        SetValues(null, null, null, null, (float)Math.Round(random.NextDouble() * 100)); //cpuTemp
                    else
                        SetValues(null, null, null, null, 0); //cpuTemp
                }
            }
            else
            {
                //cpu command anormal.
                Task<string> cpuTask = CanGetCpu ? RunSshCommand("bash -c 'read -r _ u1 n1 s1 i1 w1 x1 y1 z1 < /proc/stat; sleep 0.3; read -r _ u2 n2 s2 i2 w2 x2 y2 z2 < /proc/stat; t1=$((u1+n1+s1+i1+w1+x1+y1+z1)); t2=$((u2+n2+s2+i2+w2+x2+y2+z2)); idle1=$((i1+w1)); idle2=$((i2+w2)); dt=$((t2-t1)); di=$((idle2-idle1)); echo $(( (1000*(dt-di)/dt+5)/10 ))'") : Task.FromResult<string>(null);
                Task<string> ramTask = CanGetRam ? RunSshCommand("free | awk '/Mem:/{print int($3/$2*100)}'") : Task.FromResult<string>(null);
                Task<string> diskTask = CanGetDisc ? RunSshCommand("df / | tail -1 | awk '{print $5}' | tr -d '%'") : Task.FromResult<string>(null);
                Task<string> wifiTask = CanGetWifi ? RunSshCommand("IF=$(ip route | awk '/default/ {print $5}' | head -1); R1=$(cat /sys/class/net/$IF/statistics/rx_bytes); T1=$(cat /sys/class/net/$IF/statistics/tx_bytes); sleep 0.5; R2=$(cat /sys/class/net/$IF/statistics/rx_bytes); T2=$(cat /sys/class/net/$IF/statistics/tx_bytes); echo \"$(( (R2-R1)*2/1024 )) $(( (T2-T1)*2/1024 ))\"") : Task.FromResult<string>(null);
                Task<string> tempTask = CanGetCpuTemp ? RunSshCommand("cat /sys/class/thermal/thermal_zone0/temp | awk '{print $1/1000}'") : Task.FromResult<string>(null);
                await Task.WhenAll(cpuTask, ramTask, diskTask, wifiTask, tempTask);

                SetValues(
                    CanGetCpu ? await ParseValue(cpuTask.Result,"cpu") : 0,
                    CanGetRam ? await ParseValue(ramTask.Result, "ram") : 0,
                    CanGetDisc ? await ParseValue(diskTask.Result, "disk") : 0,
                    CanGetWifi ? (string.IsNullOrWhiteSpace(wifiTask.Result) ? "0 0" : wifiTask.Result.Trim()) : "0 0",
                    CanGetCpuTemp ? await ParseValue(tempTask.Result, "temp") : 0
                );

            }
        }
        private static async Task<float> ParseValue(string raw, string who)
        {
            if (string.IsNullOrWhiteSpace(raw))
            {
                Console.WriteLine($"ParseValue: value null or empty and {who} want to write -> {raw}");
                return 0f;
            }

            var trimmed = raw.Trim();

            if (who == "wifi")
            {
                var parts = trimmed.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
                float sum = 0f;
                bool any = false;
                foreach (var p in parts)
                {
                    if (float.TryParse(p, NumberStyles.Float, CultureInfo.InvariantCulture, out var v))
                    {
                        sum += v;
                        any = true;
                    }
                }
                if (any) return sum;

                Console.WriteLine($"ParseValue: cant be a parse -> '{raw}'");
                return 0f;
            }

            if (float.TryParse(trimmed, NumberStyles.Float, CultureInfo.InvariantCulture, out var val))
            {
                return val;
            }

            Console.WriteLine($"ParseValue:{who} wantto be a parse but cannot -> '{raw}'");
            return 0f;
        }
        #endregion
    }
}

