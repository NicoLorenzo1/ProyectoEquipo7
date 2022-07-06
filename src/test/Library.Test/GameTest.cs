using NUnit.Framework;
using Library;
using System;
using System.Collections.Generic;
using System.Collections;


namespace Test.Library
{
    public class GameTest
    {
        [SetUp]
        public void setup()
        {
            Administrator.Instance.usersRegisteredWithState.Clear();
            Administrator.Instance.BotEnabled = false;
        }

        [Test]
        public void NumOutOfBoardTest()
        {
            User user = new User("User");
            User user2 = new User("User2");
            Game game = new Game(user, user2, "Classic");
            bool coord = game.CoordCheck("a", "15");
            Assert.IsTrue(coord);
        }

        [Test]
        public void AlphaOutOfBoardTest()
        {
            User user = new User("User");
            User user2 = new User("User2");
            Game game = new Game(user, user2, "Classic");
            bool coord = game.CoordCheck("z", "5");
            Assert.IsTrue(coord);
        }

        [Test]
        public void ValidCoordTest()
        {
            User user = new User("User");
            User user2 = new User("User2");
            Game game = new Game(user, user2, "Classic");
            bool coord = game.CoordCheck("b", "5");
            Assert.IsFalse(coord);
        }

        [Test]
        public void AlreadyShot()
        {
            User user = new User("User");
            User user2 = new User("User2");
            Board board = new Board(user);
            board.shots.Add("a");
            board.shots.Add("4");
            Game game = new Game(user, user2, "Classic");
            bool shot = game.ShotHistory("a", "4", board);
            Assert.False(shot);
        }

        [Test]
        public void ValidShot()
        {
            User user = new User("User");
            User user2 = new User("User2");
            Board board = new Board(user);
            Game game = new Game(user, user2, "Classic");
            bool shot = game.ShotHistory("a", "4", board);
            Assert.IsFalse(shot);
        }

        [Test]
        public void OutOfBoardAttack()
        {
            User user = new User("User");
            User user2 = new User("User2");
            Game game = new Game(user, user2, "Classic");
            string attack = game.Attack("o", "9", user);
            Assert.AreEqual("reintentar", attack);
        }

        [Test]
        public void MissedAttack()
        {
            User user = new User("User");
            User user2 = new User("User2");
            Game game = new Game(user, user2, "Classic");
            string attack = game.Attack("a", "9", user);
            Assert.AreEqual("Agua", attack);
        }
    }
}
