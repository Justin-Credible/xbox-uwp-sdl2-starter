using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;

namespace xbox_uwp_sdl2_starter
{
    class HelloWorldScene
    {
        public void Render(IntPtr sdlRenderer)
        {
            SDL.SDL_SetRenderDrawColor(sdlRenderer, 255, 0, 0, 255);
            SDL.SDL_RenderClear(sdlRenderer);
            SDL.SDL_RenderPresent(sdlRenderer);
        }
    }
}
