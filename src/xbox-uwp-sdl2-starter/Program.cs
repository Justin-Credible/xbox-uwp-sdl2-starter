using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;

namespace xbox_uwp_sdl2_starter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set hints for how we want SDL to behave: https://wiki.libsdl.org/CategoryHints
            SDL.SDL_SetHint("SDL_WINRT_HANDLE_BACK_BUTTON", "1");

            // Delegate to SDL to allow it to perform all the necessary tasks needed to
            // boostrap a UWP app, so we don't have to! Once it's ready it will fire SDLMain.
            SDL.SDL_main_func mainFunction = SDLMain;
            SDL.SDL_WinRTRunApp(mainFunction, IntPtr.Zero);
        }

        private static int SDLMain(int argc, IntPtr argv)
        {
            // Initialize SDL; tell SDL which subsystems we want to use.

            var initResult = SDL.SDL_Init(SDL.SDL_INIT_VIDEO | SDL.SDL_INIT_AUDIO);

            if (initResult != 0)
                throw new Exception(String.Format("Failure while initializing SDL. SDL Error: {0}", SDL.SDL_GetError()));

            // Get the current display resolution.

            SDL.SDL_DisplayMode displayMode;

            var getDisplayModeResult = SDL.SDL_GetCurrentDisplayMode(0, out displayMode);

            if (getDisplayModeResult != 0)
                throw new Exception(String.Format("Failure while getting display mode. SDL Error: {0}", SDL.SDL_GetError()));

            // Create the window we'll be rendering in; make it the full size of the screen.

            var window = SDL.SDL_CreateWindow("XBOX UWP SDL2 Starter",
                SDL.SDL_WINDOWPOS_CENTERED,
                SDL.SDL_WINDOWPOS_CENTERED,
                displayMode.w,
                displayMode.h,
                SDL.SDL_WindowFlags.SDL_WINDOW_FULLSCREEN_DESKTOP
            );

            if (window == IntPtr.Zero)
                throw new Exception(String.Format("Unable to create a window. SDL Error: {0}", SDL.SDL_GetError()));

            // Create a renderer for our new window.

            var renderer = SDL.SDL_CreateRenderer(window, -1, SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED /*| SDL.SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC*/);

            if (renderer == IntPtr.Zero)
                throw new Exception(String.Format("Unable to create a renderer. SDL Error: {0}", SDL.SDL_GetError()));

            // We can scale the image up or down based on a scaling factor.
            //SDL.SDL_RenderSetScale(renderer, 2, 2);

            // By setting the logical size we ensure that the image will scale to fit the window while
            // still maintaining the original aspect ratio.
            SDL.SDL_RenderSetLogicalSize(renderer, 960, 540);

            // Start the game loop.
            GameLoop(renderer);

            return 0;
        }

        private static void GameLoop(IntPtr sdlRenderer)
        {
            var scene = new HelloWorldScene();

            SDL.SDL_Event sdlEvent;

            while (true)
            {
                while (SDL.SDL_PollEvent(out sdlEvent) != 0)
                {
                    switch (sdlEvent.type)
                    {
                        case SDL.SDL_EventType.SDL_QUIT:
                            return;
                    }
                }

                scene.Render(sdlRenderer);
            }
        }
    }
}
