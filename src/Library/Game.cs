using System;
using Telegram.Bot;

namespace Library
{
    public class Game : Lobby
    {
        private User Player1;
        private User Player2;
        private Board BoardPlayer1;
        private Board BoardPlayer2;
        private bool OnGoing;
        private bool Hit;
        private int HitsPlayer1;
        private int HitsPlayer2;
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

        /// <summary>
        /// Por OCP todos los modos de juego heredan de la clase Game, que posee la lógica base del juego
        /// y es abierta a extensiones, pero no recibe ningun cambio
        /// </summary>
        /// <param name="player1">Primer User que proviene de la lista UsersToPlay para el modo de juego seleccionado</param>
        /// <param name="player2">Segundo User que proviene de la lista UsersToPlay para el modo de juego seleccionado</param>
        /// <param name="name"></param>
        /// <returns></returns>
        public Game(User player1, User player2, string name) : base(name)
        {
            this.Player1 = player1;
            this.Player2 = player2;
            BoardPlayer1 = new Board(this.Player1);
            BoardPlayer2 = new Board(this.Player2);
            Administrator.Instance.currentGame.Add(this);
        }
        public Game(string name) : base(name)
        {
            if (name.ToLower() == "classic")
            {
                this.Name = name;
                Game game = new Game(this.usersWaiting.ElementAt(0), this.usersWaiting.ElementAt(1), this.Name);
                this.StartGame();
            }
            else
            {
                Console.WriteLine("Modo incorrecto");
            }
        }

        /// <summary>
        /// StartGame inicializa la lógica central del juego, en la cual le solicita a ambos usuarios que posicionen sus barcos y luego
        /// comenzará la ronda de ataques por turnos.
        /// </summary>
        public virtual void StartGame()
        {
            //System.Console.WriteLine("Comienza la batalla naval!!");
            sendTelegramMessage(Player1, "Comienza la batalla naval!!");
            sendTelegramMessage(Player2, "Comienza la batalla naval!!");

            sendTelegramMessage(Player1, $"{Player1.Name} vs {Player2.Name}");
            sendTelegramMessage(Player2, $"{Player1.Name} vs {Player2.Name}");

            //System.Console.WriteLine($"{Player1.Name} vs {Player2.Name}");
            //System.Console.WriteLine();

            sendTelegramMessage(Player1, "Cuando estes listo, envia 'Posicionar' para comenzar a posicionar tus barcos");
            sendTelegramMessage(Player2, "Cuando estes listo, envia 'Posicionar' para comenzar a posicionar tus barcos");
            //BoardPlayer1.PositionShips();
            //BoardPlayer2.PositionShips();

            /*
                System.Console.WriteLine($"Posicionamiento de barcos de {Player1.Name}");
                BoardPlayer1.PositionShips();
                System.Console.WriteLine($"Posicionamiento de barcos de {Player2.Name}");
                BoardPlayer2.PositionShips();
                */
            User recentAttacker = this.Player2;

            /*
                        OnGoing = true;
                        while (OnGoing)
                        {
                            if (recentAttacker == this.Player1)
                            {
                                this.Attack(this.Player2);
                                System.Console.WriteLine();
                                this.BoardPlayer2.PrintBoard(BoardPlayer1.shipPos, BoardPlayer2.shots, "EnemyBoard");
                                ShowBoard(this.Player2);
                                recentAttacker = Player2;
                            }
                            else
                            {
                                this.Attack(this.Player1);
                                this.BoardPlayer1.PrintBoard(BoardPlayer2.shipPos, BoardPlayer1.shots, "EnemyBoard");
                                ShowBoard(this.Player1);
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
            */
        }

