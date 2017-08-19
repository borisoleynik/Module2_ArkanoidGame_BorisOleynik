using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace ArkanoidGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.WindowWidth = 120;
            Console.WindowHeight = 40;
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            ConsoleGraphics canvas = new ConsoleGraphics();
            GameEngine theGame = new GameEngine(canvas);
            theGame.Cover();
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.R:
                        theGame.ResetLevel();
                        theGame.StartNewLevel();
                        theGame.GameOver();
                        break;

                    case ConsoleKey.Escape:
                        return;
                        
                }
            }


        }
    }
}
