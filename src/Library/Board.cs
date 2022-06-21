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
        private static List<string> rowNum = new List<string>()
        {
            "1","2","3","4","5","6","7","8","9","10"
        };
        private static List<string> charList =new List<string>()
        {
            "-","X","O","S"
        };


        public ArrayList shipPos = new ArrayList();
        public List<string> shots = new List<string>();
        private User PlayerUser;

        //public Board()
        public Board(User player1User)
        {
           this.PlayerUser = player1User;
           /*
           this.player2User;
           this.PlayerShips = shipPos;
           this.player2Ships;
           this.PlayerShots = shots;
           this.player2Shots;
           */
        }
#region ConstructorTablero
        public List<List<string>> StartBoard()
        {   
            List<List<string>> boardRows = new List<List<string>>();
            List<string> RowX = new List<string>();          
            for (int i = 0; i <= 10; i++)
            {
                RowX.Add(ABC[i]);
            }
            boardRows.Add(RowX);
            //Esto recorre filas
            for (int y = 0; y < 10; y++)
            {
                List<string> RowN = new List<string>();
                RowN.Add(rowNum[y]);
               
                //Esto recorre en cada fila, cada columna que la compone
                for (int x = 0; x < 10; x++)
                {
                    RowN.Add(charList[0]);
                }
                boardRows.Add(RowN);
            }
            return boardRows;
        }
