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

        private User Player1;
        private User Player2;
        private Board BoardPlayer1;
        private Board BoardPlayer2;




        public TimeTrialMode(User player1, User player2, string name) : base(name)
        {
            this.Player1 = player1;
            this.Player2 = player2;
            BoardPlayer1 = new Board(this.Player1);
            BoardPlayer2 = new Board(this.Player2);



        }
        public TimeTrialMode(string name) :base(name)
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