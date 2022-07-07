using System;
using Telegram.Bot;

namespace Library
{
    public class HitController
    {
        private int ShipHitter;
        private int WaterHitter;
        private Game SelectedGame;
        public HitController(Game controlledGame)
        {
            this.ShipHitter = 0;
            this.WaterHitter = 0;
            this.SelectedGame = controlledGame;
        }
        public HitController(long playerId)
        {
            this.ShipHitter = 0;
            this.WaterHitter = 0;
            this.SelectedGame = Administrator.Instance.GetPlayerGame(playerId);
        }

        public (int, int) ShowAttackHistory(Game SelectedGame)
        {
            ShipHitter = SelectedGame.hitcounter;
            WaterHitter = SelectedGame.missCounter;
            //System.Console.WriteLine($"La cantidad de tiros acertados a barcos es: {ShipHitter}");
            //System.Console.WriteLine($"La cantidad de tiros al agua es: {ShipHitter}");
            return (ShipHitter,WaterHitter);
        }
    }
}