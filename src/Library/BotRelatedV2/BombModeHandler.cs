using Telegram.Bot.Types;

namespace Library
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando para seleccionar modo de juego.
    /// </summary>
    public class BombModeHandler : BaseHandler
    {
        public BombModeHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/Bomb", "bomb", "Bomb" };
        }

        protected override bool CanHandle(Message message)
        {
            Enum state = Administrator.Instance.GetUserState(message.From.Id);
            if (state.Equals(SelectModeState.ModeSelected))
            {
                // return true;
                return base.CanHandle(message);

            }
            else
            {
                return false;
            }
        }

        protected override void InternalHandle(Message message, out string response)
        {
            response = string.Empty;

                //Agrego a la lista de usuarios esperando para jugar el user con la misma id de telegram
                User user = Administrator.Instance.isUserRegistered(message.From.Id);

                if (user != null)
                {
                    response = "Estas en la lista de espera para jugar al modo Bomb.";
                    Administrator.Instance.AddUserToPlayPool(user, "bomb");
                    Administrator.Instance.SetUserState(message.From.Id, SelectModeState.ReadyToPlay);
                    Administrator.Instance.MatchPlayers();
                }
                else{
                    response = "El usuario aun no esta registrado. Para registrarse responda /registrar";
                }
            }
        

    }
}