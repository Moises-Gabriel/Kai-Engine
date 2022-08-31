using Kai.Source.Graphics;
using Kai.Source.Logging;
using Kai.Source.Game;

namespace Kai.Source
{
    class Program
    {
        static void Main(string[] args)
        {
            Game.Game game = new();
            
            //initialize the game loop
            game.Init();
            //run the game loop
            game.Run();
        }
    }
}

