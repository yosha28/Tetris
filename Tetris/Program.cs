using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace Tetris
{
    interface IFigure
    {
        FigurePoints CreateList(Point point);
    }
    interface IMove
    {
        char Move(Point point);
    }

   class Point
    {
        public int x;
        public int y;
        public Point() { }

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;

        }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

    }

    class FigurePoints
    {
        public List<Point> points;
        public FigurePoints next;
        public int number;

        public FigurePoints()
        {
            points = new List<Point>();

        }
        public int Number { get => number; set => number = value; }

    }

    class FigureO : IFigure
    {
        public FigurePoints CreateList(Point center)
        {
            FigurePoints figure1 = new FigurePoints();
            figure1.points.Add(new Point(center.x, center.y));
            figure1.points.Add(new Point(center.x - 1, center.y));
            figure1.points.Add(new Point(center.x, center.y + 1));
            figure1.points.Add(new Point(center.x - 1, center.y + 1));

            figure1.next = figure1;
            figure1.Number = 1;


            return figure1;
        }

    }
    class FigureJ : IFigure
    {

        public FigurePoints CreateList(Point center)
        {
            FigurePoints figure1 = new FigurePoints();
            figure1.points.Add(new Point(center.x, center.y));
            figure1.points.Add(new Point(center.x, center.y - 1));
            figure1.points.Add(new Point(center.x, center.y + 1));
            figure1.points.Add(new Point(center.x - 1, center.y + 1));

            figure1.Number = 1;

            FigurePoints figure2 = new FigurePoints();
            figure2.points.Add(new Point(center.x, center.y));
            figure2.points.Add(new Point(center.x - 1, center.y));
            figure2.points.Add(new Point(center.x + 1, center.y));
            figure2.points.Add(new Point(center.x - 1, center.y - 1));

            figure2.Number = 2;

            FigurePoints figure3 = new FigurePoints();
            figure3.points.Add(new Point(center.x, center.y));
            figure3.points.Add(new Point(center.x, center.y - 1));
            figure3.points.Add(new Point(center.x, center.y + 1));
            figure3.points.Add(new Point(center.x + 1, center.y - 1));

            figure3.Number = 3;

            FigurePoints figure4 = new FigurePoints();
            figure4.points.Add(new Point(center.x, center.y));
            figure4.points.Add(new Point(center.x - 1, center.y));
            figure4.points.Add(new Point(center.x + 1, center.y));
            figure4.points.Add(new Point(center.x + 1, center.y + 1));

            figure4.Number = 4;

            figure1.next = figure2;
            figure2.next = figure3;
            figure3.next = figure4;
            figure4.next = figure1;


            return figure1;

        }

    }
    class FigureT : IFigure
    {
        public FigurePoints CreateList(Point center)
        {
            FigurePoints figure1 = new FigurePoints();
            figure1.points.Add(new Point(center.x, center.y));
            figure1.points.Add(new Point(center.x + 1, center.y));
            figure1.points.Add(new Point(center.x, center.y + 1));
            figure1.points.Add(new Point(center.x - 1, center.y));

            figure1.Number = 1;

            FigurePoints figure2 = new FigurePoints();
            figure2.points.Add(new Point(center.x, center.y));
            figure2.points.Add(new Point(center.x, center.y - 1));
            figure2.points.Add(new Point(center.x, center.y + 1));
            figure2.points.Add(new Point(center.x - 1, center.y));

            figure2.Number = 2;

            FigurePoints figure3 = new FigurePoints();
            figure3.points.Add(new Point(center.x, center.y));
            figure3.points.Add(new Point(center.x + 1, center.y));
            figure3.points.Add(new Point(center.x - 1, center.y));
            figure3.points.Add(new Point(center.x, center.y - 1));

            figure3.Number = 3;

            FigurePoints figure4 = new FigurePoints();
            figure4.points.Add(new Point(center.x, center.y));
            figure4.points.Add(new Point(center.x, center.y - 1));
            figure4.points.Add(new Point(center.x, center.y + 1));
            figure4.points.Add(new Point(center.x + 1, center.y));

            figure4.Number = 4;

            figure1.next = figure2;
            figure2.next = figure3;
            figure3.next = figure4;
            figure4.next = figure1;


            return figure1;
        }
    }
    class FigureI : IFigure
    {
        public FigurePoints CreateList(Point center)
        {
            FigurePoints figure1 = new FigurePoints();
            figure1.points.Add(new Point(center.x, center.y));
            figure1.points.Add(new Point(center.x, center.y - 1));
            figure1.points.Add(new Point(center.x, center.y - 2));
            figure1.points.Add(new Point(center.x, center.y + 1));

            figure1.Number = 1;

            FigurePoints figure2 = new FigurePoints();
            figure2.points.Add(new Point(center.x, center.y));
            figure2.points.Add(new Point(center.x + 1, center.y));
            figure2.points.Add(new Point(center.x - 1, center.y));
            figure2.points.Add(new Point(center.x - 2, center.y));

            figure2.Number = 2;

            figure1.next = figure2;
            figure2.next = figure1;

            return figure1;
        }
    }
    class FigureZ : IFigure
    {
        public FigurePoints CreateList(Point center)
        {
            FigurePoints figure1 = new FigurePoints();
            figure1.points.Add(new Point(center.x, center.y));
            figure1.points.Add(new Point(center.x - 1, center.y));
            figure1.points.Add(new Point(center.x, center.y + 1));
            figure1.points.Add(new Point(center.x + 1, center.y + 1));

            figure1.Number = 1;

            FigurePoints figure2 = new FigurePoints();
            figure2.points.Add(new Point(center.x, center.y));
            figure2.points.Add(new Point(center.x, center.y + 1));
            figure2.points.Add(new Point(center.x + 1, center.y));
            figure2.points.Add(new Point(center.x + 1, center.y - 1));

            figure2.Number = 2;

            figure1.next = figure2;
            figure2.next = figure1;

            return figure1;
        }
    }
    class FigureS : IFigure
    {
        public FigurePoints CreateList(Point center)
        {
            FigurePoints figure1 = new FigurePoints();
            figure1.points.Add(new Point(center.x, center.y));
            figure1.points.Add(new Point(center.x + 1, center.y));
            figure1.points.Add(new Point(center.x, center.y + 1));
            figure1.points.Add(new Point(center.x - 1, center.y + 1));

            figure1.Number = 1;

            FigurePoints figure2 = new FigurePoints();
            figure2.points.Add(new Point(center.x, center.y));
            figure2.points.Add(new Point(center.x, center.y - 1));
            figure2.points.Add(new Point(center.x + 1, center.y));
            figure2.points.Add(new Point(center.x + 1, center.y + 1));

            figure2.Number = 2;

            figure1.next = figure2;
            figure2.next = figure1;

            return figure1;

        }
    }
    class FigureL : IFigure
    {
        public FigurePoints CreateList(Point center)
        {
            FigurePoints figure1 = new FigurePoints();
            figure1.points.Add(new Point(center.x, center.y));
            figure1.points.Add(new Point(center.x, center.y - 1));
            figure1.points.Add(new Point(center.x, center.y + 1));
            figure1.points.Add(new Point(center.x + 1, center.y + 1));

            figure1.Number = 1;

            FigurePoints figure2 = new FigurePoints();
            figure2.points.Add(new Point(center.x, center.y));
            figure2.points.Add(new Point(center.x - 1, center.y));
            figure2.points.Add(new Point(center.x + 1, center.y));
            figure2.points.Add(new Point(center.x - 1, center.y + 1));

            figure2.Number = 2;

            FigurePoints figure3 = new FigurePoints();
            figure3.points.Add(new Point(center.x, center.y));
            figure3.points.Add(new Point(center.x, center.y - 1));
            figure3.points.Add(new Point(center.x, center.y + 1));
            figure3.points.Add(new Point(center.x - 1, center.y - 1));

            figure3.Number = 3;

            FigurePoints figure4 = new FigurePoints();
            figure4.points.Add(new Point(center.x, center.y));
            figure4.points.Add(new Point(center.x - 1, center.y));
            figure4.points.Add(new Point(center.x + 1, center.y));
            figure4.points.Add(new Point(center.x + 1, center.y - 1));

            figure4.Number = 4;

            figure1.next = figure2;
            figure2.next = figure3;
            figure3.next = figure4;
            figure4.next = figure1;


            return figure1;
        }
    }

    class ForKeyLeftUp : IMove
    {
        public char Move(Point center)
        {
            char numKey = ' ';
            ConsoleKey step = Console.ReadKey().Key;

            switch (step)
            {
                case ConsoleKey.LeftArrow:
                    center.X--;
                    numKey = 'L';
                    break;
                case ConsoleKey.RightArrow:
                    center.X++;
                    numKey = 'R';
                    break;
                case ConsoleKey.DownArrow:
                    numKey = 'D';
                    break;
                case ConsoleKey.UpArrow:
                    numKey = 'U';
                    break;
                case ConsoleKey.P:
                    ConsoleKey pause = Console.ReadKey().Key;
                    numKey = 'P';
                    break;
                default:
                    break;
            }

            return numKey;
        }

    }
    class ForKeyASDC : IMove
    {
        public char Move(Point center)
        {
            char numKey = ' ';
            ConsoleKey step = Console.ReadKey().Key;

            switch (step)
            {
                case ConsoleKey.A:
                    center.X--;
                    numKey = 'L';
                    break;
                case ConsoleKey.D:
                    center.X++;
                    numKey = 'R';
                    break;
                case ConsoleKey.C:
                    numKey = 'D';
                    break;
                case ConsoleKey.S:
                    numKey = 'U';
                    break;
                case ConsoleKey.P:
                    ConsoleKey pause = Console.ReadKey().Key;
                    numKey = 'P';
                    break;
                default:
                    break;

            }

            return numKey;
        }

    }

    class Tetris
    {
        public int[,] field;
        public int leftWall;
        public int rightWall;
        public int floor;
        public int roof;
        public Point center;

        int amtFigure = 0;
        public int level = 1;
        public double time = 2.7;
        public int record;
        public int score;

        public Tetris(Point center,Config config)
        {
            this.center = center;
            roof = center.y - 1;
            floor = center.y + 20;
            leftWall = center.x - 5;
            rightWall = center.x + 6;
            record = config.ReadRecord();
            field = new int[10, 20];
            for (int y = 0; y < 20; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    field[x, y] = 0;

                }
            }

        }
        public Tetris()
        {

        }

        public void DownFly(Point point)
        {
            point.Y = point.Y + 1;
        }
        public bool TouchFieldOrFloor(List<Point> figure)
        {
            foreach (Point point in figure)
            {
                for (int y = 0; y < 20; y++)
                {
                    for (int x = 0; x < 10; x++)
                    {
                        if (field[x, y] == 1)
                        {
                            if (point.X - 1 == x && point.Y - center.Y == y)
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (point.y >= floor || point.x >= rightWall || point.x <= leftWall/* || point.y <= roof*/)
                            {
                                return false;
                            }
                        }

                    }
                }

            }
            return true;
        }
        public bool LimitedRoof(List<Point> figure)
        {
            foreach (Point point in figure)
            {
                if (point.y <= roof)
                {
                    return false;
                }
            }
            return true;
        }
        public void FillingField(List<Point> figure)
        {
            foreach (Point point in figure)
            {
                field[point.x - 1, point.y - center.y] = 1;

            }

        }
        public void DeleteLinesScore()
        {
            int[,] tmpField = new int[10, 20];
            int count = 0;
            int str = 0;
            for (int y = 19, tmpY = 19; y > -1; y--, tmpY--)
            {
                count = 0;
                for (int x = 0; x < 10; x++)
                {
                    if (field[x, y] == 1)
                        count++;
                }
                if (count == 10)
                {
                    str++;
                    tmpY++;
                }
                else
                {
                    for (int x = 0; x < 10; x++)
                    {
                        tmpField[x, tmpY] = field[x, y];
                    }

                }
            }
            if (str == 1) score = score + 100;

            if (str == 2) score = score + 300;

            if (str == 3) score = score + 700;

            if (str == 4) score = score + 1500;

            field = tmpField;

            amtFigure++;
            if (amtFigure > 5)
            {
                NewLevel();
                amtFigure = 0;
            }

        }
        public void NewLevel()
        {
            if (level < 10)
            {
                level++;
                time = time - 0.3;
            }

        }

    }
    class Ingineer
    {
        public IMove move;
        Tetris tetris;
        Graphics graphics;
        Config config;
        IFigure ifigure = null;
        IFigure inext = null;

        FigurePoints nextFigure = null;
        FigurePoints figure = new FigurePoints();
        List<Point> tmpFigurePoints = new List<Point>();

        Point gameCenter = new Point();

        Stopwatch stopWatch = new Stopwatch();
        int tmpX, tmpY;
        int gameOver = 0;
        int flag = 0;
        public int numberVar;

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
            graphics = new Graphics(tetris.center,config);
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
        public List<Point> StartFigure(FigurePoints figure)
        {
            Random round = new Random();
            int num = round.Next(1, 10);
            while (num != 0)
            {
                figure = figure.next;
                num--;
            }

            numberVar = figure.number;
            return figure.points;
        }
        public List<Point> SearchFigure(FigurePoints figure)
        {
            while (true)
            {
                if (figure.Number == numberVar)
                    break;
                figure = figure.next;
            }

            return figure.points;
        }
        public void KeepExisting()
        {
            tmpX = gameCenter.x;
            tmpY = gameCenter.y;
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
                    // tetris.NumberVar = figure.number;
                    figure = figure.next;
                    Console.SetCursorPosition(20, 20);
                    Console.Write(figure.number);
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
                        numberVar = figure.number;

                    graphics.WipeOffFigure(tmpFigurePoints);
                    graphics.PrintFigure(figure.points);
                }
            }
            else
            {
                while (tetris.TouchFieldOrFloor(figure.points))
                {
                    KeepExisting();
                    gameCenter.Y = gameCenter.y + 1;

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

            gameCenter.X = tetris.center.x;
            gameCenter.Y = tetris.center.y;

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
                        Point center = new Point(5, 1);
                        tetris = new Tetris(center,config);
                        graphics = new Graphics(center,config);
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
    class Graphics : Tetris
    {
        public Point menuCenter;
        public Graphics(Point center,Config config) : base(center,config)
        {
            menuCenter = new Point(center.x + 13, center.y + 3);

        }
        public void PrintFigure(List<Point> figura)
        {
            Console.CursorVisible = false;
            foreach (Point i in figura)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(i.x, i.y);
                Console.Write("*");
                Console.SetCursorPosition(i.x, i.y);
            }

        }
        public void SettingsOutput(string str, int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(x, y);
            Console.Write(str);
            Console.SetCursorPosition(x + 1, y + 2);
            Console.ForegroundColor = ConsoleColor.White;

        }
        public void PrintStaticElement(List<Point> figure, int score, int level, int record)
        {
            Console.SetWindowSize(30, 35);

            for (int y = 0; y < 20; y++)
            {
                Console.SetCursorPosition(leftWall, y + center.y);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("|");
                Console.SetCursorPosition(rightWall, y + center.y);
                Console.Write("|");
                Console.Write("\n");
            }
            for (int x = leftWall; x < rightWall + 1; x++)
            {
                Console.SetCursorPosition(x, roof);
                Console.Write("-");
                Console.SetCursorPosition(x, floor);
                Console.Write("-");
            }
            SettingsOutput("next figure", rightWall + 5, roof + 1);
            PrintFigure(figure);
            SettingsOutput("score", rightWall + 5, roof + 7);
            Console.Write(score);
            SettingsOutput("level", rightWall + 5, roof + 12);
            Console.Write(level);
            SettingsOutput("record", rightWall + 5, roof + 17);
            Console.Write(record);



        }
        public void PrintField(int[,] field)
        {
            //  Console.SetCursorPosition(2, 2);
            for (int y = 0; y < 20; y++)
            {
                Console.SetCursorPosition(leftWall + 1, y + roof + 1);
                for (int x = 0; x < 10; x++)
                {
                    if (field[x, y] == 0)
                        Console.Write(" ");

                    else
                        Console.Write("*");
                }
                Console.Write("\n");
            }

        }
        public void WipeOffFigure(List<Point> figura)
        {
            foreach (Point i in figura)
            {
                Console.SetCursorPosition(i.x, i.y);
                Console.Write(" ");
                Console.SetCursorPosition(i.x, i.y);
            }

        }
        public void GameOver(int record, int score)
        {
            Console.SetCursorPosition(5, 10);
            Console.ForegroundColor = ConsoleColor.Red;
            if (score > record)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Сongratulations!\n");

                Console.WriteLine("you have set a new record " + score + "\n");
            }
            else Console.WriteLine("Game Over\n");

            Console.WriteLine("if you want start a new game\n             click ENTER\n");
            Console.WriteLine("if you want close the game\n               click ESCAPE");

        }
    }
    class Config
    {
        public IMove move;
        public int choice;
        public Config()
        {
            choice = 0;
        }
        public IMove SelectKeys()
        {
            Console.SetCursorPosition(0, 10);
            Console.WriteLine("Для управления стрелочками нажмите S ");
            Console.WriteLine("Для управления клавишами ASDC нажмите F");
            bool select = true;
            while (select)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.S:
                        move = new ForKeyLeftUp();
                        choice = 1;
                        select = false;
                        break;
                    case ConsoleKey.D:
                        move = new ForKeyASDC();
                        choice = 2;
                        select = false;
                        break;
                    default:

                        break;
                }
            }
            Console.Clear();

            return move;
        }
        public void SaveRecord(int record, int score)
        {

            DirectoryInfo dir = new DirectoryInfo(".");
            string path = dir + "Record.txt";
            if (score > record)
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.Write($"{score} ");
                }
            }
            else
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.Write($"{record} ");
                }
            }

        }
        public int ReadRecord()
        {
            DirectoryInfo dir = new DirectoryInfo(".");
            string path = dir + "Record.txt";
            int record = 0;
            using (StreamReader sr = File.OpenText(path))
            {
                record = int.Parse(sr.ReadToEnd());
                return record;
            }

        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Point center = new Point(5, 1);
            Config config = new Config();
            Tetris tetris = new Tetris(center,config);
            Graphics graphics = new Graphics(center,config);
          
            Ingineer game = new Ingineer(config, tetris);

            game.StartGame();
        }
    }
}
