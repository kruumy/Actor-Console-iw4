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
            currentValue = from;
            bool reverse = false;

            while (isRunning)
            {

                if (currentValue >= to)
                {
                    reverse = true;
                }
                else if (currentValue <= from)
                {
                    reverse = false;
                }


                if (!reverse)
                {
                    currentValue += speed;
                }
                else if (reverse)
                {
                    currentValue -= speed;
                }

                Econsole.Send($"{dvar} {currentValue}");
                System.Threading.Thread.Sleep(50);
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
