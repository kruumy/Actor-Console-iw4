using System;
using System.Net;

namespace ActorConsole.Classes
{
    internal static class UpdateChecker
    {
        public static bool CheckForUpdates(string currentVersionString)
        {
            bool isUpdateAvailable = false;
            try
            {
                WebClient client = new WebClient();

                string url = "https://raw.githubusercontent.com/kruumy/Actor-Console-iw4/main/version.txt";
                string latestVersionString = client.DownloadString(url);
                client.Dispose();

                int currentVersion = Convert.ToInt32(currentVersionString.Replace(".", "").Replace("v", "").Trim());
                int latestVersion = Convert.ToInt32(latestVersionString.Replace(".", "").Replace("v", "").Trim());

                if (latestVersion > currentVersion)
                {
                    isUpdateAvailable = true;
                }
            }
            catch
            {

            }

            return isUpdateAvailable;
        }
    }
}
