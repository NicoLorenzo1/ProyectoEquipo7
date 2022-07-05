using System;
using System.Threading.Tasks;
using System.Timers;

namespace Library
{
    /// <summary>
    /// Nuevo modo de juego el cual se va a implementar para la entrega final, se basa en el modo de juego base pero se le suma la cualidad de que va a tener un
    /// tiempo limitado, logrando de esta forma una modalidad de juego mas rapida.
    /// </summary>
    public class TimeTrial : Game
    {
        // private User Player1;
        // private User Player2;
        private Board BoardPlayer1;
        private Board BoardPlayer2;
        public static int count = 0;


        //Seteo 3 minutos en milisegundos.
        System.Timers.Timer timerCounter = new System.Timers.Timer(180000);


        public TimeTrial(User player1, User player2, string name) : base(player1, player2, name)
        {
            this.Player1 = player1;
            this.Player2 = player2;
            BoardPlayer1 = new Board(this.Player1);
            BoardPlayer2 = new Board(this.Player2);
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
    }
}