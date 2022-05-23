using Memory.Win32;
using System.Diagnostics;
using System.Text;

namespace ActorConsole.Classes
{
    internal static class MemoryFuncs
    {

        public static string GetCurrentMap()
        {
            string mapIn = "";


            Process[] processes = Process.GetProcesses();
            MemoryHelper32 m;
            try
            {
                foreach (Process process in processes)
                {
                    if (process.ProcessName == "iw4x" || process.ProcessName == "iw4m")
                    {
                        m = new MemoryHelper32(process);
                        byte[] bytes = m.ReadMemoryBytes(m.GetBaseAddress(0x5EE27A0), 15);
                        mapIn = Encoding.ASCII.GetString(bytes, 0, 15);
                        return mapIn.Normalize().Trim().Replace("\0", string.Empty);
                    }
                }
            }
            catch
            {

            }

            return mapIn;
        }

    }
}
