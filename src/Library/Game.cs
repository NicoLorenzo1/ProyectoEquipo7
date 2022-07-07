using System;

namespace Library
{
    public class Game
    {
        protected User Player1;
        protected User Player2;
        private Board BoardPlayer1;
        private Board BoardPlayer2;
        private string Mode;
        protected bool OnGoing;
        private bool Hit;
        protected int HitsPlayer1;
        protected int HitsPlayer2;
        //<summary>
        //Por Expert la clase Game es la encargada de conocer la cantidad de veces que se le
        //pegó a un barco
        //</summary>
        private int Lancha1Health = 1;
        private int Crucero1Health = 2;
        private int Submarino1Health = 3;
        private int Buque1Health = 4;
        private int Portaaviones1Health = 5;
        private int Lancha2Health = 1;
        private int Crucero2Health = 2;
        private int Submarino2Health = 3;
        private int Buque2Health = 4;
        private int Portaaviones2Health = 5;
        public int watherShots = 0;
        public int shipShots = 0;


        /// <summary>
        /// Por OCP todos los modos de juego heredan de la clase Game, que posee la lógica base del juego
        /// y es abierta a extensiones, pero no recibe ningun cambio
        /// </summary>
        /// <param name="player1">Primer User que proviene de la lista UsersToPlay para el modo de juego seleccionado</param>
        /// <param name="player2">Segundo User que proviene de la lista UsersToPlay para el modo de juego seleccionado</param>
        /// <param name="name"></param>
        /// <returns></returns>
        public Game(User player1, User player2, string name)
        {
            this.Player1 = player1;
            this.Player2 = player2;
            BoardPlayer1 = new Board(this.Player1);
            BoardPlayer2 = new Board(this.Player2);
            this.Mode = name;
            Administrator.Instance.currentGame.Add(this);
        }

        /// <summary>
        /// StartGame inicializa la lógica central del juego, en la cual le solicita a ambos usuarios que posicionen sus barcos y luego
        /// comenzará la ronda de ataques por turnos.
        /// </summary>
        public virtual void StartGame()
        {
            //System.Console.WriteLine("Comienza la batalla naval!!");
            Bot.sendTelegramMessage(Player1, "Comienza la batalla naval!!");
            Bot.sendTelegramMessage(Player2, "Comienza la batalla naval!!");
            System.Console.WriteLine("Comienza la batalla naval!!");
            System.Console.WriteLine("Modo classic");

            Bot.sendTelegramMessage(Player1, $"{Player1.Name} vs {Player2.Name}");
            Bot.sendTelegramMessage(Player2, $"{Player1.Name} vs {Player2.Name}");

            System.Console.WriteLine($"{Player1.Name} vs {Player2.Name}");
            System.Console.WriteLine();

            Bot.sendTelegramMessage(Player1, "Cuando estes listo, envia /Posicionar para comenzar a posicionar tus barcos");
            Bot.sendTelegramMessage(Player2, "Cuando estes listo, envia /Posicionar para comenzar a posicionar tus barcos");

            System.Console.WriteLine($"Posicionamiento de barcos de {Player1.Name}");
            BoardPlayer1.PositionShips();
            System.Console.WriteLine($"Posicionamiento de barcos de {Player2.Name}");
            BoardPlayer2.PositionShips();

            User recentAttacker = this.Player2;

            OnGoing = true && !Administrator.Instance.BotEnabled; // Para evitar que al jugar en Telegram se ejecuten los Console.ReadLine
            while (OnGoing)
            {
                if (recentAttacker == this.Player1)
                {
                    System.Console.WriteLine();
                    System.Console.WriteLine($"Ataca {Player2.Name}:");
                    Console.WriteLine("A donde quiere atacar?");
                    Console.Write("Escriba la primer coordenada(A-J): ");
                    string coord1 = Console.ReadLine();
                    Console.Write("Escriba la segunda coordenada(1-10): ");
                    string coord2 = Console.ReadLine();
                    this.Attack(coord1, coord2, this.Player2/*, this.BoardPlayer2, this.Player1, this.BoardPlayer1*/);
                    System.Console.WriteLine();
                    this.BoardPlayer2.PrintBoard(BoardPlayer1.shipPos, BoardPlayer2.shots, "EnemyBoard");
                    ShowBoard(this.Player2, BoardPlayer1, BoardPlayer2);
                    recentAttacker = Player2;
                }
                else
                {
                    System.Console.WriteLine();
                    System.Console.WriteLine($"Ataca {Player1.Name}:");
                    Console.WriteLine("A donde quiere atacar?");
                    Console.Write("Escriba la primer coordenada(A-J): ");
                    string coord1 = Console.ReadLine();
                    Console.Write("Escriba la segunda coordenada(1-10): ");
                    string coord2 = Console.ReadLine();
                    this.Attack(coord1, coord2, this.Player1/*, this.BoardPlayer1, this.Player2, this.BoardPlayer2*/);
                    System.Console.WriteLine();
                    this.BoardPlayer1.PrintBoard(BoardPlayer2.shipPos, BoardPlayer1.shots, "EnemyBoard");
                    ShowBoard(this.Player1, BoardPlayer1, BoardPlayer2);
                    recentAttacker = Player1;
                }
                if (HitsPlayer1 == 15 || HitsPlayer2 == 15)
                {
                    EndGame();
                    if (HitsPlayer2 == 15)
                    {
                        Player1.statistics.ModifyStatics(Player1, false);
                        Player2.statistics.ModifyStatics(Player2, true);
                        System.Console.WriteLine();
                        Console.WriteLine($"Ha ganado {Player2.Name}!!");
                    }
                    if (HitsPlayer1 == 15)
                    {
                        Player1.statistics.ModifyStatics(Player1, true);
                        Player2.statistics.ModifyStatics(Player1, false);
                        System.Console.WriteLine();
                        Console.WriteLine($"Ha ganado {Player1.Name}!!");
                    }
                }
            }
        }

