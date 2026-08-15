using System;
using Renci.SshNet;

namespace CoreTether
{
    internal class SshNetService
    {
        public static bool ConnectSsh(string host, string username, string password, int port = 22)
        {
            Console.WriteLine("Connection starting...");
            using var client = new SshClient(host, port, username, password);

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
    }
}

