using System;

namespace Library
{
    public class Challenge : Game
    {
        private User Player1;
        private User Player2;
        private Board BoardPlayer1;
        private Board BoardPlayer2;
        private bool OnGoing;
        private int WinsPlayer1 = 0;
        private int WinsPlayer2 = 0;
        public Challenge(User player1, User player2) : base(player1, player2)
        {
            this.Player1 = player1;
            this.Player2 = player2;
            BoardPlayer1 = new Board(player1);
            BoardPlayer2 = new Board(player2);
        }
        public override void StartGame()
        {
            while (WinsPlayer1<2 || WinsPlayer2<2)
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
                    //Falta ver como saber la cantidad de barcos que quedan por board
                    if (this.BoardPlayer1.AmmountofBoats == 0 || this.BoardPlayer2.AmmountofBoats == 0)
                    {
                        base.EndGame();
                        if (this.BoardPlayer1.AmmountofBoats == 0)
                        {
                            WinsPlayer2 += 1;
                            Console.WriteLine($"Gana {Player2}");
                        }
                        if (this.BoardPlayer2.AmmountofBoats == 0)
                        {
                            WinsPlayer1 += 1;
                            Console.WriteLine($"Gana {Player1}");
                        }
                    }
                }
            }
        }
    }
}