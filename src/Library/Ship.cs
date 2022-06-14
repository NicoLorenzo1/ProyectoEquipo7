using System;
using System.Collections.Generic;

namespace Library
{
    public class Ship
    {
        private string shipName;
        private int shipDim;

        public Ship(int length)
        {
            if (length == 5)
            {
                this.shipName = "Portaaviones";
                this.shipDim = 5;
            }
            else if (length == 4)
            {
                this.shipName = "Buque";
                this.shipDim = 4;
            }
            else if (length == 3)
            {
                this.shipName = "Submarino";
                this.shipDim = 3;
            }
            else if (length == 2)
            {
                this.shipName = "Crucero";
                this.shipDim = 2;
            }
            else if (length == 1)
            {
                this.shipName = "Lancha";
                this.shipDim = 1;
            }
            else
            {
                Console.WriteLine("No existe nave de ese largo, vuelva a intentar");
            }
        }

        public string Shipname
        {
            get
            {
                return this.shipName;
            }
        }
        public int ShipDim
        {
            get
            {
                return this.shipDim;
            }
        }
    }
}