namespace Library
{

    //<summary>
    //Por SRP statistics es el encargado de conocer toda la información de las estadísticas del
    // usuario al que se esta asignada
    //</summary>
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
            user.statistics.playedGames = +1;

            if (boolean == true)
            {
                user.statistics.wins = +1;
            }
            if (wins==0)
            {
                user.statistics.winRate=0;
            }
            else
            {
                user.statistics.winRate = playedGames / wins * 100; 
            }
            
        }

        public static void ShowStats(User user)
        {
            Console.WriteLine($"Estadisticas del usuario {user.Name}\n Partidas jugadas: {user.statistics.playedGames}\n Partidas ganadas: {user.statistics.wins}\n Ratio de victorias: {user.statistics.winRate}%");
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