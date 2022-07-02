using System;

namespace Library
{
    public class Menu
    {
        Administrator administrator = Administrator.Instance;

        public void ShowMenu() //Cuando llega aca que es lo primero que deberia pasar ya tiene q estar registrado y no es asi 
        {
            Console.WriteLine("Elige una opción \n 1- /Registrarse \n 2- /Jugar \n 3- /Salir");

            int num = int.Parse(Console.ReadLine());

            if (num == 1)
            {
                Console.Write("\nIngresa tu nombre de usuario para continuar: ");
                string name = Console.ReadLine();

                bool knownUser = false;
                foreach (var item in administrator.usersRegistered)
                {
                    //Console.WriteLine(item.Name);

                    if (item.Name.ToLower() == name.Trim().ToLower())
                    {
                        System.Console.WriteLine("\n-- Inicio de sesión exitoso --"); 
                        knownUser = true;
                        //######
                        // Hay que ver si acá no hay que indicar que ya existe un usuario con ese nombre
                        //return knownUser;
                    }
                }
                if (knownUser==false)
                {
                    Console.WriteLine("\nEse nombre de usuario no se encuentra registrado en el sistema aún");
                    System.Console.WriteLine("...");
                    //Si no se encuentra en el sistema se crea y se envía a la lista de usuarios registrados
                    User user = new User(name);
                    administrator.usersRegistered.Add(user);
                    System.Console.WriteLine($"Se le ha añadido a lista de usuarios registrados");
                    knownUser = true;
                    ShowMenu();
                    //return knownUser;
                }
            }
            else if(num == 2)
            {
                SelectMode(administrator.usersRegistered[1]);
            }
            else if (num == 3)
            {
                //######
                //Acá hay que añadir el chequeo que identifique que usuario es
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

        public static void GoPlay(User user)
        {
            Administrator.Instance.UsersToPlay.Add(user, "classic");

        }

        public (bool,int) SelectMode(User user)
        {
            (bool, int)returner;
            bool addedPlayer = false;
            //List<Lobby> modes = administrator.modeList;

            //Recorre la lista de nombres.
            

            Console.WriteLine("Estos son los diferentes modos de juego, ingresa un número para seleccionar.");
            int n = 0;
            System.Console.WriteLine("------------------------");
            System.Console.WriteLine(" 1- Classic\n 2- Bomb\n 3- TimeTrial\n 4- Challenge");
            
            /*
            foreach (Lobby lobby in modes)
            {
                n++;
                Console.WriteLine($"{n}-{lobby.Name}");
            }
            */
            int num = int.Parse(Console.ReadLine());

            /*
            if (modes.Contains(modes.ElementAt(num - 1)))
                modes.ElementAt(num - 1).AddUserToWaitList(user);
                Console.WriteLine($"\nEstas en la lista de espera para jugar al modo {modes.ElementAt(num - 1).Name}");
                //Console.WriteLine(administrator.modeList.ElementAt(0).usersWaiting.Count);
            }
            */
            if (num == 1)
            {
                administrator.UsersToPlay.Add(user,"Classic");
                addedPlayer = true;
            }
            else if (num == 2)
            {
                administrator.UsersToPlay.Add(user,"Bomb");
                addedPlayer = true;
            }
            else if (num == 3)
            {
                administrator.UsersToPlay.Add(user,"TimeTrial");
                addedPlayer = true;
            }
            else if (num == 4)
            {
                administrator.UsersToPlay.Add(user,"Challenge");
                addedPlayer = true;
            }
            else
            {
                Console.WriteLine("No tenemos un modo de juego válido");
            }
            return (addedPlayer,num);
        }
    }
}