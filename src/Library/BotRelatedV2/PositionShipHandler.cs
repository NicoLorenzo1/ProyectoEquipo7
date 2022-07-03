using Telegram.Bot.Types;

namespace Library
{
    public class PositionShipHandler : BaseHandler
    {
        public string check1;
        public string check2;
        public string direction1;
        public List<string> directions = new List<string>()
        {
            "arriba", "abajo", "izquierda", "derecha"
        };
        private Dictionary<int, string> shipNames = new Dictionary<int, string> { { 1, "Lancha" }, { 2, "Crucero" }, { 3, "Submarino" }, { 4, "Buque" }, { 5, "Portaaviones" } };
        public PositionShipState State { get; set; }

        public PositionShipHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "posicionar", "Posicionar", "/Reintentar" };
            State = PositionShipState.Start;
        }

        protected override bool CanHandle(Message message)
        {
            if (State == PositionShipState.Start)
            {
                return base.CanHandle(message);
            }
            else
            {
                return true;
            }
        }

        protected override void InternalHandle(Message message, out string response)
        {
            response = string.Empty;
            Board board = Administrator.Instance.GetPlayerBoard(message.From.Id);
            int shipCount = board.shipCount();
            if (shipCount == 5)
            {
                State = PositionShipState.Complete;
            }
            switch (State)
            {
                case PositionShipState.Start:
                    response = $"Posiciona el lugar de {shipNames[shipCount + 1]} (A-J)";
                    State = PositionShipState.PositionCheck1;
                    break;

                case PositionShipState.PositionCheck1:
                    if (Board.abc.Contains(message.Text.ToUpper()))
                    {
                        check1 = message.Text;
                        State = PositionShipState.PositionCheck2;
                        response = $"Posiciona el lugar de {shipNames[shipCount + 1]} (1-10)";
                    }
                    else
                    {
                        response = $"La letra ingresada no es correcta.\nPosiciona el lugar de {shipNames[shipCount + 1]} (A-J)";
                    }
                    break;

                case PositionShipState.PositionCheck2:
                    if (Board.num.Contains(message.Text.ToUpper()))
                    {
                        check2 = message.Text;
                        State = PositionShipState.Direction;
                        response = $"Posiciona la direccion de {shipNames[shipCount + 1]} (Arriba, Abajo, Derecha, Izquierda)";
                    }
                    else
                    {
                        response = $"El número ingresado no es correcta.\nPosiciona el lugar de {shipNames[shipCount + 1]} (1-10)";
                    }
                    break;
                case PositionShipState.Direction:
                    if (directions.Contains(message.Text.ToLower()))
                    {
                        direction1 = message.Text.ToLower();
                        AddShipToBoard(check1, check2, direction1, shipCount + 1, message, out response);
                        //InternalHandle(message, out response);
                    }
                    else
                    {
                        response = $"La direccion ingresada no es correcta.\nPosiciona la direccion de {shipNames[shipCount + 1]} (Arriba, Abajo, Derecha, Izquierda)";
                    }
                    break;
                case PositionShipState.Complete:
                    State = PositionShipState.Start;
                    Game game = Administrator.Instance.GetPlayerGame(message.Chat.Id);
                    if (game.boardPlayer1.shipCount() == 5 && game.boardPlayer2.shipCount() == 5)
                    {
                        Bot.sendTelegramMessage(game.player1, "Para comenzar envía /Atacar");
                        Bot.sendTelegramMessage(game.player2, $"El jugador {game.player1.Name} comienza atacando.");
                    }
                    break;
            }
        }

        protected override void InternalCancel()
        {
            this.State = PositionShipState.End;
        }

        private void AddShipToBoard(String check1, String check2, String direction, int shipSize, Message message, out string response)
        {
            response = string.Empty;
            bool overShip, overBoard;
            Board board = Administrator.Instance.GetPlayerBoard(message.From.Id);
            (overBoard, overShip) = board.Positioner(check1, check2, direction1, shipNames[shipSize], shipSize);

            if (overBoard == true)
            {
                response = "No se puede posicionar el barco en esa ubicación porque se sale del tablero \n /Reintentar";
                State = PositionShipState.Start;
            }
            else if (overShip == true)
            {
                response = "No se puede porque ya hay una nave en esa ubicación. \n /Reintentar";
                State = PositionShipState.Start;
            }

            else
            {
                Game game = Administrator.Instance.GetPlayerGame(message.Chat.Id);
                User player = game.player1.Id == message.From.Id ? game.player1 : game.player2;
                State = PositionShipState.Start;
                if (board.shipCount() == 5)
                {
                    //Bot.sendTelegramMessage(player, "La nave esta lista.");
                    Bot.sendTelegramMessage(player, "La flota esta lista.");
                }
                else if (board.shipCount() < 5)
                {
                    Bot.sendTelegramMessage(player, "La nave esta lista, debe posicionar la siguiente nave");
                    InternalHandle(message, out response);
                }

                if (game.boardPlayer1.shipCount() == 5 && game.boardPlayer2.shipCount() == 5)
                {
                    Bot.sendTelegramMessage(game.player1, "Para Comenzar envía /Atacar");
                    Bot.sendTelegramMessage(game.player2, $"El jugador {game.player1.Name} comienza atacando.");
                }

            }
        }

        public enum PositionShipState
        {
            Start,
            PositionCheck1,
            PositionCheck2,
            Direction,
            Complete,
            End

        }
    }
}
