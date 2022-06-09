using System;
using System.Collections.Generic;

namespace Library
{
    public class Ship
    {
        private string shipName;
        private int shipLength;

        public Ship(int length)
        {
            
            if (length == 5)
            {
                this.shipName = "Portaaviones";
            }
            else if (length == 4)
            {
                this.shipName = "Buque";
            }
            else if (length == 3)
            {
                this.shipName = "Submarino";
            }
            else if (length == 2)
            {
                this.shipName = "Crucero";
            }
            else if (length == 1)
            {
                this.shipName = "Lancha";
            }
            else
            {
                Console.WriteLine("No existe nave de ese largo, vuelva a intentar");
            }
            this.shipLength = length;
        }

        public string Shipname
        {
            get
            {
                return this.shipName;
            }
        }
    }
}