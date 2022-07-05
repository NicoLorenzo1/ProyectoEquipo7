namespace Library
{
    /// <summary>
    /// Almacena información de un usuario que cambia según los resultados de sus partidas.
    /// Por SRP statistics es el encargado de conocer toda la información de las estadísticas del
    /// usuario al que se esta asignada
    /// </summary>

    public class Statistics
    {
        private int playedGames;
        private int wins;
        private int winRate;
        private User user;

        /// <summary>
        /// Constructor de la clase Statistics. Siempre que se crea una estadística,
        /// se agrega al ranking global (para la 3er entrega).
        /// </summary>
        /// <param name="user">Usuario al cual pertenecen estas estadísticas.</param>
        public Statistics(User user)
        {
            this.user = user;
            //Ranking.AddToRankList(this);
        }

        /// <summary>
        /// El método ModifyStatics mantiene actualizadas las estadísticas del usuario
        /// segun los resultados de las partidas jugadas.
        /// </summary>
        /// <param name="user">Usuario al cual se le modifican las estadísticas.</param>
        /// <param name="victory">Variable booleana que determina si se le agrega una
        /// victoria al usuario.</param>
        public void ModifyStatics(User user, bool victory)
        {
            user.statistics.playedGames = +1;

            if (victory)
            {
                user.statistics.wins = +1;
            }

            if (wins == 0)
            {
                user.statistics.winRate = 0;
            }
            else
            {
                user.statistics.winRate = playedGames / wins * 100;
            }

        }

        /// <summary>
        /// El método ShowStats imprime las estadísticas del usuario.
        /// </summary>
        /// <param name="user">Usuario del cual se imprimirán las estadísticas.</param>
        public static string ShowStats(User user)
        {
            Console.WriteLine($"Estadisticas del usuario {user.Name}\n Partidas jugadas: {user.statistics.playedGames}\n Partidas ganadas: {user.statistics.wins}\n Ratio de victorias: {user.statistics.winRate}%");
            return $"Partidas jugadas: {user.statistics.playedGames}\n Partidas ganadas: {user.statistics.wins}\n Ratio de victorias: {user.statistics.winRate}%";
        }

        /// <summary>
        /// Método Get para el total de partidas jugadas del usuario.
        /// </summary>
        public int PlayedGames
        {
            get
            {
                return this.playedGames;
            }
        }
        /// <summary>
        /// Método Get para el total de victorias del usuario.
        /// </summary>
        public int Wins
        {
            get
            {
                return this.wins;
            }
        }

        /// <summary>
        /// Método Get para el porcentaje de victorias del usuario.
        /// </summary>
        public int WinRate
        {
            get
            {
                return this.winRate;
            }
        }

        /// <summary>
        /// Método Get para el usuario de estas estadísticas.
        /// </summary>
        public User User
        {
            get
            {
                return this.user;
            }
        }

        /// <summary>
        /// Equals devuelve un valor booleano que indica si la instancia actual
        /// es igual al objeto especificado o no.
        /// </summary>
        /// <param name="obj">Objeto a comparar con la instancia acual.</param>
        /// <returns>Devuelve true si son valores iguales, sino false.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Statistics input = (Statistics)obj;

            return this.user.Id == input.user.Id;
        }


    }
}