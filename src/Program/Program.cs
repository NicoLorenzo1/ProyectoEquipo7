﻿using System;
using Library;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            User player1 = new User("Juan");
            User player2 = new User("Nico");
            Game bomb = new Bomb(player1, player1);
            bomb.StartGame();
        }
    }
}
