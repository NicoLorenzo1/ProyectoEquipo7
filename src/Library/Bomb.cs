using System;

/// <summary>
/// Clase bomb la cual es otra de las nuevas funcionalidades, esta actualmente esta funcionando por consola ya que no llegamos con el tiempo necesario para
/// implementarlo con el bot e telegram.
/// </summary>

namespace Library
{
    public class Bomb : Game
    {
        private Board BoardPlayer1;
        private Board BoardPlayer2;
        private bool OnGoing;
        private int BombHitsPlayer1;
        private int BombHitsPlayer2;
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
        /// <summary>
        /// inicia la instancia del modo de juego
        /// </summary>
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

            OnGoing = true && !Administrator.Instance.BotEnabled; // Para evitar que al jugar en Telegram se ejecuten los Console.ReadLine
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
                    this.Attack(coord1, coord2, this.Player2/*, this.BoardPlayer2, this.Player1, this.BoardPlayer1*/);
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
                    this.Attack(coord1, coord2, this.Player1/*, this.BoardPlayer1, this.Player2, this.BoardPlayer2*/);
                    System.Console.WriteLine();
                    this.BoardPlayer1.PrintBoard(BoardPlayer2.shipPos, BoardPlayer1.shots, "EnemyBoard");
                    ShowBoard(this.Player1, BoardPlayer1, BoardPlayer2);
                    recentAttacker = Player1;
                }
                if (BombHitsPlayer1 == 15 || BombHitsPlayer2 == 15)
                {
                    EndGame();
                    if (BombHitsPlayer2 == 15)
                    {
                        Player1.statistics.ModifyStatics(Player1, false);
                        Player2.statistics.ModifyStatics(Player2, true);
                        System.Console.WriteLine();
                        Console.WriteLine($"Ha ganado {Player2.Name}!!");
                    }
                    if (BombHitsPlayer1 == 15)
                    {
                        Player1.statistics.ModifyStatics(Player1, true);
                        Player2.statistics.ModifyStatics(Player1, false);
                        System.Console.WriteLine();
                        Console.WriteLine($"Ha ganado {Player1.Name}!!");
                    }
                }
            }
        }

        /// <summary>
        /// Método de ataque
        /// </summary>
        /// <param name="coord1">Primer valor de la coordenada de ataque</param>
        /// <param name="coord2">Segundo valor de la coordenada de ataque</param>
        /// <param name="attacker">Jugador que realiza el ataque</param>
        /// <returns>Devuelve el resultado del ataque</returns>
        public override string Attack(string coord1, string coord2, User attacker)
        {
            Board attackerBoard, defenderBoard;
            User defender;
            string result = "";
            if (attacker == this.Player1)
            {
                attacker = Player1;
                defender = Player2;
                attackerBoard = BoardPlayer1;
                defenderBoard = BoardPlayer2;
            }
            else
            {
                attacker = Player2;
                defender = Player1;
                attackerBoard = BoardPlayer2;
                defenderBoard = BoardPlayer1;
            }

            bool outOfBoard = CoordCheck(coord1, coord2);
            bool alreadyShot = ShotHistory(coord1, coord2, attackerBoard);

            // #######################
            if ((attacker == Player1 && MissedShots1 == 1) || attacker == Player2 && MissedShots2 == 1)
            {
                System.Console.WriteLine("Entraste al tirador de bombas");
                List<string> bombita = attackerBoard.coordSurround(coord1, coord2);
                for (int i = 0; i < bombita.Count; i += 2)
                {
                    string setter1 = Convert.ToString(bombita[i]);
                    string setter2 = Convert.ToString(bombita[i + 1]);

                    bool repeatedShot = ShotHistory(setter1, setter2, attackerBoard);
                    if (repeatedShot == false)
                    {
                        attackerBoard.shots.Add(setter1);
                        attackerBoard.shots.Add(setter2);
                        (bool hit, string currentShipName) = defenderBoard.CheckShip(coord1, coord2, defenderBoard.shipPos);
                        if (hit)
                        {
                            System.Console.Write($"{setter1}{setter2} -> ");
                            (bool sink, bool wreck) = ShipMessage(currentShipName, attacker);
                            BombHitsPlayer1 += 1;
                            result = sink ? "Hundido" : "Tocado";

                        }
                        else
                        {
                            System.Console.Write($"{setter1}{setter2} -> ");
                            Console.WriteLine("Agua");
                            result = "Agua";
                        }

                    }
                }
                // MissedShots1 corresponde a player1. Si el attacker es player1 entonces si igualo a 0 de lo contrario lo dejo con el mismo valor
                // Lo mismo con MissedShots2
                MissedShots1 = attacker == Player1 ? 0 : MissedShots1;
                MissedShots2 = attacker == Player2 ? 0 : MissedShots2;
            }
            // #######################
            else
            {
                result = base.Attack(coord1, coord2, this.Player1/*, this.BoardPlayer1, this.Player2, this.BoardPlayer2*/);
                MissedShots1 += 1;
            }
            return result;
        }
    }
}
