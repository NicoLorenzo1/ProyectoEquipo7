using Telegram.Bot.Types;

namespace Library
{
    public class AttackHandler : BaseHandler
    {
        public string check1;
        public string check2;
        public string direction1;

        public AttackState State { get; set; }

        public AttackHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "posicionar", "Posicionar", "/Reintentar" };
            State = AttackState.Start;
        }

        protected override bool CanHandle(Message message)
        {
            if (State == AttackState.Start)
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
        }

        protected override void InternalCancel()
        {
            this.State = AttackState.End;
        }

       

        public enum AttackState
        {
            Start,
            PositionCheck1,
            PositionCheck2,
            Direction,
            Complete,
            End

        }
    }
}
