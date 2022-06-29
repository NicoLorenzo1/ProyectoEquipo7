using Telegram.Bot.Types;

namespace Library
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando para seleccionar modo de juego.
    /// </summary>
    public class QuickChatHandler : BaseHandler
    {
        public QuickChatState State { get; set; }

        public QuickChatHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "QuickChat", "Mensajes" };
            State = QuickChatState.Start;
        }

        protected override bool CanHandle(Message message)
        {
            if (State == QuickChatState.Start)
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
            response = "No tenemos ese mensaje disponible.";
            if (QuickChatState.Start == State)
            {
                response = "Elige el numero del mensaje que quieres enviar \n 1- Horrible! \n 2- Buen disparo! \n 3- Muy cerca!";
                State = QuickChatState.SendMessage;
            }
            else if (QuickChatState.SendMessage == State)
            {
                if (message.Text == "1")
                {
                    response = "Horrible!";
                }
                if (message.Text == "2")
                {
                    response = "Buen disparo!";
                }
                if (message.Text == "3")
                {
                    response = "Muy cerca!";
                }
            }

        }

        public enum QuickChatState
        {
            Start,
            SendMessage,
        }
    }
}