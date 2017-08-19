using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace ArkanoidGame
{
    class Player : IGameObj
    {
        private int _x, _y, _speed;

        public Player(ConsoleGraphics Canvas)
        {
            _x = Canvas.ClientWidth / 2 - 25;
            _y = Canvas.ClientHeight - 150;
            _speed = 5;
        }

        public int X
        {
            get { return _x; }
        }
        public int Y
        {
            get { return _y; }
        }


        public void Render(ConsoleGraphics canvas)
        {
            canvas.DrawLine(0xFFFFFFFF, _x, _y, _x + 50, _y, 5);
        }

        public void Update(ConsoleGraphics canvas, Player currentPlayer, Ball currentBall)
        {
            if (Input.IsKeyDown(Keys.LEFT) && _x > 0)
            {
                currentPlayer._x -= _speed;
            }
            else if (Input.IsKeyDown(Keys.RIGHT) && _x+50 < canvas.ClientWidth)
            {
                currentPlayer._x += _speed;
            }
        }
    }
}
