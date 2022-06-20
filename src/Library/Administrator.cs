namespace Library
{
    public class Administrator
    {
        public List<User> usersRegistered = new List<User>()
        {

        };
        //lista general de modos de juego.
        public List<Lobby> modeList = new List<Lobby>()
        {
            new TimeTrialMode("Time Trial"),
            new ClassicMode("Classic")
        };

        private void MatchPlayers()
        {
            foreach (Lobby m in modeList)
            {
                m.MatchPlayers();
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
