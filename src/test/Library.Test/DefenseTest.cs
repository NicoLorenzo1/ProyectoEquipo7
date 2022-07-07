using NUnit.Framework;
using Library;
using System;
using System.Collections.Generic;
using System.Collections;
using Message = Telegram.Bot.Types.Message;

namespace Test.Library
{
    public class DefenseTest
    {
        [Test]
        public void HitCounterTest()
        {

            User jose = new User("Jose");
            User nico = new User("Nico");
            Administrator administrator = Administrator.Instance;
            administrator.UsersToPlay.Add(jose, "classic");
            administrator.UsersToPlay.Add(nico, "classic");
            
            Game game = new Game(jose, nico, "classic");
            HitController counterHelper = new HitController(game);

            game.boardPlayer1.Positioner("A","1","2","Lancha",1);
            game.boardPlayer1.Positioner("B","1","2","Crucero",2);
            game.boardPlayer1.Positioner("C","1","2","Submarino",3);
            game.boardPlayer1.Positioner("D","1","2","Buque",4);
            game.boardPlayer1.Positioner("E","1","2","Portaaviones",5);

            game.boardPlayer2.Positioner("F","1","2","Lancha",1);
            game.boardPlayer2.Positioner("G","1","2","Crucero",2);
            game.boardPlayer2.Positioner("H","1","2","Submarino",3);
            game.boardPlayer2.Positioner("I","1","2","Buque",4);
            game.boardPlayer2.Positioner("J","1","2","Portaaviones",5);

            game.Attack("F", "1", jose); //HIT
            game.Attack("A", "1", nico); //HIT
            game.Attack("A", "7", jose); //FAIL
            game.Attack("F", "5", nico); //FAIL
            game.Attack("J", "1", jose); //HIT
            game.Attack("B", "3", nico); //FAIL
            game.Attack("J", "2", jose); //HIT
            game.Attack("C", "3", nico); //HIT
            game.Attack("J", "3", jose); //HIT

            (int hits, int failed) = counterHelper.ShowAttackHistory(game);


            Assert.AreEqual(6, hits);
            Assert.AreEqual(3, failed);
        }
    }
}