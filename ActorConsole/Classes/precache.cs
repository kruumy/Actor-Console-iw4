using System.Collections.Generic;
using System.IO;

namespace ActorConsole.Classes
{
    internal static class precache
    {
        public static string[] GetMPAnimsFromDir(string gscDir)
        {
            List<string> stringList = new List<string>();
            string[] output = { "" };
            try
            {
                output = File.ReadAllText(gscDir).Split('"');
            }
            catch
            {
            }

            foreach (string line in output)
            {
                if (line.Contains("pb"))
                {
                    stringList.Add(line);
                }
            }
            return stringList.ToArray();
        }
        public static string[] GetSPAnimsFromDir(string gscDir)
        {
            List<string> stringList = new List<string>();
            string[] output = { "" };
            try
            {
                output = File.ReadAllText(gscDir).Split('\n');
            }
            catch
            {
            }

            foreach (string line in output)
            {
                if (line.Contains("PrecacheMPAnim") && !line.Contains("pb") && !line.Contains("//"))
                {
                    string finalline = "";
                    finalline = line.Substring(15).Replace(')', ' ').Replace(';', ' ').Replace('\"', ' ').Trim();

                    stringList.Add(finalline);
                }
            }
            return stringList.ToArray();
        }
        public static string[] GetMPDeathAnims(string[] anims)
        {
            List<string> stringList = new List<string>();

            foreach (string anim in anims)
            {
                if (anim.Contains("death"))
                {
                    stringList.Add(anim);
                }
            }

            return stringList.ToArray();
        }
        public static string[] GetMPIdleAnims(string[] anims)
        {
            List<string> stringList = new List<string>();

            foreach (string anim in anims)
            {
                if (!anim.Contains("death") && anim.Contains("pb"))
                {
                    stringList.Add(anim);
                }
            }

            return stringList.ToArray();
        }
        public static string[] GetSPModelsFromDir(string gscDir) // not done yet
        {
            List<string> stringList = new List<string>();
            string[] output = { "" };
            try
            {
                output = File.ReadAllText(gscDir).Split('\n');
            }
            catch
            {
            }

            foreach (string line in output)
            {
                if (line.Contains("PrecacheModel"))
                {
                    stringList.Add(line.Substring(14).Replace(')', ' ').Replace(';', ' ').Replace('\"', ' ').Trim());
                }
            }
            return stringList.ToArray();
        }
    }
}
