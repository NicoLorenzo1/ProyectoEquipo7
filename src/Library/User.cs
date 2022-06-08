using System;

namespace Library
{
    public class User
    {
        public static Dictionary<string, int> users = new Dictionary<string, int>();
        private static int count = 0;

        public User(string name)
        {
            this.Name = name;
            this.Id = count += 1;

        }

        private string Name { get; set; }
        public int Id { get; set; }


        //checkUser debe ir en el el metodo de registrarse o en otro lado no aca 
        public void CheckUser(int Id)
        {
            for (int i = 0; i <= users.Count; i++)
            {
                if (users.ContainsKey(this.Name) && users.ContainsValue(this.Id))
                {
                    Console.WriteLine("El usuario ya esta registrado en el juego");
                }
                else
                {
                    users.Add(this.Name, this.Id);
                }
            }
        }

    }
}