        /// <summary>
        /// Por Expert, al Game tener la responsabilidad de conocer toda la lógica del juego,
        /// es el encargado de conocer que ataques se realizan en cada momento
        /// </summary>
        /// <param name="coord1">Primer valor de la coordenada de ataque</param>
        /// <param name="coord2">Segundo valor de la coordenada de ataque</param>
        /// <param name="attacker">Jugador que realiza el ataque</param>
        /// <returns>Devuelve el resultado del ataque</returns>
        public virtual string Attack(string coord1, string coord2, User attacker)
        {
            string result = "";
            Board attackerBoard, defenderBoard;
            User defender;

            if (attacker == this.Player1)
            {
                attacker = Player1;
                defender = Player2;
                attackerBoard = BoardPlayer1;
                defenderBoard = BoardPlayer2;
            }
            else
            {
                attacker = Player2;
                defender = Player1;
                attackerBoard = BoardPlayer2;
                defenderBoard = BoardPlayer1;
            }
            bool outOfBoard = CoordCheck(coord1, coord2);
            bool alreadyShot = ShotHistory(coord1, coord2, attackerBoard);
            if (outOfBoard == true || alreadyShot == true)
            {
                result = "reintentar";
                System.Console.WriteLine("Perdiste el turno");
            }
            else
            {
                (bool hit, string currentShipName) = defenderBoard.CheckShip(coord1, coord2, defenderBoard.shipPos);
                if (hit)
                {
                    (bool sink, bool wreck) = ShipMessage(currentShipName, attacker);
                    HitsPlayer1 += 1;
                    result = sink ? "Hundido" : "Tocado";
                    shipShots = +1;
                }
                else
                {
                    Console.WriteLine("Agua");
                    result = "Agua";
                    watherShots = +1;
                }
                attackerBoard.shots.Add(coord1.ToUpper());
                attackerBoard.shots.Add(coord2);
                Console.WriteLine($"Atacó {attacker.Name}");
            }
            return result;
        }
        /// <summary>
        /// Checkeo de si la posición del ataque es válida
        /// </summary>
        /// <param name="coord1">primer valor de la coordenada a checkear</param>
        /// <param name="coord2">segundo valor de la coordenada a checkear</param>
        /// <returns>Devuelve si el ataque está dentro del tablero</returns>
        public bool CoordCheck(string coord1, string coord2)
        {
            bool outOfBoard = false;
            if (!Board.num.Contains(coord2))
            {
                Console.WriteLine("No puede atacar en esta ubicacion");
                System.Console.WriteLine("Esta fuera del tablero");

                outOfBoard = true;
                return outOfBoard;
            }
            else if (!Board.abc.Contains(coord1.ToUpper()))
            {
                Console.WriteLine("No puede atacar en esta ubicacion");
                System.Console.WriteLine("Esta fuera del tablero");
                outOfBoard = true;
                return outOfBoard;
            }
            else
            {
                return outOfBoard;
            }
        }
        /// <summary>
        /// Checkeo si la coordenada no ha sido atacada
        /// </summary>
        /// <param name="coord1">primer valor de la coordenada a checkear</param>
        /// <param name="coord2">segundo valor de la coordenada a checkear</param>
        /// <param name="shotsBoard">Tablero que realizó los ataques</param>
        /// <returns>Devuelve si no se ha atacado en un sitio</returns>
        public bool ShotHistory(string coord1, string coord2, Board shotsBoard)
        {
            bool alreadyShot = false;
            for (int i = 0; i < shotsBoard.shots.Count; i += 2)
            {
                string setter1 = Convert.ToString(shotsBoard.shots[i]);
                string setter2 = Convert.ToString(shotsBoard.shots[i + 1]);
                if (setter1 == coord1.ToUpper())
                {
                    if (setter2 == coord2)
                    {
                        System.Console.WriteLine();
                        Console.WriteLine("Ya ha atacado aqui");
                        System.Console.WriteLine("Intente denuevo");
                        alreadyShot = true;
                        return alreadyShot;
                    }
                }
            }
            return alreadyShot;
        }

