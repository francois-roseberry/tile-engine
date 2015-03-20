using System;

namespace TileEngine
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (TileEngine game = new TileEngine())
            {
                game.Run();
            }
        }
    }
#endif
}

