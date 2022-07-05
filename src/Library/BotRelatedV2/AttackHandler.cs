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

        public AttackHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "Atacar", "/Atacar", "/ReintentarAtaque" };
        }

        protected override bool CanHandle(Message message)
        {
            Enum state = Administrator.Instance.GetUserState(message.From.Id);

            if (state.Equals(AttackState.StartAttackPlayer1)
            || (state.Equals(AttackState.StartAttackPlayer2))
            || (state.Equals(AttackState.AttackPositionCheck1))
            || (state.Equals(AttackState.AttackPositionCheck2))
            || (state.Equals(AttackState.AttackPositionCheck1Player2))
            || (state.Equals(AttackState.AttackPositionCheck2Player2))
            || (state.Equals(AttackState.Wait))
            && (!message.Text.ToLower().Equals("tablero")
            && (!message.Text.ToLower().Equals("mensajes"))))

            {

                return true;
            }
            else
            {
                return false;
            }
        }

        protected override void InternalHandle(Message message, out string response)
        {
            game = Administrator.Instance.GetPlayerGame(message.Chat.Id);
            response = game.onGoing ? "No puedes atacar, espera a que sea tu turno." : string.Empty;
            player1 = game.player1;
            player2 = game.player2;
            Enum state;

            if (message.From.Id == player1.Id)
            {
                state = Administrator.Instance.GetUserState(player1.Id);
                switch (state)
                {
                    //Comienza el ataque del player 1
                    case AttackState.StartAttackPlayer1:
                        response = "Escriba la primer coordenada para atacar(A - J)";
                        Administrator.Instance.SetUserState(player1.Id, AttackState.AttackPositionCheck1);

                        break;

                    case AttackState.AttackPositionCheck1:
                        if (Board.abc.Contains(message.Text.ToUpper()))
                        {
                            check1 = message.Text;
                            response = "Escriba la segunda coordenada para atacar(1 - 10)";
                            Administrator.Instance.SetUserState(player1.Id, AttackState.AttackPositionCheck2);
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
                            string result = Attack(player1);
                            if (result.Equals("reintentar"))
                            {
                                response = "Ya disparaste en esa posición. /ReintentarAtaque";
                            }
                            else
                            {
                                Administrator.Instance.SetUserState(player1.Id, AttackState.Wait);
                                Administrator.Instance.SetUserState(player2.Id, AttackState.StartAttackPlayer2);
                                CheckGame();
                            }
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
                state = Administrator.Instance.GetUserState(player2.Id);

                switch (state)
                {
                    //Comienza el ataque del player 2
                    case AttackState.StartAttackPlayer2:
                        response = "Escriba la primer coordenada para atacar (A - J)";
                        Administrator.Instance.SetUserState(player2.Id, AttackState.AttackPositionCheck1Player2);
                        break;

                    case AttackState.AttackPositionCheck1Player2:
                        if (Board.abc.Contains(message.Text.ToUpper()))
                        {
                            check1 = message.Text;
                            response = "Escriba la segunda coordenada para atacar (1 - 10)";
                            Administrator.Instance.SetUserState(player2.Id, AttackState.AttackPositionCheck2Player2);
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
                            string result = Attack(player2);
                            if (result.Equals("reintentar"))
                            {
                                response = "Ya disparaste en esa posición. /ReintentarAtaque";
                            }
                            else
                            {
                                Administrator.Instance.SetUserState(player2.Id, AttackState.Wait);
                                Administrator.Instance.SetUserState(player1.Id, AttackState.StartAttackPlayer1);
                                CheckGame();
                            }

                        }
                        else
                        {
                            response = "Debes ingresar un número valido";
                        }
                        break;
                }
            }
        }

        protected override void InternalCancel()
        {
        }

        private string Attack(User player)
        {
            User attacker, defender;
            Board attackerBoard, defenderBoard;
            if (player == player1)
            {
                attacker = player1;
                defender = player2;
                attackerBoard = game.boardPlayer1;
                defenderBoard = game.boardPlayer2;
            }
            else
            {
                attacker = player2;
                defender = player1;
                attackerBoard = game.boardPlayer2;
                defenderBoard = game.boardPlayer1;

            }
            string result = game.Attack(check1, check2, attacker);

            if (!result.Equals("/reintentar"))
            {
                string showBoard = attackerBoard.PrintBoard(defenderBoard.shipPos, attackerBoard.shots, "EnemyBoard");
                Bot.sendTelegramMessage(defender, $"El jugador {attacker.Name} atacó.");
                Bot.sendTelegramMessage(attacker, showBoard);
                Bot.sendTelegramMessage(attacker, $"El resultado del disparo fue: {result}");
                Bot.sendTelegramMessage(defender, $"El resultado del disparo fue: {result}");
                Bot.sendTelegramMessage(defender, "Ahora es tu turno de atacar. /Atacar");
            }

            return result;
        }
        private bool CheckGame()
        {
            User winner = game.CheckMatch(); // el ganador del match
            if (winner != null)
            { // si hay un ganador es que el match termino
                User looser = winner == player1 ? player2 : player1;
                if (game.mode.Equals("challenge"))
                {

                    User challengeWinner = game.GameWinner(); //si hay un challengeWinner es que el challenge termino
                    if (challengeWinner != null)
                    { //aca es cuando termina el challenge
                        looser = challengeWinner == player1 ? player2 : player1;
                        Bot.sendTelegramMessage(player1, $"El challenge ha finalizado\n Ha ganado {challengeWinner.Name}.");
                        Bot.sendTelegramMessage(player2, $"El challenge ha finalizado\n Ha ganado {challengeWinner.Name}.");
                        Administrator.Instance.SetUserState(player1.Id, AttackState.End);
                        Administrator.Instance.SetUserState(player2.Id, AttackState.End);
                        winner.statistics.ModifyStatics(challengeWinner, true);
                        looser.statistics.ModifyStatics(looser, false);
                    }
                    else
                    {// sino el challenge sigue y solo termino una mas de los partidas
                        Bot.sendTelegramMessage(player1, $"La partida ha finalizado\n Ha ganado {winner.Name}.");
                        Bot.sendTelegramMessage(player2, $"La partida ha finalizado\n Ha ganado {winner.Name}.");
                        Administrator.Instance.SetUserState(player1.Id, SelectModeState.ChallengeState); //Con este estado vuelven a posicionar barcos para jugar otra vez
                        Administrator.Instance.SetUserState(player2.Id, SelectModeState.ChallengeState);
                        winner.statistics.ModifyStatics(winner, true);
                        looser.statistics.ModifyStatics(looser, false);
                    }
                }
                else if (game.mode.Equals("timetrial"))
                {
                    if (!game.onGoing)
                    {
                        Bot.sendTelegramMessage(player1, $"La partida ha finalizado\n Ha ganado {winner.Name}.");
                        Bot.sendTelegramMessage(player2, $"La partida ha finalizado\n Ha ganado {winner.Name}.");
                        Administrator.Instance.SetUserState(player1.Id, AttackState.End);
                        Administrator.Instance.SetUserState(player2.Id, AttackState.End);
                        winner.statistics.ModifyStatics(winner, true);
                        looser.statistics.ModifyStatics(looser, false);
                    }
                }
                else
                {
                    Bot.sendTelegramMessage(player1, $"La partida ha finalizado\n Ha ganado {winner.Name}.");
                    Bot.sendTelegramMessage(player2, $"La partida ha finalizado\n Ha ganado {winner.Name}.");
                    Administrator.Instance.SetUserState(player1.Id, AttackState.End);
                    Administrator.Instance.SetUserState(player2.Id, AttackState.End);
                    winner.statistics.ModifyStatics(winner, true);
                    looser.statistics.ModifyStatics(looser, false);
                }
                return true;
            }
            return false;
        }
    }
    public enum AttackState
    {
        StartAttackPlayer1,
        AttackPositionCheck1,
        AttackPositionCheck2,
        StartAttackPlayer2,
        AttackPositionCheck1Player2,
        AttackPositionCheck2Player2,
        Wait,
        End
    }
}

