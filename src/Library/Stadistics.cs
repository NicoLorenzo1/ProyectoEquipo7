namespace Library
{
    public class Stadistics
    {

        //Diccionarios en los guales va a tener una key y un value, en este caso seria usuario : valor
        public static Dictionary<User, int> playedGames = new Dictionary<User, int>();
        public static Dictionary<User, int> wins = new Dictionary<User, int>();

        public static Dictionary<User, int> winsPerModdle = new Dictionary<User, int>();

        public Stadistics(User user)
        {
            playedGames.Add(user, 0);
            wins.Add(user, 0);                                // asignar el valor de partidas
            winsPerModdle.Add(user, 0);
        }

        public static void ShowStats(User user)
        {
            Console.WriteLine($"Estadisticas del usuario {user.Name}\n Partidas jugadas: {playedGames[user]}\n Partidas ganadas: {wins[user]}\n Victorias por modulo: {winsPerModdle[user]}");
        }

    }
}