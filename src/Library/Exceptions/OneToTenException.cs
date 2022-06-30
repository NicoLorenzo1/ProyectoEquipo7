using System;
using System.IO;

namespace Library
{
    public class OneToTenException : Exception
    {
        public OneToTenException() : base("No se ingresó solamente un número entero del 1 al 10")
        {            
        }
    }
}