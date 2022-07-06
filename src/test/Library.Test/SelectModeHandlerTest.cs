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
    public class SelectModeHandlerTest
    {
      Message message;
      TelegramUser tgUser;
      User user;
      SelectModeHandler selectModeHandler = new SelectModeHandler(null);
      string response;

        [SetUp]
        public void setup()
        {
            Administrator admin = Administrator.Instance;
            admin.usersRegisteredWithState.Clear();
            message = new Message();
            tgUser = new TelegramUser();
            user = new User("UserName");
            user.Id = 1234;
            user.IdChat = 1234;
            response = string.Empty;
        }

        /// <summary>
        /// Test que se encarga de verificar si se crea un usuario y cambia su estado del inicial (Start) a en proceso de registro (Register)
        /// </summary>
        [Test]
        public void SelectModeHandlerStartTest()
        {
            Administrator admin = Administrator.Instance;
            admin.usersRegisteredWithState.Add(user, RegisterState.Completed);
            message.Text = "/Jugar";
            tgUser.Id = 1234;
            message.From = tgUser;
            selectModeHandler.Handle(message, out response);
            Assert.AreEqual("Elige un modo de juego: \n 1- /Classic \n 2- /TimeTrial \n 3- /Challenge \n 4- /Bomb", response);
            Assert.AreEqual(1, admin.usersRegisteredWithState.Count);
            Assert.AreEqual(SelectModeState.ModeSelected, admin.usersRegisteredWithState.First().Value);
        }
        /// <summary>
        /// Verifica que el usuario estado del usuario no cambia si la keyword enviada al handler no es correcta
        /// y que no se devuelve ninguna respuesta
        /// </summary>
        [Test]
        public void SelectModeHandlerWrongKeywordTest()
        {
            Administrator admin = Administrator.Instance;
            admin.usersRegisteredWithState.Add(user, RegisterState.Completed);
            message.Text = "/WrongKeyword";
            tgUser.Id = 1234;
            message.From = tgUser;
            selectModeHandler.Handle(message, out response);
            Assert.AreEqual("", response);
            Assert.AreEqual(1, admin.usersRegisteredWithState.Count);
            Assert.AreEqual(RegisterState.Completed, admin.usersRegisteredWithState.First().Value);
        }

        /// <summary>
        /// Verifica que el usuario estado del usuario no cambia si el estado del usuario no es el correcto
        /// y que no se devuelve ninguna respuesta
        /// </summary>
        [Test]
        public void SelectModeHandlerWrongStateTest()
        {
            Administrator admin = Administrator.Instance;
            admin.usersRegisteredWithState.Add(user, RegisterState.Start);
            message.Text = "/Jugar";
            tgUser.Id = 1234;
            message.From = tgUser;
            selectModeHandler.Handle(message, out response);
            Assert.AreEqual("", response);
            Assert.AreEqual(1, admin.usersRegisteredWithState.Count);
            Assert.AreEqual(RegisterState.Start, admin.usersRegisteredWithState.First().Value);
        }
    }
}
