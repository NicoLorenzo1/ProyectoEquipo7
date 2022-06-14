namespace Library
{
    public class Administrator
    {
        public List<User> usersRegistered = new List<User>()
        {
            /*
            new User("juan"),
            new User("Lucas"),
            new User("German"),
            new User("Vale"),
            */

        };
        //lista general de modos de juego.
        public List<Mode> modeList = new List<Mode>()
        {
            new TimeTrialMode("Time Trial"),
            new ClassicMode("Classic")

        };

        private void MatchPlayers()
        {
            foreach (Mode m in modeList)
            {
                if (m.usersWaiting.Count >= 1)
                {
                    Mode mode = new Mode(m.Name);
                    mode.StartGame(m.usersWaiting.ElementAt(0), m.usersWaiting.ElementAt(1));
                    //Remuevo los usuarios de la lista de espera de ese modo.
                    m.usersWaiting.Remove(m.usersWaiting.ElementAt(0));
                    m.usersWaiting.Remove(m.usersWaiting.ElementAt(1));
                    Console.WriteLine($"Comenzará una nueva partida de {m.Name} con los jugadores {m.usersWaiting.ElementAt(0)} , {m.usersWaiting.ElementAt(1)}.");
                }
            }
        }

        public User CheckUser(string name)
        {
            foreach (User u in usersRegistered)
            {
                if (u.Name == name)
                {
                    Console.WriteLine("\nEl usuario ya esta registrado en el juego");
                    return u;
                }
            }

            User user = new User(name);
            usersRegistered.Add(user);
            Console.WriteLine("\nUsuario registrado exitosamente");
            return user;
        }

    }

}
