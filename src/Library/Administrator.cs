using Telegram.Bot.Types;

namespace Library
{
    /// <summary>
    /// Se encarga de manejar a los usuarios dentro del juego.
    /// </summary>
    public class Administrator
    {
        public Dictionary<User, Enum> usersRegisteredWithState = new Dictionary<User, Enum>();
        public List<Game> currentGame = new List<Game>();
        public Dictionary<User, string> UsersToPlay = new Dictionary<User, string>();
        private static Administrator instance;

        private bool botEnabled = false;

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
        public async void MatchPlayers()
        {
            KeyValuePair<User, string> match1;


            for (int i = 0; i < UsersToPlay.Count; i++)
            {
                match1 = UsersToPlay.ElementAt(i);
                for (int x = i; x < UsersToPlay.Count; x++)
                {
                    if (!(UsersToPlay.ElementAt(x).Key == match1.Key))
                    {
                        if (UsersToPlay.ElementAt(x).Value == match1.Value)
                        {
                            if (match1.Value == "classic")
                            {
                                KeyValuePair<User, string> match2 = UsersToPlay.ElementAt(x);
                                Game game = new Game(match1.Key, match2.Key, "classic");
                                game.StartGame();
                            }
                            else if (match1.Value == "challenge")
                            {
                                KeyValuePair<User, string> match2 = UsersToPlay.ElementAt(x);
                                Challenge challenge = new Challenge(match1.Key, match2.Key, "challenge");
                                challenge.StartGame();
                            }
                            else if (match1.Value == "bomb")
                            {
                                KeyValuePair<User, string> match2 = UsersToPlay.ElementAt(x);
                                Bomb bomb = new Bomb(match1.Key, match2.Key, "bomb");
                                bomb.StartGame();
                            }
                            else if (match1.Value == "timetrial")
                            {
                                KeyValuePair<User, string> match2 = UsersToPlay.ElementAt(x);
                                TimeTrial timeTrial = new TimeTrial(match1.Key, match2.Key, "timetrial");
                                timeTrial.StartGame();
                            }
                        }
                    }
                    else
                    {
                    }
                }
            }
        }


        /// <summary>
        /// Crea un objeto User en caso de que el jugador no esté ya registrado.
        /// </summary>
        /// <param name="name">Nombre del usuario.</param>
        /// <returns>Devuelve un objeto de clase User.</returns>
        public User CheckUser(string name, long chatId)
        {
            User user = isUserRegistered(chatId);
            if (user != null)
            {
                Console.WriteLine("\nEl usuario se registro en el juego");
                user.Name = name; //Actualizo el nombre del usuario
                return user;
            }
            else
            {
                user = new User(name);
                user.Id = chatId;
                user.IdChat = chatId;
                usersRegisteredWithState.Add(user, RegisterState.Start);
                Console.WriteLine("\nUsuario registrado exitosamente\n");
                return user;
            }
        }

        public Board GetPlayerBoard(long playerId)
        {
            foreach (Game game in currentGame)
            {
                if (game.player1.Id == playerId)
                {
                    return game.boardPlayer1;
                }
                else
                if (game.player2.Id == playerId)
                {
                    return game.boardPlayer2;
                }
            }
            return null;
        }

        public Game GetPlayerGame(long playerChatId)
        {
            foreach (Game game in currentGame)
            {
                if (game.player1.IdChat == playerChatId || game.player2.IdChat == playerChatId)
                {
                    return game;
                }
            }
            return null;
        }

        public User isUserRegistered(long Id)
        {
            foreach (var (user, state) in usersRegisteredWithState)
            {
                if (Id != -1 && user.IdChat == Id)
                {
                    return user;
                }
            }
            return null;
        }

        public void AddUserToPlayPool(User user, string mode)
        {
            UsersToPlay[user] = mode; // Nos aseguramos que el jugador este esperando por un solo modo de juego
        }

        public Enum GetUserState(long Id)
        {
            foreach (var (user, state) in usersRegisteredWithState)
            {
                if (Id != -1 && user.IdChat == Id)
                {
                    return state;
                }
            }
            return RegisterState.Start; //Si el usuario no se encuentra es porque aun no esta registrado y debe seguir el proceso de registro
        }
        public void SetUserState(long id, Enum state)
        {
            User user = isUserRegistered(id);
            if (user != null)
            {
                usersRegisteredWithState[user] = state;
            }
            else
            {
                // Si el usuario no existe y quiero setearle estado, creo uno para poder seguir el proceso de registro
                User u = new User("");
                u.Id = id;
                u.IdChat = id;
                usersRegisteredWithState.Add(u, state);
            }
        }

        public bool BotEnabled
        {
            get
            {
                return botEnabled;
            }
            set
            {
                botEnabled = value;
            }
        }
    }
    public enum UserState
    {
        Play
    }
}