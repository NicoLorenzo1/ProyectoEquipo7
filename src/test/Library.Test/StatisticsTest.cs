using NUnit.Framework;
using Library;
using System;
using System.Collections.Generic;
using System.Collections;

namespace Test.Library
{
    public class StatisticsTest
    {
        [Test]
        public void VerifyStaticsTest()
        {
            User player1 = new User("Manuel");
            User player2 = new User("Jose");
            
            Assert.AreEqual(player1.statistics.Wins, player2.statistics.Wins);
        }

        [Test]
        public void ModifyStaticsTest()
        {
            User player1 = new User("Manuel");
            User player2 = new User("Jose");

            player1.statistics.ModifyStatics(true);
            player2.statistics.ModifyStatics(true);
            
            Assert.AreEqual(player1.statistics.Wins, player2.statistics.Wins);
        }
        
    }
}