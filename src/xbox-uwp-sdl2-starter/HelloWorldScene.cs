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
        private bool _needsRender = true;

        public void Render(IntPtr sdlRenderer)
        {
            if (!_needsRender)
                return;

            SDL.SDL_SetRenderDrawColor(sdlRenderer, 11, 145, 4, 255); // #0b9104 - Xbox Green
            SDL.SDL_RenderClear(sdlRenderer);

            FontRenderer.RenderString(sdlRenderer, "XBOX ONE", 0, 2);
            FontRenderer.RenderString(sdlRenderer, "Hello World!", 0, 3);

            SDL.SDL_RenderPresent(sdlRenderer);

            _needsRender = false;
        }
    }
}
