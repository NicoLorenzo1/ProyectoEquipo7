using System;

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
        public Game(User player1, User player2, string name) : base(name)
        {
            this.Player1 = player1;
            this.Player2 = player2;
            BoardPlayer1 = new Board(this.Player1);
            BoardPlayer2 = new Board(this.Player2);
        }
        public Game(string name) : base(name)
<<<<<<< HEAD
        {
            if (name.ToLower() == "classic")
            {
                this.Name = name;
                //Game game = new Game(this.usersWaiting.ElementAt(0), this.usersWaiting.ElementAt(1), this.Name);
                //this.StartGame();
            }
            else
            {
                Console.WriteLine("Modo incorrecto");
            }
        }
        public virtual void StartGame()
        {
            BoardPlayer1.Position_Ships();
            BoardPlayer2.Position_Ships();
=======
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
        public virtual void StartGame()
        {
            BoardPlayer1.PositionShips();
            BoardPlayer2.PositionShips();
>>>>>>> 8c72e2053a48c200c1be9ad0707e0bccfedb20d7
            User recentAttacker = this.Player2;
            OnGoing = true;
            while (OnGoing)
            {
                if (recentAttacker == this.Player1)
                {
                    this.Attack(this.Player2);
<<<<<<< HEAD
                    this.BoardPlayer2.Print_Board(BoardPlayer1.shipPos, BoardPlayer2.shots, "EnemyBoard");
=======
                    System.Console.WriteLine();
                    this.BoardPlayer2.PrintBoard(BoardPlayer1.shipPos, BoardPlayer2.shots, "EnemyBoard");
>>>>>>> 8c72e2053a48c200c1be9ad0707e0bccfedb20d7
                    ShowBoard(this.Player2);
                    recentAttacker = Player2;
                }
                else
                {
                    this.Attack(this.Player1);
<<<<<<< HEAD
                    this.BoardPlayer1.Print_Board(BoardPlayer2.shipPos, BoardPlayer1.shots, "EnemyBoard");
=======
                    this.BoardPlayer1.PrintBoard(BoardPlayer2.shipPos, BoardPlayer1.shots, "EnemyBoard");
>>>>>>> 8c72e2053a48c200c1be9ad0707e0bccfedb20d7
                    ShowBoard(this.Player1);
                    recentAttacker = Player1;
                }
                if (HitsPlayer1 == 15 || HitsPlayer2 == 15)
                {
                    EndGame();
                    if (HitsPlayer2 == 15)
                    {
                        Player1.stadistics.ModifyStatics(Player1, false);
                        Player2.stadistics.ModifyStatics(Player2, true);
<<<<<<< HEAD
                        Console.WriteLine($"Gana {Player2.Name}");
=======
                        System.Console.WriteLine();
                        Console.WriteLine($"Ha ganado {Player2.Name}!!");
>>>>>>> 8c72e2053a48c200c1be9ad0707e0bccfedb20d7
                    }
                    if (HitsPlayer1 == 15)
                    {
                        Player1.stadistics.ModifyStatics(Player1, true);
                        Player2.stadistics.ModifyStatics(Player1, false);
<<<<<<< HEAD
                        Console.WriteLine($"Gana {Player1.Name}");
=======
                        System.Console.WriteLine();
                        Console.WriteLine($"Ha ganado {Player1.Name}!!");
>>>>>>> 8c72e2053a48c200c1be9ad0707e0bccfedb20d7
                    }
                }
            }
        }
        public virtual void Attack(User player)
        {
            bool hit = false;
            bool outOfBoard = false;
<<<<<<< HEAD
            Console.WriteLine("A donde quiere atacar?");
            Console.WriteLine("Escriba la primer coordenada(A-J)");
=======
            System.Console.WriteLine();
            System.Console.WriteLine($"Ataca {player.Name}:");
            Console.WriteLine("A donde quiere atacar?");
            Console.Write("Escriba la primer coordenada(A-J): ");
>>>>>>> 8c72e2053a48c200c1be9ad0707e0bccfedb20d7
            string coord1 = Console.ReadLine();
            Console.Write("Escriba la segunda coordenada(1-10): ");
            string coord2 = Console.ReadLine();
            if (player == this.Player1)
            {
                if (!Board.num.Contains(coord2))
                {
                    Console.WriteLine("No puede atacar en esta ubicacion");
<<<<<<< HEAD
                    outOfBoard = true;
                }
                else if (!Board.abc.Contains(coord1.ToUpper()))
                {
                    Console.WriteLine("No puede atacar en esta ubicacion");
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
                            Console.WriteLine("Ya ha atacado aqui");
                            outOfBoard = true;
                        }
                    }
                }
=======
                    System.Console.WriteLine("Esta fuera del tablero");

                    outOfBoard = true;
                }
                else if (!Board.abc.Contains(coord1.ToUpper()))
                {
                    Console.WriteLine("No puede atacar en esta ubicacion");
                    System.Console.WriteLine("Esta fuera del tablero");
                    outOfBoard = true;
                }
                        
                for (int i = 0; i < BoardPlayer1.shots.Count; i+=2)
                    {
                        string setter1 = Convert.ToString(BoardPlayer1.shots[i]);
                        string setter2 = Convert.ToString(BoardPlayer1.shots[i+1]);
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
>>>>>>> 8c72e2053a48c200c1be9ad0707e0bccfedb20d7
                if (outOfBoard)
                {
                    Attack(player);
                }
                else
                {
<<<<<<< HEAD
                    hit = this.BoardPlayer2.CheckShip(coord1, coord2, BoardPlayer2.shipPos, out string shipName);
=======
                    hit = this.BoardPlayer2.CheckShip(coord1,coord2, BoardPlayer2.shipPos,out string shipName);
>>>>>>> 8c72e2053a48c200c1be9ad0707e0bccfedb20d7
                    if (hit)
                    {
                        if (shipName.ToLower() == "lancha")
                        {
<<<<<<< HEAD
                            Lancha2Health -= 1;
                            if (Lancha2Health == 0)
                            {
                                Console.WriteLine($"Hundido {shipName}");
=======
                            Lancha2Health -=1;
                            if (Lancha2Health == 0)
                            {
                                Console.WriteLine($"{shipName} Hundido!");
>>>>>>> 8c72e2053a48c200c1be9ad0707e0bccfedb20d7
                            }
                            else
                            {
                                Console.WriteLine("Tocado");
                            }
                        }
                        else if (shipName.ToLower() == "crucero")
                        {
<<<<<<< HEAD
                            Crucero2Health -= 1;
                            if (Crucero2Health == 0)
                            {
                                Console.WriteLine($"Hundido {shipName}");
=======
                            Crucero2Health -=1;
                            if (Crucero2Health == 0)
                            {
                                Console.WriteLine($"{shipName} Hundido!");
>>>>>>> 8c72e2053a48c200c1be9ad0707e0bccfedb20d7
                            }
                            else
                            {
                                Console.WriteLine("Tocado");
                            }
                        }
                        else if (shipName.ToLower() == "submarino")
                        {
<<<<<<< HEAD
                            Submarino2Health -= 1;
                            if (Submarino2Health == 0)
                            {
                                Console.WriteLine($"Hundido {shipName}");
=======
                            Submarino2Health -=1;
                            if (Submarino2Health == 0)
                            {
                                Console.WriteLine($"{shipName} Hundido!");
>>>>>>> 8c72e2053a48c200c1be9ad0707e0bccfedb20d7
                            }
                            else
                            {
                                Console.WriteLine("Tocado");
                            }
                        }
                        else if (shipName.ToLower() == "buque")
                        {
<<<<<<< HEAD
                            Buque2Health -= 1;
                            if (Buque2Health == 0)
                            {
                                Console.WriteLine($"Hundido {shipName}");
=======
                            Buque2Health -=1;
                            if (Buque2Health == 0)
                            {
                                Console.WriteLine($"{shipName} Hundido!");
>>>>>>> 8c72e2053a48c200c1be9ad0707e0bccfedb20d7
                            }
                            else
                            {
                                Console.WriteLine("Tocado");
                            }
                        }
                        else if (shipName.ToLower() == "portaaviones")
                        {
<<<<<<< HEAD
                            Portaaviones2Health -= 1;
                            if (Portaaviones2Health == 0)
                            {
                                Console.WriteLine($"Hundido {shipName}");
=======
                            Portaaviones2Health -=1;
                            if (Portaaviones2Health == 0)
                            {
                                Console.WriteLine($"{shipName} Hundido!");
>>>>>>> 8c72e2053a48c200c1be9ad0707e0bccfedb20d7
                            }
                            else
                            {
                                Console.WriteLine("Tocado");
                            }
                        }
<<<<<<< HEAD
                        HitsPlayer1 += 1;
=======
                        HitsPlayer1 += 1;                    
>>>>>>> 8c72e2053a48c200c1be9ad0707e0bccfedb20d7
                    }
                    else
                    {
                        Console.WriteLine("Agua");
                    }
                    BoardPlayer1.shots.Add(coord1.ToUpper());
                    BoardPlayer1.shots.Add(coord2);
                    Console.WriteLine($"Atacó {player.Name}");
<<<<<<< HEAD
                }
=======
                }            
>>>>>>> 8c72e2053a48c200c1be9ad0707e0bccfedb20d7
            }
            else if (player == this.Player2)
            {
                if (!Board.num.Contains(coord2))
                {
                    Console.WriteLine("No puede atacar en esta ubicacion");
<<<<<<< HEAD
=======
                    System.Console.WriteLine("Esta fuera del tablero");
>>>>>>> 8c72e2053a48c200c1be9ad0707e0bccfedb20d7
                    outOfBoard = true;
                }
                else if (!Board.abc.Contains(coord1.ToUpper()))
                {
                    Console.WriteLine("No puede atacar en esta ubicacion");
<<<<<<< HEAD
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
                            outOfBoard = true;
                        }
                    }
                }
                if (outOfBoard)
                {
                    Attack(player);
=======
                    System.Console.WriteLine("Esta fuera del tablero");
                    outOfBoard = true;
                }
                        
                for (int i = 0; i < BoardPlayer2.shots.Count; i+=2)
                    {
                        string setter1 = Convert.ToString(BoardPlayer2.shots[i]);
                        string setter2 = Convert.ToString(BoardPlayer2.shots[i+1]);
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
                    hit = this.BoardPlayer1.CheckShip(coord1,coord2, BoardPlayer1.shipPos, out string shipName);
                    if (hit)
                    {
                        if (shipName.ToLower() == "lancha")
                        {
                            Lancha1Health -=1;
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
                            Crucero1Health -=1;
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
                            Submarino1Health -=1;
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
                            Buque1Health -=1;
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
                            Portaaviones1Health -=1;
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
>>>>>>> 8c72e2053a48c200c1be9ad0707e0bccfedb20d7
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
        public void ShowBoard(User user)
        {
            Console.WriteLine("Que tablero quiere mostrar?");
            Console.WriteLine("1- Mi tablero");
            Console.WriteLine("2- Tablero enemigo");
            string response = Console.ReadLine();
            if (user == this.Player1 && response == "1")
            {
                this.BoardPlayer1.Print_Board(BoardPlayer1.shipPos, BoardPlayer2.shots, "MyBoard");
            }
            else if (user == this.Player1 && response == "2")
            {
                this.BoardPlayer1.Print_Board(BoardPlayer2.shipPos, BoardPlayer1.shots, "EnemyBoard");
            }
            else if (user == this.Player2 && response == "1")
            {
                this.BoardPlayer2.Print_Board(BoardPlayer2.shipPos, BoardPlayer1.shots, "MyBoard");
            }
            else if (user == this.Player2 && response == "2")
            {
                this.BoardPlayer2.Print_Board(BoardPlayer1.shipPos, BoardPlayer2.shots, "EnemyBoard");
            }
            else
            {
                Console.WriteLine("No es una opción válida");
            }
        }
<<<<<<< HEAD
        public void EndGame()
        {
            OnGoing = false;
        }

        /*
        public override void MatchPlayers()
        {
         Game game = new Game(this.usersWaiting.ElementAt(0), this.usersWaiting.ElementAt(1), this.Name);
        base.MatchPlayers();
        game.StartGame();
        }
         */
=======
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
        public void EndGame()
        {
            OnGoing = false;            
        }
>>>>>>> 8c72e2053a48c200c1be9ad0707e0bccfedb20d7
    }
}