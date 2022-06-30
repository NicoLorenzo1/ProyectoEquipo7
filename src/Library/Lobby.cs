namespace Library
{
    //<summary>
    //Por DIP se crea la clase lobby, que es la que tiene los metodos y atributos
    //para que cada modo de juego posea su propia lista de espera
    //</summary>
    public class Lobby
    {
        private string name;
        public List<User> usersWaiting = new List<User>();

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">Nombre del modo de juego seleccionado.</param>
        public Lobby(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// Método Get/Set de la string que ingresó el usuario al crear el objeto Lobby.
        /// </summary>
        /// <value></value>
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        /// <summary>
        /// Agrega al usuario
        /// </summary>
        /// <param name="user"></param>
        public void AddUserToWaitList(User user)
        {
            usersWaiting.Add(user);
        }

        /// <summary>
        /// Se remueven los usuarios de la lista de espera de ese modo.
        /// </summary>
        public virtual void MatchPlayers()
        {
            if (usersWaiting.Count >= 2)
            {
                this.usersWaiting.Remove(this.usersWaiting.ElementAt(0));
                this.usersWaiting.Remove(this.usersWaiting.ElementAt(1));
                Console.WriteLine($"Comenzará una nueva partida de {this.Name} con los jugadores {this.usersWaiting.ElementAt(0)} , {this.usersWaiting.ElementAt(1)}.");
            }
        }
    }
}