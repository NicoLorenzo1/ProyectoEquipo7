

using System;
using System.Collections.Generic;
using System.Collections;
namespace Proyecto

{
    public class Board
    {
       // private List<Ship> ships = new List<Ship>();
        private static List<string> ABC = new List<string>()
        {
            "/","A","B","C","D","E","F","G","H","I","J"
        };
        private static List<string> num_Filas=new List<string>()
        {
            "1","2","3","4","5","6","7","8","9","10"
        };
        private static List<string> lista_Caracter=new List<string>()
        {
            "-","X","O"
        };
        //private Ship PlayerShips{get; set;}


        //public List<string> fila_X = new List<string>();
        public List<List<string>> Filas_Tablero = new List<List<string>>();

        //public Board(User Username)
        public Board()
        {
           // this.Username;
            Start_Board();
            
        }

#region ConstructorTablero
        public List<List<string>> Start_Board()
        {   
            List<string> fila_X = new List<string>();          
            for (int i = 0; i <= 10; i++)
            {
                fila_X.Add(ABC[i]);
            }
            Filas_Tablero.Add(fila_X);
            //Esto recorre filas
            for (int y = 0; y < 10; y++)
            {
                List<string> fila_N = new List<string>();
                fila_N.Add(num_Filas[y]);
               
                //Esto recorre en cada fila, cada columna que la compone
                for (int x = 0; x < 10; x++)
                {
                    fila_N.Add(lista_Caracter[0]);
                }
                Filas_Tablero.Add(fila_N);
            }


            return Filas_Tablero;
        }
#endregion ConstructorTablero
         /*
        public bool CheckPosition(coordinate1, coordinate2, ship)
        {
            for (int z = 1; z <= 11; z++)
            for (int w = 1; w <= 11; w++)
            {
                if Filas_Tablero[w] coordinate1
                {

                } 
            }
        }
        public void Ships_position(PlayerShips.count)
        {
        */

        public void Print_Board()
        {
            string Fila_I=null;

            //Recorro filas
            for (int y = 0; y < 11; y++)
            {
                //Recorro cada columna que compone a la fila en la que estoy
                for (int x = 0; x < 11; x++)
                {
                    if (y==0)
                    {
                        if (x==0)
                        {
                            Fila_I=($"{Fila_I}{Filas_Tablero[y][x]:>6}");
                        }
                        else if(x==1)
                        {
                            Fila_I=($"{Fila_I}  {Filas_Tablero[y][x]:>6}");
                        }
                        else
                        {
                            Fila_I=($"{Fila_I}  {Filas_Tablero[y][x]:>3}");
                        }
                    }
                    else if(y==10)
                    {
                        if (x==0)
                       {
                           Fila_I=($"{Filas_Tablero[y][x]:>3}");
                       }
                       else if (x==1)
                       {
                           Fila_I=($"{Fila_I} {Filas_Tablero[y][x]:>2}");
                       }
                       else
                       {
                           Fila_I=($"{Fila_I}  {Filas_Tablero[y][x]:>2}");
                       }
                    } 
                    else
                    {
                       if (x==0)
                       {
                           Fila_I=($"{Filas_Tablero[y][x]:>3}");
                       }
                       else
                       {
                           Fila_I=($"{Fila_I}  {Filas_Tablero[y][x]:>2}");
                       }
                   
                    }
                }
                Console.WriteLine(Fila_I);
            }


        }

    }
}


