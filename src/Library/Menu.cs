using System;

namespace Library
{
    public class Menu :IGameMode
    {

        public static void ShowMenu() //Cuando llega aca que es lo primero que deberia pasar ya tiene q estar registrado y no es asi 
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
                Console.WriteLine("Ingresa tu nombre de usuario para continuar");
                string name = Console.ReadLine();

                foreach (var item in User.users)
                {
                    if (item.Name == name);
                    SelectMode(item);
                }
                Console.WriteLine("Ese nombre de usuario no se encuentra registrado en el sistema");

                //si no se encuentra en el sistema se envia a que se registre
                Register();
                return;
            }


            if (num == 3)
            {
                Console.WriteLine("Te esperamos la proxima!");
                return;
            }

            else
            {
                Console.WriteLine("No tenemos una opción para ese numero");
            }
            return;

        }
        public static void SelectMode(User user) //como pasar un usuario o otra forma de implementarlo
        {

            Console.WriteLine("Estos son los diferentes modos de juego, ingresa un número para seleccionar.\n 1- Modo Clasico \n 2- Modo bomba \n 3- Modo TimeTrial \n 4- Modo Challenge");
            int num = int.Parse(Console.ReadLine());


            if (num == 1)
            {
                Administrator.Classic.Add(user);
                Console.WriteLine("Estas en la lista de espera para comenzar tu partida");
                return;
            }
            if (num == 2)
            {
                Administrator.Bomb.Add(user);
                Console.WriteLine("Estas en la lista de espera para comenzar tu partida");
                return;
            }
            if (num == 3)
            {
                Administrator.TimeTrial.Add(user);
                Console.WriteLine("Estas en la lista de espera para comenzar tu partida");
                return;
            }
            if (num == 4)
            {
                Administrator.Challenge.Add(user);
                Console.WriteLine("Estas en la lista de espera para comenzar tu partida");
                return;
            }
            else
            {
                Console.WriteLine("No tenemos una opción de juego para ese numero");
                SelectMode(user);
                return;
            }
        }

        public static void Register()
        {
            Console.WriteLine("Envía un nombre de usuario para registrarte.");

            string UserName = Console.ReadLine();

            if (UserName != string.Empty)
            {
                SelectMode(Administrator.CheckUser(UserName)); //inmediatamente luego de registrarse se lo envía a seleccionar modo
            }

            else
            {
                Console.WriteLine("No enviaste un nombre de usuario valido");
            }
        }
    }
}



