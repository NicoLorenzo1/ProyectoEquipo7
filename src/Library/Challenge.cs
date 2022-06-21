/*
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
        private Statistics statistics;
        private int HitsPlayer1;
        private int HitsPlayer2;
        private int WinsPlayer1 = 0;
        private int WinsPlayer2 = 0;
        public Challenge(User player1, User player2, string name) : base(name)
        {
            this.Player1 = player1;
            this.Player2 = player2;
            BoardPlayer1 = new Board(this.Player1);
            BoardPlayer2 = new Board(this.Player2);
        }
        public Challenge(string name) : base(name)
        {
            if (name.ToLower() == "challenge mode")
            {
                this.Name = name;
                Challenge game = new Challenge(this.usersWaiting.ElementAt(0), this.usersWaiting.ElementAt(1), this.Name);
                this.StartGame();   
            }
            else
            {
                Console.WriteLine("Modo incorrecto");
            }
        }
        public override void StartGame()
        {
            while (WinsPlayer1<2 || WinsPlayer2<2)
            {
                BoardPlayer1.PositionShips();
                BoardPlayer2.PositionShips();
                User recentAttacker = this.Player2;
                OnGoing = true;
                while (OnGoing)
                {
                    if (recentAttacker == this.Player1)
                    {
                        this.Attack(this.Player2);
                        ShowBoard(this.Player1);
                        recentAttacker = Player2;
                    }
                    else
                    {
                        this.Attack(this.Player1);
                        ShowBoard(this.Player2);
                        recentAttacker = Player1;
                    }
                    if ((HitsPlayer1 == 15 || HitsPlayer2 == 15))
                    {
                        base.EndGame();
                        if (HitsPlayer2 == 15)
                        {
                            WinsPlayer2 += 1;
                            Console.WriteLine($"Gana {Player2.Name}");
                        }
                        if (HitsPlayer1 == 15)
                        {
                            WinsPlayer1 += 1;
                            Console.WriteLine($"Gana {Player1.Name}");
                        }
                    }
                }
            }
            if (WinsPlayer1 == 2)
            {
                stadistics.ModifyStatics(Player1, true);
                stadistics.ModifyStatics(Player2, false);
                Console.WriteLine($"{Player1.Name} gana el torneo");
            }
            else if (WinsPlayer2 == 2)
            {
                stadistics.ModifyStatics(Player1, false);
                stadistics.ModifyStatics(Player2, true);
                Console.WriteLine($"{Player2.Name} gana el torneo");
            }
        }
        public override void MatchPlayers()
        {
            Challenge game = new Challenge("Challenge Mode");
            base.MatchPlayers();
        }
    }
}
*/