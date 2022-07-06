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
    public class HandlerRegisterTest
    {
        Message message;
        TelegramUser tgUser;
        User user;
        RegisterHandler registerHandler = new RegisterHandler(null);
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
        /// Test que se encarga de verificar si se crea un usuario y cambia su estado del inicial (Start) a en proceso de registro (Register)
        /// </summary>
        [Test]
        public void RegisterHandlerStartTest()
        {
            Administrator admin = Administrator.Instance;
            message.Text = "/registrarse";
            tgUser.Id = 1234;
            message.From = tgUser;
            registerHandler.Handle(message, out response);
            Assert.AreEqual("Ingresa un nombre de usuario para registrarte.", response);
            Assert.AreEqual(1, admin.usersRegisteredWithState.Count);
            Assert.AreEqual(RegisterState.Register, admin.usersRegisteredWithState.First().Value);
        }
        /// <summary>
        /// Verifica que el usuario es agregado a la lista de usuarios y actualiza su estado a completado (Completed)
        /// </summary>
        [Test]
        public void RegisterHandlerRegisterTest()
        {
            Administrator admin = Administrator.Instance;
            user.Id = 1234;
            user.IdChat = 1234;
            admin.usersRegisteredWithState.Add(user, RegisterState.Register);
            message.Text = "UserName";
            tgUser.Id = 1234;
            message.From = tgUser;
            registerHandler.Handle(message, out response);

            Assert.AreEqual("Usuario registrado\n Elige una opción \n 1- /Jugar \n 2- /Salir", response);
            Assert.AreEqual(1, admin.usersRegisteredWithState.Count);
            Assert.AreEqual(RegisterState.Completed, admin.usersRegisteredWithState.First().Value);
            Assert.AreEqual("UserName", admin.usersRegisteredWithState.First().Key.Name);
        }
    }
}
