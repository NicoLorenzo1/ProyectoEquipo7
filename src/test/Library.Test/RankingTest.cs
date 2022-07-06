using NUnit.Framework;
using Library;
using System;
using System.Collections.Generic;
using System.Collections;

namespace Test.Library
{
    public class RankingTest
    {
        [Test]
        public void InRankingList()
        {
            User player1 = new User("Manuel");

            Assert.Contains(player1.statistics, Ranking.playerStats);
        }
    }
}