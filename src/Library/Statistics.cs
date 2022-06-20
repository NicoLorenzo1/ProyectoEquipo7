namespace Library
{
    public class Statistics
    {
        private int playedGames;
        private int wins;
        private int winRate;
        private User user;

        public Statistics(User user)
        {
            this.user = user;
            Ranking.AddToRankList(this);     //siempre que se crea una stat, lo agrego al ranking global
        }

        public void ModifyStatics(User user, bool boolean)
        {
            user.Statistics.playedGames = +1;

            if (boolean == true)
            {
                user.Statistics.wins = +1;
            }
            user.Statistics.winRate = playedGames / wins * 100;

            //checkear si entra en la lista nueva de top 10 y sumarla o ignorarla

            
        }

        public static void ShowStats(User user)
        {
            Console.WriteLine($"Estadisticas del usuario {user.Name}\n Partidas jugadas: {user.Statistics.playedGames}\n Partidas ganadas: {user.Statistics.wins}\n Ratio de victorias: {user.Statistics.winRate}%");
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

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Statistics input = (Statistics)obj;

            return this.user.Id == input.user.Id;
        }

        public override int GetHashCode()
        {
            return this.user.Id;
        }
    }
}