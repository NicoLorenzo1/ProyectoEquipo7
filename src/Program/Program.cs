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
    /// Un programa que implementa un bot de Telegram. Para que ejecute por el bot descomentar de los "=====" para arriba
    /// para que funcione por consola dejar comentado el codigo del bot y descomentar de la linea "=======" para abajo.
    /// </summary>
    public abstract class Program
    {
        /// <summary>
        /// Punto de entrada al programa.
        /// </summary>
        public static void Main()
        {
            try{
            Bot bot = new Bot();
            bot.Setup();
            Administrator.Instance.BotEnabled = true;

            TelegramBot.Start();
            Console.WriteLine($"Bot ended!");
            }
            catch(Exception e){
                Console.WriteLine($"Excepcion: {e.Message} Stacktrace: {e.StackTrace}");
            }
//=====================================================================================================
            /*
            try
            {
                Bot bot = new Bot();
                bot.Setup();
                User jose = new User("Jose");
                User juan = new User("Juan");
                User nico = new User("Nico");
                User manu = new User("Manu");
                User maria = new User("Maria");

                Administrator administrator = Administrator.Instance;
                administrator.BotEnabled = false;


                administrator.usersRegisteredWithState.Add(juan, null);
                administrator.usersRegisteredWithState.Add(nico, null);
                administrator.usersRegisteredWithState.Add(manu, null);
                administrator.usersRegisteredWithState.Add(maria, null);
                administrator.UsersToPlay.Add(juan, "classic");
                administrator.UsersToPlay.Add(nico, "challenge");
                administrator.UsersToPlay.Add(manu, "bomb");
                administrator.UsersToPlay.Add(maria, "timetrial");

                Menu menu = new Menu();
                menu.ShowMenu();
                administrator.MatchPlayers();
            }
            catch (Exception e)
            {
                Console
                    .WriteLine($"Exception: {e.Message} Stacktrace: {e.StackTrace}");
            }*/
        }
    }
}
