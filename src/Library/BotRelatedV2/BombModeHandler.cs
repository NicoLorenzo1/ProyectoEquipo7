using Telegram.Bot.Types;

namespace Library
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando para seleccionar modo de juego.
    /// </summary>
    public class BombModeHandler : BaseHandler
    {
        public BombModeState State { get; set; }

        public BombModeHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/Bomb", "bomb", "Bomb" };
            State = BombModeState.Start;
        }

        protected override bool CanHandle(Message message)
        {
            if (State == BombModeState.Start)
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
            response = string.Empty;

            //Agrego a la lista de usuarios esperando para jugar el user con la misma id de telegram
            foreach (var user in User.users)
            {
                if (user.Id == message.From.Id)
                {
                    response = "Estas en la lista de espera para jugar al modo Bomb.";
                    Administrator.Instance.UsersToPlay.Add(user, "bomb");
                    Administrator.Instance.MatchPlayers();
                }
            }
        }

        public enum BombModeState
        {
            Start,
        }
    }
}