using System;

namespace Library
{
    public class Game
    {
        private User Player1;
        private User Player2;
        private Board BoardPlayer1;
        private Board BoardPlayer2;
        private bool OnGoing;
        private bool Hit;
        private Stadistics stadistics;
        public Game(User player1, User player2)
        {
            this.Player1 = player1;
            this.Player2 = player2;
            BoardPlayer1 = new Board(player1);
            BoardPlayer2 = new Board(player2); 
        }
        public virtual void StartGame()
        {   
            User recentAttacker = this.Player2;
            OnGoing = true;
            while (OnGoing)
            {
                if (recentAttacker == this.Player1)
                {
                    this.Attack(this.Player2);
                    ShowBoard(BoardPlayer2);
                    recentAttacker = Player2;
                }
                else
                {
                    this.Attack(this.Player1);
                    ShowBoard(BoardPlayer1);
                    recentAttacker = Player1;
                }
                /*if (this.BoardPlayer1.AmmountofBoats == 0 || this.BoardPlayer2.AmmountofBoats == 0)
                {
                    EndGame();
                    if (this.BoardPlayer1.AmmountofBoats == 0)
                    {
                        stadistics.ModifyStatistics(Player1, false);
                        stadistics.ModifyStatistics(Player2, true);
                        Console.WriteLine($"Gana {Player2}");
                    }
                    if (this.BoardPlayer2.AmmountofBoats == 0)
                    {
                        stadistics.ModifyStatistics(Player1, true);
                        stadistics.ModifyStatistics(Player2, false);
                        Console.WriteLine($"Gana {Player1}");
                    }
                }*/
            }
        }
        public virtual void Attack(User player)
        {
            //Falta checkear si pega o no
            Console.WriteLine("Escriba la primer coordenada(A-J)");
            string coord1 = Console.ReadLine();
            Console.WriteLine("Escriba la segunda coordenada(1-10)");
            string coord2 = Console.ReadLine();
            if (player == this.Player1)
            {
                this.BoardPlayer2.Edit_Board(coord1,coord2);
            }
            else if (player == this.Player2)
            {
                this.BoardPlayer1.Edit_Board(coord1, coord2);
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