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
            this.Keywords = new string[] { "/jugar", "/Jugar" };
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
            response = "Elige un modo de juego: \n 1- /Classic \n 2- /TimeTrial \n 3- /Challenge \n 4- /Bomb";
        }

        public enum SelectModeState
        {
            Start,
        }

    }
}