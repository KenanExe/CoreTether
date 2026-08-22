using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreTether
{
    public static class WarningSystem
    {
        public static int MaxCpuTemp { get; private set; }
        public static int MaxCpuUsage { get; private set; }
        public static int MaxRamUsage { get; private set; }

        public static bool CheckCpuTemp { get; private set; }
        public static bool CheckCpuUsage { get; private set; }
        public static bool CheckRamUsage { get; private set; }

        public static async void SetFrequency(int SetMaxCpuTemp, int SetMaxCpuUsage, int SetMaxRamUsage)
        {
            MaxCpuTemp = SetMaxCpuTemp;
            MaxCpuUsage = SetMaxCpuUsage;
            MaxRamUsage = SetMaxRamUsage;
        }
        public static async void SetChecked(bool SetChkCpuTemp, bool SetChkCpuUsage, bool SetChkRamUsage)
        {
            CheckCpuTemp = SetChkCpuTemp;
            CheckCpuUsage = SetChkCpuUsage;
            CheckRamUsage = SetChkRamUsage;
        }


        async public static Task<bool> CheckWarningsAsync()
        {
            bool warningTriggered = false;
            if (CheckCpuTemp)
            {
                float currentCpuTemp = SshNetService.CpuTemp;
                if (currentCpuTemp > MaxCpuTemp)
                {
                    Form1.WarningTriggered("CPU Temperature", currentCpuTemp, MaxCpuTemp);
                }
            }
            if (CheckCpuUsage)
            {
                float currentCpuUsage = SshNetService.Cpu;
                if (currentCpuUsage > MaxCpuUsage)
                {
                    Form1.WarningTriggered("CPU Usage", currentCpuUsage, MaxCpuUsage);
                }
            }
            if (CheckRamUsage)
            {
                float currentRamUsage = SshNetService.Ram;
                if (currentRamUsage > MaxRamUsage)
                {
                    Form1.WarningTriggered("RAM Usage", currentRamUsage, MaxRamUsage);
                }
            }
            return warningTriggered;
        }
        
       
    }
}
