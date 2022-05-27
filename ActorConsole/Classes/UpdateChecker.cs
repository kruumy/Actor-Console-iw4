using System.Net;

namespace ActorConsole.Classes
{
    internal static class UpdateChecker
    {
        public static bool CheckForUpdates(string currentVersion)
        {
            bool isUpdateAvailable = false;
            try
            {
                WebClient client = new WebClient();

                string url = "https://raw.githubusercontent.com/kruumy/Actor-Console-iw4/main/version.txt";
                string latestVersion = client.DownloadString(url);
                client.Dispose();

                if (latestVersion != currentVersion)
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
