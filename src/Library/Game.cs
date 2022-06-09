using System;

namespace Library
{
    public class Game
    {
        private User Player1;
        private User Player2;
        private Board Board1;
        private Board Board2;
        private bool OnGoing;
        public Game(User player1, User player2, Board board1, Board board2)
        {
            this.Player1 = player1;
            this.Player2 = player2;
            this.Board1 = board1;
            this.Board2 = board2;
        }
        public void StartGame(User player1, User player2)
        {   
            this.Player1 = player1;
            this.Player2 = player2;
            User recentAttacker = this.Player2;
            OnGoing = true;
            while (OnGoing)
            {
                if (recentAttacker == this.Player1)
                {
                    this.Attack(this.Player2);
                    recentAttacker = Player2;
                }
                else
                {
                    this.Attack(this.Player1);
                    recentAttacker = Player1;
                }
            }
        }
        public void CheckStatus()
        {
            if (true)
            {
                
            }
        }
        public void Attack(User player)
        {
            Console.WriteLine("Escriba la primer coordenada(A-J)");
            string coord1 = Console.ReadLine();
            Console.WriteLine("Escriba la segunda coordenada(1-10)");
            string coord2 = Console.ReadLine();
        }
        public void ShowBoard()
        {

        }
        public void EndGame()
        {
            if (this.Board1.AmmountofBoats == 0 || this.Board2.AmmountofBoats == 0)
            {
                OnGoing = false;
                if (this.Board1.AmmountofBoats == 0)
                {
                    Player2.Wins += 1;
                    Console.WriteLine($"Gana {Player2}");
                }
                if (this.Board2.AmmountofBoats == 0)
                {
                    Player1.Wins += 1;
                    Console.WriteLine($"Gana {Player1}");
                }
            }
        }
    }
}