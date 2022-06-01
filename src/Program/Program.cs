using System;
using Library;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User("user");
            User user2 = new User("user1");
            User user4 = new User("user4");

            //Console.WriteLine(User.users["user"]);
           Console.WriteLine(user.Id);
           Console.WriteLine(user2.Id);
           Console.WriteLine(user4.Id);

            
        }
    }
}