        /// <summary>
        /// Método que determina si un barco fue hundido o no
        /// </summary>
        /// <param name="currentShipName">El nombre del barco al que se le pegó</param>
        /// <param name="Player">Usuario al que corresponde el barco</param>
        /// <returns>Devuelve si el barco fue hundido o tocado</returns>
        public (bool, bool) ShipMessage(string currentShipName, User Player)
        {
            bool sink = false;
            bool wreck = false;
            if (Player == Player1)
            {
                if (currentShipName.ToLower() == "lancha")
                {
                    Lancha1Health -= 1;
                    if (Lancha1Health == 0)
                    {
                        Console.WriteLine($"Hundido {currentShipName}");
                        sink = true;
                        return (sink, wreck);
                    }
                    else
                    {
                        Console.WriteLine("Tocado");
                        wreck = true;
                        return (sink, wreck);
                    }
                }
                else if (currentShipName.ToLower() == "crucero")
                {
                    Crucero1Health -= 1;
                    if (Crucero1Health == 0)
                    {
                        Console.WriteLine($"Hundido {currentShipName}");
                        sink = true;
                        return (sink, wreck);
                    }
                    else
                    {
                        Console.WriteLine("Tocado");
                        wreck = true;
                        return (sink, wreck);
                    }
                }
                else if (currentShipName.ToLower() == "submarino")
                {
                    Submarino1Health -= 1;
                    if (Submarino1Health == 0)
                    {
                        Console.WriteLine($"Hundido {currentShipName}");
                        sink = true;
                        return (sink, wreck);
                    }
                    else
                    {
                        Console.WriteLine("Tocado");
                        wreck = true;
                        return (sink, wreck);
                    }
                }
                else if (currentShipName.ToLower() == "buque")
                {
                    Buque1Health -= 1;
                    if (Buque1Health == 0)
                    {
                        Console.WriteLine($"Hundido {currentShipName}");
                        sink = true;
                        return (sink, wreck);
                    }
                    else
                    {
                        Console.WriteLine("Tocado");
                        wreck = true;
                        return (sink, wreck);
                    }
                }
                else if (currentShipName.ToLower() == "portaaviones")
                {
                    Portaaviones1Health -= 1;
                    if (Portaaviones1Health == 0)
                    {
                        Console.WriteLine($"Hundido {currentShipName}");
                        sink = true;
                        return (sink, wreck);
                    }
                    else
                    {
                        Console.WriteLine("Tocado");
                        wreck = true;
                        return (sink, wreck);
                    }
                }
                else
                {
                }
                return (sink, wreck);
            }
            else
            {
                if (currentShipName.ToLower() == "lancha")
                {
                    Lancha2Health -= 1;
                    if (Lancha2Health == 0)
                    {
                        Console.WriteLine($"Hundido {currentShipName}");
                        sink = true;
                        return (sink, wreck);
                    }
                    else
                    {
                        Console.WriteLine("Tocado");
                        wreck = true;
                        return (sink, wreck);
                    }
                }
                else if (currentShipName.ToLower() == "crucero")
                {
                    Crucero2Health -= 1;
                    if (Crucero2Health == 0)
                    {
                        Console.WriteLine($"Hundido {currentShipName}");
                        sink = true;
                        return (sink, wreck);
                    }
                    else
                    {
                        Console.WriteLine("Tocado");
                        wreck = true;
                        return (sink, wreck);
                    }
                }
                else if (currentShipName.ToLower() == "submarino")
                {
                    Submarino2Health -= 1;
                    if (Submarino2Health == 0)
                    {
                        Console.WriteLine($"Hundido {currentShipName}");
                        sink = true;
                        return (sink, wreck);
                    }
                    else
                    {
                        Console.WriteLine("Tocado");
                        wreck = true;
                        return (sink, wreck);
                    }
                }
                else if (currentShipName.ToLower() == "buque")
                {
                    Buque2Health -= 1;
                    if (Buque2Health == 0)
                    {
                        Console.WriteLine($"Hundido {currentShipName}");
                        sink = true;
                        return (sink, wreck);
                    }
                    else
                    {
                        Console.WriteLine("Tocado");
                        wreck = true;
                        return (sink, wreck);
                    }
                }
                else if (currentShipName.ToLower() == "portaaviones")
                {
                    Portaaviones2Health -= 1;
                    if (Portaaviones2Health == 0)
                    {
                        Console.WriteLine($"Hundido {currentShipName}");
                        sink = true;
                        return (sink, wreck);
                    }
                    else
                    {
                        Console.WriteLine("Tocado");
                        wreck = true;
                        return (sink, wreck);
                    }
                }
                else
                {
                }
                return (sink, wreck);
            }

        }



