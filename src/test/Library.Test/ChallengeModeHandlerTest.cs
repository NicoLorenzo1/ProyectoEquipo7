using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Library;
using NUnit.Framework;

using Message = Telegram.Bot.Types.Message;
using TelegramUser = Telegram.Bot.Types.User;

namespace Test.Library
{
    public class ChallengeModeHandlerTest
    {
      Message message;
      TelegramUser tgUser;
      User user;
      ChallengeModeHandler challengeModeHandler = new ChallengeModeHandler(null);
      string response;

        [SetUp]
        public void setup()
        {
            Administrator admin = Administrator.Instance;
            admin.usersRegisteredWithState.Clear();
            message = new Message();
            tgUser = new TelegramUser();
            user = new User("");
            response = string.Empty;
        }

        /// <summary>
        /// Test que se encarga de verificar si al seleccionar un modo de juego Challenge se actualiza el estado del usuario
        /// y se envia una respuesta notificando al jugador
        /// </summary>
        [Test]
        public void ChallengeModeHandlerStartTest()
        {
            Administrator admin = Administrator.Instance;
            user.Id = 1234;
            user.IdChat = 1234;
            admin.usersRegisteredWithState.Add(user, SelectModeState.ModeSelected);
            message.Text = "/challenge";
            tgUser.Id = 1234;
            message.From = tgUser;
            challengeModeHandler.Handle(message, out response);
            Assert.AreEqual("Estas en la lista de espera para jugar al modo Challenge.", response);
            Assert.AreEqual(SelectModeState.ReadyToPlay, admin.usersRegisteredWithState.First().Value);
        }

        /// <summary>
        /// Verifica que el si el usuario usa el keyword incorrecto no se modifica su estado (ModeSelected)
        /// y la respuesta es vacia
        /// </summary>
        [Test]
        public void ChallengeModeHandlerWrongKeywordTest()
        {
            Administrator admin = Administrator.Instance;
            user.Id = 1234;
            user.IdChat = 1234;
            admin.usersRegisteredWithState.Add(user, SelectModeState.ModeSelected);
            message.Text = "wrongKeyword";
            tgUser.Id = 1234;
            message.From = tgUser;
            challengeModeHandler.Handle(message, out response);

            Assert.AreEqual("", response);
            Assert.AreEqual(SelectModeState.ModeSelected, admin.usersRegisteredWithState.First().Value);
        }

        /// <summary>
        /// Verifica que el si el usuario usa el keyword incorrecto no se modifica su estado (ModeSelected)
        /// y la respuesta es vacia
        /// </summary>
        [Test]
        public void ChallengeModeHandlerWrongStateTest()
        {
            Administrator admin = Administrator.Instance;
            user.Id = 1234;
            user.IdChat = 1234;
            admin.usersRegisteredWithState.Add(user, SelectModeState.ReadyToPlay);
            message.Text = "/challenge";
            tgUser.Id = 1234;
            message.From = tgUser;
            challengeModeHandler.Handle(message, out response);

            Assert.AreEqual("", response);
            Assert.AreEqual(SelectModeState.ReadyToPlay, admin.usersRegisteredWithState.First().Value);
        }
    }
}
