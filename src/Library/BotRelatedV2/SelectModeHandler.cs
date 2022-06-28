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
            this.Keywords = new string[] { "jugar" };
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
            response = "Elige una opción \n 1- Modo Classic \n 2- Modo TimeTrial \n 3- Modo Challenge \n 4- Modo Bomb";
        }


        public enum SelectModeState
        {
            Start,
        }

    }
}