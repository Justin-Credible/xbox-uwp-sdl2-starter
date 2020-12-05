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
            SDL.SDL_SetHint("SDL_WINRT_HANDLE_BACK_BUTTON", "1");
            SDL.SDL_main_func mainFunction = SDLMain;
            SDL.SDL_WinRTRunApp(mainFunction, IntPtr.Zero);
        }

        private static int SDLMain(int argc, IntPtr argv)
        {
            // Your SDL2 code here.
            return 0;
        }
    }
}
