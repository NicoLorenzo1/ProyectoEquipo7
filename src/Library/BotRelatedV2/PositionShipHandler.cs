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
            this.Keywords = new string[] { "prueba" };
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
                    direction1 = message.Text;
                    foreach (var game in Administrator.Instance.currentGame)
                    {
                        if (game.player1.IdChat == message.Chat.Id)
                        {
                            game.boardPlayer1.Positioner(check1, check2, direction1, "Lancha", 1);
                        }
                        else
                        {
                            game.boardPlayer2.Positioner(check1, check2, direction1, "Lancha", 1);
                            response = $"{check1}, {check2}, {direction1}";
                        }
                    }
                    State = PositionShipState.StartCrucero;
                }
                else
                {
                    response = "Debes ingresar una dirección valida";
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
                //metodo(posicion de lancha)
                response = "Posiciona el lugar de la Crucero(1-9)";
                State = PositionShipState.PositionShipsCruceroCheck2;
            }
            else if (State == PositionShipState.PositionShipsCruceroCheck2)
            {
                check2 = message.Text;
                //metodo(posicion de lancha)
                response = "Elige una direccion para crucero";
                State = PositionShipState.directionCrucero;
            }
            else if (State == PositionShipState.directionCrucero)
            {
                foreach (var game in Administrator.Instance.currentGame)
                {
                    if (game.player1.IdChat == message.Chat.Id)
                    {
                        game.boardPlayer1.Positioner(check1, check2, direction1, "Crucero", 1);
                    }
                    else
                    {
                        game.boardPlayer2.Positioner(check1, check2, direction1, "Crucero", 1);
                        response = $"{check1}, {check2}, {direction1}";

                    }
                }
                State = PositionShipState.StartSubmarino;
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
                    if (game.player1.IdChat == message.Chat.Id)
                    {
                        game.boardPlayer1.Positioner(check1, check2, direction1, "Submarino", 1);
                    }
                    else
                    {
                        game.boardPlayer2.Positioner(check1, check2, direction1, "Submarino", 1);
                        response = $"{check1}, {check2}, {direction1}";

                    }
                }
                State = PositionShipState.StartBuque;
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
                State = PositionShipState.PositionShipsBuqueCheck1;
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
                    if (game.player1.IdChat == message.Chat.Id)
                    {
                        game.boardPlayer1.Positioner(check1, check2, direction1, "Buque", 1);
                    }
                    else
                    {
                        game.boardPlayer2.Positioner(check1, check2, direction1, "Buque", 1);
                        response = $"{check1}, {check2}, {direction1}";

                    }
                }
                State = PositionShipState.StartPortaaviones;
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
                    if (game.player1.IdChat == message.Chat.Id)
                    {
                        game.boardPlayer1.Positioner(check1, check2, direction1, "Portaaviones", 1);
                    }
                    else
                    {
                        game.boardPlayer2.Positioner(check1, check2, direction1, "Portaaviones", 1);
                        response = $"{check1}, {check2}, {direction1}";

                    }
                }
                State = PositionShipState.End;
            }
        }




        /*

                    int s = 1;
                    // while (s < 5)
                    // {
                    Ship actualShip;
                    switch (State)
                    {

                        case PositionShipState.Start:
                            Console.WriteLine("start");

                            actualShip = new Ship(1);
                            State = PositionShipState.PositionShips1Check1;
                            response = $"Ingrese la posición inicial de {actualShip.Shipname} \n Ingrese la cordenada 1(A - J)";
                            //Console.WriteLine($"Ingrese la posición inicial de {actualShip.Shipname} \n Ingrese la cordenada 1(A - J)");


                            break;

                        case PositionShipState.PositionShips1Check1:

                            if (Board.abc.Contains(message.Text.ToUpper()))
                            {
                                check2 = message.Text;
                                State = PositionShipState.PositionShips1Check2;
                                response = $"Ingrese la cordenada 2(1-10)";
                            }
                            else
                            {
                                response = "Debes ingresar una coordenada valida";
                            }
                            break;

                        case PositionShipState.PositionShips1Check2:
                            if (Board.num.Contains(message.Text.ToUpper()))
                            {
                                check2 = message.Text;
                                State = PositionShipState.direction1;
                                response = $"Ingrese la direccion('Izquierda', 'Derecha', 'Arriba', 'Abajo')";

                            }
                            else
                            {
                                response = "Debes ingresar una direccion valida";
                            }
                            break;

                        case PositionShipState.direction1:

                            if (directions.Contains(message.Text.ToLower()))
                            {
                                direction1 = message.Text;
                                State = PositionShipState.StartCrucero;
                                response = "Barco creado correctamente";
                            }
                            else
                            {
                                response = "Debes ingresar una direccion valida";
                            }
                            break;

                        //Crucero
                        case PositionShipState.StartCrucero:
                            actualShip = new Ship(2);
                            State = PositionShipState.PositionShipsCruceroCheck1;
                            response = $"Ingrese la posición inicial de {actualShip.Shipname} \n Ingrese la cordenada 1(A - J)";
                            break;

                        case PositionShipState.PositionShipsCruceroCheck1:

                            if (Board.abc.Contains(message.Text.ToUpper()))
                            {
                                check2 = message.Text;
                                State = PositionShipState.PositionShipsCruceroCheck2;
                                response = $"Ingrese la cordenada 2(1-10)";
                            }
                            else
                            {
                                response = "Debes ingresar una coordenada valida";
                            }
                            break;

                        case PositionShipState.PositionShipsCruceroCheck2:
                            if (Board.num.Contains(message.Text.ToUpper()))
                            {
                                check2 = message.Text;
                                State = PositionShipState.directionCrucero;
                                response = $"Ingrese la direccion('Izquierda', 'Derecha', 'Arriba', 'Abajo')";

                            }
                            else
                            {
                                response = "Debes ingresar una direccion valida";
                            }
                            break;

                        case PositionShipState.directionCrucero:

                            if (directions.Contains(message.Text.ToLower()))
                            {
                                direction1 = message.Text;
                                State = PositionShipState.StartSubmarino;
                                response = "Nave creada correctamente";
                            }
                            else
                            {
                                response = "Debes ingresar una direccion valida";
                            }
                            break;
                        //Submarino
                        case PositionShipState.StartSubmarino:
                            actualShip = new Ship(3);
                            State = PositionShipState.PositionShipsSubmarinoCheck1;
                            response = $"Ingrese la posición inicial de {actualShip.Shipname} \n Ingrese la cordenada 1(A - J)";
                            break;

                        case PositionShipState.PositionShipsSubmarinoCheck1:

                            if (Board.abc.Contains(message.Text.ToUpper()))
                            {
                                check2 = message.Text;
                                State = PositionShipState.PositionShipsSubmarinoCheck2;
                                response = $"Ingrese la cordenada 2(1-10)";
                            }
                            else
                            {
                                response = "Debes ingresar una coordenada valida";
                            }
                            break;

                        case PositionShipState.PositionShipsSubmarinoCheck2:
                            if (Board.num.Contains(message.Text.ToUpper()))
                            {
                                check2 = message.Text;
                                State = PositionShipState.directionSubmarino;
                                response = $"Ingrese la direccion('Izquierda', 'Derecha', 'Arriba', 'Abajo')";
                            }
                            else
                            {
                                response = "Debes ingresar una direccion valida";
                            }
                            break;

                        case PositionShipState.directionSubmarino:

                            if (directions.Contains(message.Text.ToLower()))
                            {
                                direction1 = message.Text;
                                State = PositionShipState.StartBuque;
                                response = "Nave creada correctamente";
                            }
                            else
                            {
                                response = "Debes ingresar una direccion valida";
                            }
                            break;

                        //Buque
                        case PositionShipState.StartBuque:
                            actualShip = new Ship(4);
                            State = PositionShipState.PositionShipsBuqueCheck1;
                            response = $"Ingrese la posición inicial de {actualShip.Shipname} \n Ingrese la cordenada 1(A - J)";
                            break;

                        case PositionShipState.PositionShipsBuqueCheck1:

                            if (Board.abc.Contains(message.Text.ToUpper()))
                            {
                                check2 = message.Text;
                                State = PositionShipState.PositionShipsBuqueCheck2;
                                response = $"Ingrese la cordenada 2(1-10)";
                            }
                            else
                            {
                                response = "Debes ingresar una coordenada valida";
                            }
                            break;

                        case PositionShipState.PositionShipsBuqueCheck2:
                            if (Board.num.Contains(message.Text.ToUpper()))
                            {
                                check2 = message.Text;
                                State = PositionShipState.directionBuque;
                                response = $"Ingrese la direccion('Izquierda', 'Derecha', 'Arriba', 'Abajo')";
                            }
                            else
                            {
                                response = "Debes ingresar una direccion valida";
                            }
                            break;

                        case PositionShipState.directionBuque:

                            if (directions.Contains(message.Text.ToLower()))
                            {
                                direction1 = message.Text;
                                State = PositionShipState.StartPortaaviones;
                                response = "Nave creada correctamente";
                            }
                            else
                            {
                                response = "Debes ingresar una direccion valida";
                            }
                            break;

                        //Portaaviones
                        case PositionShipState.StartPortaaviones:
                            actualShip = new Ship(5);
                            State = PositionShipState.PositionShipsPortaavionesCheck1;
                            response = $"Ingrese la posición inicial de {actualShip.Shipname} \n Ingrese la cordenada 1(A - J)";
                            break;

                        case PositionShipState.PositionShipsPortaavionesCheck1:

                            if (Board.abc.Contains(message.Text.ToUpper()))
                            {
                                check2 = message.Text;
                                State = PositionShipState.PositionShipsPortaavionesCheck2;
                                response = $"Ingrese la cordenada 2(1-10)";
                            }
                            else
                            {
                                response = "Debes ingresar una coordenada valida";
                            }
                            break;

                        case PositionShipState.PositionShipsPortaavionesCheck2:
                            if (Board.num.Contains(message.Text.ToUpper()))
                            {
                                check2 = message.Text;
                                State = PositionShipState.directionPortaaviones;
                                response = $"Ingrese la direccion('Izquierda', 'Derecha', 'Arriba', 'Abajo')";
                            }
                            else
                            {
                                response = "Debes ingresar una direccion valida";
                            }
                            break;

                        case PositionShipState.directionPortaaviones:

                            if (directions.Contains(message.Text.ToLower()))
                            {
                                direction1 = message.Text;
                                State = PositionShipState.End;
                                response = "Nave creada correctamente";
                            }
                            else
                            {
                                response = "Debes ingresar una direccion valida";
                            }
                            break;

                    }
                }
                */










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

