using System;

namespace Library
{
    public class Menu
    {
        Administrator administrator = Administrator.Instance;
        public bool addedPlayer = false;


        public void ShowMenu()
        {
            Console.WriteLine("Elige una opción \n 1- /Registrarse \n 2- /Jugar \n 3- /Salir");

            int num = int.Parse(Console.ReadLine());

            if (num == 1)
            {
                Console.Write("\nIngresa tu nombre de usuario para continuar: ");
                string name = Console.ReadLine();

                bool knownUser = false;
                foreach (var (item, state) in administrator.usersRegisteredWithState)
                {
                    if (item.Name.ToLower() == name.Trim().ToLower())
                    {
                        System.Console.WriteLine("\n-- Inicio de sesión exitoso --");
                        knownUser = true;
                    }
                }
                if (knownUser == false)
                {
                    Console.WriteLine("\nEse nombre de usuario no se encuentra registrado en el sistema aún");
                    System.Console.WriteLine("...");
                    //Si no se encuentra en el sistema se crea y se envía a la lista de usuarios registrados
                    User user = new User(name);
                    administrator.usersRegisteredWithState.Add(user, null);
                    System.Console.WriteLine($"Se le ha añadido a lista de usuarios registrados\n");
                    knownUser = true;
                    SelectMode(user);
                }
            }
            else if (num == 2)
            {
                SelectMode(administrator.usersRegisteredWithState.Keys.Last());

            }
            else if (num == 3)
            {
                Console.WriteLine("\nTe esperamos la proxima!");
                return;
            }
            else
            {
                Console.WriteLine("\nNo es una opción válida");
            }
            return;
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