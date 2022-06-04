using System;
using System.Collections.Generic;

namespace PROYECTOEQUIPO7
{
    public class Commands               //LO VOY A CAMBIAR A UN DICCIONARIO, LO SUBO PARA TENER ALGO NOMAS
    {
        private List<string> commandList = new List<string>() {"/ShowCommands", "/CommandSelect", " "};     //nombres de comandos

        public void ShowCommands()
        {
            Console.WriteLine(commandList);       //tengo que darle formato de lista prolijo todavía
        }

        //por aca definir más métodos de otros comandos

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
                Console.WriteLine(" ");     //mensaje de error
            }
        }
    }
}
