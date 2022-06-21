using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Por SRP, se crea la clase ship que es la única encargada de conocer la información de cada barco
    /// </summary>
    public class Ship
    {
        private string shipName;
        private int shipDim;

        /// <summary>
        /// Constructor de los objetos Ship en base a su dimensión.
        /// </summary>
        /// <param name="length"> Recibe por parámetro el largo del barco que se desea construir.
        /// En base al valor se identifica que barco es y que nombre le corresponde para realizar
        /// la construcción del objeto</param>
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

        /// <summary>
        /// Función Get que te devuelve el nombre del barco
        /// </summary>
        /// <value></value>
        public string Shipname
        {
            get
            {
                return this.shipName;
            }
        }
        /// <summary>
        /// Función Get que te devuelve la dimensión del barco
        /// </summary>
        /// <value></value>
        public int ShipDim
        {
            get
            {
                return this.shipDim;
            }
        }
    }
}