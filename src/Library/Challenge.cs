using System;

//<summary>
//Por motivos de tiempo, no fuimos capaces de realizar los tests necesarios para
//la clase Challenge, por lo que, al ser una modalidad agregada por nosotros,
//decidimos dejarla sin funcionamiento para esta entrega
//</summary>

namespace Library
{
    public class Challenge : Game
    {
        private User Player1;
        private User Player2;
        private Board BoardPlayer1;
        private Board BoardPlayer2;
        private bool OnGoing;
        private int ChallengeHitsPlayer1;
        private int ChallengeHitsPlayer2;
        private int WinsPlayer1;
        private int WinsPlayer2;
        public Challenge(User player1, User player2, string name) : base(player1, player2, name)
        {
            this.Player1 = player1;
            this.Player2 = player2;
            this.BoardPlayer1 = new Board(Player1);
            this.BoardPlayer2 = new Board(Player2);
            ChallengeHitsPlayer1 = 0;
            ChallengeHitsPlayer2 = 0;
            WinsPlayer1 = 0;
            WinsPlayer1 = 0;
        }


        public override void StartGame()
        {
            System.Console.WriteLine("Comienza la batalla naval!!");
            System.Console.WriteLine("Challenge!!!");
            System.Console.WriteLine($"{Player1.Name} vs {Player2.Name}");

            while (WinsPlayer1 < 2 && WinsPlayer2 < 2)
            {
                int counter = WinsPlayer1 + WinsPlayer2;
                if (counter == 0)
                {
                    System.Console.WriteLine("-- Primer partida --");
                }
                else if (counter == 1)
                {
                    System.Console.WriteLine("-- Segunda partida --");
                }
                else if (counter == 2)
                {
                    System.Console.WriteLine("-- Tercer y últuma partida --");
                }
                ClearBoards(BoardPlayer1, BoardPlayer2);
                System.Console.WriteLine($"\nPosicionamiento de barcos de {Player1.Name}");
                BoardPlayer1.PositionShips();
                System.Console.WriteLine($"\nPosicionamiento de barcos de {Player2.Name}");
                BoardPlayer2.PositionShips();
                User recentAttacker = Player2;
                OnGoing = true;
                while (OnGoing)
                {
                    if (recentAttacker == Player1)
                    {
                        System.Console.WriteLine();
                        System.Console.WriteLine($"Ataca {Player2.Name}:");
                        Console.WriteLine("A donde quiere atacar?");
                        Console.Write("Escriba la primer coordenada(A-J): ");
                        string coord1 = Console.ReadLine();
                        Console.Write("Escriba la segunda coordenada(1-10): ");
                        string coord2 = Console.ReadLine();
                        Attack(coord1, coord2, Player2, BoardPlayer2, Player1, BoardPlayer1);
                        this.BoardPlayer2.PrintBoard(this.BoardPlayer1.shipPos, BoardPlayer2.shots, "EnemyBoard");
                        ShowBoard(Player2, BoardPlayer1, BoardPlayer2);
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
                        Attack(coord1, coord2, Player1, BoardPlayer1, Player2, BoardPlayer2);
                        this.BoardPlayer1.PrintBoard(this.BoardPlayer2.shipPos, this.BoardPlayer1.shots, "EnemyBoard");
                        ShowBoard(Player1, BoardPlayer1, BoardPlayer2);
                        recentAttacker = Player1;
                    }
                    if ((hitsPlayer1 == 1 || hitsPlayer2 == 1))
                    {

                        if (hitsPlayer2 == 1)
                        {
                            WinsPlayer2 += 1;
                            System.Console.WriteLine();
                            Console.WriteLine($"Gana {Player2.Name}");
                            ChallengeHitsPlayer1 = 0;
                            ChallengeHitsPlayer2 = 0;
                            OnGoing = false;
                            hitsPlayer2=0;
                            RestartHits();
                        }
                        if (hitsPlayer1 == 1)
                        {
                            WinsPlayer1 += 1;
                            System.Console.WriteLine();
                            Console.WriteLine($"Gana {Player1.Name}");
                            ChallengeHitsPlayer1 = 0;
                            ChallengeHitsPlayer2 = 0;
                            OnGoing = false;
                            hitsPlayer1=0;
                            RestartHits();
                        }
                    }
                }
            }
            if (WinsPlayer1 == 2)
            {
                Player1.statistics.ModifyStatics(Player1, true);
                Player2.statistics.ModifyStatics(Player2, false);
                Console.WriteLine($"{Player1.Name} gana el Challenge contra {Player2.Name}");
                System.Console.WriteLine("-- Fin del pa partida --");
                base.EndGame();
            }
            else if (WinsPlayer2 == 2)
            {
                Player1.statistics.ModifyStatics(Player1, false);
                Player2.statistics.ModifyStatics(Player2, true);
                Console.WriteLine($"{Player2.Name} gana el Challenge contra {Player1.Name}");
                base.EndGame();
            }
        }
        public void ClearBoards(Board BoardPlayer1, Board BoardPlayer2)
        {
            BoardPlayer1.shipPos.Clear();
            BoardPlayer2.shipPos.Clear();
            BoardPlayer1.shots.Clear();
            BoardPlayer2.shots.Clear();
        }
    }
}