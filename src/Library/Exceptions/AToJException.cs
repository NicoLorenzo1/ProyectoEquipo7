using System;
using System.IO;

namespace Library
{
    public class AToJException : Exception
    {
        public AToJException() : base("No se ingresó solamente una letra de la A a la J")
        {            
        }
    }
}