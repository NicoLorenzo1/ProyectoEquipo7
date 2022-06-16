/*
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
            
            playersList.Sort((Stadistics userA, Stadistics userB) =>
            {
                int result = userA.wins.CompareTo(userB.wins);
                
                return result == 0 ? userA.winRate.CompareTo(userB.winRate) : result;
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

        public void ShowMyRank(Stadistics stadistics)
        {
            Console.WriteLine($"Tu posición en el ranking global es: {stadistics.}");
        }
    }
}
*/