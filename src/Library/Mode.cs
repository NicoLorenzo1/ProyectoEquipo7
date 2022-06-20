namespace Library
{
    public class Mode : Game 
    {
        public string name;
        public List<User> usersWaiting = new List<User>();

        private User player1;
        private User player2;
        private Board board1 = new Board();
        private Board board2 = new Board();
        public Mode(string name)
        {
        }

        public Mode()
        {
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
        public User Player1
        {
            get
            {
                return this.player1;
            }
            set
            {
                this.player1 = value;
            }
        }
        public User Player2
        {
            get
            {
                return this.player2;
            }
            set
            {
                this.player2 = value;
            }
        }
        public Board Board1
        {
            get
            {
                return this.board1;
            }
            set
            {
                this.board1 = value;
            }
        }
        public Board Board2
        {
            get
            {
                return this.board2;
            }
            set
            {
                this.board2 = value;
            }
        }

        //Todos los modos tienen su lista de espera
        public void AddUserToWaitList(User user)
        {
            usersWaiting.Add(user);
        }

        //ver donde se va a llamar este metodo (se debe actualizar a cada rato pq solo agarra los dos primeros lugares)
        public void MatchPlayers(Mode m)
        {
            if (usersWaiting.Count >= 2)
            {
                m.StartGame(this.usersWaiting.ElementAt(0), this.usersWaiting.ElementAt(1));
                //Remuevo los usuarios de la lista de espera de ese modo.
                this.usersWaiting.Remove(this.usersWaiting.ElementAt(0));
                this.usersWaiting.Remove(this.usersWaiting.ElementAt(1));
                Console.WriteLine($"Comenzará una nueva partida de {this.Name} con los jugadores {this.usersWaiting.ElementAt(0)} , {this.usersWaiting.ElementAt(1)}.");
            }
        }
    }
}
