using System;
using Library;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            User jose = new User("jose");

            Administrator administrator = Administrator.Instance;
            administrator.UsersToPlay.Add(jose, "Classic");

            //Game game = new Game("classic");
            //game.AddUserToWaitList(user1);
            //game.AddUserToWaitList(user2);

            Menu menu = new Menu();
            menu.ShowMenu();

        }
    }
}

