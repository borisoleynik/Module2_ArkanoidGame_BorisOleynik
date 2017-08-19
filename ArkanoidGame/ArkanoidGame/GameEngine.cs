using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;
using System.IO;

namespace ArkanoidGame
{
    class GameEngine
    {
        private Player _player;
        private Ball _ball;
        private List<Brick> _brickWall;
        private ConsoleGraphics _canvas;
        private ConsoleImage _gameOver;
        private ConsoleImage _cover;
        public static int _count = 0;


        public GameEngine(ConsoleGraphics Canvas)
        {
            _canvas = Canvas;
        }

        public void ResetLevel()
        {
            _player = new Player(_canvas);
            _ball = new Ball();

            _brickWall = new List<Brick>();
            int xWall = 0;
            int yWall = 40;
            int rowCount = 0;
            int rowWidth = 800;
            for (int i = 0; rowCount < 4; i++)
            {
                switch (i)
                {
                    case 0:
                        xWall = 60;
                        break;
                    case 1:
                        xWall = 165;
                        break;

                    case 2:
                        xWall = 270;
                        break;

                    case 3:
                        xWall = 375;
                        break;
                }
                while (xWall <= rowWidth)
                {
                    _brickWall.Add(new Brick(_canvas, xWall, yWall));
                    xWall += 105;
                }
                yWall += 40;
                rowWidth -= 100;
                rowCount += 1;
            }
        }

        public void StartNewLevel()
        {
            do
            {
                Console.SetCursorPosition(0, 0);
                BestScore();
                System.Threading.Thread.Sleep(3);
                _player.Update(_canvas, _player, _ball);
                _ball.Update(_canvas, _player, _ball);
                if (Input.IsKeyDown(Keys.SPACE))
                {
                    _ball.LaunchTheBall = true;
                    _ball.changeDirection = Direction.UpLeft;
                }
                foreach (var item in _brickWall)
                {
                    item.Update(_canvas, _player, _ball);
                }

                _canvas.FillRectangle(0xF0000000, 0, 0, _canvas.ClientWidth, _canvas.ClientHeight);
                
                foreach (var item in _brickWall)
                {
                    item.Render(_canvas);
                }
                _player.Render(_canvas);
                _ball.Render(_canvas);
                _canvas.FlipPages();


            } while (_ball.GetY <= _canvas.ClientHeight);

        }

        public void GameOver()
        {

            _canvas.FillRectangle(0xF0000000, 0, 0, _canvas.ClientWidth, _canvas.ClientHeight);
            _gameOver = _canvas.LoadImage("GameOver.bmp");
            _canvas.DrawImage(_gameOver, 0, 0);
            _canvas.FlipPages();
        }
        public void Cover()
        {

            _canvas.FillRectangle(0xF0000000, 0, 0, _canvas.ClientWidth, _canvas.ClientHeight);
            _cover = _canvas.LoadImage("Cover.bmp");
            _canvas.DrawImage(_cover, 0, 0);
            _canvas.FlipPages();
        }
        public void BestScore()
        {
            int fileReader = int.Parse(File.ReadAllText(@"Scores\BestScore.txt"));
            if (_count > fileReader )
            {
                File.WriteAllText(@"Scores\BestScore.txt", _count.ToString());
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("{0} - BEST SCORE",_count);
            }
            else
            {
                fileReader = int.Parse(File.ReadAllText(@"Scores\BestScore.txt"));
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("{0} - BEST SCORE",fileReader);
            }
            
        }
    }
}
