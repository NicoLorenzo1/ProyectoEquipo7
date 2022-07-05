using NUnit.Framework;
using Library;
using System;
using System.Collections.Generic;
using System.Collections;
using Message = Telegram.Bot.Types.Message;

namespace Test.Library
{
    public class HandlerRegisterTest
    {
        /// <summary>
        /// Test que se encarga de verificar si se crea una instancia de juego correctamente y se añade a currentGame
        /// </summary>
        [Test]
        public void HandlerRegister()
        {

            User player1 = new User("nico");
            player1.Id = 1;
            Administrator.Instance.usersRegisteredWithState.Add(player1, RegisterState.Start);
            RegisterHandler registerHandler = new RegisterHandler(null);
            string response;
            Message message = new Message();
            message.From.Id = 2;
            message.Text = "/registrarse";
            registerHandler.Handle(message, out response);
            Assert.AreEqual(response, "Ingresa un nombre de usuario para registrarte."
            );

        }
    }
}