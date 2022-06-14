

using System;
using System.Collections.Generic;
using System.Collections;
namespace Library

{
    public class Board
    {
       // private List<Ship> ships = new List<Ship>();
        private static List<string> ABC = new List<string>()
        {
            "/","A","B","C","D","E","F","G","H","I","J"
        };
        private static List<string> row_Num = new List<string>()
        {
            "1","2","3","4","5","6","7","8","9","10"
        };
        private static List<string> char_List =new List<string>()
        {
            "-","X","O"
        };
        //private Ship PlayerShips{get; set;}


        //public List<string> Row_X = new List<string>();
        public List<List<string>> board_Rows = new List<List<string>>();

        //public Board(User Username)
        public Board()
        {
           // this.Username;
            Start_Board();
            
        }

#region ConstructorTablero
        public List<List<string>> Start_Board()
        {   
            List<string> Row_X = new List<string>();          
            for (int i = 0; i <= 10; i++)
            {
                Row_X.Add(ABC[i]);
            }
            board_Rows.Add(Row_X);
            //Esto recorre filas
            for (int y = 0; y < 10; y++)
            {
                List<string> Row_N = new List<string>();
                Row_N.Add(row_Num[y]);
               
                //Esto recorre en cada fila, cada columna que la compone
                for (int x = 0; x < 10; x++)
                {
                    Row_N.Add(char_List[0]);
                }
                board_Rows.Add(Row_N);
            }


            return board_Rows;
        }
#endregion ConstructorTablero
         /*
        public bool CheckPosition(coordinate1, coordinate2, ship)
        {
            for (int z = 1; z <= 11; z++)
            for (int w = 1; w <= 11; w++)
            {
                if board_Rows[w] coordinate1
                {

                } 
            }
        }
        public void Ships_position(PlayerShips.count)
        {
        */

        public void Print_Board()
        {
            string Row_I="";

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
                            Row_I=($"{Row_I}{board_Rows[y][x]:>6}");
                        }
                        else if(x==1)
                        {
                            Row_I=($"{Row_I}  {board_Rows[y][x]:>6}");
                        }
                        else
                        {
                            Row_I=($"{Row_I}  {board_Rows[y][x]:>3}");
                        }
                    }
                    else if(y==10)
                    {
                        if (x==0)
                       {
                           Row_I=($"{board_Rows[y][x]:>3}");
                       }
                       else if (x==1)
                       {
                           Row_I=($"{Row_I} {board_Rows[y][x]:>2}");
                       }
                       else
                       {
                           Row_I=($"{Row_I}  {board_Rows[y][x]:>2}");
                       }
                    } 
                    else
                    {
                       if (x==0)
                       {
                           Row_I=($"{board_Rows[y][x]:>3}");
                       }
                       else
                       {
                           Row_I=($"{Row_I}  {board_Rows[y][x]:>2}");
                       }
                   
                    }
                }
                Console.WriteLine(Row_I);
            }


        }

        public void Edit_Board(string coord1, string coord2)
        {
            if (ABC.Contains(coord1.ToUpper()))
            {
                Console.WriteLine("Coord1 esta dentro de la lista");
            }
            else
            {
                Console.WriteLine("Coord1 no esta dentro de la lista");
            }

            bool hit;
            hit = false;
            int Index_Y;
            int Index_X;

            //Prueba de indices
            int Index_Z;
            Index_Z= ABC.IndexOf(coord1.ToUpper());
            Console.WriteLine($"El indice de {coord1} es: {Index_Z}");
            int Index_K;
            Index_K= row_Num.IndexOf(coord2);
            Console.WriteLine($"El indice de {coord2} es: {Index_K+1}");
            board_Rows[Index_Z+1][Index_K+1]=char_List[1];


            // board_Rows=[[/ABCDEFG][1-X--------][2----------][]]


            for (int y = 0; y < 11; y++)
            {
                if (board_Rows[y][0]==coord2)
                {
                    Index_Y=y;
                    for (int x = 0; x < 11; x++)
                    {
                        if (board_Rows[0][x]==coord1.ToUpper())
                        {
                            Index_X=x;
                            hit=true;
                            if (hit==true)
                            {
                                board_Rows[Index_Y][Index_X]=char_List[1];
                            }
                        }      
                    }
                }
            } 
        }
    }
}


