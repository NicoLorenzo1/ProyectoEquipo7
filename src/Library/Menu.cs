using System;
using System.Diagnostics;

namespace Library
{
    public class Menu
    {
        Administrator administrator = Administrator.Instance;

        public void ShowMenu()
        {
            int num = 0;
            while (num == 0)
            {
                Console.WriteLine("Elige una opción \n 1- /Registrarse \n 2- /Jugar \n 3- /Salir");  
                try
                {
                    num = int.Parse(Console.ReadLine());  
                }
                catch(InvalidUserInputException ex)
                {
                    Debug.WriteLine("Input del usuario no válido");
                    num = 0;
                }
                num = readNumber(num);
            }
        }

        private int readNumber(int num)
        {
            if (num != 1 || num != 2 || num != 3 || num != 4)
            {
                throw (new InvalidUserInputException("Input de opción seleccionada del usuario no válida"));
            }
            return num;
        }

        public void Register()
        {
            Console.WriteLine("\nEnvía un nombre de usuario para registrarte.");

            string UserName = Console.ReadLine();

            //inmediatamente luego de registrarse se lo envía a seleccionar modo
            if (UserName != string.Empty)
            {
                //SelectMode(administrator.CheckUser());
               // administrator.MatchPlayers(administrator.CheckUser(UserName), "Classic");
            }

            else
            {
                Console.WriteLine("\nNo enviaste un nombre de usuario valido");
            }
        }

        /// <summary>
        /// Selector de modos de juego
        /// </summary>
        /// <param name="user">Usuario que quiere jugar</param>
        /// <returns>Devuelve que el usuario este añadido y el modo que quiere jugar</returns>
        public (bool,int) SelectMode(User user)
        {
            bool addedPlayer = false;

            Console.WriteLine("Estos son los diferentes modos de juego, ingresa un número para seleccionar.");
            int n = 0;
            System.Console.WriteLine("------------------------");
            System.Console.WriteLine(" 1- Classic\n 2- Bomb\n 3- TimeTrial\n 4- Challenge");

            int num = int.Parse(Console.ReadLine());
            if (num == 1)
            {
                administrator.UsersToPlay.Add(user, "classic");
                addedPlayer = true;
            }
            else if (num == 2)
            {
                administrator.UsersToPlay.Add(user, "bomb");
                addedPlayer = true;
            }
            else if (num == 3)
            {
                administrator.UsersToPlay.Add(user, "timetrial");
                addedPlayer = true;
            }
            else if (num == 4)
            {
                administrator.UsersToPlay.Add(user, "challenge");
                addedPlayer = true;
            }
            else
            {
                Console.WriteLine("No tenemos un modo de juego válido");
            }
            return (addedPlayer, num);
        }
    }
}