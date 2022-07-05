using Telegram.Bot.Types;

namespace Library
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "tablero".
    /// </summary>
    public class PrintBoardHandler : BaseHandler
    {
        public PrintBoardState State { get; set; }

        /// <summary>
        /// Esta clase procesa el mensaje "tablero".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public PrintBoardHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "Tablero", "tablero", "/MiTablero", "/TableroEnemigo" };
            State = PrintBoardState.Start;
        }

        /// <summary>
        /// Procesa el mensaje "tablero" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override void InternalHandle(Message message, out string response)
        {
            response = "Imprimir Tablero";

            if (State == PrintBoardState.Start)
            {
                response = "¿Que tablero deseas imprimir?\n /MiTablero \n /TableroEnemigo";
                State = PrintBoardState.Print;
            }
            else if (State == PrintBoardState.Print)
            {
                Game game = Administrator.Instance.GetPlayerGame(message.From.Id);

                if (message.Text.ToLower() == "/MiTablero")
                {
                    if (game.player1.Id == message.From.Id)
                    {
                        string finalTable = game.boardPlayer1.PrintBoard(game.boardPlayer1.shipPos, game.boardPlayer2.shots, "MyBoard");
                        response = finalTable;
                    }
                    else
                    {
                        string finalTable = game.boardPlayer2.PrintBoard(game.boardPlayer2.shipPos, game.boardPlayer1.shots, "MyBoard");
                        response = finalTable;
                    }
                }
                else
                {
                    if (game.player1.Id == message.From.Id)
                    {
                        string finalTable = game.boardPlayer1.PrintBoard(game.boardPlayer2.shipPos, game.boardPlayer1.shots, "EnemyBoard");
                        response = finalTable;
                    }
                    else
                    {
                        string finalTable = game.boardPlayer2.PrintBoard(game.boardPlayer1.shipPos, game.boardPlayer2.shots, "EnemyBoard");
                        response = finalTable;
                    }
                }
                State = PrintBoardState.Start;

            }
        }

        public enum PrintBoardState
        {
            Start,
            Print,
        }
    }
}