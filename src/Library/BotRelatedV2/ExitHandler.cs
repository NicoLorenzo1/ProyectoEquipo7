using Telegram.Bot.Types;

namespace Library
{
    public class ExitHandler : BaseHandler
    {
        public ExitHandlerState State { get; set; }
        public ExitHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/Salir", "salir", "Salir" };
            this.State = ExitHandlerState.Start;
        }
        protected override bool CanHandle(Message message)
        {
            if (this.State == ExitHandlerState.Start)
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
            response = "Nos vemos la próxima!";
            Administrator.Instance.SetUserState(message.From.Id, RegisterState.Start);
        }

        public enum ExitHandlerState
        {
            Start,
        }

    }
}
