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
        public Lobby(string name)
        {
            this.name = name;
        }

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

        //Todos los modos tienen su lista de espera
        public void AddUserToWaitList(User user)
        {
            usersWaiting.Add(user);
        }

        public virtual void MatchPlayers()
        {
            if (usersWaiting.Count >= 2)
            {
                //Remuevo los usuarios de la lista de espera de ese modo.
                this.usersWaiting.Remove(this.usersWaiting.ElementAt(0));
                this.usersWaiting.Remove(this.usersWaiting.ElementAt(1));
                Console.WriteLine($"Comenzará una nueva partida de {this.Name} con los jugadores {this.usersWaiting.ElementAt(0)} , {this.usersWaiting.ElementAt(1)}.");
            }
        }
    }
}