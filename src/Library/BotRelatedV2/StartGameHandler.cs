using Telegram.Bot.Types;

namespace Library
{
    public class StartGameHandler : BaseHandler
    {
        public StartGameState State { get; set; }

        public StartGameHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {""};
            State = StartGameState.Start;
        }

        protected override bool CanHandle(Message message)
        {
            if (State == StartGameState.Start)
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
            response = "";
        }

        public enum StartGameState
        {
            Start,
        }
    }
}