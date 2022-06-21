namespace Library
{
    /// <summary>
    /// Almacena información de un usuario que cambia según los resultados de sus partidas.
    /// </summary>
    public class Statistics
    {
        private int playedGames;
        private int wins;
        private int winRate;
        private User user;

        /// <summary>
        /// Constructor de la clase Statistics. Siempre que se crea una estadística,
        /// se agrega al ranking global.
        /// </summary>
        /// <param name="user">Usuario al cual pertenecen estas estadísticas.</param>
        public Statistics(User user)
        {
            this.user = user;
            Ranking.AddToRankList(this);
        }

        /// <summary>
        /// El método ModifyStatics mantiene actualizadas las estadísticas del usuario
        /// segun los resultados de las partidas jugadas.
        /// </summary>
        /// <param name="user">Usuario al cual se le modifican las estadísticas.</param>
        /// <param name="boolean">Variable booleana que determina si se le agrega una
        /// victoria al usuario.</param>
        public void ModifyStatics(User user, bool boolean)
        {
            user.Statistics.playedGames = +1;

            if (boolean == true)
            {
                user.Statistics.wins = +1;
            }

            if (user.Statistics.wins == 0)
            {
                user.Statistics.winRate = 0;
            }
            else
            {
                user.Statistics.winRate = playedGames / wins * 100;
            }
            
            Ranking.checkTop10Status(this);

            //checkear si entra en la lista nueva de top 10 y sumarla o ignorarla

            
        }

        /// <summary>
        /// El método ShowStats imprime las estadísticas del usuario.
        /// </summary>
        /// <param name="user">Usuario del cual se imprimirán las estadísticas.</param>
        public static void ShowStats(User user)
        {
            Console.WriteLine($"Estadisticas del usuario {user.Name}\n Partidas jugadas: {user.Statistics.playedGames}\n Partidas ganadas: {user.Statistics.wins}\n Ratio de victorias: {user.Statistics.winRate}%");
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

        /// <summary>
        /// GetHashCode consigue el HashCode del Id del usuario.
        /// </summary>
        /// <returns>Devuelve el Id del usuario.</returns>
        public override int GetHashCode()
        {
            return this.user.Id;
        }
    }
}