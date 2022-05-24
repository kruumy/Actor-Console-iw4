using System.Diagnostics;

namespace ActorConsole.Classes
{
    internal static class ProcessFuncs
    {
        public static bool IsConsoleAlreadyRunning()
        {
            Process currentP = Process.GetCurrentProcess();
            Process[] allP = Process.GetProcesses();
            int i = 0;
            foreach (Process p in allP)
            {
                if (currentP.ProcessName == p.ProcessName)
                {
                    i++;
                    if (i >= 2)
                    {
                        currentP.Dispose();
                        p.Dispose();
                        return true;
                    }
                    else
                    {
                        p.Dispose();
                    }
                }
                else
                {
                    p.Dispose();
                }
            }
            currentP.Dispose();
            return false;

        }
        public static bool IsGameConnected()
        {
            Process[] processesiw4x = Process.GetProcessesByName("iw4x");
            Process[] processesiw4m = Process.GetProcessesByName("iw4m");
            if (processesiw4m.Length == 0)
            {
                if (processesiw4x.Length > 0)
                {
                    DisposeArray(processesiw4x);
                    DisposeArray(processesiw4m);
                    return true;
                }
                else
                {
                    DisposeArray(processesiw4x);
                    DisposeArray(processesiw4m);
                    return false;
                }
            }
            else
            {
                DisposeArray(processesiw4x);
                DisposeArray(processesiw4m);
                return true;
            }

            void DisposeArray(Process[] array)
            {
                try
                {
                    foreach (Process p in array)
                    {
                        p.Dispose();
                    }
                }
                catch
                {

                }
            }

        }
        public static void DisposeArray(Process[] array)
        {
            try
            {
                foreach (Process p in array)
                {
                    p.Dispose();
                }
            }
            catch
            {

            }
        }
        public static uint GetGameProcId()
        {
            Process[] processesiw4x = Process.GetProcessesByName("iw4x");
            Process[] processesiw4m = Process.GetProcessesByName("iw4m");

            if (processesiw4x.Length > 0)
            {
                return (uint)processesiw4x[0].Id;
            }
            else if (processesiw4m.Length > 0)
            {
                return (uint)processesiw4m[0].Id;
            }

            DisposeArray(processesiw4x);
            DisposeArray(processesiw4m);
            return 0;
        }
        public static string GetGameProcName()
        {
            Process[] processesiw4x = Process.GetProcessesByName("iw4x");
            Process[] processesiw4m = Process.GetProcessesByName("iw4m");

            if (processesiw4x.Length > 0)
            {
                return processesiw4x[0].ProcessName;
            }
            else if (processesiw4m.Length > 0)
            {
                return processesiw4m[0].ProcessName;
            }

            DisposeArray(processesiw4x);
            DisposeArray(processesiw4m);
            return "";
        }
    }
}
