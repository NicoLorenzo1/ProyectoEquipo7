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
        public PositionShipState State { get; set; }

        public PositionShipHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "posicionar", "Posicionar" };
            State = PositionShipState.Start;
        }

        protected override bool CanHandle(Message message)
        {
            if (State == PositionShipState.End)
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
            response = "No hay mas barcos disponibles para colocar.";


            if (State == PositionShipState.Start)
            {
                response = "Posiciona el lugar de la Lancha (A-J)";
                State = PositionShipState.PositionShips1Check1;
            }

            else if (State == PositionShipState.PositionShips1Check1)
            {
                if (Board.abc.Contains(message.Text.ToUpper()))
                {
                    check1 = message.Text;
                    response = "Posiciona el lugar de la lancha(1-9)";
                    State = PositionShipState.PositionShips1Check2;
                }
                else
                {
                    response = "Debes ingresar una letra valida";
                }
            }
            else if (State == PositionShipState.PositionShips1Check2)
            {
                if (Board.num.Contains(message.Text))
                {
                    check2 = message.Text;
                    response = "Elige una direccion para lancha (Izquierda - Derecha - Arriba - Abajo)";
                    State = PositionShipState.direction1;
                }
                else
                {
                    response = "debes ingresar un numero valido";
                }
            }
            else if (State == PositionShipState.direction1)
            {
                if (directions.Contains(message.Text.ToLower()))
                {
                    direction1 = "3";

                    foreach (var game in Administrator.Instance.currentGame)
                    {
                        bool overBoard;
                        bool overShip;

                        if (game.player1.IdChat == message.Chat.Id)
                        {
                            (overBoard, overShip) = game.boardPlayer2.Positioner(check1, check2, direction1, "Lancha", 1);

                            if (overBoard == true)
                            {
                                response = "No se puede posicionar el barco en esa ubicación porque se sale del tablero";
                                State = PositionShipState.Start;
                            }
                            else if (overShip == true)
                            {
                                response = "No se puede porque ya hay un barco en esa ubicación";
                                State = PositionShipState.Start;
                            }
                            else
                            {
                                game.boardPlayer1.Positioner(check1, check2, direction1, "Lancha", 1);
                                State = PositionShipState.StartCrucero;
                            }
                        }
                        else
                        {
                            //overBoard = game.boardPlayer2.Positioner(check1, check2, direction1, "Lancha", 1).Item1;
                            // overShip = game.boardPlayer2.Positioner(check1, check2, direction1, "Lancha", 1).Item2;
                            (overBoard, overShip) = game.boardPlayer2.Positioner(check1, check2, direction1, "Lancha", 1);

                            if (overBoard == true)
                            {
                                response = "No se puede posicionar el barco en esa ubicación porque se sale del tablero";
                                State = PositionShipState.Start;
                            }
                            else if (overShip == true)
                            {
                                response = "No se puede porque ya hay un barco en esa ubicación";
                                State = PositionShipState.Start;
                            }
                            else
                            {
                                game.boardPlayer2.Positioner(check1, check2, direction1, "Lancha", 1);
                                State = PositionShipState.StartCrucero;
                            }
                        }
                    }

                    //Posicionamiento del crucero
                    if (State == PositionShipState.StartCrucero)
                    {
                        response = "Posiciona el lugar de Crucero (A-J)";
                        State = PositionShipState.PositionShipsCruceroCheck1;
                    }
                    else if (State == PositionShipState.PositionShipsCruceroCheck1)
                    {
                        check1 = message.Text;
                        response = "Posiciona el lugar de la Crucero(1-9)";
                        State = PositionShipState.PositionShipsCruceroCheck2;
                    }
                    else if (State == PositionShipState.PositionShipsCruceroCheck2)
                    {
                        check2 = message.Text;
                        response = "Elige una direccion para crucero";
                        State = PositionShipState.directionCrucero;
                    }
                    else if (State == PositionShipState.directionCrucero)
                    {
                        foreach (var game in Administrator.Instance.currentGame)
                        {
                            bool overBoard;
                            bool overShip;

                            if (game.player1.IdChat == message.Chat.Id)
                            {
                                (overBoard, overShip) = game.boardPlayer2.Positioner(check1, check2, direction1, "Lancha", 1);

                                if (overBoard)
                                {
                                    response = "No se puede posicionar el barco en esa ubicación porque se sale del tablero";
                                    State = PositionShipState.StartCrucero;

                                }
                                else if (overShip)
                                {
                                    response = "No se puede porque ya hay un barco en esa ubicación";
                                    State = PositionShipState.StartCrucero;
                                }
                                else
                                {
                                    game.boardPlayer1.Positioner(check1, check2, direction1, "Crucero", 3);
                                    State = PositionShipState.StartSubmarino;
                                }
                            }
                            else
                            {
                                (overBoard, overShip) = game.boardPlayer2.Positioner(check1, check2, direction1, "Lancha", 1);

                                if (overBoard)
                                {
                                    response = "No se puede posicionar el barco en esa ubicación porque se sale del tablero";
                                    State = PositionShipState.StartCrucero;
                                }
                                else if (overShip)
                                {
                                    response = "No se puede porque ya hay un barco en esa ubicación";
                                    State = PositionShipState.StartCrucero;
                                }
                                else
                                {
                                    game.boardPlayer2.Positioner(check1, check2, direction1, "Crucero", 2);
                                    State = PositionShipState.StartSubmarino;
                                }
                            }
                        }

                        //Posicionamiento del Submarino
                        if (State == PositionShipState.StartSubmarino)
                        {
                            response = "Posiciona el lugar de Submarino (A-J)";
                            State = PositionShipState.PositionShipsSubmarinoCheck1;
                        }

                        else if (State == PositionShipState.PositionShipsSubmarinoCheck1)
                        {
                            check1 = message.Text;
                            response = "Posiciona el lugar de la Submarino(1-9)";
                            State = PositionShipState.PositionShipsSubmarinoCheck2;
                        }
                        else if (State == PositionShipState.PositionShipsSubmarinoCheck2)
                        {
                            check2 = message.Text;
                            response = "Elige una direccion para Submarino";
                            State = PositionShipState.directionSubmarino;
                        }
                        else if (State == PositionShipState.directionSubmarino)
                        {
                            foreach (var game in Administrator.Instance.currentGame)
                            {
                                bool overBoard;
                                bool overShip;
                                if (game.player1.IdChat == message.Chat.Id)
                                {
                                    (overBoard, overShip) = game.boardPlayer2.Positioner(check1, check2, direction1, "Lancha", 1);

                                    if (overBoard)
                                    {
                                        response = "No se puede posicionar el barco en esa ubicación porque se sale del tablero";
                                        State = PositionShipState.StartSubmarino;
                                    }
                                    else if (overShip)
                                    {
                                        response = "No se puede porque ya hay un barco en esa ubicación";
                                        State = PositionShipState.StartSubmarino;

                                    }
                                    else
                                    {
                                        game.boardPlayer1.Positioner(check1, check2, direction1, "Submarino", 3);
                                        State = PositionShipState.StartBuque;
                                    }
                                }
                                else
                                {
                                    (overBoard, overShip) = game.boardPlayer2.Positioner(check1, check2, direction1, "Lancha", 1);

                                    if (overBoard)
                                    {
                                        response = "No se puede posicionar el barco en esa ubicación porque se sale del tablero";
                                        State = PositionShipState.StartSubmarino;
                                    }
                                    else if (overShip)
                                    {
                                        response = "No se puede porque ya hay un barco en esa ubicación";
                                        State = PositionShipState.StartSubmarino;

                                    }
                                    else
                                    {
                                        State = PositionShipState.StartBuque;
                                        game.boardPlayer2.Positioner(check1, check2, direction1, "Submarino", 3);
                                    }
                                }
                            }
                        }

                        //Posicionamiento del Buque

                        if (State == PositionShipState.StartBuque)
                        {
                            response = "Posiciona el lugar de Buque (A-J)";
                            State = PositionShipState.PositionShipsBuqueCheck1;
                        }
                        else if (State == PositionShipState.PositionShipsBuqueCheck1)
                        {
                            check1 = message.Text;
                            response = "Posiciona el lugar de la Buque(1-9)";
                            State = PositionShipState.PositionShipsBuqueCheck2;
                        }
                        else if (State == PositionShipState.PositionShipsBuqueCheck2)
                        {
                            check2 = message.Text;
                            response = "Elige una direccion para Buque";
                            State = PositionShipState.directionBuque;
                        }
                        else if (State == PositionShipState.directionBuque)
                        {
                            foreach (var game in Administrator.Instance.currentGame)
                            {
                                bool overBoard;
                                bool overShip;
                                if (game.player1.IdChat == message.Chat.Id)
                                {
                                    (overBoard, overShip) = game.boardPlayer2.Positioner(check1, check2, direction1, "Lancha", 1);

                                    if (overBoard)
                                    {
                                        response = "No se puede posicionar el barco en esa ubicación porque se sale del tablero";
                                        State = PositionShipState.StartBuque;

                                    }
                                    else if (overShip)
                                    {
                                        response = "No se puede porque ya hay un barco en esa ubicación";
                                        State = PositionShipState.StartBuque;

                                    }
                                    else
                                    {
                                        game.boardPlayer1.Positioner(check1, check2, direction1, "Buque", 4);
                                        State = PositionShipState.StartPortaaviones;
                                    }
                                }
                                else
                                {
                                    (overBoard, overShip) = game.boardPlayer2.Positioner(check1, check2, direction1, "Lancha", 1);

                                    if (overBoard)
                                    {
                                        response = "No se puede posicionar el barco en esa ubicación porque se sale del tablero";
                                        State = PositionShipState.StartBuque;
                                    }
                                    else if (overShip)
                                    {
                                        response = "No se puede porque ya hay un barco en esa ubicación";
                                        State = PositionShipState.StartBuque;
                                    }
                                    else
                                    {
                                        State = PositionShipState.StartPortaaviones;
                                        game.boardPlayer2.Positioner(check1, check2, direction1, "Buque", 4);
                                    }
                                }
                            }
                        }

                        //Posicionamiento del Portaaviones
                        if (State == PositionShipState.StartPortaaviones)
                        {
                            response = "Posiciona el lugar de Portaaviones (A-J)";
                            State = PositionShipState.PositionShipsPortaavionesCheck1;
                        }
                        else if (State == PositionShipState.PositionShipsPortaavionesCheck1)
                        {
                            check1 = message.Text;
                            response = "Posiciona el lugar de la Portaaviones (1-9)";
                            State = PositionShipState.PositionShipsPortaavionesCheck1;
                        }
                        else if (State == PositionShipState.PositionShipsPortaavionesCheck2)
                        {
                            check2 = message.Text;
                            response = "Elige una direccion para Portaaviones";
                            State = PositionShipState.directionPortaaviones;
                        }
                        else if (State == PositionShipState.directionPortaaviones)
                        {
                            foreach (var game in Administrator.Instance.currentGame)
                            {
                                bool overBoard;
                                bool overShip;
                                if (game.player1.IdChat == message.Chat.Id)
                                {
                                    (overBoard, overShip) = game.boardPlayer2.Positioner(check1, check2, direction1, "Lancha", 1);

                                    if (overBoard)
                                    {
                                        response = "No se puede posicionar el barco en esa ubicación porque se sale del tablero";
                                        State = PositionShipState.StartPortaaviones;

                                    }
                                    else if (overShip)
                                    {
                                        response = "No se puede porque ya hay un barco en esa ubicación";
                                        State = PositionShipState.StartPortaaviones;
                                    }
                                    else
                                    {
                                        game.boardPlayer1.Positioner(check1, check2, direction1, "Portaaviones", 5);
                                        State = PositionShipState.End;
                                    }
                                }
                                else
                                {
                                    (overBoard, overShip) = game.boardPlayer2.Positioner(check1, check2, direction1, "Lancha", 1);

                                    if (overBoard)
                                    {
                                        response = "No se puede posicionar el barco en esa ubicación porque se sale del tablero";
                                        State = PositionShipState.StartPortaaviones;
                                    }
                                    else if (overShip)
                                    {
                                        response = "No se puede porque ya hay un barco en esa ubicación";
                                        State = PositionShipState.StartPortaaviones;
                                    }
                                    else
                                    {
                                        game.boardPlayer2.Positioner(check1, check2, direction1, "Portaaviones", 5);
                                        State = PositionShipState.End;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        protected override void InternalCancel()
        {
            this.State = PositionShipState.End;
        }

        public enum PositionShipState
        {
            Start,
            InPosition,
            PositionShips1Check1,
            PositionShips1Check2,
            direction1,

            StartCrucero,
            PositionShipsCruceroCheck1,
            PositionShipsCruceroCheck2,
            directionCrucero,

            StartSubmarino,
            PositionShipsSubmarinoCheck1,
            PositionShipsSubmarinoCheck2,
            directionSubmarino,

            StartBuque,
            PositionShipsBuqueCheck1,
            PositionShipsBuqueCheck2,
            directionBuque,


            StartPortaaviones,
            PositionShipsPortaavionesCheck1,
            PositionShipsPortaavionesCheck2,
            directionPortaaviones,

            End

        }
    }
}

