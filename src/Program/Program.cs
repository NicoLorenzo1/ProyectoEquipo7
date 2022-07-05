using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
namespace Library
{
    /// <summary>
    /// Un programa que implementa un bot de Telegram.
    /// </summary>
    public abstract class Program
    {
        /// <summary>
        /// Punto de entrada al programa.
        /// </summary>
        public static void Main()
        {

            User jose = new User("Jose");
            User juan = new User("Juan");
            User nico = new User("Nico");
            User manu = new User("Manu");
            User maria = new User("Maria");

            Administrator administrator = Administrator.Instance;

            administrator.usersRegistered.Add(juan);
            administrator.usersRegistered.Add(nico);
            administrator.usersRegistered.Add(manu);
            administrator.usersRegistered.Add(maria);
            administrator.UsersToPlay.Add(juan, "classic");
            administrator.UsersToPlay.Add(nico, "challenge");
            administrator.UsersToPlay.Add(manu, "bomb");
            administrator.UsersToPlay.Add(maria, "timetrial");


            Menu menu = new Menu();
            menu.ShowMenu();
            administrator.MatchPlayers();
        }

    }
}