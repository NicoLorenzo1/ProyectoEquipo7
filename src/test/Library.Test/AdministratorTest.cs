using NUnit.Framework;
using Library;
using System;
using System.Collections.Generic;
using System.Collections;

namespace Test.Library
{
    public class AdministratorTest
    {

        [SetUp]
        public void setup()
        {
            Administrator.Instance.usersRegisteredWithState.Clear();
            Administrator.Instance.UsersToPlay.Clear();

        }
        /// <summary>
        /// Test que se encarga de verificar si devuelve null en caso que no se encuentre el usuario registrado.
        /// </summary>
        [Test]
        public void NotRegisteredUserTest()
        {
            User player1 = new User("nico");
            player1.IdChat = 1;
            User returnUser = Administrator.Instance.isUserRegistered(player1.IdChat);
            Assert.AreEqual(null, returnUser);
        }

        /// <summary>
        /// Test que se encarga de verificar en caso de que el usuario este registrado lo retorne correctamente.
        /// </summary>
        [Test]
        public void RegisteredUserTest()
        {
            User player1 = new User("nico");
            player1.IdChat = 1;
            Administrator.Instance.usersRegisteredWithState.Add(player1, null);
            User returnUser = Administrator.Instance.isUserRegistered(player1.IdChat);
            Assert.AreEqual(player1, returnUser);
        }

        /// <summary>
        /// Test que se encarga de verificar si el metodo AddUserToPlayPool asigna correctamente el modo seleccionado
        /// </summary>
        [Test]
        public void AddUserToPlayPoolKeyTest()
        {
            User player1 = new User("nico");
            Administrator.Instance.AddUserToPlayPool(player1, "classic");
            bool contains = Administrator.Instance.UsersToPlay.ContainsKey(player1);

            Assert.AreEqual(true, contains);
        }

        /// <summary>
        /// Test que se encarga de verificar si se encuentra el modo elegido que el usuario selecciono en la lista usersToPlay
        /// </summary>
        [Test]
        public void AddUserToPlayPoolValueTest()
        {
            User player1 = new User("nico");
            Administrator.Instance.AddUserToPlayPool(player1, "classic");
            bool contains = Administrator.Instance.UsersToPlay.ContainsValue("classic");
            Assert.AreEqual(true, contains);
        }

        [Test]
        public void GetUserStateTest()
        {
            User player1 = new User("nico");
            player1.IdChat = 1;

            bool contains = Administrator.Instance.usersRegisteredWithState.ContainsKey(player1);
            Assert.AreEqual(false, contains);
        }

        /// <summary>
        /// Test que se encarga de verificar si se asigna correctamente el estado a los usuarios y se guarda en la lista.
        /// </summary>
        [Test]
        public void SetUserStateTest()
        {
            User player1 = new User("nico");
            player1.IdChat = 1;

            Administrator.Instance.SetUserState(player1.IdChat, RegisterState.Start);
            bool contains = Administrator.Instance.usersRegisteredWithState.ContainsValue(RegisterState.Start);
            bool contains1 = Administrator.Instance.usersRegisteredWithState.ContainsKey(player1);

            Assert.AreEqual(true, contains);
            Assert.AreEqual(Administrator.Instance.usersRegisteredWithState.ContainsValue(RegisterState.Start), true);
        }
    }
}