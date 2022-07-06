using Telegram.Bot.Types;

/// <summary>
/// Handler que se encarga de posicionar los barcos interactuando con el usuario, este realiza varias validaciones a la hora de recibir mensajes de usuarios.
/// </summary>
namespace Library
{
    public class PositionShipHandler : BaseHandler
    {
        // Se asignan los valores check1, check2 y direction junto al Id del usuario en diccionarios para evitar conflictos
        public Dictionary<long, string> checks1 = new Dictionary<long, string>();

        public Dictionary<long, string> checks2 = new Dictionary<long, string>();

        public Dictionary<long, string> direction = new Dictionary<long, string>();

        public List<string> directions = new List<string>()
        {
            "/arriba", "/abajo", "/izquierda", "/derecha"
        };
        private Dictionary<int, string> shipNames = new Dictionary<int, string> { { 1, "Lancha" }, { 2, "Crucero" }, { 3, "Submarino" }, { 4, "Buque" }, { 5, "Portaaviones" } };

        public PositionShipHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "posicionar", "Posicionar", "/Reintentar" };
            // State = PositionShipState.Start;
        }

        protected override bool CanHandle(Message message)
        {
            Enum state = Administrator.Instance.GetUserState(message.From.Id);

            if (state.Equals(SelectModeState.ReadyToPlay)
            || (state.Equals(PositionShipState.Complete))
            || (state.Equals(PositionShipState.PositionCheck1))
            || (state.Equals(PositionShipState.PositionCheck2))
            || (state.Equals(PositionShipState.Direction)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected override void InternalHandle(Message message, out string response)
        {
            response = string.Empty;
            Board board = Administrator.Instance.GetPlayerBoard(message.From.Id);
            int shipCount = board.shipCount();

            if (shipCount == 5)
            {
                // State = PositionShipState.Complete;
                Administrator.Instance.SetUserState(message.From.Id, PositionShipState.Complete);
            }
            Enum state = Administrator.Instance.GetUserState(message.From.Id);
            switch (state)
            {
                case SelectModeState.ReadyToPlay:
                    response = $"Posiciona el lugar de {shipNames[shipCount + 1]} (A-J)";
                    Administrator.Instance.SetUserState(message.From.Id, PositionShipState.PositionCheck1);
                    break;

                case PositionShipState.PositionCheck1:
                    if (Board.abc.Contains(message.Text.ToUpper()))
                    {
                        checks1[message.From.Id] = message.Text;
                        Administrator.Instance.SetUserState(message.From.Id, PositionShipState.PositionCheck2);
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
                        checks2[message.From.Id] = message.Text;

                        Administrator.Instance.SetUserState(message.From.Id, PositionShipState.Direction);
                        response = $"Posiciona la direccion de {shipNames[shipCount + 1]} (/Arriba, /Abajo, /Derecha, /Izquierda)";
                    }
                    else
                    {
                        response = $"El número ingresado no es correcta.\nPosiciona el lugar de {shipNames[shipCount + 1]} (1-10)";
                    }
                    break;
                case PositionShipState.Direction:
                    if (directions.Contains(message.Text.ToLower()))
                    {
                        direction[message.From.Id] = message.Text.ToLower();

                        AddShipToBoard(checks1[message.From.Id], checks2[message.From.Id], direction[message.From.Id], shipCount + 1, message, out response);
                        //InternalHandle(message, out response);
                    }
                    else
                    {
                        response = $"La direccion ingresada no es correcta.\nPosiciona la direccion de {shipNames[shipCount + 1]} (/Arriba, /Abajo, /Derecha, /Izquierda)";
                    }
                    break;
                case PositionShipState.Complete:

                    Administrator.Instance.SetUserState(message.From.Id, SelectModeState.ReadyToPlay);
                    Game game = Administrator.Instance.GetPlayerGame(message.Chat.Id);
                    if (game.boardPlayer1.shipCount() == 5 && game.boardPlayer2.shipCount() == 5)
                    {
                        Administrator.Instance.SetUserState(game.player1.Id, AttackState.StartAttackPlayer1);
                        Administrator.Instance.SetUserState(game.player2.Id, AttackState.Wait);

                        Bot.sendTelegramMessage(game.player1, "Para comenzar envía /Atacar");
                        Bot.sendTelegramMessage(game.player2, $"El jugador {game.player1.Name} comienza atacando.");
                    }
                    break;
            }
        }

        protected override void InternalCancel()
        {
        }

        private void AddShipToBoard(String check1, String check2, String direction, int shipSize, Message message, out string response)
        {
            response = string.Empty;
            bool overShip, overBoard;
            Board board = Administrator.Instance.GetPlayerBoard(message.From.Id);
            (overBoard, overShip) = board.Positioner(check1, check2, direction, shipNames[shipSize], shipSize);

            if (overBoard == true)
            {
                response = "No se puede posicionar el barco en esa ubicación porque se sale del tablero \n /Reintentar";
                Administrator.Instance.SetUserState(message.From.Id, SelectModeState.ReadyToPlay);
            }
            else if (overShip == true)
            {
                response = "No se puede porque ya hay una nave en esa ubicación. \n /Reintentar";
                Administrator.Instance.SetUserState(message.From.Id, SelectModeState.ReadyToPlay);
            }

            else
            {
                Console.WriteLine($">>>> messageChatId: {message.Chat.Id} messgeFromId: {message.From.Id}");
                Game game = Administrator.Instance.GetPlayerGame(message.Chat.Id);
                User player = game.player1.Id == message.From.Id ? game.player1 : game.player2;
                Administrator.Instance.SetUserState(message.From.Id, SelectModeState.ReadyToPlay);
                if (board.shipCount() == 5)
                {
                    Bot.sendTelegramMessage(player, "La flota esta lista.");
                    InternalHandle(message, out response);

                }
                else if (board.shipCount() < 5)
                {
                    Bot.sendTelegramMessage(player, "La nave esta lista, debe posicionar la siguiente nave");
                    InternalHandle(message, out response);
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
