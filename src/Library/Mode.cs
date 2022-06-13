namespace Library
{
    public class Mode : Game
    {
        private string name;
        public List<User> usersWaiting = new List<User>();

        private User player1;
        private User player2;
        private Board board1 = new Board();
        private Board board2 = new Board();
        public Mode(string name)
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
    }
}
