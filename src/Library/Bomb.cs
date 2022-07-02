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
        private bool Hit;
        private int HitsPlayer1;
        private int HitsPlayer2;
        private int MissedShotsPlayer1 = 0;
        private int MissedShotsPlayer2 = 0;
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
        public Bomb(User player1, User player2, string name) : base(player1, player2, name)
        {
            this.Player1 = player1;
            this.Player2 = player2;
            BoardPlayer1 = new Board(player1);
            BoardPlayer2 = new Board(player2); 
            Administrator.Instance.currentGame.Add(this);
        }
        public override void Attack(User player)
        {
            if (MissedShotsPlayer1 == 3 || MissedShotsPlayer2 == 3)
            {
                if (MissedShotsPlayer1 == 3 && player == this.Player1)
                {
                    bool hit = false;
                    bool outOfBoard = false;
                    System.Console.WriteLine();
                    System.Console.WriteLine($"Ataca {player.Name}:");
                    Console.WriteLine("A donde quiere atacar?");
                    Console.Write("Escriba la primer coordenada(A-J): ");
                    string coord1 = Console.ReadLine();
                    Console.Write("Escriba la segunda coordenada(1-10): ");
                    string coord2 = Console.ReadLine();
                    if (!Board.num.Contains(coord2))
                    {
                        Console.WriteLine("No puede atacar en esta ubicacion");
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
                    if (outOfBoard)
                    {
                        Attack(player);
                    }
                    else
                    {
                        hit = this.BoardPlayer2.CheckShip(coord1,coord2, BoardPlayer2.shipPos,out string shipName);
                        if (hit)
                        {
                            if (shipName.ToLower() == "lancha")
                            {
                                Lancha2Health -=1;
                                if (Lancha2Health == 0)
                                {
                                    Console.WriteLine($"{shipName} Hundido!");
                                }
                                else
                                {
                                    Console.WriteLine("Tocado");
                                }
                            }
                            else if (shipName.ToLower() == "crucero")
                            {
                            Crucero2Health -=1;
                                if (Crucero2Health == 0)
                                {
                                    Console.WriteLine($"{shipName} Hundido!");
                                }
                                else
                                {
                                    Console.WriteLine("Tocado");
                                }
                            }
                            else if (shipName.ToLower() == "submarino")
                            {
                                Submarino2Health -=1;
                                if (Submarino2Health == 0)
                                {
                                    Console.WriteLine($"{shipName} Hundido!");
                                }
                                else
                                {
                                    Console.WriteLine("Tocado");
                                }
                            }
                            else if (shipName.ToLower() == "buque")
                            {
                                Buque2Health -=1;
                                if (Buque2Health == 0)
                                {
                                    Console.WriteLine($"{shipName} Hundido!");
                                }
                                else
                                {
                                    Console.WriteLine("Tocado");
                                }
                            }
                            else if (shipName.ToLower() == "portaaviones")
                            {
                                Portaaviones2Health -=1;
                                if (Portaaviones2Health == 0)
                                {
                                    Console.WriteLine($"{shipName} Hundido!");
                                }
                                else
                                {
                                    Console.WriteLine("Tocado");
                                }
                            }
                            HitsPlayer1 += 1;                    
                        }
                        else
                        {
                            Console.WriteLine("Agua");
                        }
                        List<string> attacks = BoardPlayer2.coordSurround(coord1, coord2);
                        foreach (string attack in attacks)
                        {
                            this.BoardPlayer1.shots.Add(attack.ToUpper());
                        }
                        Console.WriteLine($"Atacó {player.Name}");
                        MissedShotsPlayer1 = 0;
                    }            
                }
                else if (MissedShotsPlayer2 == 3 && player == this.Player2)
                {
                    bool hit = false;
                    bool outOfBoard = false;
                    System.Console.WriteLine();
                    System.Console.WriteLine($"Ataca {player.Name}:");
                    Console.WriteLine("A donde quiere atacar?");
                    Console.Write("Escriba la primer coordenada(A-J): ");
                    string coord1 = Console.ReadLine();
                    Console.Write("Escriba la segunda coordenada(1-10): ");
                    string coord2 = Console.ReadLine();
                    if (!Board.num.Contains(coord2))
                    {
                        Console.WriteLine("No puede atacar en esta ubicacion");
                        System.Console.WriteLine("Esta fuera del tablero");
                        outOfBoard = true;
                    }
                    else if (!Board.abc.Contains(coord1.ToUpper()))
                    {
                        Console.WriteLine("No puede atacar en esta ubicacion");
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
                        List<string> attacks = BoardPlayer1.coordSurround(coord1, coord2);
                        foreach (string attack in attacks)
                        {
                            this.BoardPlayer2.shots.Add(attack.ToUpper());
                        }
                        Console.WriteLine($"Atacó {player.Name}");
                        MissedShotsPlayer2 = 0;
                        }
                    
                    }
                }
                else
                {
                    base.Attack(player);
                    if (!Hit && player == this.Player1)
                    {
                        MissedShotsPlayer1 += 1;
                    }
                    else if (!Hit && player == this.Player2)
                    {
                        MissedShotsPlayer2 += 1;
                    }
                    else if (Hit && player == this.Player1)
                    {
                        MissedShotsPlayer1 = 0;
                    }
                    else if (Hit && player == this.Player2)
                    {
                        MissedShotsPlayer2 = 0;
                    }
                } 
        }
    }
}