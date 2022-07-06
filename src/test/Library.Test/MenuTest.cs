
using NUnit.Framework;
using Library;
using System;
using System.Collections.Generic;
using System.Collections;

namespace Test.Library
{
    public class UserHistoryTest
    {

        [Test]
        public void SelectModeTest()
        {
            User player1 = new User("nico");
            Menu menu = new Menu();
            Administrator.Instance.UsersToPlay.Add(player1, "classic");
            Assert.AreEqual(menu.addedPlayer, false);
        }

    }
}