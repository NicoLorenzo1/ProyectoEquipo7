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
            this.Keywords = new string[] { "Tablero", "tablero" };
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
            response = string.Empty;

            if (State == PrintBoardState.Start)
            {
                response = "¿Que tablero deseas imprimir?\n -Mi tablero \n Tablero enemigo";
                State = PrintBoardState.Print;
            }
            else if (State == PrintBoardState.Print)
            {
                if (message.Text.ToLower() == "mi tablero")
                {
                    foreach (var game in Administrator.Instance.currentGame)
                    {
                        if (game.player1.IdChat == message.Chat.Id)
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
                }
                else
                {
                    foreach (var game in Administrator.Instance.currentGame)
                    {
                        if (game.player1.IdChat == message.Chat.Id)
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

                }
            }
        }



        public enum PrintBoardState
        {
            Start,
            Print,

        }
    }
}