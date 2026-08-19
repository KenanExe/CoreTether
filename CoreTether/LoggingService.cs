using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DomainChecker
{
    internal class LoggingService
    {
        /*
         * First version of log system.
         * Will be updated in the future with more features and better design.
        */

        // Win32 API Importları
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private const int SW_RESTORE = 9;

        static ConsoleColor WarnColor = ConsoleColor.Red;
        static ConsoleColor DefaultColor = ConsoleColor.Gray;

        public static void Log(string Message)
        {
            IntPtr consoleHandle = GetConsoleWindow();
            if (consoleHandle != IntPtr.Zero)
            {
                ShowWindow(consoleHandle, SW_RESTORE);
                SetForegroundWindow(consoleHandle);
            }

            StackTrace stackTrace = new StackTrace();

            var CallerFrame = stackTrace.GetFrame(1);
            var Method = CallerFrame?.GetMethod(); // null check eklendi

            var Header = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Log Entry: ";
            var Body = Method != null ? $"{Method.DeclaringType?.Name}.{Method.Name} " : "Unknown.Method ";
            var Back = Message;

            Console.Write(Header);
            Console.ForegroundColor = WarnColor;
            Console.Write(Body);
            Console.ForegroundColor = DefaultColor;
            Console.WriteLine(Back);
            Console.WriteLine("x-x-x");
        }
        public static void line()
        {
            IntPtr consoleHandle = GetConsoleWindow();
            if (consoleHandle != IntPtr.Zero)
            {
                ShowWindow(consoleHandle, SW_RESTORE);
                SetForegroundWindow(consoleHandle);
            }
            Console.WriteLine("-x-x-x-x-x-x-x-x-x-");
        }
    }
}