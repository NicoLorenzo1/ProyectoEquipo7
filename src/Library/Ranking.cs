
//Funcionalidad extra. Será correctamente implementada para la 3er entrega.
using System;
using System.Collections;

namespace Library
{
    /// <summary>
    /// Singleton. Mantiene una lista estática con los stats de todos los usuarios.
    /// Por Expert se crea ranking que es el encargado de conocer todas las estadisticas de todos los usuarios
    /// y de ordenarlas en base a ciertos criterios
    /// </summary>

    public class Ranking
    {
        /// <summary>
        /// HashSet de estadísticas como atributo.
        /// </summary>
        /// <typeparam name="Statistics">Los objetos que componen el HashSet son de la clase
        /// Statistics.</typeparam>
        public static HashSet<Statistics> playerStats = new HashSet<Statistics>() { }; 

        /// <summary>
        /// Lista de estadísticas como atributo.
        /// </summary>
        /// <typeparam name="Statistics">Los objetos que componen la lista son de la clase
        /// Statistics.</typeparam>
        public List<Statistics> top10 = new List<Statistics>() { };

        /// <summary>
        /// Constructor de Ranking.
        /// </summary>
        public Ranking() { }

        /// <summary>
        /// El método getAllSorted usa al método sortStats para devolver la lista global ordenada.
        /// </summary>
        /// <returns>Devuelve el ranking global ordenado en forma de lista.</returns>
        private List<Statistics> getAllSorted()
        {
            List<Statistics> statsList = playerStats.ToList();

            sortStats(statsList);

            return statsList;
        }

        /// <summary>
        /// El método sortStats recibe una lista de objetos de la clase Statistics y la ordena
        /// según su total de victorias y luego según su porcentaje de victorias.
        /// </summary>
        /// <param name="stats">Lista de objetos de clase Statistics para ordenar.</param>
        private void sortStats(List<Statistics> stats)
        {
            stats.Sort((Statistics stats1, Statistics stats2) =>
                {
                    int result = stats1.Wins.CompareTo(stats2.Wins);

                    return result == 0 ? stats1.WinRate.CompareTo(stats2.WinRate) : result;
                });
        }

        /// <summary>
        /// El método checkTop10Status recibe un objeto de clase Statistics y verifica si 
        /// entra a los primeros 10 usuarios en el ranking.
        /// </summary>
        /// <param name="st">Objeto de clase Statistics para verificar si entra en el top10.</param>
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

        /// <summary>
        /// El método AddToRankList agrega las estadísticas de un usuario al ranking global.
        /// </summary>
        /// <param name="stats">Objeto de clase Statistics.</param>
        public static void AddToRankList(Statistics stats)
        {
            playerStats.Add(stats);    
        }

        /// <summary>
        /// El método ShowAll muestra el ranking global de jugadores.
        /// </summary>
        public void ShowAll()
        {
            List<Statistics> sortedAll = getAllSorted();

            Console.WriteLine("Ranking de jugadores:");
            for (int i = 0; i < sortedAll.Count ; i++)
            {   
                Console.WriteLine($"{i+1}-Nombre:{sortedAll[i].User.Name} - Wins={sortedAll[i].Wins} - WinRate={sortedAll[i].WinRate}");
            }
        }

        /// <summary>
        /// El método ShowAll muestra el ranking global de jugadores.
        /// </summary>
        public void ShowTop10()
        {
            List<Statistics> sortedAll = getAllSorted();

            Console.WriteLine("Ranking de jugadores:");
            for (int i = 0; i < sortedAll.Count ; i++)
            {   
                Console.WriteLine($"{i+1}-Nombre:{sortedAll[i].User.Name} - Wins={sortedAll[i].Wins} - WinRate={sortedAll[i].WinRate}");
            }
        }

        /// <summary>
        /// El método ShowMyRank recive a un objeto de clase Usuario, y le permite 
        /// al jugador ver su posición en el ranking sin tener que buscarse entre 
        /// todos los jugadores del ranking.
        /// </summary>
        /// <param name="user">Objeto de clase User.</param>
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
