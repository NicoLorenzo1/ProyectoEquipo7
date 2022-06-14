using System;
using Library;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User("user");

            //User user2 = new User("user1");
            //User user4 = new User("user4");

            //Console.WriteLine(User.users["user"]);
            //Console.WriteLine(user.Id);
            // Console.WriteLine(user2.Id);
            // Console.WriteLine(user4.Id);

            //TimeTrial timeTrial = new TimeTrial();
            //timeTrial.FinishTimeGame();

            Menu menu = new Menu();
            menu.ShowMenu();
        


            //Console.WriteLine(Stadistics.playedGames.Count);



            //QuickChat.SendPredefinedChat(1);
            //QuickChat.AllMessages();
            //Stadistics.ShowStats(user);




        }
    }
}

