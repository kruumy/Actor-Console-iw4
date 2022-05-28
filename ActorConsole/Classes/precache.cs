using System.Collections.Generic;
using System.IO;

namespace ActorConsole.Classes
{
    internal static class precache
    {

        // replace these all with regex to make it more flexible
        public static string[] GetMPAnimsFromDir(string gscDir)
        {
            List<string> stringList = new List<string>();
            try
            {
                string[] output = File.ReadAllText(gscDir).Split('"');
                foreach (string line in output)
                {
                    if (line.Contains("pb"))
                    {
                        stringList.Add(line);
                    }
                }
            }
            catch
            {
            }
            return stringList.ToArray();
        }
        public static string[] GetSPAnimsFromDir(string gscDir)
        {
            List<string> stringList = new List<string>();
            try
            {
                string[] output = File.ReadAllText(gscDir).Split('\n');
                foreach (string line in output)
                {
                    if (line.Contains("PrecacheMPAnim") && !line.Contains("pb") && !line.Contains("//"))
                    {
                        string finalline = "";
                        finalline = line.Trim().Substring(15).Replace(')', ' ').Replace('(', ' ').Replace(';', ' ').Replace('\"', ' ').Trim();

                        stringList.Add(finalline);
                    }
                }
            }
            catch
            {
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
        public static string[] GetSPModelsFromDir(string gscDir)
        {
            List<string> stringList = new List<string>();
            try
            {
                string[] output = File.ReadAllLines(gscDir);
                foreach (string line in output)
                {
                    if (line.Contains("PrecacheModel") && !line.Contains("//"))
                    {
                        stringList.Add(line.Trim().Substring(14).Replace(')', ' ').Replace('(', ' ').Replace(';', ' ').Replace('\"', ' ').Trim());
                    }
                }
            }
            catch
            {
            }

            return stringList.ToArray();
        }
    }
}
