using System;
using System.Collections.Generic;

namespace Library
{
    public class Commands            
    {  
        
        public static Dictionary<int, string> predefinedCommands = new Dictionary<int, string>()
        {
            {1, ""},                         //nombres de los métodos para mostrarle al usuario
            {2, ""},
        };

        public void ShowCommands()
        {
            foreach (var item in predefinedCommands)
            {
                Console.WriteLine($"-{item.Key}: {item.Value}");
            }         
        }

        public void CommandSelect(string userInput)
        {
            if (userInput == "/ShowCommands")
            {
                ShowCommands();
            }
            else if (userInput == " ")      //para los comandos que se nos ocurra
            {

            }
            else
            {
                Console.WriteLine("No existe comando para el texto ingresado, vuelva a intentar");     //mensaje de error
            }
        }        
    }
}
