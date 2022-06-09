namespace Library
{
    public class Stadistics
    {
        public static List<Stadistics> stadisticsList = new List<Stadistics>();
        private int UserId;
        private int PlayGames;
        private int Wins;
        private int WinsPerMode;
        public Stadistics()
        {
            this.UserId = UserId;
            this.PlayGames = PlayGames;
            this.Wins = Wins;
            this.WinsPerMode = WinsPerMode;
        }

        public Stadistics ShowStats(int Id)
        {
            Stadistics stadisticUser = new Stadistics();
            stadisticUser.UserId = Id;
            stadisticUser.Wins = 0;
            stadisticUser.PlayGames = 0;
            stadisticUser.WinsPerMode = 0;
            
    

            foreach (var item in stadisticsList)
            {
                if (item.UserId == Id)
                {
                    return item;
                }
            }
            return null;
            
        }

    }
}