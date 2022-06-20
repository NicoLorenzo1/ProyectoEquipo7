using System;
using System.Collections;

namespace Library
{
    public class Ranking
    {
        public static HashSet<Statistics> playerStats = new HashSet<Statistics>() { };  //Stat

        public List<Statistics> top10 = new List<Statistics>() { };

        public Ranking() { }

        private List<Statistics> getAllSorted()
        {
            List<Statistics> statsList = playerStats.ToList();

            sortStats(statsList);

            return statsList;
        }

        private void sortStats(List<Statistics> stats)
        {
            stats.Sort((Statistics stats1, Statistics stats2) =>
                {
                    int result = stats1.Wins.CompareTo(stats2.Wins);

                    return result == 0 ? stats1.WinRate.CompareTo(stats2.WinRate) : result;
                });
        }

        public void checkTop10Status(Statistics st)
        {
            if (top10.IndexOf(st) == -1)
            {
                int initialWins = top10.Count > 0 ? int.MaxValue : -1;

                foreach (Statistics t10 in top10)
                {
                    initialWins = t10.Wins < initialWins ? t10.Wins : initialWins;
                }
                if (st.Wins > initialWins)
                {
                    top10.Add(st);

                    sortStats(top10);

                    if (top10.Count > 10)
                    {
                        top10.RemoveAt(10);
                    }
                }
            }
        }

        public static void AddToRankList(Statistics stats)
        {
            playerStats.Add(stats);    
        }

        public void ShowAll()
        {
            List<Statistics> sortedAll = getAllSorted();

            Console.WriteLine("Top 10 jugadores:");
            for (int i = 0; i < sortedAll.Count ; i++)
            {   
                Console.WriteLine($"{i+1}-Nombre:{sortedAll[i].User.Name} - Wins={sortedAll[i].Wins} - WinRate={sortedAll[i].WinRate}");
            }
        }

        public void ShowMyRank(User user)
        {
            List<Statistics> sortedAll = getAllSorted();

            int i = 1;
            foreach (Statistics st in sortedAll)
            {
                if (user.Id == st.User.Id)
                {
                    Console.WriteLine($"Tu posición en el ranking global es: {i}");
                    break;
                }
                i++;
            }
        }
    }
}
