namespace Library
{
    /// <summary>
    /// Se encarga de manejar a los usuarios dentro del juego.
    /// </summary>
    public class Administrator
    {
        public List<User> usersRegistered = new List<User>();
        public List<Game> currentGame = new List<Game>();
        public Dictionary<User, string> UsersToPlay = new Dictionary<User, string>();
        private static Administrator instance;

        /// <summary>
        /// Se crea una única instancia de la clase Administrator.
        /// </summary>
        public static Administrator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Administrator();
                }

                return instance;
            }
        }

        /// <summary>
        /// Empareja dos jugadores según el modo de juego que seleccionaron y comienza su partida.
        /// </summary>
        /// <param name="user">Usuario a emparejar.</param>
        /// <param name="mode">Modo de juego seleccionado.</param>
        public void MatchPlayers(User user, string mode)
        {

            int counter = 0;
            UsersToPlay.Add(user, mode);
            KeyValuePair<User, string> match1;

            
            for (int i = 0; i < UsersToPlay.Count; i++)
            {   
                if (counter==0)
                {
                    match1 = UsersToPlay.ElementAt(i);
                    counter =+1;
                    for (int x = i; x < UsersToPlay.Count; x++)
                    {
                        if (!(UsersToPlay.ElementAt(x).Key==match1.Key))
                        {   
                            if (UsersToPlay.ElementAt(x).Value==match1.Value)
                            {
                                KeyValuePair<User, string> match2 = UsersToPlay.ElementAt(x);
                                Game game = new Game(match1.Key, match2.Key, "Classic");
                                game.StartGame(); 
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Crea un objeto User en caso de que el jugador no esté ya registrado.
        /// </summary>
        /// <param name="name">Nombre del usuario.</param>
        /// <returns>Devuelve un objeto de clase User.</returns>
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
            Console.WriteLine("\nUsuario registrado exitosamente\n");
            return user;
        }

        //lista general de modos de juego.
        
        public List<Lobby> modeList = new List<Lobby>()
        {
            new TimeTrial("Time Trial"),
            new Game("Classic"),
            new BombMode("")
        };
        //Metodo para encontrar jugadores del mismo modo para cuando tengamos los nuevos modos
        private void MatchPlayers()
        {
            foreach (Lobby m in modeList)
            {
                m.MatchPlayers();
            }
        }
    }
}