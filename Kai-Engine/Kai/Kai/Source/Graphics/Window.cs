using System.Xml.Serialization;
using Kai.Source.Logging;
using static SDL2.SDL;

namespace Kai.Source.Graphics
{
    internal class Window
    {
        private readonly Logger logger = new();

        private IntPtr window;
        private IntPtr renderer;

        public bool isRunning = false;

        //Initialize
        public void Init(string title, int width, int height)
        {
           SDL_SetMainReady();
           if (SDL_Init(SDL_INIT_EVERYTHING) < 0)
           {
               logger.Log(LogType.Error, "Could not initialize SDL!");
               SDL_Quit();
           }
           else
           {
               logger.Log(LogType.Info, "Initialized SDL!");
                //create Window
                Create(title, width, height);
           }
        }
        //create Window
        void Create(string title, int width, int height)
        {
            //assign window and renderer
            window = SDL_CreateWindow(title, SDL_WINDOWPOS_UNDEFINED, SDL_WINDOWPOS_UNDEFINED, width, height, 0);

            renderer = SDL_CreateRenderer(window, -1, 0);

            SDL_SetRenderDrawColor(renderer, 255, 0, 100, 225);
            SDL_RenderClear(renderer);

            SDL_RenderPresent(renderer);

            if (window != IntPtr.Zero)
            {
                logger.Log(LogType.Info, "Window created!");

                renderer = SDL_GetRenderer(window);
                if (renderer != IntPtr.Zero)
                    logger.Log(LogType.Info, "Renderer created!");
                else
                    logger.Log(LogType.Error, "Renderer could not be created!");

                SDL_Delay(5000);
                Clean();
            }
            else
                logger.Log(LogType.Error, "Window could not be created!");

            isRunning = true;
        }

        public void Clean()
        {
            SDL_DestroyWindow(window);
            logger.Log(LogType.Warning, "Window destroyed!");
            SDL_DestroyRenderer(renderer);
            logger.Log(LogType.Warning, "Renderer destroyed!");
            SDL_Quit();
            logger.Log(LogType.Warning, "Quit SDL!");
        }
    }
}
