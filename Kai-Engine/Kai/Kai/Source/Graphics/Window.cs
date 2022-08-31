using Kai.Source.Logging;
using static SDL2.SDL;

namespace Kai.Source.Graphics;

internal class Window
{
    private readonly Logger _logger = new();

    private IntPtr _window;
    private IntPtr _renderer;

    public bool IsRunning = true;

    //create Window
    public void Create(string title, int width, int height)
    {
        _logger.Log(LogType.Info, "Starting <Kai Engine>!");
        SDL_SetMainReady();
        if (SDL_Init(SDL_INIT_EVERYTHING) < 0)
        {
            _logger.Log(LogType.Error, "Could not initialize SDL!");
            SDL_Quit();
        }
        else
            _logger.Log(LogType.Info, "Initialized SDL!");

        //assign window and renderer
        _window = SDL_CreateWindow(title, SDL_WINDOWPOS_CENTERED, SDL_WINDOWPOS_CENTERED, width, height, 0);
        _renderer = SDL_CreateRenderer(_window, -1, 0);

        //Check if initialized properly and get renderer
        if (_window != IntPtr.Zero)
        {
            _logger.Log(LogType.Info, "Window created!");

            _renderer = SDL_GetRenderer(_window);
            if (_renderer != IntPtr.Zero)
                _logger.Log(LogType.Info, "Renderer created!");
            else
                _logger.Log(LogType.Error, "Renderer could not be created!");
        }
        else
        {
            _logger.Log(LogType.Error, "Window could not be created!");
        }
    }

    private void Render()
    {
        //Color screen
        SDL_SetRenderDrawColor(_renderer, 0, 0, 0, 225);
        SDL_RenderClear(_renderer);

        //Render things in here
        SDL_SetRenderDrawColor(_renderer, 255, 0, 0, 225);
        SDL_Rect rect = new()
        {
            w = 200,
            h = 200,
            x = 1,
            y = 1
        };
        SDL_RenderFillRect(_renderer, ref rect);
        //

        //Present rendered objects
        SDL_RenderPresent(_renderer);
    }

    public void Update()
    {
        while (IsRunning)
        {
            SDL_Event _event = new();
            while (SDL_PollEvent(out _event) != 0)
                switch (_event.type)
                {
                    case SDL_EventType.SDL_QUIT:
                        Clean();
                        IsRunning = false;
                        break;
                    case SDL_EventType.SDL_WINDOWEVENT:
                        Render();
                        break;
                }
        }
    }

    public void Clean()
    {
        SDL_DestroyWindow(_window);
        _logger.Log(LogType.Warning, "Window destroyed!");
        SDL_DestroyRenderer(_renderer);
        _logger.Log(LogType.Warning, "Renderer destroyed!");
        SDL_Quit();
        _logger.Log(LogType.Warning, "Quit SDL!");
    }
}