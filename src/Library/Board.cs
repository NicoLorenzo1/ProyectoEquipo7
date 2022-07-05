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
        private static List<string> charList = new List<string>()
        {
            "-","X","O","S"
        };


        public ArrayList shipPos = new ArrayList();
        public List<string> shots = new List<string>();
        private User PlayerUser;

        /// <summary>
        /// El constructor de la clase Board y donde se detallan los atributos vinculados.
        /// Aquí se deja guardado el Usuario para el cual fue generado el tablero.
        /// </summary>
        /// <param name="player1User"> Es el User para el cual fue generado el tablero</param>
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
        /// <summary>
        /// Este método StartBoard lo que hace es generar un tablero ficticio conformado
        /// por una Lista de Listas de Strings desde cero. Estos tableros ficticios serán 
        /// utilizados por los otros métodos de la clase Board para ejecutar sus funciones.
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Por Creator, el responsable de conocer las lineas del tablero es la clase Board
        /// y el responsable de imprimirlas debe ser él.
        /// </summary>
        /// <param name="refreshShips"> Este parámetro indica que Arraylist de barcos (propios o enemigos)
        /// se debe consultar para realizar la impresión que corresponda. Se recorrerá esta lista
        /// y se actualizará el nuevo tablero ficticio generado por StartBoard() con la posición de
        /// estos barcos.</param>
        /// <param name="refreshShots"> Este parámetro indica que lista de tiros (propios o enemigos)
        /// serán utilizados para la generación del tablero ficticio que será impreso</param>
        /// <param name="printMode"> Este parámetro indica el tipo de tablero que deberá construir
        /// lo cual afectará en la construcción del mismo. Este parámetro será utilizado en el
        /// método RefreshBoard()</param>
        public string PrintBoard(ArrayList refreshShips, List<string> refreshShots, string printMode)
        {
            List<List<string>> boardRows = StartBoard();
            RefreshBoard(refreshShips, refreshShots, printMode, boardRows);
            string finalTable = "";
            int counter = 0;
            string RowI = "";
            //Recorro filas
            for (int y = 0; y < 11; y++)
            {
                //Recorro cada columna que compone a la fila en la que estoy
                for (int x = 0; x < 11; x++)
                {
                    if (y == 0)
                    {
                        if (x == 0)
                        {
                            RowI = ($"{RowI}{boardRows[y][x]:>6}");
                        }
                        else if (x == 1)
                        {
                            RowI = ($"{RowI}  {boardRows[y][x]:>6}");
                        }
                        else
                        {
                            RowI = ($"{RowI}  {boardRows[y][x]:>3}");
                        }
                    }
                    else if (y == 10)
                    {
                        if (x == 0)
                        {
                            RowI = ($"{boardRows[y][x]:>3}");
                        }
                        else if (x == 1)
                        {
                            RowI = ($"{RowI} {boardRows[y][x]:>2}");
                        }
                        else
                        {
                            RowI = ($"{RowI}  {boardRows[y][x]:>2}");
                        }
                    }
                    else
                    {
                        if (x == 0)
                        {
                            RowI = ($"{boardRows[y][x]:>3}");
                        }
                        else
                        {
                            RowI = ($"{RowI}  {boardRows[y][x]:>2}");
                        }
                    }
                }
                Console.WriteLine(RowI);
                if (counter == 0)
                {
                    finalTable += ($"{RowI}");
                }
                else
                {
                    finalTable += ($"\n{RowI}");
                }
                counter += 1;
            }
            return finalTable;
        }
        /// <summary>
        /// Por Creator, el responsable de conocer las lineas del tablero es la clase Board
        /// y el responsable de editarlas debe ser él
        /// </summary>
        /// <param name="coord1"> Coordenada 1 en donde se modificará el tablero ficticio</param>
        /// <param name="coord2"> Coordenada 2 en donde se modificará el tablero ficticio</param>
        /// <param name="editor"> Símbolo que será utilizado para editar el tablero (-,X,O,S)</param>
        /// <param name="boardRows"> Se le pasa el nuevo tablero ficticio generado antes de la 
        /// ejecución de este método EditBoard</param>
        public void EditBoard(string coord1, string coord2, string editor, List<List<string>> boardRows)
        {
            for (int y = 0; y < 11; y++)
            {
                if (boardRows[y][0] == coord2)
                {
                    int IndexY;
                    IndexY = y;
                    for (int x = 0; x < 11; x++)
                    {
                        if (boardRows[0][x] == coord1.ToUpper())
                        {
                            int IndexX;
                            IndexX = x;
                            if (editor == "-")
                            {
                                boardRows[IndexY][IndexX] = charList[0];
                            }
                            else if (editor.ToUpper() == "X")
                            {
                                boardRows[IndexY][IndexX] = charList[1];
                            }
                            else if (editor.ToUpper() == "O")
                            {
                                boardRows[IndexY][IndexX] = charList[2];
                            }
                            else if (editor.ToUpper() == "S")
                            {
                                boardRows[IndexY][IndexX] = charList[3];
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
        /// <summary>
        /// Por Expert, al Board conocer lo que hay en cada posición del tablero, es el responsable
        /// de colocar los barcos en dicho tablero.
        /// En este método también se encuentra la lógica de ordenamiento y pedido de coordenadas
        /// y dirección al usuario. Luego verifica si en la posición seleccionada es posible 
        /// colocar el barco correspondiente teniendo en cuenta la dimensión del tablero 
        /// y si en esa posición ya hay otro barco posicionado.
        /// Esto modifica el ArrayList de shipPos que es donde se almacena el barco correspondiente
        /// y las coordenadas que ocupa de forma individual
        /// </summary>
        public void PositionShips()
        {
            List<List<string>> boardRows = StartBoard();
            for (int s = 1; s <= 2; s++)
            {
                Ship actualShip = new Ship(s);

                while (false)
                {
                    Console.WriteLine($"Ingrese la posición inicial de {actualShip.Shipname}: ");
                    Console.Write("Ingrese la cordenada 1(A-J): ");
                    string entry1;
                    entry1 = Console.ReadLine();
                    if (ABC.Contains(entry1.ToUpper()))
                    {
                        int IndexX;
                        IndexX = ABC.IndexOf(entry1.ToUpper());

                        string entry2;
                        Console.Write("Ingrese la cordenada 2(1-10): ");
                        entry2 = Console.ReadLine();
                        if (rowNum.Contains(entry2))
                        {
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
                            bool overBoard = false;
                            bool overShip = false;
                            if (dir != "1" && dir != "2" && dir != "3" && dir != "4")
                            {
                                System.Console.WriteLine("No es un dirección válida\n");

                            }
                            else
                            {
                                (overBoard, overShip) = Positioner(entry1, entry2, dir, actualShip.Shipname, actualShip.ShipDim);
                                break;
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
        /// <summary>
        /// Recibe por parametro dos coordenadas, una direccion, el tipo de barco y la dimension de barco, 
        /// y devuelve si se sale del tablero y el otro booleano devuelve si ya hay un barco en esa posicion o se solapa sobre otro
        /// </summary>
        /// <param name="entry1"></param>
        /// <param name="entry2"></param>
        /// <param name="dir"></param>
        /// <param name="actualShipName"></param>
        /// <param name="actualShipDim"></param>
        /// <returns></returns>
        public (bool, bool) Positioner(string entry1, string entry2, string dir, string actualShipName, int actualShipDim)
        {
            bool overShip = false;
            bool overBoard = false;
            int IndexX;
            IndexX = ABC.IndexOf(entry1.ToUpper());
            int IndexY;
            IndexY = rowNum.IndexOf(entry2) + 1;

            if (dir == "1" || dir == "/arriba")
            {
                if (IndexY - actualShipDim < 0)
                {
                    System.Console.WriteLine("No podes posicionar un barco en esa dirección");
                    System.Console.WriteLine("No se puede ubicar barcos fuera del tablero de juego");
                    System.Console.WriteLine();
                    overBoard = true;
                }
                else
                {
                    bool trigger = false;
                    for (int x = 0; x < actualShipDim; x++)
                    {
                        string poscheck1;
                        string poscheck2;
                        int IndexCheck1;
                        int IndexCheck2;
                        bool shipTest;

                        IndexCheck1 = (rowNum.IndexOf(entry2));
                        if (x == 0)
                        {
                            (shipTest, string currentShipName) = CheckShip(entry1, rowNum[IndexCheck1], this.shipPos);
                            if (shipTest == true)
                            {
                                trigger = true;
                            }
                        }
                        else
                        {
                            poscheck1 = entry1;
                            poscheck2 = rowNum[IndexCheck1 - x];
                            (shipTest, string currentShipName) = CheckShip(entry1, poscheck2, this.shipPos);
                            if (shipTest == true)
                            {
                                trigger = true;
                            }
                        }
                    }
                    if (trigger == true)
                    {
                        System.Console.WriteLine("No podes posicionar un barco ahi");
                        System.Console.WriteLine("Ya hay un barco ocupando una de las ubicaciones selecionadas");
                        System.Console.WriteLine();
                        overShip = true;

                    }
                    else
                    {
                        ArrayList posList = new ArrayList();
                        posList.Add(actualShipName);
                        for (int i = 1; i <= actualShipDim; i++)
                        {
                            string pos1;
                            string pos2;
                            int IndexK;
                            int IndexZ;
                            IndexK = (rowNum.IndexOf(entry2) + 1);
                            if (i == 1)
                            {
                                //EditBoard(entry1,entry2,"S", boardRows);                                                
                                posList.Add(entry1.ToUpper());
                                posList.Add(entry2);
                            }
                            else
                            {
                                pos1 = entry1;
                                pos2 = rowNum[IndexK - i];
                                //EditBoard(entry1,pos2,"S", boardRows);
                                posList.Add(entry1.ToUpper());
                                posList.Add(pos2);
                            }
                        }
                        shipPos.Add(posList);
                        string finalTable = PrintBoard(this.shipPos, this.shots, "MyBoard");
                        System.Console.WriteLine("### Aca viene el nuevo print: ###");
                        System.Console.WriteLine($"{finalTable}");
                        return (overBoard, overShip);
                    }
                }
            }
            else if (dir == "2" || dir == "/abajo")
            {
                if (IndexY + actualShipDim > 11)
                {
                    System.Console.WriteLine("No podes posicionar un barco en esa dirección");
                    System.Console.WriteLine("No se puede ubicar barcos fuera del tablero de juego");
                    System.Console.WriteLine();
                    overBoard = true;
                }
                else
                {
                    bool trigger = false;
                    for (int x = 0; x < actualShipDim; x++)
                    {
                        string poscheck1;
                        string poscheck2;
                        int IndexCheck1;
                        int IndexCheck2;
                        bool shipTest;

                        IndexCheck1 = (rowNum.IndexOf(entry2));
                        if (x == 0)
                        {
                            (shipTest, string currentShipName) = CheckShip(entry1, rowNum[IndexCheck1], this.shipPos);
                            if (shipTest == true)
                            {
                                trigger = true;
                            }
                        }
                        else
                        {
                            poscheck1 = entry1;
                            poscheck2 = rowNum[IndexCheck1 + x];
                            (shipTest, string currentShipName) = CheckShip(entry1, poscheck2, this.shipPos);
                            if (shipTest == true)
                            {
                                trigger = true;
                            }
                        }
                    }
                    if (trigger == true)
                    {
                        System.Console.WriteLine("No podes posicionar un barco ahi");
                        System.Console.WriteLine("Ya hay un barco ocupando una de las ubicaciones selecionadas");
                        System.Console.WriteLine();
                        overShip = true;
                    }
                    else
                    {
                        ArrayList posList = new ArrayList();
                        posList.Add(actualShipName);
                        for (int i = 1; i <= actualShipDim; i++)
                        {
                            string pos1;
                            string pos2;
                            int IndexK;
                            int IndexZ;
                            IndexK = (rowNum.IndexOf(entry2) + 1);
                            if (i == 1)
                            {
                                //EditBoard(entry1,entry2,"S");                                                
                                posList.Add(entry1.ToUpper());
                                posList.Add(entry2);
                            }
                            else
                            {
                                pos1 = entry1;
                                pos2 = rowNum[IndexK + (i - 2)];

                                //ACORDATE DE SACAR ESTE COMENT

                                //EditBoard(entry1,pos2,"S");
                                posList.Add(entry1.ToUpper());
                                posList.Add(pos2);
                            }
                        }
                        shipPos.Add(posList);
                        PrintBoard(this.shipPos, this.shots, "MyBoard");
                        return (overBoard, overShip);
                    }
                }
            }
            else if (dir == "3" || dir == "/derecha")
            {
                if (IndexX + actualShipDim > 11)
                {
                    System.Console.WriteLine("No podes posicionar un barco en esa dirección");
                    System.Console.WriteLine("No se puede ubicar barcos fuera del tablero de juego");
                    System.Console.WriteLine();
                    overBoard = true;
                }
                else
                {
                    bool trigger = false;

                    for (int x = 0; x < actualShipDim; x++)
                    {
                        string poscheck1;
                        string poscheck2;
                        int IndexCheck1;
                        int IndexCheck2;
                        bool shipTest;

                        IndexCheck1 = (rowNum.IndexOf(entry2));
                        IndexCheck2 = (ABC.IndexOf(entry1.ToUpper()));
                        if (x == 0)
                        {
                            (shipTest, string currentShipName) = CheckShip(ABC[IndexCheck2], entry2, this.shipPos);
                            //System.Console.WriteLine(shipTest);
                            if (shipTest == true)
                            {
                                trigger = true;
                            }
                        }
                        else
                        {
                            poscheck1 = ABC[IndexCheck2 + (x)];
                            poscheck2 = entry2;
                            (shipTest, string currentShipName) = CheckShip(poscheck1, entry2, this.shipPos);
                            if (shipTest == true)
                            {
                                trigger = true;
                            }
                        }
                    }
                    if (trigger == true)
                    {
                        System.Console.WriteLine("No podes posicionar un barco ahi");
                        System.Console.WriteLine("Ya hay un barco ocupando una de las ubicaciones selecionadas");
                        System.Console.WriteLine();
                        overShip = true;
                    }
                    else
                    {
                        ArrayList posList = new ArrayList();
                        posList.Add(actualShipName);
                        for (int i = 1; i <= actualShipDim; i++)
                        {
                            string pos1;
                            string pos2;
                            int IndexK;
                            int IndexZ;
                            IndexZ = (ABC.IndexOf(entry1.ToUpper()));
                            if (i == 1)
                            {
                                //EditBoard(entry1,entry2,"S", boardRows);                                                
                                posList.Add(entry1.ToUpper());
                                posList.Add(entry2);
                            }
                            else
                            {
                                pos1 = ABC[IndexZ + (i - 1)];
                                pos2 = entry2;
                                //EditBoard(pos1,entry2,"S", boardRows);
                                posList.Add(pos1.ToUpper());
                                posList.Add(pos2);
                            }
                        }
                        shipPos.Add(posList);
                        PrintBoard(this.shipPos, this.shots, "MyBoard");
                        return (overBoard, overShip);
                    }
                }
            }
            else if (dir == "4" || dir == "/izquierda")
            {
                if (IndexX - actualShipDim < 0)
                {
                    System.Console.WriteLine("No podes posicionar un barco en esa dirección");
                    System.Console.WriteLine("No se puede ubicar barcos fuera del tablero de juego");
                    System.Console.WriteLine();
                    overBoard = true;
                }
                else
                {
                    bool trigger = false;

                    for (int x = 0; x < actualShipDim; x++)
                    {
                        string poscheck1;
                        string poscheck2;
                        int IndexCheck1;
                        int IndexCheck2;
                        bool shipTest;

                        IndexCheck1 = (rowNum.IndexOf(entry2));
                        IndexCheck2 = (ABC.IndexOf(entry1.ToUpper()));
                        if (x == 0)
                        {
                            (shipTest, string currentShipName) = CheckShip(ABC[IndexCheck2], entry2, this.shipPos);
                            if (shipTest == true)
                            {
                                trigger = true;
                            }
                        }
                        else
                        {
                            poscheck1 = ABC[IndexCheck2 - x];
                            poscheck2 = entry2;
                            (shipTest, string currentShipName) = CheckShip(poscheck1, entry2, this.shipPos);
                            if (shipTest == true)
                            {
                                trigger = true;
                            }
                        }
                    }
                    if (trigger == true)
                    {
                        System.Console.WriteLine("No podes posicionar un barco ahi");
                        System.Console.WriteLine("Ya hay un barco ocupando una de las ubicaciones selecionadas");
                        System.Console.WriteLine();
                        overShip = true;
                    }
                    else
                    {
                        ArrayList posList = new ArrayList();
                        posList.Add(actualShipName);
                        for (int i = 1; i <= actualShipDim; i++)
                        {
                            string pos1;
                            string pos2;
                            int IndexK;
                            int IndexZ;
                            IndexZ = (ABC.IndexOf(entry1.ToUpper()));
                            if (i == 1)
                            {
                                //EditBoard(entry1,entry2,"S", boardRows);                                                
                                posList.Add(entry1.ToUpper());
                                posList.Add(entry2);
                            }
                            else
                            {
                                pos1 = ABC[IndexZ - (i - 1)];
                                pos2 = entry2;
                                //EditBoard(pos1,entry2,"S", boardRows);
                                posList.Add(pos1.ToUpper());
                                posList.Add(pos2);
                            }
                        }
                        shipPos.Add(posList);
                        PrintBoard(this.shipPos, this.shots, "MyBoard");
                        return (overBoard, overShip);
                    }
                }
            }
            else
            {
                System.Console.WriteLine();
                System.Console.WriteLine("No es una dirección válida");
                System.Console.WriteLine();
            }
            return (overBoard, overShip);
        }


        /// <summary>
        /// Por Expert, al Board conocer lo que hay en cada posición del tablero, es el encargado
        /// de conocer si hay un barco en una posición en específica o no.
        /// Si encuentra una coincidencia en la posición indicada, te retorna un bool llamado
        /// coincidence, el cual si es true es porque encontró un barco en esas coordenadas.
        /// </summary>
        /// <param name="check1"> Primer coordenada a verificar en el listado de barcos y sus posiciones</param>
        /// <param name="check2"> Segunda coordenada a verificar en el listado de barcos y sus posiciones</param>
        /// <param name="chosenShips"> Lista de barcos en donde se verificará si hay una coincidencia</param>
        /// <param name="shipName"> Retorna el nombre del barco en el cual se generó la coincidencia</param>
        /// <returns>coincidence</returns>
        public (bool, string) CheckShip(string check1, string check2, ArrayList chosenShips)
        {
            bool coincidence = false;
            string currentShipName = "";
            foreach (ArrayList item in chosenShips)
            {
                for (int i = 1; i <= (item.Count - 1); i++)
                {
                    string checker1 = Convert.ToString(item[i]);
                    string checker2 = check1.ToUpper();

                    if (checker1 == checker2)
                    {
                        string numCheck = Convert.ToString(item[i + 1]);
                        if (check2 == numCheck)
                        {
                            currentShipName = Convert.ToString(item[0]);
                            coincidence = true;
                            return (coincidence, currentShipName);
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
            return (coincidence, currentShipName);
        }
        /// <summary>
        /// Por Expert, al Board ser el responsable de conocer lo que se encuentra en cada linea
        /// del tablero, es el encargado de crear uno nuevo a partir de la posición de los barcos y
        /// de los ataques
        /// Este método esta encargado de actualizar el tablero ficticio nuevo generado e incluir
        /// los barcos que se le pasan por parámetro o no dependiendo el caso y posicionar las coordenadas
        ///  de ataques de la lista shots recibida por parámetro
        /// </summary>
        /// <param name="refreshShips"> Lista de Barcos que será utilizada para realizar la actualización</param>
        /// <param name="refreshShots"> Lista de disparos que será utilizada para realizar la actualización</param>
        /// <param name="printMode"> Tipo de tablero deseado</param>
        /// <param name="boardRows"> Tablero ficticio nuevo generado previamente</param>
        public void RefreshBoard(ArrayList refreshShips, List<string> refreshShots, string printMode, List<List<string>> boardRows)
        {
            if (printMode == "MyBoard")
            {
                foreach (ArrayList item in refreshShips)
                {
                    for (int i = 1; i <= (item.Count - 1); i += 2)
                    {
                        string setter1 = Convert.ToString(item[i]);
                        string setter2 = Convert.ToString(item[i + 1]);
                        EditBoard(setter1, setter2, "S", boardRows);
                    }
                }
                for (int i = 0; i < refreshShots.Count; i += 2)
                {
                    string setter1 = Convert.ToString(refreshShots[i]);
                    string setter2 = Convert.ToString(refreshShots[i + 1]);

                    (bool result, string currentShipName) = CheckShip(setter1, setter2, refreshShips);
                    if (result == true)
                    {
                        EditBoard(setter1, setter2, "X", boardRows);
                    }
                    else
                    {
                        EditBoard(setter1, setter2, "O", boardRows);
                    }
                }
            }
            else if (printMode == "EnemyBoard")
            {
                for (int i = 0; i < refreshShots.Count; i += 2)
                {
                    string setter1 = Convert.ToString(refreshShots[i]);
                    string setter2 = Convert.ToString(refreshShots[i + 1]);

                    //Hay que agregar parametro de shipPos al checkship porque hay que pasarle en que lista de barcos mirar
                    (bool result, string currentShipName) = CheckShip(setter1, setter2, refreshShips);
                    if (result == true)
                    {
                        EditBoard(setter1, setter2, "X", boardRows);
                    }
                    else
                    {
                        EditBoard(setter1, setter2, "O", boardRows);
                    }
                }
            }
        }
        //private List<string> surroundCoords = new List<string>();
        /// <summary>
        /// Recibe una coordenada y devuelve las 8 que la rodean
        /// </summary>
        /// <param name="alphaCoord">Coordenada alfabética deseada</param>
        /// <param name="numCoord">Coordenada númerica deseada</param>
        /// <returns>Devuelve la lista de coordenadas que se encuentran al rededor de la deseada</returns>
        public List<string> coordSurround(string alphaCoord, string numCoord)
        {
            List<string> surroundCoords = new List<string>();
            if (ABC.Contains(alphaCoord.ToUpper()))
            {
                int IndexX = ABC.IndexOf(alphaCoord.ToUpper());
                if (rowNum.Contains(numCoord))
                {
                    int IndexY = rowNum.IndexOf(numCoord) + 1;
                    int rowPosOne = IndexY - 2;
                    int rowPosTwo = IndexY - 1;
                    int rowPosThree = IndexY;
                    if (rowPosOne >= 0)
                    {
                        //System.Console.WriteLine("Entro a rowPosOne");
                        for (int i = IndexX - 1; i <= IndexX + 1; i++)
                        {
                            if (i >= 1 && i <= 11)
                            {
                                string stringCollector1 = ABC[i];
                                string stringCollector2 = rowNum[rowPosOne];
                                surroundCoords.Add(stringCollector1);
                                surroundCoords.Add(stringCollector2);
                            }
                        }
                    }
                    for (int i = IndexX - 1; i <= IndexX + 1; i++)
                    {
                        if (i >= 1 && i <= 11)
                        {
                            string stringCollector1 = ABC[i];
                            string stringCollector2 = rowNum[rowPosTwo];
                            surroundCoords.Add(stringCollector1);
                            surroundCoords.Add(stringCollector2);
                        }
                    }
                    if (!(rowPosThree > 11))
                    {
                        for (int i = IndexX - 1; i <= IndexX + 1; i++)
                        {
                            if (i >= 1 && i <= 11)
                            {
                                string stringCollector1 = ABC[i];
                                string stringCollector2 = rowNum[rowPosThree];
                                surroundCoords.Add(stringCollector1);
                                surroundCoords.Add(stringCollector2);
                            }
                        }
                    }
                    return surroundCoords;
                }
            }
            else
            {
                System.Console.WriteLine("No es una coordenada válida");
                return surroundCoords;
            }
            return surroundCoords;


        }

        /// <summary>
        /// Getter del listado ABC, que es utilizado para verificar indices desde fuera de Board
        /// </summary>
        /// <value></value>
        public static List<string> abc
        {
            get
            {
                return ABC;
            }
        }
        /// <summary>
        /// Getter del listado rowNum, que es utilizado para verificar indices desde fuera de Board
        /// </summary>
        /// <value></value>
        public static List<string> num
        {
            get
            {
                return rowNum;
            }
        }

        public int shipCount()
        {
            return shipPos.Count;
        }


        public void showList()
        {
            foreach (ArrayList item in shipPos)
            {
                System.Console.WriteLine($"{item[0]} está ubicado en: ");

                for (int i = 1; i < (item.Count - 1); i += 2)
                {
                    for (int j = i; j <= (i + 1); j++)
                    {
                        System.Console.Write($"[{item[j]}] ");
                    }
                    if (i == (item.Count - 2))
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

    }

}



