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

            game.Start();
            game.Update();
        }
    }
}

