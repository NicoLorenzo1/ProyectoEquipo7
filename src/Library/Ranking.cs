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
        /// Lisa de estadísticas como atributo.
        /// </summary>
        /// <typeparam name="Statistics">Los objetos que componen el Lista son de la clase
        /// Statistics.</typeparam>
        public static List<Statistics> playerStats = new List<Statistics>() { }; 

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
        /// Muestra por consola los primeros 10 jugadores del ranking global.
        /// </summary>
        public void ShowTop10()
        {
            List<Statistics> sortedAll = getAllSorted();
            Console.WriteLine("Top 10 Jugadores:");
            for (int i = 0; i < 10 ; i++)
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
        public string ShowMyRank(User user)
        {
            List<Statistics> sortedAll = getAllSorted();

            int userRankingIndex = 0;
            int i = 1;
            foreach (Statistics st in sortedAll)
            {
                if (user.Id == st.User.Id)
                {
                    userRankingIndex = i;
                    break;
                }
                i++;
            }
            return ($"Tu posición en el ranking global es: {userRankingIndex}");
        }
    }
}