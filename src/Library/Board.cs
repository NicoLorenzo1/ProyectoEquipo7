

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
            "-","X","O","S"
        };
        //private Ship PlayerShips{get; set;}


        //public List<string> Row_X = new List<string>();
        public List<List<string>> board_Rows = new List<List<string>>();

        //public Board(User Username)
        public Board()
        {
           // this.Username;
            Start_Board();
            //this.Start_Board();
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
        public void Edit_Board(string coord1, string coord2, string editor)

        {
            
            if (ABC.Contains(coord1.ToUpper()))
            {
                Console.WriteLine($"{coord1} es una coordenada válida");
            }
            else
            {
                Console.WriteLine($"{coord1} no es una coordenada válida");
            }
            

/*
########################################################################################
            //Prueba de indices
            int Index_Z;
            int Index_K;
            Index_Z=coord1;
            Index_K=coord2;
            //Index_Z= ABC.IndexOf(coord1.ToUpper());
            //Console.WriteLine($"El indice de {coord1.ToUpper()} es: {Index_Z}");
            //Index_K= (row_Num.IndexOf(coord2)+1);
            //Console.WriteLine($"El indice de {coord2} es: {Index_K}");
            if (editor=="S")
            {
                //board_Rows[Index_K][Index_Z]=char_List[3];
                board_Rows[Index_K][Index_Z]=char_List[3];
            }
########################################################################################
*/
            


            // board_Rows=[[/,A,B,C,D,E,F,G,H,I,J][1-X--------][2----------][]]

            
            for (int y = 0; y < 11; y++)
            {
                if (board_Rows[y][0]==coord2)
                {
                    int Index_Y;
                    Index_Y=y;
                    for (int x = 0; x < 11; x++)
                    {
                        if (board_Rows[0][x]==coord1.ToUpper())
                        {
                            int Index_X;
                            Index_X=x;
                            //hit=true;
                            //if (hit==true)
                            if (editor== "-")
                            {
                                board_Rows[Index_Y][Index_X]=char_List[0];
                            }
                            else if(editor.ToUpper() == "X")
                            {
                                board_Rows[Index_Y][Index_X]=char_List[1];
                            }
                            else if(editor.ToUpper() == "O")
                            {
                                board_Rows[Index_Y][Index_X]=char_List[2];
                            }
                            else if(editor.ToUpper() == "S")
                            {
                                board_Rows[Index_Y][Index_X]=char_List[3];
                            }
                            else
                            {
                                System.Console.WriteLine("No es un caractér válido para introducir en el tablero");
                            }
                        }      
                    }
                }
            } 
            
        }

        public ArrayList shipPos = new ArrayList();
        public void Position_Ships()
        {
            for (int s = 1; s <=5; s++)
            {
                Ship actualShip = new Ship(s);;
                Console.WriteLine($"Ingrese la posición inicial de {actualShip.Shipname}: ");
                while (true)
                {
                    Console.WriteLine("Ingrese la cordenada 1(A-J): ");
                    string entry1;
                    entry1=Console.ReadLine();
                    if (ABC.Contains(entry1.ToUpper()))
                    {
                        int Index_X;
                        Index_X= ABC.IndexOf(entry1.ToUpper());
        

                        string entry2;
                        Console.WriteLine("Ingrese la cordenada 2(1-10): ");
                        entry2=Console.ReadLine();
                        if (row_Num.Contains(entry2))
                        {
                            int Index_Y;
                            Index_Y= row_Num.IndexOf(entry2)+1;
                            string dir;
                            System.Console.WriteLine("Dirección:");
                            System.Console.WriteLine("---------------:");
                            System.Console.WriteLine("1-Hacia arriba");
                            System.Console.WriteLine("2-Hacia abajo");
                            System.Console.WriteLine("3-Derecha");
                            System.Console.WriteLine("4-Izquierda");
                            dir = Console.ReadLine();
                            if(dir=="1")
                            {
                                if (Index_Y-actualShip.ShipDim<0)
                                {
                                    System.Console.WriteLine("No podes posicionar un barco en esa dirección");
                                }
                                else
                                {
                                    ArrayList posList = new ArrayList();
                                    posList.Add(actualShip.Shipname);
                                    for (int i = 1; i <= actualShip.ShipDim; i++)
                                    {
                                        List<int> coordList;
                                        string pos1;
                                        string pos2;
                                        int Index_K;
                                        int Index_Z;
                                        Index_K= (row_Num.IndexOf(entry2)+1);
                                        if (i==1)
                                        {
                                            Edit_Board(entry1,entry2,"S");                                                
                                            posList.Add(entry1.ToUpper());
                                            posList.Add(entry2);
                                        }
                                        else
                                        {
                                            pos1=entry1;
                                            pos2=row_Num[Index_K-i];
                                            Edit_Board(entry1,pos2,"S");
                                            posList.Add(entry1);
                                            posList.Add(pos2);
                                        }                                           
                                        shipPos.Add(posList);
                                    }
                                    break;
                                }
                            }    
                            else if(dir=="2")
                            {
                                //System.Console.WriteLine($"El Index_Y es: {Index_Y} y el actualShip.ShipDim es: {actualShip.ShipDim}");
                                //System.Console.WriteLine("Tiene que superar la condición Index_Y-actualShip.ShipDim>10 para que le diga que no");
                                if (Index_Y+actualShip.ShipDim>11)
                                {
                                    System.Console.WriteLine("No podes posicionar un barco en esa dirección");
                                }
                                else
                                {
                                    ArrayList posList = new ArrayList();
                                    posList.Add(actualShip.Shipname);
                                    for (int i = 1; i <= actualShip.ShipDim; i++)
                                    {
                                        List<int> coordList;
                                        string pos1;
                                        string pos2;
                                        int Index_K;
                                        int Index_Z;
                                        Index_K= (row_Num.IndexOf(entry2)+1);
                                        if (i==1)
                                        {
                                            Edit_Board(entry1,entry2,"S");                                                
                                            posList.Add(entry1.ToUpper());
                                            posList.Add(entry2);
                                        }
                                        else
                                        {
                                            pos1=entry1;
                                            pos2=row_Num[Index_K+(i-2)];
                                            Edit_Board(entry1,pos2,"S");
                                            posList.Add(entry1);
                                            posList.Add(pos2);
                                        }                                           
                                        shipPos.Add(posList);
                                    }
                                    break;
                                }
                            }
                            else if(dir=="3")
                            {
                                //System.Console.WriteLine($"El Index_Y es: {Index_Y} y el actualShip.ShipDim es: {actualShip.ShipDim}");
                                //System.Console.WriteLine("Tiene que superar la condición Index_Y-actualShip.ShipDim>10 para que le diga que no");
                                if (Index_X+actualShip.ShipDim>11)
                                {
                                    System.Console.WriteLine("No podes posicionar un barco en esa dirección");
                                }
                                else
                                {
                                    ArrayList posList = new ArrayList();
                                    posList.Add(actualShip.Shipname);
                                    for (int i = 1; i <= actualShip.ShipDim; i++)
                                    {
                                        List<int> coordList;
                                        string pos1;
                                        string pos2;
                                        int Index_K;
                                        int Index_Z;
                                        Index_Z= (ABC.IndexOf(entry1.ToUpper()));
                                        if (i==1)
                                        {
                                            Edit_Board(entry1,entry2,"S");                                                
                                            posList.Add(entry1.ToUpper());
                                            posList.Add(entry2);
                                        }
                                        else
                                        {
                                            pos1=ABC[Index_Z+(i-1)];
                                            pos2=entry2;
                                            Edit_Board(pos1,entry2,"S");
                                            posList.Add(entry1);
                                            posList.Add(pos2);
                                        }                                           
                                        shipPos.Add(posList);
                                    }
                                    break;
                                }
                            }
                            else if(dir=="4")
                            {
                                //System.Console.WriteLine($"El Index_Y es: {Index_Y} y el actualShip.ShipDim es: {actualShip.ShipDim}");
                                //System.Console.WriteLine("Tiene que superar la condición Index_Y-actualShip.ShipDim>10 para que le diga que no");
                                if (Index_X-actualShip.ShipDim<1)
                                {
                                    System.Console.WriteLine("No podes posicionar un barco en esa dirección");
                                }
                                else
                                {
                                    ArrayList posList = new ArrayList();
                                    posList.Add(actualShip.Shipname);
                                    for (int i = 1; i <= actualShip.ShipDim; i++)
                                    {
                                        List<int> coordList;
                                        string pos1;
                                        string pos2;
                                        int Index_K;
                                        int Index_Z;
                                        Index_Z= (ABC.IndexOf(entry1.ToUpper()));
                                        if (i==1)
                                        {
                                            Edit_Board(entry1,entry2,"S");                                                
                                            posList.Add(entry1.ToUpper());
                                            posList.Add(entry2);
                                        }
                                        else
                                        {
                                            pos1=ABC[Index_Z-(i-1)];
                                            pos2=entry2;
                                            Edit_Board(pos1,entry2,"S");
                                            posList.Add(entry1);
                                            posList.Add(pos2);
                                        }                                           
                                        shipPos.Add(posList);
                                    }
                                    break;
                                }
                            }
                            else
                            {

                            }
                        }
                    }    
                    else
                    {
                        Console.WriteLine("No es una coordenada posible");
                    }
                }
            }
        }
        
        public void showList()
        {
            foreach (ArrayList item in shipPos)
            {
                System.Console.WriteLine($"{item}");
            }
            //System.Console.WriteLine(shipPos[0][0]); 
        }      
    }
}




