using Telegram.Bot.Types;
using Telegram.Bot;

namespace Library
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "Classic" para seleccionar modo de juego.
    /// </summary>
    public class ClassicModeHandler : BaseHandler
    {
        public ClassicModeState State { get; set; }

        public ClassicModeHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/Classic", "classic", "Classic" };
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
            response = string.Empty;

            //Agrego a la lista de usuarios esperando para jugar el user con la misma id de telegram
            foreach (var user in User.users)
            {
                if (user.Id == message.From.Id)
                {
                    sendTelegramMessage(user);
                    //response = "Estas en la lista de espera para jugar al modo Classic.";
                    Administrator.Instance.UsersToPlay.Add(user, "classic");
                    Administrator.Instance.MatchPlayers();
                }
            }
        }

        private async void sendTelegramMessage(User user)
        {
            await TelegramBot.telegramClient.SendTextMessageAsync(user.IdChat, "Estas en la lista de espera para jugar al modo Classic.");

        }
        public enum ClassicModeState
        {
            Start,
        }
    }
}