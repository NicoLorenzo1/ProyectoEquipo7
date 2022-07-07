using Telegram.Bot.Types;
using Telegram.Bot;

namespace Library
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "Classic" para seleccionar modo de juego.
    /// </summary>
    public class ClassicModeHandler : BaseHandler
    {

        public ClassicModeHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "Modo Classic", "classic", "/classic", "/Classic" };
        }

        protected override bool CanHandle(Message message)
        {
            Enum state = Administrator.Instance.GetUserState(message.From.Id);

            if (state.Equals(SelectModeState.ModeSelected))
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
            response = "ClassicModeHandler";
            //Agrego a la lista de usuarios esperando para jugar el user con la misma id de telegram
            User user = Administrator.Instance.isUserRegistered(message.From.Id);

            if (user != null)
            {
                response = "Estas en la lista de espera para jugar al modo Classic.";
                Administrator.Instance.AddUserToPlayPool(user, "classic");
                Administrator.Instance.SetUserState(message.From.Id, SelectModeState.ReadyToPlay);
                Administrator.Instance.MatchPlayers();
            }
            else
            {
                response = "El usuario aun no esta registrado. Para registrarse responda /registrar";
            }
        }
    }
}
