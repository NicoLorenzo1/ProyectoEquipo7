using Telegram.Bot.Types;

namespace Library
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando para seleccionar modo de juego cuando se le envía la palabra clave (jugar)
    /// </summary>
    public class SelectModeHandler : BaseHandler
    {
        // public SelectModeState State { get; set; }

        public SelectModeHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/jugar", "/Jugar" };
        }

        protected override bool CanHandle(Message message)
        {
            Enum state = Administrator.Instance.GetUserState(message.From.Id);

            if (state.Equals(RegisterState.Completed))
            {
                return base.CanHandle(message);
            }
            else
            {
                return false;
            }
        }

        protected override void InternalHandle(Message message, out string response)
        {
            response = "Elige un modo de juego: \n 1- /Classic \n 2- /TimeTrial \n 3- /Challenge \n 4- /Bomb";
            Administrator.Instance.SetUserState(message.From.Id, SelectModeState.ModeSelected);
        }
    }
    public enum SelectModeState
    {
        Start,
        ModeSelected,
        ReadyToPlay,
        ChallengeState,
        TimeTrialState
    }
}