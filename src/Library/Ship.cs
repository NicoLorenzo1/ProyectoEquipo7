using System;
using System.Collections.Generic;

namespace Library
{

    //<summary>
    //Por SRP, se crea la clase ship que es la única encargada de conocer la información de cada barco
    //</summary>
    public class Ship
    {
        private string shipName;
        private int shipDim;

        public Ship(int length)
        {
            this.shipDim = length;
            
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