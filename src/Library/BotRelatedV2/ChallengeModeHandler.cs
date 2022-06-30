using Telegram.Bot.Types;

namespace Library
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando para seleccionar modo de juego.
    /// </summary>
    public class ChallengeModeHandler : BaseHandler
    {
        public ChallengeModeState State { get; set; }

        public ChallengeModeHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "Modo Challenge", "challenge" };
            State = ChallengeModeState.Start;
        }

        protected override bool CanHandle(Message message)
        {
            if (State == ChallengeModeState.Start)
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
            response = "Estas en la lista de espera para jugar al modo Challenge.";

            //Agrego a la lista de usuarios esperando para jugar el user con la misma id de telegram
            foreach (var user in User.users)
            {
                if (user.Id == message.From.Id)
                {
                    Administrator.Instance.UsersToPlay.Add(user, "Challenge");
                }
            }
        }

        public enum ChallengeModeState
        {
            Start,
        }
    }
}