        /// <summary>
        /// Por Expert, al Game tener la responsabilidad de conocer toda la lógica del juego,
        /// es el encargado de conocer que ataques se realizan en cada momento
        /// </summary>
        /// <param name="player">Aquí se indica cual es el usuario que está atacando en ese momento</param>
        public virtual void Attack(User player)
        {
            bool hit = false;
            bool outOfBoard = false;
            System.Console.WriteLine();
            System.Console.WriteLine($"Ataca {player.Name}:");
            Console.WriteLine("A donde quiere atacar?");
            Console.Write("Escriba la primer coordenada(A-J): ");
            string coord1 = Console.ReadLine();
            Console.Write("Escriba la segunda coordenada(1-10): ");
            string coord2 = Console.ReadLine();
            if (player == this.Player1)
            {
                if (!Board.num.Contains(coord2))
                {
                    Console.WriteLine("No puede atacar en esta ubicacion");
                    System.Console.WriteLine("Esta fuera del tablero");

                    outOfBoard = true;
                }
                else if (!Board.abc.Contains(coord1.ToUpper()))
                {
                    Console.WriteLine("No puede atacar en esta ubicacion");
                    System.Console.WriteLine("Esta fuera del tablero");
                    outOfBoard = true;
                }

                for (int i = 0; i < BoardPlayer1.shots.Count; i += 2)
                {
                    string setter1 = Convert.ToString(BoardPlayer1.shots[i]);
                    string setter2 = Convert.ToString(BoardPlayer1.shots[i + 1]);
                    if (setter1 == coord1.ToUpper())
                    {
                        if (setter2 == coord2)
                        {
                            System.Console.WriteLine();
                            Console.WriteLine("Ya ha atacado aqui");
                            System.Console.WriteLine("Intente denuevo");
                            outOfBoard = true;
                        }
                    }
                }
                if (outOfBoard)
                {
                    Attack(player);
                }
                else
                {
                    hit = this.BoardPlayer2.CheckShip(coord1, coord2, BoardPlayer2.shipPos, out string shipName);
                    if (hit)
                    {
                        if (shipName.ToLower() == "lancha")
                        {
                            Lancha2Health -= 1;
                            if (Lancha2Health == 0)
                            {
                                Console.WriteLine($"{shipName} Hundido!");
                            }
                            else
                            {
                                Console.WriteLine("Tocado");
                            }
                        }
                        else if (shipName.ToLower() == "crucero")
                        {
                            Crucero2Health -= 1;
                            if (Crucero2Health == 0)
                            {
                                Console.WriteLine($"{shipName} Hundido!");
                            }
                            else
                            {
                                Console.WriteLine("Tocado");
                            }
                        }
                        else if (shipName.ToLower() == "submarino")
                        {
                            Submarino2Health -= 1;
                            if (Submarino2Health == 0)
                            {
                                Console.WriteLine($"{shipName} Hundido!");
                            }
                            else
                            {
                                Console.WriteLine("Tocado");
                            }
                        }
                        else if (shipName.ToLower() == "buque")
                        {
                            Buque2Health -= 1;
                            if (Buque2Health == 0)
                            {
                                Console.WriteLine($"{shipName} Hundido!");
                            }
                            else
                            {
                                Console.WriteLine("Tocado");
                            }
                        }
                        else if (shipName.ToLower() == "portaaviones")
                        {
                            Portaaviones2Health -= 1;
                            if (Portaaviones2Health == 0)
                            {
                                Console.WriteLine($"{shipName} Hundido!");
                            }
                            else
                            {
                                Console.WriteLine("Tocado");
                            }
                        }
                        HitsPlayer1 += 1;
                    }
                    else
                    {
                        Console.WriteLine("Agua");
                    }
                    BoardPlayer1.shots.Add(coord1.ToUpper());
                    BoardPlayer1.shots.Add(coord2);
                    Console.WriteLine($"Atacó {player.Name}");
                }
            }
            else if (player == this.Player2)
            {
                if (!Board.num.Contains(coord2))
                {
                    Console.WriteLine("No puede atacar en esta ubicacion");
                    System.Console.WriteLine("Esta fuera del tablero");
                    outOfBoard = true;
                }
                else if (!Board.abc.Contains(coord1.ToUpper()))
                {
                    Console.WriteLine("No puede atacar en esta ubicacion");
                    System.Console.WriteLine("Esta fuera del tablero");
                    outOfBoard = true;
                }

                for (int i = 0; i < BoardPlayer2.shots.Count; i += 2)
                {
                    string setter1 = Convert.ToString(BoardPlayer2.shots[i]);
                    string setter2 = Convert.ToString(BoardPlayer2.shots[i + 1]);
                    if (setter1 == coord1.ToUpper())
                    {
                        if (setter2 == coord2)
                        {
                            Console.WriteLine("Ya ha atacado aqui");
                            System.Console.WriteLine("Intente denuevo");
                            outOfBoard = true;
                        }
                    }
                }
                if (outOfBoard)
                {
                    Attack(player);
                }
                else
                {
                    hit = this.BoardPlayer1.CheckShip(coord1, coord2, BoardPlayer1.shipPos, out string shipName);
                    if (hit)
                    {
                        if (shipName.ToLower() == "lancha")
                        {
                            Lancha1Health -= 1;
                            if (Lancha1Health == 0)
                            {
                                Console.WriteLine($"Hundido {shipName}");
                            }
                            else
                            {
                                Console.WriteLine("Tocado");
                            }
                        }
                        else if (shipName.ToLower() == "crucero")
                        {
                            Crucero1Health -= 1;
                            if (Crucero1Health == 0)
                            {
                                Console.WriteLine($"Hundido {shipName}");
                            }
                            else
                            {
                                Console.WriteLine("Tocado");
                            }
                        }
                        else if (shipName.ToLower() == "submarino")
                        {
                            Submarino1Health -= 1;
                            if (Submarino1Health == 0)
                            {
                                Console.WriteLine($"Hundido {shipName}");
                            }
                            else
                            {
                                Console.WriteLine("Tocado");
                            }
                        }
                        else if (shipName.ToLower() == "buque")
                        {
                            Buque1Health -= 1;
                            if (Buque1Health == 0)
                            {
                                Console.WriteLine($"Hundido {shipName}");
                            }
                            else
                            {
                                Console.WriteLine("Tocado");
                            }
                        }
                        else if (shipName.ToLower() == "portaaviones")
                        {
                            Portaaviones1Health -= 1;
                            if (Portaaviones1Health == 0)
                            {
                                Console.WriteLine($"Hundido {shipName}");
                            }
                            else
                            {
                                Console.WriteLine("Tocado");
                            }
                        }
                        else
                        {
                        }
                        HitsPlayer2 += 1;
                    }
                    else
                    {
                        Console.WriteLine("Agua");
                    }
                    BoardPlayer2.shots.Add(coord1.ToUpper());
                    BoardPlayer2.shots.Add(coord2);
                    Console.WriteLine($"Atacó {player.Name}");
                }
            }
        }
        /// <summary>
        /// Por creator el responsable de saber la información de cómo estan compuestos los tableros
        /// es la clase Board, por ende el método ShowBoard le dice a Board la información que debe de mostrar
        /// </summary>
        /// <param name="user"> Al igual que en Attack, se indica que usuario está ingresando
        /// la solicitud del tablero que seleccione</param>
        public void ShowBoard(User user)
        {
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
                this.BoardPlayer1.PrintBoard(BoardPlayer1.shipPos, BoardPlayer2.shots, "MyBoard");
            }
            else if (user == this.Player1 && response == "2")
            {
                System.Console.WriteLine();
                this.BoardPlayer1.PrintBoard(BoardPlayer2.shipPos, BoardPlayer1.shots, "EnemyBoard");
            }
            else if (user == this.Player2 && response == "1")
            {
                System.Console.WriteLine();
                this.BoardPlayer2.PrintBoard(BoardPlayer2.shipPos, BoardPlayer1.shots, "MyBoard");
            }
            else if (user == this.Player2 && response == "2")
            {
                System.Console.WriteLine();
                this.BoardPlayer2.PrintBoard(BoardPlayer1.shipPos, BoardPlayer2.shots, "EnemyBoard");
            }
            else
            {
                Console.WriteLine("No es una opción válida");
                System.Console.WriteLine("Intente denuevo");
            }
        }
        /// <summary>
        /// Por Expert, el encargado de terminar un juego en curso es Game mediante el
        /// método EndGame()
        /// </summary>
        public void EndGame()
        {
            OnGoing = false;
            Administrator.Instance.currentGame.Remove(this);
            //administrator.currentGame.Remove(this);            
        }

        private async void sendTelegramMessage(User user, string message)
        {
            await TelegramBot.telegramClient.SendTextMessageAsync(user.IdChat, message);

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
                return this.BoardPlayer1;
            }
        }
    }
}