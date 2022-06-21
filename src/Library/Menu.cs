using System;

namespace Library
{
    public class Menu
    {
        Administrator administrator = Administrator.Instance;

        public void ShowMenu() //Cuando llega aca que es lo primero que deberia pasar ya tiene q estar registrado y no es asi 
        {
            Console.WriteLine("Elige una opción \n 1- Registrarse \n 2- Jugar \n 3- Salir");

            int num = int.Parse(Console.ReadLine());

            if (num == 1)
            {
                Register();
                return;
            }

            if (num == 2)
            {
                Console.WriteLine("\nIngresa tu nombre de usuario para continuar");
                string name = Console.ReadLine();

                foreach (var item in administrator.usersRegistered)
                {
                    Console.WriteLine(item.Name);

                    if (item.Name.ToLower() == name.Trim().ToLower())
                    {
                        //SelectMode(item);
                        GoPlay(item);
                        return;

                    }
                }
                Console.WriteLine("\nEse nombre de usuario no se encuentra registrado en el sistema");
                //si no se encuentra en el sistema se envia a que se registre
                Register();
                return;
            }

            if (num == 3)
            {
                Console.WriteLine("\nTe esperamos la proxima!");
                return;
            }

            else
            {
                Console.WriteLine("\nNo tenemos una opción para ese numero");
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
                administrator.MatchPlayers(administrator.CheckUser(UserName), "Classic");
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
        /*
        public void SelectMode(User user)
        {
            //List<Lobby> modes = administrator.modeList;

            //Recorre la lista de nombres.
            

            Console.WriteLine("Estos son los diferentes modos de juego, ingresa un número para seleccionar.");
            int n = 0;
            foreach (Lobby lobby in modes)
            {
                n++;
                Console.WriteLine($"{n}-{lobby.Name}");
            }
            int num = int.Parse(Console.ReadLine());

            if (modes.Contains(modes.ElementAt(num - 1)))
            {
                modes.ElementAt(num - 1).AddUserToWaitList(user);
                Console.WriteLine($"\nEstas en la lista de espera para jugar al modo {modes.ElementAt(num - 1).Name}");
                //Console.WriteLine(administrator.modeList.ElementAt(0).usersWaiting.Count);
            }
            else
            {
                Console.WriteLine("No tenemos un modo de juego asignado para ese numero");
            }
            return;
        }
        */
    }
}