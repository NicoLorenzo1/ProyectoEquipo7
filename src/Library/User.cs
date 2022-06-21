using System;

namespace Library
{
    public class User
    {
        //public static Dictionary<string, int> users = new Dictionary<string, int>();
        public static List<User> users = new List<User>();

        private static int count = 0;
        private string name;
        private int id;

        public Statistics Statistics;

        public User(string name)
        {
            this.name = name;
            this.id = count += 1;
            this.Statistics = new Statistics(this);
            users.Add(this);
        }


        public string Name
        {
            get
            {
                return this.name;
            }
        }
        public int Id
        {
            get
            {
                return this.id;
            }
        }

    }

    
}