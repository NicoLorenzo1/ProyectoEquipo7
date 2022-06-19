using System;
using System.Threading.Tasks;
using System.Timers;

namespace Library
{
    public class TimeTrialMode : Game
    {
        public static int count = 0;


        //Seteo 3 minutos en milisegundos.
        System.Timers.Timer timerCounter = new System.Timers.Timer(180000);


        public TimeTrialMode(string name) : base ()
        {

        }
        public override void StartGame()
        {
            while (true)
            {
                if (timerCounter.Enabled == false)
                {
                    break;
                }
            }
            base.EndGame();
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
        }

        public override void MatchPlayers()
        {
            TimeTrialMode game = new TimeTrialMode(this.usersWaiting.ElementAt(0), this.usersWaiting.ElementAt(1));
            base.MatchPlayers();
            Console.WriteLine($"Comenzará una nueva partida de contrarreloj con los jugadores {this.usersWaiting.ElementAt(0)} , {this.usersWaiting.ElementAt(1)}.");
            game.StartGame();
        }
    }
}