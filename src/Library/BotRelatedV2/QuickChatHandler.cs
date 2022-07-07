using Telegram.Bot.Types;
using Telegram.Bot;


namespace Library
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando Mensajes para enviar mensajes predefinidos a los demas usuarios.
    /// </summary>
    public class QuickChatHandler : BaseHandler
    {
        public static List<string> messages = new List<string>{"/Horrible", "/Buen_disparo", "/Muy_cerca"};
        public QuickChatState State { get; set; }

        public QuickChatHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "QuickChat", "Mensajes", "/Horrible", "/Buen_disparo", "/Muy_cerca" };
        }

        protected override bool CanHandle(Message message)
        {
            return base.CanHandle(message);
        }

        protected override void InternalHandle(Message message, out string response)
        {
            response = string.Empty;
            User from, to;
            Game game = Administrator.Instance.GetPlayerGame(message.From.Id);
            if(game != null){
                if (game.player1.Id == message.From.Id)
                {
                    from = game.player1;
                    to = game.player2;
                }else{
                    from = game.player2;
                    to = game.player1;
                }
                if(!messages.Contains(message.Text)){
                    Bot.sendTelegramMessage(from, "Elige el mensaje que quieres enviar \n /Horrible \n /Buen_disparo \n /Muy_cerca");
                }
                else{
                    SendMessage(message, from , to);
                }
            }
        }

        /// <summary>
        /// Metodo para seleccionar a que jugador enviar el mensaje predefinido.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private static async void SendMessage(Message message, User from, User to)
        {
            Bot.sendTelegramMessage(to, $"El jugador {from.Name} dijo: {message.Text}");
        }

        public enum QuickChatState
        {
            Start,
            SendMessage,
        }
    }
}