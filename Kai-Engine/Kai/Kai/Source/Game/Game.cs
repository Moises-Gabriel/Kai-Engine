using Kai.Source.Graphics;

namespace Kai.Source.Game
{
    public class Game
    {
        private Window window = new();

        public void Init()
        {
            window.Create("Kai Engine", 640, 480);
        }

        public void Run()
        {
            if (window.IsRunning)
                window.Update();
        }
    }
}
