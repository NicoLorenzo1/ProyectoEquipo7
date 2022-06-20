

using System;
using System.Collections.Generic;
using System.Collections;
namespace Library

{
    public class Board
    {
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
        //public List<List<string>> board_Rows = new List<List<string>>();
        public ArrayList shipPos = new ArrayList();
        public List<string> shots = new List<string>();
        private User PlayerUser;
        public int healthLancha = 1;

        public Board(User player1User)
        //public Board()
        {
           this.PlayerUser = player1User;
           /*
           this.player2User;
           this.PlayerShips = shipPos;
           this.player2Ships;
           this.PlayerShots = shots;
           this.player2Shots;
           */


            //Start_Board();
            //this.Start_Board();
        }

#region ConstructorTablero
        public List<List<string>> Start_Board()
        {   
            List<List<string>> board_Rows = new List<List<string>>();
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
        public void Print_Board(ArrayList refreshShips, List<string> refreshShots , string printMode)
        {
            List<List<string>> board_Rows = Start_Board();
            RefreshBoard(refreshShips, refreshShots, printMode, board_Rows);

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
        public void Edit_Board(string coord1, string coord2, string editor, List<List<string>> board_Rows)
        {   
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
        public void Position_Ships()
        {
            List<List<string>> board_Rows = Start_Board();
            for (int s = 1; s <=5; s++)
            {
                Ship actualShip = new Ship(s);;
                
                while (true)
                {   
                    Console.WriteLine($"Ingrese la posición inicial de {actualShip.Shipname}: ");
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
                            System.Console.WriteLine();
                            System.Console.WriteLine("Dirección:");
                            System.Console.WriteLine("---------------");
                            System.Console.WriteLine("1-Hacia arriba");
                            System.Console.WriteLine("2-Hacia abajo");
                            System.Console.WriteLine("3-Derecha");
                            System.Console.WriteLine("4-Izquierda");
                            System.Console.WriteLine();
                            System.Console.WriteLine("Ingrese la dirección escogida (1-4): ");
                            dir = Console.ReadLine();
                            System.Console.WriteLine();
                            if(dir=="1")
                            {
                                if (Index_Y-actualShip.ShipDim<0)
                                {
                                    System.Console.WriteLine("No podes posicionar un barco en esa dirección");
                                    System.Console.WriteLine("No se puede ubicar barcos fuera del tablero de juego");
                                    System.Console.WriteLine();
                                }
                                else
                                {
                                    bool trigger=false;
                                    for (int x = 0; x < actualShip.ShipDim; x++)
                                    {
                                        string poscheck1;
                                        string poscheck2;
                                        int IndexCheck1;
                                        int IndexCheck2;
                                        bool shipTest;
                                        
                                        IndexCheck1 = (row_Num.IndexOf(entry2));
                                        if(x==0)
                                        {
                                            shipTest=CheckShip(entry1,row_Num[IndexCheck1],this.shipPos, out string shipName);
                                            if (shipTest==true)
                                            {
                                                trigger=true;
                                            }
                                        }
                                        else
                                        {
                                            poscheck1=entry1;
                                            poscheck2=row_Num[IndexCheck1-x];
                                            shipTest=CheckShip(entry1,poscheck2,this.shipPos, out string shipName);
                                            if (shipTest==true)
                                            {
                                                trigger=true;
                                            }
                                        }
                                    }
                                    if (trigger==true)
                                    {
                                        System.Console.WriteLine("No podes posicionar un barco ahi");
                                        System.Console.WriteLine("Ya hay un barco ocupando una de las ubicaciones selecionadas");
                                        System.Console.WriteLine();
                                        
                                    }
                                    else
                                    {
                                        ArrayList posList = new ArrayList();
                                        posList.Add(actualShip.Shipname);
                                        for (int i = 1; i <= actualShip.ShipDim; i++)
                                        {
                                            string pos1;
                                            string pos2;
                                            int Index_K;
                                            int Index_Z;
                                            Index_K= (row_Num.IndexOf(entry2)+1);
                                            if (i==1)
                                            {
                                                Edit_Board(entry1,entry2,"S", board_Rows);                                                
                                                posList.Add(entry1.ToUpper());
                                                posList.Add(entry2);
                                            }
                                            else
                                            {
                                                pos1=entry1;
                                                pos2=row_Num[Index_K-i];
                                                Edit_Board(entry1,pos2,"S", board_Rows);
                                                posList.Add(entry1.ToUpper());
                                                posList.Add(pos2);
                                            }                                           
                                        }
                                        shipPos.Add(posList);
                                        break;
                                    }
                                }
                            }    
                            else if(dir=="2")
                            {
                                if (Index_Y+actualShip.ShipDim>11)
                                {
                                    System.Console.WriteLine("No podes posicionar un barco en esa dirección");
                                    System.Console.WriteLine("No se puede ubicar barcos fuera del tablero de juego");
                                    System.Console.WriteLine();
                                }
                                else
                                {
                                    bool trigger=false;
                                    for (int x = 0; x < actualShip.ShipDim; x++)
                                    {
                                        string poscheck1;
                                        string poscheck2;
                                        int IndexCheck1;
                                        int IndexCheck2;
                                        bool shipTest;

                                        IndexCheck1 = (row_Num.IndexOf(entry2));
                                        if(x==0)
                                        {
                                            shipTest=CheckShip(entry1,row_Num[IndexCheck1],this.shipPos, out string shipName);
                                            if (shipTest==true)
                                            {
                                                trigger=true;
                                            }
                                        }
                                        else
                                        {
                                            poscheck1=entry1;
                                            poscheck2=row_Num[IndexCheck1+x];
                                            shipTest=CheckShip(entry1,poscheck2,this.shipPos, out string shipName);
                                            if (shipTest==true)
                                            {
                                                trigger=true;
                                            }
                                        }
                                    }
                                    if (trigger==true)
                                    {
                                        System.Console.WriteLine("No podes posicionar un barco ahi");
                                        System.Console.WriteLine("Ya hay un barco ocupando una de las ubicaciones selecionadas");
                                        System.Console.WriteLine();
                                    }
                                    else
                                    {
                                        ArrayList posList = new ArrayList();
                                        posList.Add(actualShip.Shipname);
                                        for (int i = 1; i <= actualShip.ShipDim; i++)
                                        {
                                            string pos1;
                                            string pos2;
                                            int Index_K;
                                            int Index_Z;
                                            Index_K= (row_Num.IndexOf(entry2)+1);
                                            if (i==1)
                                            {
                                                //ACORDATE DE SACAR ESTE COMENT

                                                //Edit_Board(entry1,entry2,"S");                                                
                                                posList.Add(entry1.ToUpper());
                                                posList.Add(entry2);
                                            }
                                            else
                                            {
                                                pos1=entry1;
                                                pos2=row_Num[Index_K+(i-2)];

                                                //ACORDATE DE SACAR ESTE COMENT

                                                //Edit_Board(entry1,pos2,"S");
                                                posList.Add(entry1.ToUpper());
                                                posList.Add(pos2);
                                            }                                           
                                        }
                                        shipPos.Add(posList);
                                        break;
                                    }
                                }
                            }
                            else if(dir=="3")
                            {
                                if (Index_X+actualShip.ShipDim>11)
                                {
                                    System.Console.WriteLine("No podes posicionar un barco en esa dirección");
                                    System.Console.WriteLine("No se puede ubicar barcos fuera del tablero de juego");
                                    System.Console.WriteLine();
                                }
                                else
                                {
                                    bool trigger=false;

                                    for (int x = 0; x < actualShip.ShipDim; x++)
                                    {
                                        string poscheck1;
                                        string poscheck2;
                                        int IndexCheck1;
                                        int IndexCheck2;
                                        bool shipTest;

                                        IndexCheck1 = (row_Num.IndexOf(entry2));
                                        IndexCheck2 = (ABC.IndexOf(entry1.ToUpper()));
                                        if (x==0)
                                        {
                                            shipTest=CheckShip(ABC[IndexCheck2],entry2,this.shipPos,out string shipName);
                                            //System.Console.WriteLine(shipTest);
                                            if (shipTest==true)
                                            {
                                                trigger=true;
                                            }
                                        }
                                        else
                                        {
                                            poscheck1=ABC[IndexCheck2+1];
                                            poscheck2=entry2;
                                            shipTest=CheckShip(poscheck1,entry2,this.shipPos, out string shipName);
                                            if (shipTest==true)
                                            {
                                                trigger=true;
                                            }
                                        } 
                                    }
                                    if (trigger==true)
                                    {
                                        System.Console.WriteLine("No podes posicionar un barco ahi");
                                        System.Console.WriteLine("Ya hay un barco ocupando una de las ubicaciones selecionadas");
                                        System.Console.WriteLine();
                                    }
                                    else
                                    {
                                        ArrayList posList = new ArrayList();
                                        posList.Add(actualShip.Shipname);
                                        for (int i = 1; i <= actualShip.ShipDim; i++)
                                        {
                                            string pos1;
                                            string pos2;
                                            int Index_K;
                                            int Index_Z;
                                            Index_Z= (ABC.IndexOf(entry1.ToUpper()));
                                            if (i==1)
                                            {
                                                Edit_Board(entry1,entry2,"S", board_Rows);                                                
                                                posList.Add(entry1.ToUpper());
                                                posList.Add(entry2);
                                            }
                                            else
                                            {
                                                pos1=ABC[Index_Z+(i-1)];
                                                pos2=entry2;
                                                Edit_Board(pos1,entry2,"S", board_Rows);
                                                posList.Add(entry1.ToUpper());
                                                posList.Add(pos2);
                                            }                                           
                                        }
                                        shipPos.Add(posList);
                                        break;
                                    }    
                                }
                            }
                            else if(dir=="4")
                            {
                                if (Index_X-actualShip.ShipDim<1)
                                {
                                    System.Console.WriteLine("No podes posicionar un barco en esa dirección");
                                    System.Console.WriteLine("No se puede ubicar barcos fuera del tablero de juego");
                                    System.Console.WriteLine();
                                }
                                else
                                {
                                    bool trigger=false;

                                    for (int x = 0; x < actualShip.ShipDim; x++)
                                    {
                                        string poscheck1;
                                        string poscheck2;
                                        int IndexCheck1;
                                        int IndexCheck2;
                                        bool shipTest;

                                        IndexCheck1 = (row_Num.IndexOf(entry2));
                                        IndexCheck2 = (ABC.IndexOf(entry1.ToUpper()));
                                        if (x==0)
                                        {
                                            shipTest=CheckShip(ABC[IndexCheck2],entry2,this.shipPos, out string shipName);
                                            if (shipTest==true)
                                            {
                                                trigger=true;
                                            }
                                        }
                                        else
                                        {
                                            poscheck1=ABC[IndexCheck2-1];
                                            poscheck2=entry2;
                                            shipTest=CheckShip(poscheck1,entry2,this.shipPos, out string shipName);
                                            if (shipTest==true)
                                            {
                                                trigger=true;
                                            }
                                        }
                                    }
                                    if (trigger==true)
                                    {
                                        System.Console.WriteLine("No podes posicionar un barco ahi");
                                        System.Console.WriteLine("Ya hay un barco ocupando una de las ubicaciones selecionadas");
                                        System.Console.WriteLine();
                                    }
                                    else
                                    {
                                        ArrayList posList = new ArrayList();
                                        posList.Add(actualShip.Shipname);
                                        for (int i = 1; i <= actualShip.ShipDim; i++)
                                        {
                                            string pos1;
                                            string pos2;
                                            int Index_K;
                                            int Index_Z;
                                            Index_Z= (ABC.IndexOf(entry1.ToUpper()));
                                            if (i==1)
                                            {
                                                Edit_Board(entry1,entry2,"S", board_Rows);                                                
                                                posList.Add(entry1.ToUpper());
                                                posList.Add(entry2);
                                            }
                                            else
                                            {
                                                pos1=ABC[Index_Z-(i-1)];
                                                pos2=entry2;
                                                Edit_Board(pos1,entry2,"S", board_Rows);
                                                posList.Add(entry1.ToUpper());
                                                posList.Add(pos2);
                                            }                                           
                                        }
                                        shipPos.Add(posList);
                                        break;                  
                                    }
                                }
                            }
                            else
                            {
                                System.Console.WriteLine();
                                System.Console.WriteLine("No es una dirección válida");
                                System.Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("No es una coordenada posible");
                            System.Console.WriteLine();
                        }
                    }    
                    else
                    {
                        Console.WriteLine("No es una coordenada posible");
                        System.Console.WriteLine();
                    }
                }
            }
        }
        public void showList()
        {
            foreach (ArrayList item in shipPos)
            {
                System.Console.WriteLine($"{item[0]} está ubicado en: ");

                for (int i = 1; i < (item.Count-1); i+=2)
                {
                    for (int j = i; j <= (i+1); j++)
                    {
                     System.Console.Write($"[{item[j]}] ");                           
                    }
                    if (i==(item.Count-2))
                    {
                        System.Console.WriteLine();
                    }
                    else
                    {
                        System.Console.Write(",");
                    }
                }
                System.Console.WriteLine();
            }
        }
        public bool CheckShip(string check1, string check2, ArrayList chosenShips, out string shipName)
        {
            bool coincidence = false;
            foreach (ArrayList item in chosenShips)
            {
                for (int i = 1; i <= (item.Count-1); i++)
                {
                    string checker1 = Convert.ToString(item[i]);
                    string checker2 = check1.ToUpper();
                    
                    if (checker1==checker2)
                    {
                        string numCheck = Convert.ToString(item[i+1]);
                        if (check2==numCheck)
                        {
                            shipName = Convert.ToString(item[0]);
                            coincidence=true;
                            return coincidence;
                        }
                        else
                        {
                        }
                    }
                    else
                    {
                    }                                       
                }                    
            }
            shipName = "";
            return coincidence;
        }
        public void RefreshBoard(ArrayList refreshShips, List<string> refreshShots , string printMode, List<List<string>> board_Rows)
        {
            if (printMode=="MyBoard")
            {
                foreach (ArrayList item in refreshShips)
                {
                    for (int i = 1; i <= (item.Count-1); i+=2)
                    {
                        string setter1 = Convert.ToString(item[i]);
                        string setter2 = Convert.ToString(item[i+1]);
                        Edit_Board(setter1,setter2,"S", board_Rows);                                
                    }                    
                }
                for (int i = 0; i < refreshShots.Count; i+=2)
                {
                    string setter1 = Convert.ToString(refreshShots[i]);
                    string setter2 = Convert.ToString(refreshShots[i+1]);

                    bool result=CheckShip(setter1,setter2,refreshShips, out string shipName);
                    if (result == true)
                    {
                        Edit_Board(setter1,setter2,"X", board_Rows); 
                    }
                    else
                    {
                        Edit_Board(setter1,setter2,"O", board_Rows); 
                    }  
                }
            }
            else if (printMode=="EnemyBoard")
            {
                for (int i = 0; i < refreshShots.Count; i+=2)
                {
                    string setter1 = Convert.ToString(refreshShots[i]);
                    string setter2 = Convert.ToString(refreshShots[i+1]);

                    //Hay que agregar parametro de shipPos al checkship porque hay que pasarle en que lista de barcos mirar
                    bool result=CheckShip(setter1,setter2,refreshShips, out string shipName);
                    if (result == true)
                    {
                        Edit_Board(setter1,setter2,"X", board_Rows); 
                    }
                    else
                    {
                        Edit_Board(setter1,setter2,"O", board_Rows); 
                    }  
                }
            }
        }
        public static List<string> abc
        {
            get
            {
                return ABC;
            }
        }
        public static List<string> num
        {
            get
            {
                return row_Num;
            }
        }
        
/*        public void PrintSelector(User requestor, string action)
        {
            /*
            Action1 = My board
            Action2 = Enemy Board
            //

            if (requestor==this.player1 && action==1)
            {
                boardMaker=Start_Board();


            }
            
        }*/
        
    }
}



