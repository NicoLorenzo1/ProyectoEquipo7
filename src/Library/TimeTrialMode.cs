using System;
using System.Threading.Tasks;
using System.Timers;

namespace Library
{
    public class TimeTrialMode : Mode
    {
        public static int count = 0;


        //Seteo 3 minutos en milisegundos.
        System.Timers.Timer timerCounter = new System.Timers.Timer(180000);


        public TimeTrialMode(string name)
        {

        }

        public void FinishTimeGame()
        {
            timerCounter.Elapsed += timerCounter_Elapsed;
            timerCounter.AutoReset = false;
            timerCounter.Enabled = true;
            timerCounter.Start();
            Console.ReadKey();

        }

        private static void timerCounter_Elapsed(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("finalizo");
            //Game.EndGame;
        }
    }
}