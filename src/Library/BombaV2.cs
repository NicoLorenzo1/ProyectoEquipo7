using System;

        //<summary>
        //La clase BombaV2 es una de las modalidades que decidimos agregar, que a día de hoy
        //no funciona como debería de hacerlo, ya que no hemos logrado implementar una
        //manera de que el ataque sea un cuadrado de 3x3 con el centro en las coordenadas
        //que se le pasan
        //</summary>

namespace Library
{
    public class BombaV2 : Game
    {
        private User Player1;
        private User Player2;
        private Board BoardPlayer1;
        private Board BoardPlayer2;
        private bool Hit;
        private int MissedShots = 0;
        public BombaV2(User player1, User player2, string name) : base(player1, player2, name)
        {
            this.Player1 = player1;
            this.Player2 = player2;
            BoardPlayer1 = new Board(player1);
            BoardPlayer2 = new Board(player2); 
        }
//------------------------------
        public BombaV2(string name) : base(name)
        {
            if (name.ToLower() == "BombaV2 mode")
            {
                this.Name = name;
                //BombaV2 game = new BombaV2(this.usersWaiting.ElementAt(0), this.usersWaiting.ElementAt(1), this.Name);
                this.StartGame();   
            }
            else
            {
                Console.WriteLine("Modo incorrecto");
            }
        }
//-------------------------------
        public override void Attack(User player)
        {
            if (MissedShots == 3)
            {
                //Falta ver como hacer un ataque 3x3
                Console.WriteLine("Escriba la primer coordenada del centro de la BombaV2a(A-J)");
                string coord1 = Console.ReadLine();
                Console.WriteLine("Escriba la segunda coordenada del centro de la BombaV2a(1-10)");
                string coord2 = Console.ReadLine();
                if (player == this.Player1)
                {
                    this.BoardPlayer2.EditBoard(coord1,coord2);
                }
                else if (player == this.Player2)
                {
                    this.BoardPlayer1.EditBoard(coord1, coord2);
                }
                MissedShots = 0;
            }
            else
            {
                base.Attack(player);
                if (!Hit)
                {
                    MissedShots += 1;
                }
            } 
        }
        public override void MatchPlayers()
        {
            BombaV2 game = new BombaV2("BombaV2 Mode");
            base.MatchPlayers();
        }
    }
}
