namespace Library
{
    public class Administrator
    {
        public List<User> usersRegistered = new List<User>()
        {

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
                m.MatchPlayers(m);
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
