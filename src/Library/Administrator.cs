using Telegram.Bot.Types;
using Telegram.Bot;
namespace Library
{
    /// <summary>
    /// Se encarga de manejar a los usuarios dentro del juego.
    /// </summary>
    public class Administrator
    {
        private static IHandler firstHandler;
        private static TelegramBotClient telegramClient;
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
        public async void MatchPlayers()
        {
            int counter = 0;
            //UsersToPlay.Add(user, mode);
            KeyValuePair<User, string> match1;

            for (int i = 0; i < UsersToPlay.Count; i++)
            {
                if (counter == 0)
                {
                    match1 = UsersToPlay.ElementAt(i);
                    counter = +1;
                    for (int x = i; x < UsersToPlay.Count; x++)
                    {
                        if (!(UsersToPlay.ElementAt(x).Key == match1.Key))
                        {
                            if (UsersToPlay.ElementAt(x).Value == match1.Value.ToLower())
                            {

                                //await TelegramBot.telegramClient.SendTextMessageAsync(match1.Key.IdChat, $"Comenzara la batalla contra {match2.Key.Name}");
                                //await TelegramBot.telegramClient.SendTextMessageAsync(match2.Key.IdChat, $"Comenzara la batalla contra {match1.Key.Name}");

                                //game.StartGame();
                                if (match1.Value.ToLower() == "classic")
                                {
                                    KeyValuePair<User, string> match2 = UsersToPlay.ElementAt(x);
                                    Game game = new Game(match1.Key, match2.Key, "classic");
                                    game.StartGame();
                                }
                                else if (match1.Value.ToLower() == "bomb")
                                {
                                    KeyValuePair<User, string> match2 = UsersToPlay.ElementAt(x);
                                    Challenge game = new Challenge(match1.Key, match2.Key, "bomb");
                                    game.StartGame();
                                }
                                else if (match1.Value.ToLower() == "challenge")
                                {
                                    KeyValuePair<User, string> match2 = UsersToPlay.ElementAt(x);
                                    Challenge game = new Challenge(match1.Key, match2.Key, "challenge");
                                    game.StartGame();
                                }
                                else if (match1.Value.ToLower() == "challenge")
                                {
                                    KeyValuePair<User, string> match2 = UsersToPlay.ElementAt(x);
                                    Challenge game = new Challenge(match1.Key, match2.Key, "challenge");
                                    game.StartGame();
                                }

                            }
                        }
                        else
                        {
                        }
                    }
                }
                else
                {
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

        public Board GetPlayerBoard(long playerId)
        {
            foreach (Game game in currentGame)
            {
                Console.WriteLine($">>>> playerId {game.player1.Id} - {game.player2.Id} - {playerId}");
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