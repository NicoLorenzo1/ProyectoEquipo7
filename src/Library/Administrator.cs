namespace Library
{
    public class Administrator
    {
        public List<User> usersRegistered = new List<User>();
        public List<Game> currentGame = new List<Game>();
        public Dictionary<User, string> UsersToPlay = new Dictionary<User, string>();
        private static Administrator instance;

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

        public void MatchPlayers(User user, string mode)
        {
            UsersToPlay.Add(user, mode);
            KeyValuePair<User, string> match1;
            foreach (var element in UsersToPlay)
            {
                for (int i = 0; i < UsersToPlay.Count; i++)
                {   
                    //string mode = element;
                    //System.Console.WriteLine(element.Value);
                    // UserToPlay = { (jose,classic), (juan, classic)  }
                    if (element.Value[0] == element.Value[i])
                    {
                        if (!(UsersToPlay.ElementAt(x).Key == match1.Key))
                        {
                            if (UsersToPlay.ElementAt(x).Value == match1.Value)
                            {
                                if(match1.Value=="Classic")
                                {
                                    KeyValuePair<User, string> match2 = UsersToPlay.ElementAt(x);
                                    Game game = new Game(match1.Key, match2.Key, "Classic");
                                    game.StartGame(); 
                                }
                                else if (match1.Value=="Bomb")
                                {
                                    KeyValuePair<User, string> match2 = UsersToPlay.ElementAt(x);
                                    Bomb game = new Bomb(match1.Key, match2.Key, "Bomb");
                                    game.StartGame(); 
                                }
                                else if (match1.Value=="Challenge")
                                {
                                    KeyValuePair<User, string> match2 = UsersToPlay.ElementAt(x);
                                    Challenge game = new Challenge(match1.Key, match2.Key, "Challenge");
                                    game.StartGame(); 
                                }
                                else if (match1.Value=="TimeTrial")
                                {
                                    KeyValuePair<User, string> match2 = UsersToPlay.ElementAt(x);
                                    TimeTrialMode game = new TimeTrialMode(match1.Key, match2.Key, "TimeTrial");
                                    game.StartGame(); 
                                }
                                
                            }
                        }
                        else
                        {
                        }
                    }
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
            Console.WriteLine("\nUsuario registrado exitosamente\n");
            return user;
        }

        //lista general de modos de juego.
        /*
        public List<Lobby> modeList = new List<Lobby>()
        {
            new TimeTrialMode("Time Trial"),
            new Game("Classic")
        };


        //Metodo para encontrar jugadores del mismo modo para cuando tengamos los nuevos modos
        private void MatchPlayers()
        {
            foreach (Lobby m in modeList)
            {
                m.MatchPlayers();
            }
        }*/
    }
}