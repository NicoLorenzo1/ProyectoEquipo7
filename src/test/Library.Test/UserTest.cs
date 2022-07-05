using NUnit.Framework;
using Library;
using System;
using System.Collections.Generic;
using System.Collections;

namespace Test.Library
{
    public class UserTest
    {
        /// <summary>
        /// Test que se encarga de verificar si se crea un usuario correctamente y se asigna a la lista de usuarios registrados
        /// </summary>       
        [Test]
        public void CreateUserTest()
        {
            User player1 = new User("Jose");
            
            Assert.Contains(player1,User.users);
        }
    }
}
