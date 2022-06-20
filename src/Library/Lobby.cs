namespace Library
{
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

        //ver donde se va a llamar este metodo (se debe actualizar a cada rato pq solo agarra los dos primeros lugares)
        public virtual void MatchPlayers()
        {
            if (usersWaiting.Count >= 2)
            {
                Game game = new Game(this.usersWaiting.ElementAt(0), this.usersWaiting.ElementAt(1), "Classic Mode");
                game.StartGame(/*this.usersWaiting.ElementAt(0), this.usersWaiting.ElementAt(1)*/);
                //Remuevo los usuarios de la lista de espera de ese modo.
                this.usersWaiting.Remove(this.usersWaiting.ElementAt(0));
                this.usersWaiting.Remove(this.usersWaiting.ElementAt(0));
            }
        }
    }
}
