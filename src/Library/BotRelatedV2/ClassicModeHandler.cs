using Telegram.Bot.Types;

namespace Library
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando para seleccionar modo de juego.
    /// </summary>
    public class ClassicModeHandler : BaseHandler
    {
        public ClassicModeState State { get; set; }

        public ClassicModeHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "Modo Classic", "classic" };
            State = ClassicModeState.Start;
        }

        protected override bool CanHandle(Message message)
        {
            if (State == ClassicModeState.Start)
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
            response = "Estas en la lista de espera para jugar al modo Classic.";

            //Agrego a la lista de usuarios esperando para jugar el user con la misma id de telegram
            foreach (var user in User.users)
            {
                if (user.Id == message.From.Id)
                {
                    Administrator.Instance.UsersToPlay.Add(user, "classic");
                }
            }
        }

        public enum ClassicModeState
        {
            Start,
        }
    }
}