namespace Library
{
    public class Administrator
    {
        public List<List<User>> modeList = new List<List<User>>(); //lista general de modos de juego.

        public static List<User> Classic = new List<User>();
        public static List<User> Bomb = new List<User>();

        public static List<User> TimeTrial = new List<User>();

        public static List<User> Challenge = new List<User>();

        //private List<Game> CurrentGames = new List<User>();

        private void MatchPlayers()
        {
            while (true)
            {
                foreach (var modelist in modeList)
                {
                    if (modelist.Count > 2)
                    {
                        //Game.StartGame(modelist.ElementAt(0), modelist.ElementAt(1))

                    }
                }
            }

            /*
                        while (true)
                        {
                            if (Classic.Count > 2)
                            {
                                //Game.StartGame(Classic.ElementAt(0), Classic.ElementAt(1))
                            }
                            if (Bomb.Count > 2)
                            {
                                //Game.StartGame()
                            }
                            if (TimeTrial.Count > 2)
                            {
                                //Game.StartGame()
                            }
                            if (Challenge.Count > 2)
                            {
                                //Game.StartGame()
                            }
                        }
                    */

        }

        public static User CheckUser(string name)
        {

            foreach (var item in User.users)
            {
                if (item.Name == name)
                {
                    Console.WriteLine("El usuario ya esta registrado en el juego");
                    return item;
                }
            }

            var user = new User(name);
            User.users.Add(user);
            Console.WriteLine("Usuario registrado exitosamente");
            return user;
        }

    }
}
