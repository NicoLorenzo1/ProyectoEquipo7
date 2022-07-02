using Telegram.Bot.Types;

namespace Library
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando para seleccionar modo de juego.
    /// </summary>
    public class TimeTrialModeHandler : BaseHandler
    {
        public TimeTrialModeState State { get; set; }

        public TimeTrialModeHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "Modo TimeTrial", "timetrial" };
            State = TimeTrialModeState.Start;
        }

        protected override bool CanHandle(Message message)
        {
            if (State == TimeTrialModeState.Start)
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
                    response = "Estas en la lista de espera para jugar al modo TimeTrial.";
                    Administrator.Instance.UsersToPlay.Add(user, "TimeTrial");
                    Administrator.Instance.MatchPlayers();
                }
            }
        }

        public enum TimeTrialModeState
        {
            Start,
        }
    }
}