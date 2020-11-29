using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using ClassLibraryFigures;

namespace Tetris
{
    class Ingineer
    {
        public IMove move;
        Tetris tetris;
        MyGraphics graphics;
        Config config;
        IFigure ifigure = null;
        IFigure inext = null;

        FigurePoints nextFigure = null;
        FigurePoints figure = new FigurePoints();
        List<MyPoint> tmpFigurePoints = new List<MyPoint>();

        MyPoint gameCenter = new MyPoint();

        Stopwatch stopWatch = new Stopwatch();
        int tmpX, tmpY;
        int gameOver = 0;
        int flag = 0;
        public int NumberVar;

        public Ingineer(Config config, Tetris tetris)
        {
            this.config = config;
            if (config.choice == 0)//что б не выбирать клавиши в следующей игре.
            {
                move = config.SelectKeys();
            }
            if (config.choice == 1)
            {
                move = new ForKeyLeftUp();
            }
            if (config.choice == 2)
            {
                move = new ForKeyASDC();
            }
            this.tetris = tetris;
            graphics = new MyGraphics(tetris.center, config);
        }

        public IFigure AssortyFigure()
        {
            Random round = new Random();
            int form = round.Next(1, 8);
            IFigure ifigure = null;

            switch (form)
            {
                case 1:
                    ifigure = new FigureJ();
                    break;
                case 2:
                    ifigure = new FigureL();
                    break;
                case 3:
                    ifigure = new FigureT();
                    break;
                case 4:
                    ifigure = new FigureS();
                    break;
                case 5:
                    ifigure = new FigureZ();
                    break;
                case 6:
                    ifigure = new FigureO();
                    break;
                case 7:
                    ifigure = new FigureI();
                    break;
            }


            return ifigure;
        }
        public List<MyPoint> StartFigure(FigurePoints figure)
        {
            Random round = new Random();
            int num = round.Next(1, 10);
            while (num != 0)
            {
                figure = figure.next;
                num--;
            }

            NumberVar = figure.Number;
            return figure.points;
        }
        public List<MyPoint> SearchFigure(FigurePoints figure)
        {
            while (true)
            {
                if (figure.Number == NumberVar)
                    break;
                figure = figure.next;
            }

            return figure.points;
        }
        public void KeepExisting()
        {
            tmpX = gameCenter.X;
            tmpY = gameCenter.Y;
            tmpFigurePoints = figure.points;
        }
        //проверяет допустимость перемещения фигуры
        public void Admissibility(char k)
        {
            if (k != 'D')
            {
                if (k != 'U')//move дал новые координаты центра ,создаем фигуру и ее проверяем
                {
                    figure = ifigure.CreateList(gameCenter);
                    figure.points = SearchFigure(figure);
                }

                else
                {
                    // tetris.NumberVar = figure.Number;
                    figure = figure.next;
                    Console.SetCursorPosition(20, 20);
                    Console.Write(figure.Number);
                }
                if (!tetris.TouchFieldOrFloor(figure.points) || !tetris.LimitedRoof(figure.points))
                {
                    if (k != 'U')
                    {
                        gameCenter.X = tmpX;
                        gameCenter.Y = tmpY;

                    }
                    if (k != 'F')
                    {
                        figure.points = tmpFigurePoints;
                        Console.SetCursorPosition(tmpX, tmpY);//при зажатии клавиш вправо/лево не съедает поле
                    }
                }
                else
                {
                    if (k == 'U')
                        NumberVar = figure.Number;

                    graphics.WipeOffFigure(tmpFigurePoints);
                    graphics.PrintFigure(figure.points);
                }
            }
            else
            {
                while (tetris.TouchFieldOrFloor(figure.points))
                {
                    KeepExisting();
                    gameCenter.Y = gameCenter.Y + 1;

                    figure = ifigure.CreateList(gameCenter);
                    figure.points = SearchFigure(figure);

                    graphics.WipeOffFigure(tmpFigurePoints);
                }

                figure.points = tmpFigurePoints;
                gameCenter.X = tmpX;
                gameCenter.Y = tmpY;

                graphics.PrintFigure(figure.points);
            }
        }
        // создает новую и следующую фигуру
        public void CreateNextNewFigure()
        {

            gameCenter.X = tetris.center.X;
            gameCenter.Y = tetris.center.Y;

            if (flag == 0)
            {
                inext = AssortyFigure();
                nextFigure = inext.CreateList(graphics.menuCenter);
                ifigure = AssortyFigure();
                figure = ifigure.CreateList(gameCenter);
                figure.points = StartFigure(figure);
                flag = 1;
            }
            else
            {
                ifigure = inext;
                figure = ifigure.CreateList(gameCenter);
                figure.points = StartFigure(figure);

                graphics.WipeOffFigure(nextFigure.points);
                inext = AssortyFigure();
                nextFigure = inext.CreateList(graphics.menuCenter);
            }
        }
        //корректирует появление фигуры под потолком
        public void AppearanceFigure()
        {
            while (!tetris.LimitedRoof(figure.points))//коррект выход фигуры целиком под потолком.
            {                      //проверка на заполненность стакана до потолка

                if (!tetris.TouchFieldOrFloor(figure.points))
                {
                    gameOver = 1;
                    break;
                }
                tetris.DownFly(gameCenter);
                figure = ifigure.CreateList(gameCenter);
                figure.points = SearchFigure(figure);
                if (!tetris.TouchFieldOrFloor(figure.points))
                {
                    gameOver = 1;
                    break;
                }
                figure = ifigure.CreateList(gameCenter);
                figure.points = SearchFigure(figure);
            }

        }
        public void MoveFigure()
        {
            while (tetris.TouchFieldOrFloor(figure.points) && gameOver == 0)
            {
                stopWatch.Start();
                while (stopWatch.Elapsed.TotalSeconds < tetris.time)
                {
                    graphics.PrintFigure(figure.points);
                    KeepExisting();
                    if (Console.KeyAvailable)
                    {
                        Admissibility(move.Move(gameCenter));
                    }
                }
                stopWatch.Stop();
                stopWatch.Reset();

                KeepExisting();
                tetris.DownFly(gameCenter);
                Admissibility('F');

            }

        }

        public void GameOver()
        {
            config.SaveRecord(tetris.record, tetris.score);
            graphics.GameOver(tetris.record, tetris.score);
            bool select = true;
            while (select)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Enter:
                        Console.Clear();
                        MyPoint center = new MyPoint(5, 1);
                        tetris = new Tetris(center, config);
                        graphics = new MyGraphics(center, config);
                        //  Config config = new Config();
                        Ingineer game = new Ingineer(config, tetris);
                        select = false;
                        game.StartGame();
                        break;
                    case ConsoleKey.Escape:
                        select = false;
                        break;
                    default:
                        break;
                }
            }
        }
        public void StartGame()
        {
            while (gameOver == 0)
            {
                graphics.PrintField(tetris.field);
                CreateNextNewFigure();
                graphics.PrintStaticElement(nextFigure.points, tetris.score, tetris.level, tetris.record);
                AppearanceFigure();
                MoveFigure();
                tetris.FillingField(tmpFigurePoints);
                tetris.DeleteLinesScore();
            }

            GameOver();
        }
    }
}
