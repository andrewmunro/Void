using System;

namespace VoidRadar
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Radar game = new Radar())
            {
                game.Run();
            }
        }
    }
#endif
}

