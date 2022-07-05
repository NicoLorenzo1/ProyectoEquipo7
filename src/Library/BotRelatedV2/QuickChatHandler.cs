using Telegram.Bot.Types;
using Telegram.Bot;


namespace Library
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando Mensajes para enviar mensajes predefinidos a los demas usuarios.
    /// </summary>
    public class QuickChatHandler : BaseHandler
    {
        public QuickChatState State { get; set; }

        public QuickChatHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "QuickChat", "Mensajes" };
            State = QuickChatState.Start;
        }

        protected override bool CanHandle(Message message)
        {
            if (State == QuickChatState.Start)
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
            /*
            response = "No tenemos ese mensaje disponible.";
            if (QuickChatState.Start == State)
            {
                response = "Elige el numero del mensaje que quieres enviar \n 1- Horrible! \n 2- Buen disparo! \n 3- Muy cerca!";
                State = QuickChatState.SendMessage;
            }
            else if (QuickChatState.SendMessage == State)
            {
                SendMessage(message);
            }
            */
            

        }

        private Message isValidQuickChat(Message message)
        {
            
        }

        /// <summary>
        /// Metodo para seleccionar a que jugador enviar el mensaje predefinido.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private static async void SendMessage(Message message)
        {
            foreach (var game in Administrator.Instance.currentGame)
            {
                if (game.player2.IdChat == message.Chat.Id)
                {
                    if (message.Text == "1")
                    {
                        await TelegramBot.telegramClient.SendTextMessageAsync(game.player1.IdChat, $"El jugador {game.player2.Name} dijo: Horrible!");
                    }
                    if (message.Text == "2")
                    {
                        await TelegramBot.telegramClient.SendTextMessageAsync(game.player1.IdChat, $"El jugador {game.player2.Name} dijo: Buen disparo!");

                    }
                    if (message.Text == "3")
                    {
                        await TelegramBot.telegramClient.SendTextMessageAsync(game.player1.IdChat, $"El jugador {game.player2.Name} dijo: Muy cerca!");
                    }
                }
                else if (game.player1.IdChat == message.Chat.Id)
                {
                    if (message.Text == "1")
                    {
                        await TelegramBot.telegramClient.SendTextMessageAsync(game.player2.IdChat, $"El jugador {game.player1.Name} dijo: Horrible!");
                    }
                    if (message.Text == "2")
                    {
                        await TelegramBot.telegramClient.SendTextMessageAsync(game.player2.IdChat, $"El jugador {game.player1.Name} dijo: Buen disparo!");
                    }
                    if (message.Text == "3")
                    {
                        await TelegramBot.telegramClient.SendTextMessageAsync(game.player2.IdChat, $"El jugador {game.player1.Name} dijo: Muy cerca!");
                    }
                }
            }

        }

        public enum QuickChatState
        {
            Start,
            SendMessage,
        }
    }
}