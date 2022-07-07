using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
namespace Library
{
    /// <summary>
    /// Clase telegramBot donde se encuentra la cadena de handlers que recorre al momento de encontrar una palabra clave.
    /// </summary>
    public abstract class TelegramBot
    {
        public static TelegramBotClient telegramClient;
        private static IHandler firstHandler;

        public static async void Start()
        {
            telegramClient = new TelegramBotClient(Bot.token);

            firstHandler =
                new HelloHandler(
                new GoodByeHandler(
                new MenuHandler(
                new RegisterHandler(
                new SelectModeHandler(
                new ClassicModeHandler(
               new TimeTrialModeHandler(
                new ChallengeModeHandler(
                new BombModeHandler(
                new CounterShotsHandler(
                new AttackHandler(
                new StaticsHandler(
                new CommandsHandler(
                new QuickChatHandler(
                new PositionShipHandler(
                new PrintBoardHandler(

                new ExitHandler(null)
            ))))))))))))))));

            var cts = new CancellationTokenSource();

            // Comenzamos a escuchar mensajes. Esto se hace en otro hilo (en background). El primer método
            // HandleUpdateAsync es invocado por el bot cuando se recibe un mensaje. El segundo método HandleErrorAsync
            // es invocado cuando ocurre un error.
            telegramClient.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                new ReceiverOptions()
                {
                    AllowedUpdates = Array.Empty<UpdateType>()
                },
                cts.Token
            );
            Console.WriteLine($"Bot is up!");

            Console.ReadLine();

            // Terminamos el bot.
            cts.Cancel();
        }


        /// <summary>
        /// Maneja las actualizaciones del bot (todo lo que llega), incluyendo mensajes, ediciones de mensajes,
        /// respuestas a botones, etc. En este ejemplo sólo manejamos mensajes de texto.
        /// </summary>
        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            try
            {
                // Sólo respondemos a mensajes de texto
                if (update.Type == UpdateType.Message)
                {
                    await HandleMessageReceived(botClient, update.Message);
                }
            }
            catch (Exception e)
            {
                await HandleErrorAsync(botClient, e, cancellationToken);
            }
        }

        /// <summary>
        /// Maneja los mensajes que se envían al bot a través de handlers de una chain of responsibility.
        /// </summary>
        /// <param name="message">El mensaje recibido</param>
        /// <returns></returns>
        private static async Task HandleMessageReceived(ITelegramBotClient botClient, Message message)
        {
            Console.WriteLine($"Received a message from {message.From.FirstName} saying: {message.Text}");

            string response = string.Empty;

            firstHandler.Handle(message, out response);

            if (!string.IsNullOrEmpty(response))
            {
                await telegramClient.SendTextMessageAsync(message.Chat.Id, response);
            }
        }

        /// <summary>
        /// Manejo de excepciones. Por ahora simplemente la imprimimos en la consola.
        /// </summary>
        public static Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(exception.Message);
            return Task.CompletedTask;
        }
    }
}