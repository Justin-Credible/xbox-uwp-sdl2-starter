using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;

namespace xbox_uwp_sdl2_starter
{
    class HelloWorldScene
    {
        private static Color XBOX_GREEN = Color.FromArgb(11, 145, 4); // #0b9104
        private const string WHITE = "{255,255,255}";
        private const string LIME_GREEN = "{50,205,50}";
        private const string WINDOWS_BLUE = "{0,173,239}";
        private const string SALMON_RED = "{250,128,114}";

        private bool _needsRender = true;

        public void Render(IntPtr sdlRenderer)
        {
            if (!_needsRender)
                return;

            // Clear the screen.
            SDL.SDL_SetRenderDrawColor(sdlRenderer, 0, 0, 0, 0);
            SDL.SDL_RenderClear(sdlRenderer);

            // Render the giant Xbox logo ASCII art as the background.
            for (var i = 0; i < AsciiArt.XBOX_LOGO.Length; i++)
                FontRenderer.RenderString(sdlRenderer, AsciiArt.XBOX_LOGO[i], 0, i * 8, XBOX_GREEN, Color.White);

            // Overlay the following message.
            FontRenderer.RenderString(sdlRenderer, "                                     ", 40 * 8, 61 * 8, Color.White, Color.Black);
            FontRenderer.RenderString(sdlRenderer, "       H E L L O    W O R L D        ", 40 * 8, 62 * 8, Color.White, Color.Black);
            FontRenderer.RenderString(sdlRenderer, "                                     ", 40 * 8, 63 * 8, Color.White, Color.Black);
            FontRenderer.RenderString(sdlRenderer, $"    {LIME_GREEN}X B O X  {WHITE}/  {WINDOWS_BLUE}U W P  {WHITE}/  {SALMON_RED}S D L 2    ", 40 * 8, 64 * 8, Color.White, Color.Black);
            FontRenderer.RenderString(sdlRenderer, "                                     ", 40 * 8, 65 * 8, Color.White, Color.Black);

            SDL.SDL_RenderPresent(sdlRenderer);

            // No need to continuously re-render this once it's been done once.
            _needsRender = false;
        }
    }
}
