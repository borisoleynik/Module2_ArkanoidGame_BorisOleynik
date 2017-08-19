using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace ArkanoidGame
{
    class Brick : IGameObj
    {
        int _x, _y;
        private ConsoleImage image;

        public int SetX
        {
            set
            {
                _x = value;
            }
        }
        public ConsoleImage getImage
        {
            get
            {
                return  image;
            }
        }
        public Brick(ConsoleGraphics _canvas, int X, int Y )
        {
            image = _canvas.LoadImage("Brick.bmp");
            _x = X;
            _y = Y;
        }

        public void Render(ConsoleGraphics canvas)
        {
            if (image != null)
            {
            canvas.DrawImage(image,_x,_y );
            }
        }

        public void Update(ConsoleGraphics _canvas, Player _player, Ball _ball)
        {
            if (image != null)
            {
                if (_ball.GetX >= _x && _ball.GetX <= _x +image.Width && _ball.GetY >= _y && _ball.GetY <= _y+image.Height)
                {
                    image = null;
                    GameEngine._count++;
                    switch (_ball.changeDirection)
                    {
                        case Direction.UpLeft:
                            _ball.changeDirection = Direction.DownLeft;
                            break;
                        case Direction.UpRight:
                            _ball.changeDirection = Direction.DownRight;
                            break;
                        case Direction.DownLeft:
                            _ball.changeDirection = Direction.UpLeft;
                            break;
                        case Direction.DownRight:
                            _ball.changeDirection = Direction.UpRight;
                            break;
                    }
                    
                }
            }

        }



       
    }
}