#endregion ConstructorTablero

        //<summary>
        //Por Creator, el responsable de conocer las lineas del tablero es la clase Board
        //y el responsable de imprimirlas debe ser él
        //</summary>
        public void PrintBoard(ArrayList refreshShips, List<string> refreshShots , string printMode)
        {
            List<List<string>> boardRows = StartBoard();
            RefreshBoard(refreshShips, refreshShots, printMode, boardRows);

            string RowI="";
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
                            RowI=($"{RowI}{boardRows[y][x]:>6}");
                        }
                        else if(x==1)
                        {
                            RowI=($"{RowI}  {boardRows[y][x]:>6}");
                        }
                        else
                        {
                            RowI=($"{RowI}  {boardRows[y][x]:>3}");
                        }
                    }
                    else if(y==10)
                    {
                        if (x==0)
                       {
                           RowI=($"{boardRows[y][x]:>3}");
                       }
                       else if (x==1)
                       {
                           RowI=($"{RowI} {boardRows[y][x]:>2}");
                       }
                       else
                       {
                           RowI=($"{RowI}  {boardRows[y][x]:>2}");
                       }
                    } 
                    else
                    {
                       if (x==0)
                       {
                           RowI=($"{boardRows[y][x]:>3}");
                       }
                       else
                       {
                           RowI=($"{RowI}  {boardRows[y][x]:>2}");
                       }
                    }
                }
                Console.WriteLine(RowI);
            }
        }
        //<summary>
        //Por Creator, el responsable de conocer las lineas del tablero es la clase Board
        //y el responsable de editarlas debe ser él
        //</summary>
        public void EditBoard(string coord1, string coord2, string editor, List<List<string>> boardRows)
        {   
            for (int y = 0; y < 11; y++)
            {
                if (boardRows[y][0]==coord2)
                {
                    int IndexY;
                    IndexY=y;
                    for (int x = 0; x < 11; x++)
                    {
                        if (boardRows[0][x]==coord1.ToUpper())
                        {
                            int IndexX;
                            IndexX=x;
                            if (editor== "-")
                            {
                                boardRows[IndexY][IndexX]=charList[0];
                            }
                            else if(editor.ToUpper() == "X")
                            {
                                boardRows[IndexY][IndexX]=charList[1];
                            }
                            else if(editor.ToUpper() == "O")
                            {
                                boardRows[IndexY][IndexX]=charList[2];
                            }
                            else if(editor.ToUpper() == "S")
                            {
                                boardRows[IndexY][IndexX]=charList[3];
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
        //<summary>
        //Por Expert, al Board conocer lo que hay en cada posición del tablero, es el responsable
        //de colocar los barcos en dicho tablero
        //</summary>
        public void PositionShips()
        {
            List<List<string>> boardRows = StartBoard();
            for (int s = 1; s <=5; s++)
            {
                Ship actualShip = new Ship(s);;
                
                while (true)
                {   
                    Console.WriteLine($"Ingrese la posición inicial de {actualShip.Shipname}: ");
                    Console.Write("Ingrese la cordenada 1(A-J): ");
                    string entry1;
                    entry1=Console.ReadLine();
                    if (ABC.Contains(entry1.ToUpper()))
                    {
                        int IndexX;
                        IndexX= ABC.IndexOf(entry1.ToUpper());
        
                        string entry2;
                        Console.Write("Ingrese la cordenada 2(1-10): ");
                        entry2=Console.ReadLine();
                        if (rowNum.Contains(entry2))
                        {
                            int IndexY;
                            IndexY= rowNum.IndexOf(entry2)+1;
                            string dir;
                            System.Console.WriteLine();
                            System.Console.WriteLine("Dirección:");
                            System.Console.WriteLine("---------------");
                            System.Console.WriteLine("1-Hacia arriba");
                            System.Console.WriteLine("2-Hacia abajo");
                            System.Console.WriteLine("3-Derecha");
                            System.Console.WriteLine("4-Izquierda");
                            System.Console.WriteLine();
                            System.Console.Write("Ingrese la dirección escogida (1-4): ");
                            dir = Console.ReadLine();
                            System.Console.WriteLine();
                            if(dir=="1")
                            {
                                if (IndexY-actualShip.ShipDim<0)
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
                                        
                                        IndexCheck1 = (rowNum.IndexOf(entry2));
                                        if(x==0)
                                        {
                                            shipTest=CheckShip(entry1,rowNum[IndexCheck1],this.shipPos, out string shipName);
                                            if (shipTest==true)
                                            {
                                                trigger=true;
                                            }
                                        }
                                        else
                                        {
                                            poscheck1=entry1;
                                            poscheck2=rowNum[IndexCheck1-x];
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
                                            int IndexK;
                                            int IndexZ;
                                            IndexK= (rowNum.IndexOf(entry2)+1);
                                            if (i==1)
                                            {
                                                //EditBoard(entry1,entry2,"S", boardRows);                                                
                                                posList.Add(entry1.ToUpper());
                                                posList.Add(entry2);
                                            }
                                            else
                                            {
                                                pos1=entry1;
                                                pos2=rowNum[IndexK-i];
                                                //EditBoard(entry1,pos2,"S", boardRows);
                                                posList.Add(entry1.ToUpper());
                                                posList.Add(pos2);
                                            }                                           
                                        }
                                        shipPos.Add(posList);
                                        PrintBoard(this.shipPos, this.shots, "MyBoard");
                                        break;
                                    }
                                }
                            }    
                            else if(dir=="2")
                            {
                                if (IndexY+actualShip.ShipDim>11)
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

                                        IndexCheck1 = (rowNum.IndexOf(entry2));
                                        if(x==0)
                                        {
                                            shipTest=CheckShip(entry1,rowNum[IndexCheck1],this.shipPos, out string shipName);
                                            if (shipTest==true)
                                            {
                                                trigger=true;
                                            }
                                        }
                                        else
                                        {
                                            poscheck1=entry1;
                                            poscheck2=rowNum[IndexCheck1+x];
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
                                            int IndexK;
                                            int IndexZ;
                                            IndexK= (rowNum.IndexOf(entry2)+1);
                                            if (i==1)
                                            {
                                                //EditBoard(entry1,entry2,"S");                                                
                                                posList.Add(entry1.ToUpper());
                                                posList.Add(entry2);
                                            }
                                            else
                                            {
                                                pos1=entry1;
                                                pos2=rowNum[IndexK+(i-2)];

                                                //ACORDATE DE SACAR ESTE COMENT

                                                //EditBoard(entry1,pos2,"S");
                                                posList.Add(entry1.ToUpper());
                                                posList.Add(pos2);
                                            }                                           
                                        }
                                        shipPos.Add(posList);
                                        PrintBoard(this.shipPos, this.shots, "MyBoard");
                                        break;
                                    }
                                }
                            }
                            else if(dir=="3")
                            {
                                if (IndexX+actualShip.ShipDim>11)
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

                                        IndexCheck1 = (rowNum.IndexOf(entry2));
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
                                            poscheck1=ABC[IndexCheck2+(x)];
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
                                            int IndexK;
                                            int IndexZ;
                                            IndexZ= (ABC.IndexOf(entry1.ToUpper()));
                                            if (i==1)
                                            {
                                                //EditBoard(entry1,entry2,"S", boardRows);                                                
                                                posList.Add(entry1.ToUpper());
                                                posList.Add(entry2);
                                            }
                                            else
                                            {
                                                pos1=ABC[IndexZ+(i-1)];
                                                pos2=entry2;
                                                //EditBoard(pos1,entry2,"S", boardRows);
                                                posList.Add(pos1.ToUpper());
                                                posList.Add(pos2);
                                            }                                           
                                        }
                                        shipPos.Add(posList);
                                        PrintBoard(this.shipPos, this.shots, "MyBoard");
                                        break;
                                    }    
                                }
                            }
                            else if(dir=="4")
                            {
                                if (IndexX-actualShip.ShipDim<0)
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

                                        IndexCheck1 = (rowNum.IndexOf(entry2));
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
                                            poscheck1=ABC[IndexCheck2-x];
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
                                            int IndexK;
                                            int IndexZ;
                                            IndexZ= (ABC.IndexOf(entry1.ToUpper()));
                                            if (i==1)
                                            {
                                                //EditBoard(entry1,entry2,"S", boardRows);                                                
                                                posList.Add(entry1.ToUpper());
                                                posList.Add(entry2);
                                            }
                                            else
                                            {
                                                pos1=ABC[IndexZ-(i-1)];
                                                pos2=entry2;
                                                //EditBoard(pos1,entry2,"S", boardRows);
                                                posList.Add(pos1.ToUpper());
                                                posList.Add(pos2);
                                            }                                           
                                        }
                                        shipPos.Add(posList);
                                        PrintBoard(this.shipPos, this.shots, "MyBoard");
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
        //<summary>
        //Por Expert, al Board conocer lo que hay en cada posición del tablero, es el encargado
        //de conocer si hay un barco en una posición en específica o no
        //</summary>
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
        
        //<summary>
        //Por Expert, al Board ser el responsable de conocer lo que se encuentra en cada linea
        //del tablero, es el encargado de crear uno nuevo a partir de la posición de los barcos y
        //de los ataques
        //</summary>
        public void RefreshBoard(ArrayList refreshShips, List<string> refreshShots , string printMode, List<List<string>> boardRows)
        {
            if (printMode=="MyBoard")
            {
                foreach (ArrayList item in refreshShips)
                {
                    for (int i = 1; i <= (item.Count-1); i+=2)
                    {
                        string setter1 = Convert.ToString(item[i]);
                        string setter2 = Convert.ToString(item[i+1]);
                        EditBoard(setter1,setter2,"S", boardRows);                                
                    }                    
                }
                for (int i = 0; i < refreshShots.Count; i+=2)
                {
                    string setter1 = Convert.ToString(refreshShots[i]);
                    string setter2 = Convert.ToString(refreshShots[i+1]);

                    bool result=CheckShip(setter1,setter2,refreshShips, out string shipName);
                    if (result == true)
                    {
                        EditBoard(setter1,setter2,"X", boardRows); 
                    }
                    else
                    {
                        EditBoard(setter1,setter2,"O", boardRows); 
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
                        EditBoard(setter1,setter2,"X", boardRows); 
                    }
                    else
                    {
                        EditBoard(setter1,setter2,"O", boardRows); 
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
                return rowNum;
            }
        }
    /*   
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
    */
    }
}



