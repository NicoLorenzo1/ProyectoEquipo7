using Telegram.Bot.Types;

namespace Library
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando para seleccionar modo de juego.
    /// </summary>
    public class SelectModeHandler : BaseHandler
    {
        public SelectModeState State { get; set; }

        public SelectModeHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "Classic", "Bomb", "Challenge", "TimeTrial" };
            this.State = SelectModeState.Start;
        }


        protected override bool CanHandle(Message message)
        {
            if (this.State == SelectModeState.Start)
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
            if (message.ToString() == "Classic")
            {
                response = "Estas en la lista de espera para jugar al modo Classic";
            }
            else if (message.ToString() == "Bomb")
            {
                response = "Estas en la lista de espera para jugar al modo Bomb";
            }
            else if (message.ToString() == "Challenge")
            {
                response = "Estas en la lista de espera para jugar al modo Bomb";
            }
            else if (message.ToString() == "TimeTrial")
            {
                response = "Estas en la lista de espera para jugar al modo TimeTrial";
            }
            else
            {
                response = string.Empty;
            }
        }


        public enum SelectModeState
        {
            Start,
        }

    }
}