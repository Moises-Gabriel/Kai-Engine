using System.Xml.Serialization;
using Kai.Source.Logging;
using static SDL2.SDL;

namespace Kai.Source.Graphics
{
    internal class Window
    {
        private readonly Logger logger = new();

        private IntPtr _window;
        private IntPtr _renderer;

        public bool IsRunning = true;

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
            _window = SDL_CreateWindow(title, SDL_WINDOWPOS_UNDEFINED, SDL_WINDOWPOS_UNDEFINED, width, height, SDL_WindowFlags.SDL_WINDOW_RESIZABLE);
            _renderer = SDL_CreateRenderer(_window, -1, 0);
            
            //Check if initialized properly and get renderer
            if (_window != IntPtr.Zero)
            {
                logger.Log(LogType.Info, "Window created!");

                _renderer = SDL_GetRenderer(_window);
                if (_renderer != IntPtr.Zero)
                    logger.Log(LogType.Info, "Renderer created!");
                else
                    logger.Log(LogType.Error, "Renderer could not be created!");
            }
            else
                logger.Log(LogType.Error, "Window could not be created!");

            SDL_RenderPresent(_renderer);
        }

        void Render()
        {
            //Render to screen
            SDL_SetRenderDrawColor(_renderer, 255, 0, 100, 225);
            SDL_RenderClear(_renderer);

            SDL_RenderPresent(_renderer);
        }

        public void Update()
        {
            while (IsRunning)
            {
                SDL_Event windowEvent = new();
                while (SDL_PollEvent(out windowEvent) != 0)
                {
                    switch (windowEvent.type)
                    {
                        case SDL_EventType.SDL_QUIT:
                            IsRunning = false;
                            Clean();
                            break;
                        case SDL_EventType.SDL_WINDOWEVENT:
                            Render();
                            break;
                    }
                }
            }
        }

        public void Clean()
        {
            SDL_DestroyWindow(_window);
            logger.Log(LogType.Warning, "Window destroyed!");
            SDL_DestroyRenderer(_renderer);
            logger.Log(LogType.Warning, "Renderer destroyed!");
            SDL_Quit();
            logger.Log(LogType.Warning, "Quit SDL!");
        }
    }
}
