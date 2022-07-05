using System;

//<summary>
//La clase Bomb es una de las modalidades que decidimos agregar, que a día de hoy
//no funciona como debería de hacerlo, ya que no hemos logrado implementar una
//manera de que el ataque sea un cuadrado de 3x3 con el centro en las coordenadas
//que se le pasan
//</summary>

namespace Library
{
    public class Bomb : Game
    {
        private User Player1;
        private User Player2;
        private Board BoardPlayer1;
        private Board BoardPlayer2;
        private bool OnGoing;
        private bool Hit;
        private int MissedShots1;
        private int MissedShots2;
        public Bomb(User player1, User player2, string name) : base(player1, player2, name)
        {
            this.Player1 = player1;
            this.Player2 = player2;
            BoardPlayer1 = new Board(player1);
            BoardPlayer2 = new Board(player2);
            this.MissedShots1 = 0;
            this.MissedShots2 = 0;
        }

        public override void StartGame()
        {
            System.Console.WriteLine("Comienza la batalla naval!!");
            System.Console.WriteLine("Modo Bomb");
            System.Console.WriteLine($"{Player1.Name} vs {Player2.Name}");
            System.Console.WriteLine();

            System.Console.WriteLine($"Posicionamiento de barcos de {Player1.Name}");
            BoardPlayer1.PositionShips();
            System.Console.WriteLine($"Posicionamiento de barcos de {Player2.Name}");
            BoardPlayer2.PositionShips();

            User recentAttacker = this.Player2;

            OnGoing = true;
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
                    this.Attack(coord1, coord2, this.Player2, this.BoardPlayer2, this.Player1, this.BoardPlayer1);
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
                    this.Attack(coord1, coord2, this.Player1, this.BoardPlayer1, this.Player2, this.BoardPlayer2);
                    System.Console.WriteLine();
                    this.BoardPlayer1.PrintBoard(BoardPlayer2.shipPos, BoardPlayer1.shots, "EnemyBoard");
                    ShowBoard(this.Player1, BoardPlayer1, BoardPlayer2);
                    recentAttacker = Player1;
                }
                if (hitsPlayer1 == 15 || hitsPlayer2 == 15)
                {
                    EndGame();
                    if (hitsPlayer2 == 15)
                    {
                        Player1.statistics.ModifyStatics(Player1, false);
                        Player2.statistics.ModifyStatics(Player2, true);
                        System.Console.WriteLine();
                        Console.WriteLine($"Ha ganado {Player2.Name}!!");
                    }
                    if (hitsPlayer1 == 15)
                    {
                        Player1.statistics.ModifyStatics(Player1, true);
                        Player2.statistics.ModifyStatics(Player1, false);
                        System.Console.WriteLine();
                        Console.WriteLine($"Ha ganado {Player1.Name}!!");
                    }
                }
            }
        }
        public override void Attack(string coord1, string coord2, User attacker, Board attackerBoard, User defender, Board defenderBoard)
        {

            if (attacker == this.Player1)
            {
                //bool outOfBoard = CoordCheck(coord1, coord2);
                //bool alreadyShot = ShotHistory(coord1, coord2, attackerBoard);

                // #######################
                if (MissedShots1 == 1)
                {
                    //System.Console.WriteLine("Entraste al tirador de bombas");
                    List<string> bombita = this.BoardPlayer1.coordSurround(coord1, coord2);
                    for (int i = 0; i < bombita.Count; i += 2)
                    {
                        string setter1 = Convert.ToString(bombita[i]);
                        string setter2 = Convert.ToString(bombita[i + 1]);
                        System.Console.Write($"{setter1}{setter2} ");

                        bool repeatedShot = ShotHistory(setter1, setter2, attackerBoard);
                        if (repeatedShot == false)
                        {
                            this.BoardPlayer1.shots.Add(setter1);
                            this.BoardPlayer1.shots.Add(setter2);
                            //defenderBoard.showList();
                            (bool hit, string currentShipName) = defenderBoard.CheckShip(setter1, setter2, defenderBoard.shipPos);
                            if (hit==true)
                            {
                                System.Console.Write($"{setter1}{setter2} -> ");
                                (bool sink, bool wreck) = ShipMessage(currentShipName, attacker);
                                hitsPlayer1 += 1;
                            }
                            else
                            {
                                System.Console.Write($"{setter1}{setter2} -> ");
                                Console.WriteLine("Agua");
                            }

                        }
                        else
                        {
                            repeatedShot = true;
                        }
                    }
                    MissedShots1 = 0;
                }
                // #######################
                else
                {
                    base.Attack(coord1, coord2, this.Player1, this.BoardPlayer1, this.Player2, this.BoardPlayer2);
                    MissedShots1 += 1;
                }
            }
            else if (attacker == this.Player2)
            {
                //bool outOfBoard = CoordCheck(coord1, coord2);
                //bool alreadyShot = ShotHistory(coord1, coord2, attackerBoard);

                // #######################
                if (MissedShots2 == 1)
                {
                    List<string> bombita = this.BoardPlayer2.coordSurround(coord1, coord2);
                    for (int i = 0; i < bombita.Count; i += 2)
                    {
                        string setter1 = Convert.ToString(bombita[i]);
                        string setter2 = Convert.ToString(bombita[i + 1]);

                        bool repeatedShot = ShotHistory(setter1, setter2, attackerBoard);
                        if (repeatedShot == false)
                        {
                            this.BoardPlayer2.shots.Add(setter1);
                            this.BoardPlayer2.shots.Add(setter2);
                            (bool hit, string currentShipName) = defenderBoard.CheckShip(coord1, coord2, defenderBoard.shipPos);
                            if (hit==true)
                            {
                                System.Console.Write($"{setter1}{setter2} -> ");
                                (bool sink, bool wreck) = ShipMessage(currentShipName, attacker);
                                hitsPlayer1 += 1;
                            }
                            else
                            {
                                System.Console.Write($"{setter1}{setter2} -> ");
                                Console.WriteLine("Agua");
                            }
                        }
                        else
                        {
                            repeatedShot = true;
                        }
                    }
                    
                    MissedShots2 = 0;
                }
                // #######################
                else
                {
                    base.Attack(coord1, coord2, this.Player2, this.BoardPlayer2, this.Player1, this.BoardPlayer1);
                    MissedShots2 += 1;
                }
            }
        }
    }
}
