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
            User user = new User("user1");
            Administrator.Instance.UsersToPlay.Add(user, "classic");
            //Bot.Instance.Setup();
            Bot bot = new Bot();
            bot.Setup();
            TelegramBot.Start();
            Console.WriteLine($"Bot ended!");

            // Esperamos a que el usuario aprete Enter en la consola para terminar el bot.

        }

    }
}