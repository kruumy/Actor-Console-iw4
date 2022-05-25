using Memory.Win32;
using System.Diagnostics;
using System.Text;

namespace ActorConsole.Classes
{
    internal static class MemoryFuncs
    {

        public static string GetCurrentMap()
        {
            string mapIn = "Could Not Find Current Map";


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
                        process.Dispose();
                        return mapIn.Normalize().Trim().Replace("\0", string.Empty);
                    }
                }
            }
            catch
            {

            }

            return mapIn;
        }
        public static float[] GetCurrentSunSettings()
        {
            uint sunRedAdd = 0x0085B878;
            uint sunGreenAdd = 0x0085B87C;
            uint sunBlueAdd = 0x0085B880;
            uint sunXAdd = 0x0085B884;
            uint sunYAdd = 0x0085B888;
            uint sunZAdd = 0x0085B88C;

            Process[] processes = Process.GetProcesses();
            MemoryHelper32 m;

            try
            {
                foreach (Process process in processes)
                {
                    if (process.ProcessName == "iw4x" || process.ProcessName == "iw4m")
                    {
                        m = new MemoryHelper32(process);

                        float red = m.ReadMemory<float>(sunRedAdd);
                        float green = m.ReadMemory<float>(sunGreenAdd);
                        float blue = m.ReadMemory<float>(sunBlueAdd);
                        float x = m.ReadMemory<float>(sunXAdd);
                        float y = m.ReadMemory<float>(sunYAdd);
                        float z = m.ReadMemory<float>(sunZAdd);
                        process.Dispose();

                        float[] Farray = { red, green, blue, x, y, z };

                        return Farray;


                    }
                }
            }
            catch
            {
            }

            return null;



        }

        public static void WriteSunPosition(float X, float Y, float Z)
        {
            uint sunXAdd = 0x0085B884;
            uint sunYAdd = 0x0085B888;
            uint sunZAdd = 0x0085B88C;

            Process[] processes = Process.GetProcesses();
            MemoryHelper32 m;

            try
            {
                foreach (Process process in processes)
                {
                    if (process.ProcessName == "iw4x" || process.ProcessName == "iw4m")
                    {
                        m = new MemoryHelper32(process);
                        m.WriteMemory<float>(sunXAdd, X);
                        m.WriteMemory<float>(sunYAdd, Y);
                        m.WriteMemory<float>(sunZAdd, Z);


                    }
                    process.Dispose();
                }
            }
            catch
            {
            }



        }
        public static void WriteSunColor(float R, float G, float B)
        {
            uint sunRedAdd = 0x0085B878;
            uint sunGreenAdd = 0x0085B87C;
            uint sunBlueAdd = 0x0085B880;

            Process[] processes = Process.GetProcesses();
            MemoryHelper32 m;

            try
            {
                foreach (Process process in processes)
                {
                    if (process.ProcessName == "iw4x" || process.ProcessName == "iw4m")
                    {
                        m = new MemoryHelper32(process);

                        m.WriteMemory<float>(sunRedAdd, R);
                        m.WriteMemory<float>(sunGreenAdd, G);
                        m.WriteMemory<float>(sunBlueAdd, B);

                    }
                    process.Dispose();
                }
            }
            catch
            {
            }



        }

    }
}
