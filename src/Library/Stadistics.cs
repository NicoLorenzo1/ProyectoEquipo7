namespace Library
{
    public class Stadistics
    {

        private int playedGames;
        private int wins;
        private int winRate;
        private User user;

        public Stadistics(User user)
        {
            this.user = user;
        }

        public void ModifyStatics(User user, bool boolean)
        {
            user.stadistics.playedGames = +1;

            if (boolean == true)
            {
                user.stadistics.wins = +1;
            }
            if (user.stadistics.wins == 0)
            {
                user.stadistics.winRate = 0;
            }
            else
            {
                user.stadistics.winRate = playedGames / wins * 100;
            }
        }

        public static void ShowStats(User user)
        {
            Console.WriteLine($"Estadisticas del usuario {user.Name}\n Partidas jugadas: {user.stadistics.playedGames}\n Partidas ganadas: {user.stadistics.wins}\n Ratio de victorias: {user.stadistics.winRate}%");
        }

        public int PlayedGames
        {
            get
            {
                return this.playedGames;
            }
        }
        public int Wins
        {
            get
            {
                return this.wins;
            }
        }
        public int WinRate
        {
            get
            {
                return this.winRate;
            }
        }
        public User User
        {
            get
            {
                return this.user;
            }
        }
    }
}