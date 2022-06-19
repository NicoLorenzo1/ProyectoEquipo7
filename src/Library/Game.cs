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
        private Stadistics stadistics;
        private int HitsPlayer1;
        private int HitsPlayer2;
        public Game(User player1, User player2, string name) : base(name)
        {
            this.Player1 = player1;
            this.Player2 = player2;
            BoardPlayer1 = new Board(this.Player1);
            BoardPlayer2 = new Board(this.Player2);
        }
        public Game(string name) : base(name)
        {
            if (name.ToLower() == "classic mode")
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
            //BoardPlayer1.Position_Ships();
            //BoardPlayer2.Position_Ships();
            User recentAttacker = this.Player2;
            OnGoing = true;
            while (OnGoing)
            {
                if (recentAttacker == this.Player1)
                {
                    this.Attack(this.Player2);
                    ShowBoard(BoardPlayer1);
                    recentAttacker = Player2;
                }
                else
                {
                    this.Attack(this.Player1);
                    ShowBoard(BoardPlayer2);
                    recentAttacker = Player1;
                }
                if (HitsPlayer1 == 15 || HitsPlayer2 == 15)
                {
                    EndGame();
                    if (HitsPlayer2 == 15)
                    {
                        stadistics.ModifyStatics(Player1, false);
                        stadistics.ModifyStatics(Player2, true);
                        Console.WriteLine($"Gana {Player2.Name}");
                    }
                    if (HitsPlayer1 == 15)
                    {
                        stadistics.ModifyStatics(Player1, true);
                        stadistics.ModifyStatics(Player1, false);
                        Console.WriteLine($"Gana {Player1.Name}");
                    }
                }
            }
        }
        public virtual void Attack(User player)
        {
            bool hit = false;
            bool attack = false;
            Console.WriteLine("A donde quiere atacar?");
            Console.WriteLine("Escriba la primer coordenada(A-J)");
            string coord1 = Console.ReadLine();
            Console.WriteLine("Escriba la segunda coordenada(1-10)");
            string coord2 = Console.ReadLine();
            if (player == this.Player1)
            {
                if (!Board.num.Contains(coord2))
                {
                    Console.WriteLine("No puede atacar en esta ubicacion");
                    attack = true;
                }
                else if (!Board.abc.Contains(coord1.ToUpper()))
                {
                    Console.WriteLine("No puede atacar en esta ubicacion");
                    attack = true;
                }
                        
                for (int i = 0; i < BoardPlayer1.shots.Count; i+=2)
                    {
                        string setter1 = Convert.ToString(BoardPlayer1.shots[i]);
                        string setter2 = Convert.ToString(BoardPlayer1.shots[i+1]);
                        if (setter1 == coord1.ToUpper())
                        {
                            if (setter2 == coord2)
                            {
                                Console.WriteLine("Ya ha atacado aqui");
                                attack = true;
                            }
                        }
                    }
                if (attack)
                {
                    Attack(player);
                }
                hit = this.BoardPlayer2.CheckShip(coord1,coord2);
                if (hit)
                {
                    this.BoardPlayer2.Edit_Board(coord1, coord2, "X");
                    HitsPlayer1 += 1;
                    Console.WriteLine("Pegó");
                }
                else
                {
                    this.BoardPlayer2.Edit_Board(coord1, coord2, "O");
                    Console.WriteLine("Agua");
                }
                BoardPlayer1.shots.Add(coord1.ToUpper());
                BoardPlayer1.shots.Add(coord2);
            }
            else if (player == this.Player2)
            {
                hit = this.BoardPlayer1.CheckShip(coord1,coord2);
                if (hit)
                {
                    this.BoardPlayer1.Edit_Board(coord1, coord2, "X");
                    HitsPlayer2 += 1;
                    Console.WriteLine("Pegó");
                }
                else
                {
                    this.BoardPlayer1.Edit_Board(coord1, coord2, "O");
                    Console.WriteLine("Agua");
                }
            }
            Console.WriteLine($"Atacó {player.Name}");
        }
        public void ShowBoard(Board board)
        {
            Console.WriteLine($"Tablero de {board.Username.Name}");
            board.Print_Board();
        }
        public void EndGame()
        {
            OnGoing = false;            
        }
    }
}



