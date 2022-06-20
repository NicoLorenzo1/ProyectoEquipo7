using System;
using System.Threading.Tasks;
using System.Timers;

namespace Library
{
    public class TimeTrialMode : Game
    {
        private User Player1;
        private User Player2;
        private Board BoardPlayer1;
        private Board BoardPlayer2;
        public static int count = 0;


        //Seteo 3 minutos en milisegundos.
        System.Timers.Timer timerCounter = new System.Timers.Timer(180000);


        public TimeTrialMode(User player1, User player2, string name) : base(name)
        {
            this.Player1 = player1;
            this.Player2 = player2;
            BoardPlayer1 = new Board(this.Player1);
            BoardPlayer2 = new Board(this.Player2);
        }
        public TimeTrialMode(string name) : base(name)
        {
            if (name.ToLower() == "timetrial mode")
            {
                this.Name = name;
                TimeTrialMode game = new TimeTrialMode(this.usersWaiting.ElementAt(0), this.usersWaiting.ElementAt(1), this.Name);
                this.StartGame();   
            }
            else
            {
                Console.WriteLine("Modo incorrecto");
            }
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
            TimeTrialMode game = new TimeTrialMode(this.usersWaiting.ElementAt(0), this.usersWaiting.ElementAt(1), "Time Trial");
            base.MatchPlayers();
            Console.WriteLine($"Comenzará una nueva partida de contrarreloj con los jugadores {this.usersWaiting.ElementAt(0)} , {this.usersWaiting.ElementAt(1)}.");
            game.StartGame();
        }
    }
}