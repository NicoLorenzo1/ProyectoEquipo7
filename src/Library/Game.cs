using System;

namespace Library
{
    public class Game
    {

 

        public Game()
        {

        }

        public void StartGame(User player1, User player2)
        {
            
            User recentAttacker = player2;
            OnGoing = true;
            while (OnGoing)
            {
                if (recentAttacker == player1)
                {
                    this.Attack(player2);
                    recentAttacker = player2;
                }
                else
                {
                    this.Attack(player1);
                    recentAttacker = player1;
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
        /*
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
            */

    }
}



