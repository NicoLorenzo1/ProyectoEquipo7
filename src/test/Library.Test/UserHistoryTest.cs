
/*using NUnit.Framework;
using Library;
using System;
using System.Collections.Generic;
using System.Collections;

namespace Test.Library
{
    public class UserHistoryTest
    {
        /// <summary>
        /// Test que se encarga de verificar si se crea una instancia de juego correctamente y se añade a currentGame
        /// </summary>
        [Test]
        public void StartGameTest()
        {
            User player1 = new User("Jose");
            User player2 = new User("Juan");

            Game game = new Game(player1,player2,"Classic");

            Assert.Contains(game, Administrator.Instance.currentGame);

        }
<<<<<<< HEAD
=======

        /// <summary>
        /// Test que se encarga de verificar si se crea un usuario correctamente y se asigna a la lista de usuarios registrados
        /// </summary>       
        [Test]
        public void CreateUserTest()
        {
            User player1 = new User("Jose");
            
            Assert.Contains(player1,User.users);
        }
>>>>>>> main
        
        /// <summary>
        /// Test que se encarga de verificar si el Metodo MatchPlayers() añade correctamente al jugador al diccionario UserToPlay
        /// para luego encontrar otro jugador y comenzar una partida
        /// </summary>
        [Test]
        public void MatchPlayersTest()
        {
            User player1 = new User("Jose");

            Administrator.Instance.MatchPlayers(player1,"Classic");

            
            
            Assert.IsTrue(Administrator.Instance.UsersToPlay.ContainsValue("Classic"));
            Assert.IsTrue(Administrator.Instance.UsersToPlay.ContainsKey(player1));
        }
        

        /// <summary>
        /// Test que verifica la creación de tableros es igual para todos los Board y sus usuarios
        /// </summary>
        [Test]
        public void StartBoardTest()
        {
            User player1 = new User("Jose");
            User player2 = new User("Juan");
            Board board = new Board(player1);
            Board board2 = new Board(player2);
            List<List<string>> boardRows=board.StartBoard();
            List<List<string>> boardRows2=board2.StartBoard();

            Assert.AreEqual(boardRows.Count,boardRows2.Count);
            Assert.AreEqual(boardRows,boardRows2);
        }
        /// <summary>
        /// Test que verifica la edición de tableros. Se le pasa 2 coordenadas y se verifica si la fila correspondiente se ve afectada
        /// </summary>
        [Test]
        public void EditBoardTest()
        {
            User player1 = new User("Jose");

            Board board = new Board(player1);

            List<List<string>> boardRows=board.StartBoard();
            board.EditBoard("A","1","X",boardRows);

            List<string> test = new List<string>()
            {
                "1","X","-","-","-","-","-","-","-","-","-"
            };
            Assert.AreEqual(boardRows[1],test);
        }
<<<<<<< HEAD
    }
}
=======

        [Test]
        public void VerifyStaticsTest()
        {
            User player1 = new User("Manuel");
            User player2 = new User("Jose");

            //player1.statistics.ModifyStatics(player1, true);
            
            Assert.AreEqual(player1.statistics.Wins, player2.statistics.Wins);
        }

        [Test]
        public void ModifyStaticsTest()
        {
            User player1 = new User("Manuel");
            User player2 = new User("Jose");

            player1.statistics.ModifyStatics(player1, true);
            player2.statistics.ModifyStatics(player2, true);
            
            Assert.AreEqual(player1.statistics.Wins, player2.statistics.Wins);
        }

        [Test]
        public void VerifyShipSize()
        {
            Ship s1 = new Ship(5);

            Assert.AreEqual(s1.ShipDim, 5);
        }

        [Test]
        public void VerifyShipName()
        {
            Ship s1 = new Ship(5);

            Assert.AreEqual(s1.Shipname, "Portaaviones");
        }
    }
}*/
>>>>>>> main
