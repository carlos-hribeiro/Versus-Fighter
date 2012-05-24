using System;

namespace Versus_Fighter
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (VersusFighter game = new VersusFighter())
            {
                game.Run();
            }
        }
    }
#endif
}

