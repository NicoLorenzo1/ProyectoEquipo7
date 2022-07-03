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
            //User user = new User("user1");
            //Administrator.Instance.UsersToPlay.Add(user, "classic");
            //Bot.Instance.Setup();
            Bot bot = new Bot();
            bot.Setup();
            TelegramBot.Start();
            Console.WriteLine($"Bot ended!");
            //User jose = new User("Jose");
            //User juan = new User("Juan");

            Administrator administrator = Administrator.Instance;
            //administrator.usersRegistered.Add(jose);

            //administrator.UsersToPlay.Add(jose, "Classic");
            //administrator.usersRegistered.Add(juan);
            //administrator.UsersToPlay.Add(juan, "Challenge");



            //Game game = new Game("classic");
            //game.AddUserToWaitList(user1);
            //game.AddUserToWaitList(user2);

            //Menu menu = new Menu();
            //menu.ShowMenu();
            //administrator.MatchPlayers();
            //menu.SelectMode(jose);

            /* Esto es lo que tenia yo

            User user = new User("user");
            User user2 = new User("user2");
            Game game = new Game(user,user2,"classic");
            game.StartGame();
            */








            //User user2 = new User("user1");
            //User user4 = new User("user4");

            //Console.WriteLine(User.users["user"]);
            //Console.WriteLine(user.Id);
            // Console.WriteLine(user2.Id);
            // Console.WriteLine(user4.Id);

            //TimeTrial timeTrial = new TimeTrial();
            //timeTrial.FinishTimeGame();

            //Menu menu = new Menu();
            //menu.ShowMenu();



            //Console.WriteLine(Stadistics.playedGames.Count);



            //QuickChat.SendPredefinedChat(1);
            //QuickChat.AllMessages();
            //Stadistics.ShowStats(user);



            // Esperamos a que el usuario aprete Enter en la consola para terminar el bot.

        }

    }
}