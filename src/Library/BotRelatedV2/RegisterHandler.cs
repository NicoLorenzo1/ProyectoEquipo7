using Telegram.Bot.Types;

namespace Library
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "hola".
    /// </summary>
    public class RegisterHandler : BaseHandler
    {
        public RegisterState State { get; set; }
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="HelloHandler"/>. Esta clase procesa el mensaje "hola".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public RegisterHandler(BaseHandler next) : base(next)
        {
            Keywords = new string[] { "1" };
            State = RegisterState.Start;
        }


        protected override bool CanHandle(Message message)
        {

            if (this.State == RegisterState.Finish)
            {
                return base.CanHandle(message);
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Procesa el mensaje "hola" y retorna true; retorna false en caso contrario.
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
                response = "Registrando al usuario";
                this.State = RegisterState.SelectMode;
            }
            else if (State == RegisterState.SelectMode)
            {
                response = "Elige una opción \n 1- Modo Classic \n 2- Modo TimeTrial \n 3- Modo Challenge \n 4- Modo Bomb";
                State = RegisterState.Finish;

            }
            else
            {
                response = string.Empty;
            }


            /*

            if (Administrator.Instance.CheckUser(message.Text) == true)
            {
                response = "Usuario registrado exitosamente.";

            }
            else if (Administrator.Instance.CheckUser(message.Text) == false)
            {
                response = "Usuario ya registrado";

            }
            */
        }

        protected override void InternalCancel()
        {
            this.State = RegisterState.Start;
        }

    }



    public enum RegisterState
    {
        Start,
        SelectMode,
        Finish,
        Register
    }

}
