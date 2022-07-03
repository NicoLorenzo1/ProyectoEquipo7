using Telegram.Bot.Types;

namespace Library
{
    public class AttackHandler : BaseHandler
    {
        private string check1;
        private string check2;
        private Game game;
        private User player1;
        private User player2;

        public AttackState State { get; set; }

        public AttackHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "Atacar" };
            State = AttackState.StartAttackPlayer1;
        }

        protected override bool CanHandle(Message message)
        {
            if (State == AttackState.StartAttackPlayer1)
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
            response = "No puedes atacar, espera a que sea tu turno.";

            game = Administrator.Instance.GetPlayerGame(message.Chat.Id);
            player1 = game.player1;
            player2 = game.player2;

            if (message.From.Id == player1.Id)
            {
                switch (State)
                {
                    //Comienza el ataque del player 1
                    case AttackState.StartAttackPlayer1:
                        response = "Escriba la primer coordenada para atacar(A - J)";
                        State = AttackState.AttackPositionCheck1;
                        break;

                    case AttackState.AttackPositionCheck1:
                        if (Board.abc.Contains(message.Text.ToUpper()))
                        {
                            check1 = message.Text;
                            response = "Escriba la segunda coordenada para atacar(1 - 10)";
                            State = AttackState.AttackPositionCheck2;
                        }
                        else
                        {
                            response = "Debes ingresar una letra valida";
                        }
                        break;

                    case AttackState.AttackPositionCheck2:
                        if (Board.num.Contains(message.Text))
                        {
                            check2 = message.Text;
                            Attack(player1);
                            State = AttackState.StartAttackPlayer2;
                            CheckGame();
                        }
                        else
                        {
                            response = "Debes ingresar un número valido";
                        }
                        break;
                }
                //=================================================================================================================
            }
            else
            {
                switch (State)
                {
                    //Comienza el ataque del player 2
                    case AttackState.StartAttackPlayer2:
                        response = "Escriba la primer coordenada para atacar (A - J)";
                        State = AttackState.AttackPositionCheck1Player2;
                        break;

                    case AttackState.AttackPositionCheck1Player2:
                        if (Board.abc.Contains(message.Text))
                        {
                            check1 = message.Text;
                            response = "Escriba la segunda coordenada para atacar (1 - 10)";
                            State = AttackState.AttackPositionCheck2Player2;
                        }
                        else
                        {
                            response = "Debes ingresar una letra valida";
                        }
                        break;

                    case AttackState.AttackPositionCheck2Player2:
                        if (Board.num.Contains(message.Text))
                        {
                            check2 = message.Text;
                            Attack(player2);
                            State = AttackState.StartAttackPlayer1;
                            CheckGame();
                        }
                        else
                        {
                            response = "Debes ingresar un número valido";
                        }
                        break;

                    default:
                        Console.WriteLine($"entra default {State}");
                        break;
                }
            }
        }

        protected override void InternalCancel()
        {
            this.State = AttackState.End;
        }

        private void Attack(User player)
        {
            game.Attack(check1, check2, player);
            if (player == player1)
            {
                //response = $"Atacando al jugador {player2.Name}";
                Bot.sendTelegramMessage(player2, $"El jugador {player1.Name} atacó.");
                Bot.sendTelegramMessage(player2, "Ahora es tu turno de atacar. /Atacar");
                string showBoard = game.boardPlayer1.PrintBoard(game.boardPlayer2.shipPos, game.boardPlayer1.shots, "EnemyBoard");
                Bot.sendTelegramMessage(player1, showBoard);
            }
            else
            {
                //response = $"Atacando al jugador {player1.Name}";
                Bot.sendTelegramMessage(player1, $"El jugador {player2.Name} atacó.");
                Bot.sendTelegramMessage(player1, "Ahora es tu turno de atacar. /Atacar");
                string showBoard = game.boardPlayer2.PrintBoard(game.boardPlayer1.shipPos, game.boardPlayer2.shots, "EnemyBoard");
                Bot.sendTelegramMessage(player2, showBoard);
            }
        }
        private bool CheckGame()
        {
            if (game.hitsPlayer1 == 1 || game.hitsPlayer2 == 1)
            {
                game.EndGame();
                if (game.hitsPlayer2 == 1)
                {
                    Bot.sendTelegramMessage(player1, $"La partida ha finalizado\n Ha ganado {player2.Name}.");
                    Bot.sendTelegramMessage(player2, $"La partida ha finalizado\n Ha ganado {player2.Name}.");

                    player1.statistics.ModifyStatics(player1, false);
                    player2.statistics.ModifyStatics(player2, true);
                    State = AttackState.End;
                    return true;
                }
                if (game.hitsPlayer1 == 1)
                {
                    Bot.sendTelegramMessage(player1, $"La partida ha finalizado\n Ha ganado {player1.Name}.");
                    Bot.sendTelegramMessage(player2, $"La partida ha finalizado\n Ha ganado {player1.Name}.");

                    player1.statistics.ModifyStatics(player1, true);
                    player2.statistics.ModifyStatics(player2, false);
                    State = AttackState.End;
                    return true;
                }
            }
            return false;
        }


        public enum AttackState
        {
            StartAttackPlayer1,
            AttackPositionCheck1,
            AttackPositionCheck2,
            StartAttackPlayer2,
            AttackPositionCheck1Player2,
            AttackPositionCheck2Player2,
            End

        }
    }
}

