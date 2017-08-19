using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace ArkanoidGame
{
    enum Direction { Left, Right, DownRight, DownLeft, UpRight, UpLeft }

    class Ball : IGameObj
    {
        private int _x, _y, _speed;
        public Direction changeDirection = new Direction();
        private bool _isLaunched = false;

        public Ball()
        {
            _x = 120;
            _y = 120;
            _speed = 4;
        }

        public int GetX
        {
            get { return _x; }
        }
        public int GetY
        {
            get { return _y; }
        }


        public bool LaunchTheBall
        {
            set { _isLaunched = value; }
        }

        public void Render(ConsoleGraphics canvas)
        {
            canvas.DrawLine(0xFFFFFFFF, _x, _y, _x + 5, _y, 5);
        }

        public void Update(ConsoleGraphics _canvas, Player currentPlayer, Ball currentBall)
        {
            if (_isLaunched == true)
            {
                if (_x <= 0 && changeDirection == Direction.UpLeft)
                {
                    changeDirection = Direction.UpRight;

                }
                if (changeDirection == Direction.DownLeft && _x <=0  )
                {
                    changeDirection = Direction.DownRight;

                }
                if (changeDirection == Direction.UpLeft && _x <= 0  )
                {
                    changeDirection = Direction.UpRight;
                }
            if (changeDirection == Direction.DownLeft && (_y >= currentPlayer.Y && _y <= currentPlayer.Y+4) && _x >= currentPlayer.X && _x <= (currentPlayer.X + 50))
                {
                    changeDirection = Direction.UpLeft;
                }
            if (changeDirection == Direction.DownRight && (_y >= currentPlayer.Y && _y <= currentPlayer.Y + 4) && _x >= currentPlayer.X  && _x <= (currentPlayer.X + 50))
                {
                    changeDirection = Direction.UpRight;
                }
                if (_y <= 0 && changeDirection == Direction.UpRight)
                {
                    changeDirection = Direction.DownRight;
                }
                if (_y <= 0 && changeDirection == Direction.UpLeft)
                {
                    changeDirection = Direction.DownLeft;
                }
                if (_x > _canvas.ClientWidth && changeDirection == Direction.DownRight)
                {
                    changeDirection = Direction.DownLeft;
                }
                if (_x > _canvas.ClientWidth && changeDirection == Direction.UpRight)
                {
                    changeDirection = Direction.UpLeft;
                }




                if (changeDirection == Direction.DownRight)
                {
                    _x += _speed;
                    _y += _speed;
                }
                if (changeDirection == Direction.DownLeft)
                {
                    _x -= _speed;
                    _y += _speed;
                }
                else if (changeDirection == Direction.UpRight)
                {
                    _x += _speed;
                    _y -= _speed;
                }
                else if (changeDirection == Direction.UpLeft)
                {
                    _x -= _speed;
                    _y -= _speed;
                }
            }
            else
            {
                _x = currentPlayer.X + 20;
                _y = currentPlayer.Y - 20;
            }
        }
    }
}
