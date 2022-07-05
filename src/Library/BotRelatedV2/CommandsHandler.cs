using Telegram.Bot.Types;

namespace Library
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "estadisticas".
    /// </summary>
    public class CommandsHandler : BaseHandler
    {
        public CommandsHandlerState State { get; set; }

        public CommandsHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "Comandos" };
            State = CommandsHandlerState.Start;
        }

        protected override bool CanHandle(Message message)
        {
            if (State == CommandsHandlerState.Start)
            {
                return base.CanHandle(message);
            }
            else
            {
                return true;
            }
        }

        protected override void InternalHandle(Message message, out string response)
        {
            response = "Los comandos disponibles son; \n-/Tablero \n-/Estadisticas";
        }

        public enum CommandsHandlerState
        {
            Start,
        }
    }
}