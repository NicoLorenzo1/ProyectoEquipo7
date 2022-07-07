using Telegram.Bot.Types;

namespace Library
{
    /// <summary>
    /// Clase CounterShotsHandler que se encarga de enviarle al usuario la cantidad de tiros que tocaron agua, los que tocaron barcos, y los totales.
    /// Saca la información de game que es quien conoce la cantidad de shots.
    /// </summary>
    public class CounterShotsHandler : BaseHandler
    {
        public CounterShotsState State { get; set; }
        public CounterShotsHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "Disparos", "disparos" };
            this.State = CounterShotsState.Start;
        }
        protected override bool CanHandle(Message message)
        {
            return base.CanHandle(message);

            /*
            if (this.State == .Start)
            {
                return base.CanHandle(message);
            }
            else
            {
                return true;
            }
            */
        }

        /// <summary>
        /// Procesa el mensaje "hola" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override void InternalHandle(Message message, out string response)
        {
            response = string.Empty;
            if (State == CounterShotsState.Start)
            {

                Game game = Administrator.Instance.GetPlayerGame(message.From.Id);
                int result = game.watherShots + game.shipShots;

                if (game.player1.Id == message.From.Id)
                {
                    Bot.sendTelegramMessage(game.player1, $"Los disparos que tocaron agua fueron: {game.watherShots}\n Los disparos que tocaron barco fueron: {game.shipShots} \n Los disparos totales fueron {result}");
                }
                else
                {
                    Bot.sendTelegramMessage(game.player2, $"Los disparos que tocaron agua fueron: {game.watherShots}\n Los disparos que tocaron barco fueron: {game.shipShots} \n Los disparos totales fueron {result}");
                }

                Administrator.Instance.SetUserState(message.From.Id, RegisterState.Start);
            }
        }
        public enum CounterShotsState
        {
            Start,
        }

    }
}