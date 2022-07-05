using Telegram.Bot.Types;

namespace Library
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "Iniciar".
    /// </summary>
    public class MenuHandler : BaseHandler
    {
        public MenuState State { get; set; }
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="HelloHandler"/>. Esta clase procesa el mensaje "Iniciar".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public MenuHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "Iniciar", "iniciar" };
            this.State = MenuState.Start;
        }


        protected override bool CanHandle(Message message)
        {
            if (this.State == MenuState.Start)
            {
                return base.CanHandle(message);
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Procesa el mensaje "Iniciar" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override void InternalHandle(Message message, out string response)
        {
            response = "Elige una opción \n 1- /Registrarse \n 2- /Salir";

        }


        public enum MenuState
        {
            Start,
        }

    }
}