using Telegram.Bot.Types;

namespace Library
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "registrarse".
    /// </summary>
    public class RegisterHandler : BaseHandler
    {
        public RegisterState State { get; set; }
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="HelloHandler"/>. Esta clase procesa el mensaje "registrarse".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public RegisterHandler(BaseHandler next) : base(next)
        {
            Keywords = new string[] { "registrarse" };
            State = RegisterState.Start;

        }

        protected override bool CanHandle(Message message)
        {

            if (this.State == RegisterState.Start)
            {
                return base.CanHandle(message);
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Procesa el mensaje "registrarse" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override void InternalHandle(Message message, out string response)
        {
            if (State == RegisterState.Start)
            {
                response = "Ingresa un nombre de usuario para registrarte.";
                State = RegisterState.Register;
            }
            else if (State == RegisterState.Register)
            {
                Administrator.Instance.CheckUser(message.Text);

                //Le asigno al user la id de telegram
                foreach (var user in User.users)
                {
                    if (user.Name == message.Text)
                    {
                        user.Id = message.From.Id;
                        user.IdChat = message.Chat.Id;
                        Console.WriteLine(user.Id);

                    }
                }
                response = "Usuario registrado\n Elige una opción \n 1- Jugar \n 2- Salir";
                State = RegisterState.Start;

            }
            else
            {
                response = string.Empty;
            }
        }


        protected override void InternalCancel()
        {
            this.State = RegisterState.Start;
        }
    }


    public enum RegisterState
    {
        Start,
        Register,

    }

}
