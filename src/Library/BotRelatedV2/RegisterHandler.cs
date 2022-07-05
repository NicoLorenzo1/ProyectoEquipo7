using Telegram.Bot.Types;

namespace Library
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "registrarse".
    /// </summary>
    public class RegisterHandler : BaseHandler
    {
        // public RegisterState State { get; set; }
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="RegisterHandler"/>. Esta clase procesa el mensaje "registrarse".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public RegisterHandler(BaseHandler next) : base(next)
        {
            Keywords = new string[] { "/registrarse", "/Registrarse" };
        }

        protected override bool CanHandle(Message message)
        {
            Enum state = Administrator.Instance.GetUserState(message.From.Id);

            if (state.Equals(RegisterState.Start)
            || state.Equals(RegisterState.Register))
            {
                return true;
            }
            else
            {
                return false;
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
            response = string.Empty;
            Enum state = Administrator.Instance.GetUserState(message.From.Id);
            switch (state)
            {
                case RegisterState.Start:
                    response = "Ingresa un nombre de usuario para registrarte.";
                    Administrator.Instance.SetUserState(message.From.Id, RegisterState.Register);
                    break;

                case RegisterState.Register:
                    Administrator.Instance.CheckUser(message.Text, message.From.Id);
                    response = "Usuario registrado\n Elige una opción \n 1- /Jugar \n 2- /Salir";
                    Administrator.Instance.SetUserState(message.From.Id, RegisterState.Completed);
                    break;
            }
        }

        protected override void InternalCancel()
        {
            // this.State = RegisterState.Start;

        }
    }


    public enum RegisterState
    {
        Start,
        Register,
        Completed
    }

}
