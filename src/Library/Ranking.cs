using System;
using System.Collections;

namespace Library
{
    public class Ranking          
    {
        public List<Stadistics> playersList = new List<Stadistics>(){};
        
        private int userId;
        private int totalGames;
        private int totalWins;

        public Ranking()
        {
            this.playersList = playersList;
            this.userId = userId;
            this.totalGames = totalGames;
            this.totalWins = totalWins;
        }

        public void UpdateRanking()
        {   

            // List<User> sortedList = User.users.OrderBy(x=>x.wins);
            
            playersList.Sort((Stadistics stats1, Stadistics stats2) =>
            {
                int result = stats1.wins.CompareTo(stats2.wins);
                
                return result == 0 ? stats1.winRate.CompareTo(stats2.winRate) : result;

                
            });

        }

        public void ShowTop10()
        {
            Console.WriteLine("Top 10 jugadores:");
            for (int i = 0; i < 11; i++)
            {
                Console.WriteLine(sortedList[i]);
            }
        }

        public void ShowMyRank(Stadistics stats)
        {
            //Console.WriteLine($"Tu posición en el ranking global es: {playersList}");
            foreach (var i = 0; i < this.playersList.Count; i++)
            {

            }
        }
    }
}
