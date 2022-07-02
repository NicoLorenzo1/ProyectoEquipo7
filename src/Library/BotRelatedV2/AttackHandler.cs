using Telegram.Bot.Types;

namespace Library
{
    public class AttackHandler : BaseHandler
    {
        bool OnGoing;

        public AttackState State { get; set; }

        public AttackHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/Atacar" };
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

            Game game = Administrator.Instance.GetPlayerGame(message.Chat.Id);
            User player1 = game.player1;
            User player2 = game.player2;

            User recentAttacker = player2;

            OnGoing = true;

            while (OnGoing)
            {
                if (recentAttacker == player1)
                {
                    //Ataca player 2 y recibe el ataque el jugador 1

                    //Aca va la logica para pedir por telegram las coor donde va a atacar el player2 

                    //game.Attack(this.Player2, this.BoardPlayer2, this.Player1, this.BoardPlayer1);
                    //Muestro tablero que ataque 
                    string showBoard = game.boardPlayer2.PrintBoard(game.boardPlayer1.shipPos, game.boardPlayer2.shots, "EnemyBoard");
                    Bot.sendTelegramMessage(player2, showBoard);
                    recentAttacker = player2;
                }
                else
                {

                    //Aca va la logica para pedir por telegram las coor donde va a atacar el player1

                    //this.Attack(this.Player1, this.BoardPlayer1, this.Player2, this.BoardPlayer2);
                    string showBoard = game.boardPlayer1.PrintBoard(game.boardPlayer2.shipPos, game.boardPlayer1.shots, "EnemyBoard");
                    Bot.sendTelegramMessage(player1, showBoard);
                    recentAttacker = player1;
                }
                if (game.hitsPlayer1 == 15 || game.hitsPlayer2 == 15)
                {
                    game.EndGame();
                    if (game.hitsPlayer2 == 15)
                    {
                        player1.statistics.ModifyStatics(player1, false);
                        player2.statistics.ModifyStatics(player2, true);
                        System.Console.WriteLine();
                        Console.WriteLine($"Ha ganado {player2.Name}!!");
                    }
                    if (game.hitsPlayer1 == 15)
                    {
                        player1.statistics.ModifyStatics(player1, true);
                        player2.statistics.ModifyStatics(player2, false);
                        System.Console.WriteLine();
                        Console.WriteLine($"Ha ganado {player1.Name}!!");
                    }
                }
            }
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
