using System.Threading.Tasks;

namespace ActorConsole.Classes
{
    internal static class DvarAnimation
    {
        public static bool isRunning = false;
        private static Classes.ExternalConsole Econsole = new Classes.ExternalConsole();


        private static string dvar;
        private static double from;
        private static double to;
        private static double speed;
        public static double currentValue;

        private static void DoWork()
        {
            isRunning = true;
            double currentValue = from;

            while (isRunning)
            {

                if (currentValue >= to)
                {
                    currentValue = from;
                }
                else
                {
                    currentValue += speed;
                }

                Econsole.Send($"{dvar} {currentValue}");
                System.Threading.Thread.Sleep(100);
            }
        }


        public static void StartAnimation(string dvarIN, double fromIN, double toIN, double speedIN)
        {
            dvar = dvarIN;
            from = fromIN;
            to = toIN;
            speed = speedIN;


            Task.Run(DoWork);
        }
        public static void StopAnimation()
        {
            isRunning = false;
        }
    }
}
