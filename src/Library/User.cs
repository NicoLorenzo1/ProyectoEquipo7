using System;

namespace Library
{
    /// <summary>
    /// Almacena información del jugador.
    /// </summary>
    public class User
    {
        // public static List<User> users = new List<User>();

        private static int count = 0;
        private string name;
        private long id;
        private long idChat;

        public Statistics statistics;

        /// <summary>
        /// Constructor de User.
        /// </summary>
        /// <param name="name">String que va a ser el nombre del usuario.</param>
        public User(string name)
        {
            this.name = name;
            //this.id = count += 1;
            this.statistics = new Statistics(this);
        }

        /// <summary>
        /// Get del nombre del usuario.
        /// </summary>
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
        /// Get del nombre del usuario.
        /// </summary>
        public long Id
        {
            get
            {
                return this.id;
            }
            set
            {
                id = value;
            }
        }

        public long IdChat
        {
            get
            {
                return this.idChat;
            }
            set
            {
                idChat = value;
            }
        }

    }


}