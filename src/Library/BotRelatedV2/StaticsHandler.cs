using Telegram.Bot.Types;

namespace Library
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "estadisticas". En caso que el usuario no se haya registrado 
    /// no le mostrara las estadisticas.
    /// </summary>
    public class StaticsHandler : BaseHandler
    {
        public StaticsHandlerState State { get; set; }

        public StaticsHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "estadisticas", "/Estadisticas", "Estadisticas" };
            State = StaticsHandlerState.Start;
        }

        protected override bool CanHandle(Message message)
        {
            if (State == StaticsHandlerState.Start)
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
            response = "No hay estadisticas disponibles para mostrar.";

            if (Administrator.Instance.usersRegisteredWithState.Count > 0)
            {
                foreach (var user in Administrator.Instance.usersRegisteredWithState)
                {
                    if (user.Key.Id == message.From.Id)
                    {
                        response = $"Las estadisticas del usuario: {user.Key.Name} son {Statistics.ShowStats(user.Key)}";
                    }
                }
            }
        }

        public enum StaticsHandlerState
        {
            Start,
        }
    }
}