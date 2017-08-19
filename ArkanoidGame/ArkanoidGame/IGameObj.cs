using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace ArkanoidGame
{
    interface IGameObj
    {
            void Render(ConsoleGraphics canvas);

            void Update(ConsoleGraphics _canvas, Player _player, Ball _ball);
    }
}
