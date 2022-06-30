using Telegram.Bot.Types;

namespace Library
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "estadisticas".
    /// </summary>
    public class StaticsHandler : BaseHandler
    {
        public StaticsHandlerState State { get; set; }

        public StaticsHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "estadisticas" };
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

            if (User.users.Count > 0)
            {
                foreach (var user in User.users)
                {
                    if (user.Id == message.From.Id)
                    {
                        response = $"Las estadisticas del usuario: {user.Name} son {Statistics.ShowStats(user)}";
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