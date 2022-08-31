using Kai.Source.Graphics;

namespace Kai.Source.Game
{
    public class Game
    {
        private Window window = new();

        public void Start()
        {
            window.Init("Kai Engine", 640, 480);
        }

        public void End()
        {
            window.Clean();
        }
    }
}
