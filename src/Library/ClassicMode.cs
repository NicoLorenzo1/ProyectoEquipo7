using System;

namespace Library
{
    public class ClassicMode : Game
    {
        public ClassicMode(string name) : base(name)
        {
    
        }
        public override void MatchPlayers()
        {
            ClassicMode game = new ClassicMode("");
            base.MatchPlayers();
            game.StartGame();
        }
    }
}