﻿using System;
using Library;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            User jose = new User("Jose");
            User juan = new User("Juan");
            User nico = new User("Nico");

            Administrator administrator = Administrator.Instance;
            administrator.usersRegistered.Add(jose);
            //administrator.UsersToPlay.Add(jose, "Classic");
            administrator.usersRegistered.Add(juan);
            //administrator.UsersToPlay.Add(juan, "Challenge");
            administrator.usersRegistered.Add(nico);
            //administrator.UsersToPlay.Add(nico, "Bomb");
            
            

            //Game game = new Game("classic");
            //game.AddUserToWaitList(user1);
            //game.AddUserToWaitList(user2);

            Menu menu = new Menu();
            menu.ShowMenu();
            administrator.MatchPlayers(jose,"Classic");
            administrator.MatchPlayers(nico,"Bomb");
            administrator.MatchPlayers(juan,"Challenge");
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




        }
    }
}