        /// <summary>
        /// Por creator el responsable de saber la información de cómo estan compuestos los tableros
        /// es la clase Board, por ende el método ShowBoard le dice a Board la información que debe de mostrar
        /// </summary>
        /// <param name="user"> Al igual que en Attack, se indica que usuario está ingresando
        /// la solicitud del tablero que seleccione</param>
        public void ShowBoard(User user, Board board1, Board board2)
        {
            /* Comentado para evitar Readlines
            System.Console.WriteLine();
            Console.WriteLine("Que tablero quiere mostrar?");
            Console.WriteLine("1- Mi tablero");
            Console.WriteLine("2- Tablero enemigo");
            System.Console.WriteLine();
            System.Console.Write("Selección: ");
            string response = Console.ReadLine();
            if (user == this.Player1 && response == "1")
            {
                System.Console.WriteLine();
                board1.PrintBoard(board1.shipPos, board2.shots, "MyBoard");
            }
            else if (user == this.Player1 && response == "2")
            {
                System.Console.WriteLine();
                board1.PrintBoard(board2.shipPos, board1.shots, "EnemyBoard");
            }
            else if (user == this.Player2 && response == "1")
            {
                System.Console.WriteLine();
                board2.PrintBoard(board2.shipPos, board1.shots, "MyBoard");
            }
            else if (user == this.Player2 && response == "2")
            {
                System.Console.WriteLine();
                board2.PrintBoard(board1.shipPos, board2.shots, "EnemyBoard");
            }
            else
            {
                Console.WriteLine("No es una opción válida");
                System.Console.WriteLine("Intente denuevo");
                ShowBoard(user, board1, board2);
            }
            */
        }
        public virtual User CheckMatch()
        {
            if (HitsPlayer1 == 15 || HitsPlayer2 == 15)
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
        /// <summary>
        /// Se determina el ganador del juego y se termina dicho juego
        /// </summary>
        /// <returns>Devuelve el usuario que ganó</returns>
        public virtual User GameWinner()
        {
            User winner;
            if (HitsPlayer1 > HitsPlayer2)
            {
                winner = Player1;
            }
            else
            {
                winner = Player2;
            }
            EndGame();
            return winner;
        }
        /// <summary>
        /// Por Expert, el encargado de terminar un juego en curso es Game mediante el
        /// método EndGame()
        /// </summary>
        public void EndGame()
        {
            OnGoing = false;
            Administrator.Instance.currentGame.Remove(this);
        }

        /// <summary>
        /// Resetea la vida de los barcos
        /// </summary>
        public void RestartHits()
        {
            Lancha1Health = 1;
            Crucero1Health = 2;
            Submarino1Health = 3;
            Buque1Health = 4;
            Portaaviones1Health = 5;
            Lancha2Health = 1;
            Crucero2Health = 2;
            Submarino2Health = 3;
            Buque2Health = 4;
            Portaaviones2Health = 5;
        }

        public User player1
        {
            get
            {
                return this.Player1;
            }
        }

        public User player2
        {
            get
            {
                return this.Player2;
            }
        }
        public Board boardPlayer1
        {
            get
            {
                return this.BoardPlayer1;
            }
        }
        public Board boardPlayer2
        {
            get
            {
                return this.BoardPlayer2;
            }
        }
        public string mode
        {
            get
            {
                return this.Mode;
            }
        }
        public int hitsPlayer1
        {
            get
            {
                return this.HitsPlayer1;
            }
            set
            {
                HitsPlayer1 = value;
            }
        }
        public int hitsPlayer2
        {
            get
            {
                return this.HitsPlayer2;
            }
            set
            {
                HitsPlayer2 = value;
            }
        }

        public bool onGoing
        {
            get
            {
                return this.OnGoing;
            }
            set
            {
                OnGoing = value;
            }
        }
    }
}