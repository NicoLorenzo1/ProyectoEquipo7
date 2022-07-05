using System;
using System.Threading.Tasks;
using System.Timers;

namespace Library
{
    /// <summary>
    /// Nuevo modo de juego, se basa en el modo de juego base pero se le suma la cualidad de que va a tener un
    /// tiempo limitado, logrando de esta forma una modalidad de juego mas rapida.
    /// </summary>
    public class TimeTrial : Game
    {
        private Board BoardPlayer1;
        private Board BoardPlayer2;

        //Seteo 3 minutos en milisegundos. 180000
        System.Timers.Timer timerCounter = new System.Timers.Timer(180000);


        public TimeTrial(User player1, User player2, string name) : base(player1, player2, name)
        {
            this.Player1 = player1;
            this.Player2 = player2;
            BoardPlayer1 = new Board(this.Player1);
            BoardPlayer2 = new Board(this.Player2);
        }

        /// <summary>
        /// Comienza el contador para el juego
        /// </summary>
        public void StartTimer()
        {
            timerCounter.Elapsed += timerCounterElapsed;
            timerCounter.AutoReset = false;
            timerCounter.Enabled = true;
            timerCounter.Start();
            //Console.ReadKey();
        }
        /// <summary>
        /// Termina el juego cuando se termine el tiempo
        /// </summary>
        private void timerCounterElapsed(Object source, ElapsedEventArgs e)
        {
            if (OnGoing)
            {
                OnGoing = false;
                Bot.sendTelegramMessage(Player1, "Finalizo La Partida de timeTrial");
                Bot.sendTelegramMessage(Player2, "Finalizo la Partida de timeTrial");
            }
        }
        /// <summary>
        /// Método que comienza le juego
        /// </summary>
        public override void StartGame()
        {
            System.Console.WriteLine("Comienza la batalla naval!!");
            System.Console.WriteLine("TimeTrial!!!");
            System.Console.WriteLine($"{Player1.Name} vs {Player2.Name}");
            Bot.sendTelegramMessage(Player1, "Cuando estes listo, envia /Posicionar para comenzar a posicionar tus barcos");
            Bot.sendTelegramMessage(Player2, "Cuando estes listo, envia /Posicionar para comenzar a posicionar tus barcos");
            OnGoing = false;
            StartTimer();
            OnGoing = true;
        }

        public override User CheckMatch()
        {
            if (!OnGoing)
            {
                if (HitsPlayer1 > HitsPlayer2)
                {
                    return Player1;
                }
                else
                {
                    return Player2;
                }
            }
            else
            {
                return null;
            }
        }
    }
}