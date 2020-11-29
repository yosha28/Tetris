using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryFigures
{
    public interface IFigure
    {
         FigurePoints CreateList(MyPoint point);
    }
    public interface IMove
    {
         char Move(MyPoint point);
    }

    public class MyPoint

    {
        int x;
        int y;
        public MyPoint() { }

        public MyPoint(int x, int y)
        {
            this.x = x;
            this.y = y;

        }
        public int X { get => x; set => x = value; }//вставить в сет ограничения по полю
        public int Y { get => y; set => y = value; }

    }

    public class FigurePoints
    {
        public List<MyPoint> points;
        public FigurePoints next;
        int number;

        public FigurePoints()
        {
            points = new List<MyPoint>();

        }
        public int Number { get => number; set => number = value; }

    }
    public struct FigureO : IFigure
    // class FigureO : IFigure
    {
        public FigurePoints CreateList(MyPoint center)
        {
            FigurePoints figure1 = new FigurePoints();
            figure1.points.Add(new MyPoint(center.X, center.Y));
            figure1.points.Add(new MyPoint(center.X - 1, center.Y));
            figure1.points.Add(new MyPoint(center.X, center.Y + 1));
            figure1.points.Add(new MyPoint(center.X - 1, center.Y + 1));

            figure1.next = figure1;
            figure1.Number = 1;


            return figure1;
        }

    }
    public struct FigureJ : IFigure
    {

        public FigurePoints CreateList(MyPoint center)
        {
            FigurePoints figure1 = new FigurePoints();
            figure1.points.Add(new MyPoint(center.X, center.Y));
            figure1.points.Add(new MyPoint(center.X, center.Y - 1));
            figure1.points.Add(new MyPoint(center.X, center.Y + 1));
            figure1.points.Add(new MyPoint(center.X - 1, center.Y + 1));

            figure1.Number = 1;

            FigurePoints figure2 = new FigurePoints();
            figure2.points.Add(new MyPoint(center.X, center.Y));
            figure2.points.Add(new MyPoint(center.X - 1, center.Y));
            figure2.points.Add(new MyPoint(center.X + 1, center.Y));
            figure2.points.Add(new MyPoint(center.X - 1, center.Y - 1));

            figure2.Number = 2;

            FigurePoints figure3 = new FigurePoints();
            figure3.points.Add(new MyPoint(center.X, center.Y));
            figure3.points.Add(new MyPoint(center.X, center.Y - 1));
            figure3.points.Add(new MyPoint(center.X, center.Y + 1));
            figure3.points.Add(new MyPoint(center.X + 1, center.Y - 1));

            figure3.Number = 3;

            FigurePoints figure4 = new FigurePoints();
            figure4.points.Add(new MyPoint(center.X, center.Y));
            figure4.points.Add(new MyPoint(center.X - 1, center.Y));
            figure4.points.Add(new MyPoint(center.X + 1, center.Y));
            figure4.points.Add(new MyPoint(center.X + 1, center.Y + 1));

            figure4.Number = 4;

            figure1.next = figure2;
            figure2.next = figure3;
            figure3.next = figure4;
            figure4.next = figure1;


            return figure1;

        }

    }
    public struct FigureT : IFigure
    {
        public FigurePoints CreateList(MyPoint center)
        {
            FigurePoints figure1 = new FigurePoints();
            figure1.points.Add(new MyPoint(center.X, center.Y));
            figure1.points.Add(new MyPoint(center.X + 1, center.Y));
            figure1.points.Add(new MyPoint(center.X, center.Y + 1));
            figure1.points.Add(new MyPoint(center.X - 1, center.Y));

            figure1.Number = 1;

            FigurePoints figure2 = new FigurePoints();
            figure2.points.Add(new MyPoint(center.X, center.Y));
            figure2.points.Add(new MyPoint(center.X, center.Y - 1));
            figure2.points.Add(new MyPoint(center.X, center.Y + 1));
            figure2.points.Add(new MyPoint(center.X - 1, center.Y));

            figure2.Number = 2;

            FigurePoints figure3 = new FigurePoints();
            figure3.points.Add(new MyPoint(center.X, center.Y));
            figure3.points.Add(new MyPoint(center.X + 1, center.Y));
            figure3.points.Add(new MyPoint(center.X - 1, center.Y));
            figure3.points.Add(new MyPoint(center.X, center.Y - 1));

            figure3.Number = 3;

            FigurePoints figure4 = new FigurePoints();
            figure4.points.Add(new MyPoint(center.X, center.Y));
            figure4.points.Add(new MyPoint(center.X, center.Y - 1));
            figure4.points.Add(new MyPoint(center.X, center.Y + 1));
            figure4.points.Add(new MyPoint(center.X + 1, center.Y));

            figure4.Number = 4;

            figure1.next = figure2;
            figure2.next = figure3;
            figure3.next = figure4;
            figure4.next = figure1;


            return figure1;
        }
    }
    public struct FigureI : IFigure
    {
        public FigurePoints CreateList(MyPoint center)
        {
            FigurePoints figure1 = new FigurePoints();
            figure1.points.Add(new MyPoint(center.X, center.Y));
            figure1.points.Add(new MyPoint(center.X, center.Y - 1));
            figure1.points.Add(new MyPoint(center.X, center.Y - 2));
            figure1.points.Add(new MyPoint(center.X, center.Y + 1));

            figure1.Number = 1;

            FigurePoints figure2 = new FigurePoints();
            figure2.points.Add(new MyPoint(center.X, center.Y));
            figure2.points.Add(new MyPoint(center.X + 1, center.Y));
            figure2.points.Add(new MyPoint(center.X - 1, center.Y));
            figure2.points.Add(new MyPoint(center.X - 2, center.Y));

            figure2.Number = 2;

            figure1.next = figure2;
            figure2.next = figure1;

            return figure1;
        }
    }
    public struct FigureZ : IFigure
    {
        public FigurePoints CreateList(MyPoint center)
        {
            FigurePoints figure1 = new FigurePoints();
            figure1.points.Add(new MyPoint(center.X, center.Y));
            figure1.points.Add(new MyPoint(center.X - 1, center.Y));
            figure1.points.Add(new MyPoint(center.X, center.Y + 1));
            figure1.points.Add(new MyPoint(center.X + 1, center.Y + 1));

            figure1.Number = 1;

            FigurePoints figure2 = new FigurePoints();
            figure2.points.Add(new MyPoint(center.X, center.Y));
            figure2.points.Add(new MyPoint(center.X, center.Y + 1));
            figure2.points.Add(new MyPoint(center.X + 1, center.Y));
            figure2.points.Add(new MyPoint(center.X + 1, center.Y - 1));

            figure2.Number = 2;

            figure1.next = figure2;
            figure2.next = figure1;

            return figure1;
        }
    }
    public struct FigureS : IFigure
    {
        public FigurePoints CreateList(MyPoint center)
        {
            FigurePoints figure1 = new FigurePoints();
            figure1.points.Add(new MyPoint(center.X, center.Y));
            figure1.points.Add(new MyPoint(center.X + 1, center.Y));
            figure1.points.Add(new MyPoint(center.X, center.Y + 1));
            figure1.points.Add(new MyPoint(center.X - 1, center.Y + 1));

            figure1.Number = 1;

            FigurePoints figure2 = new FigurePoints();
            figure2.points.Add(new MyPoint(center.X, center.Y));
            figure2.points.Add(new MyPoint(center.X, center.Y - 1));
            figure2.points.Add(new MyPoint(center.X + 1, center.Y));
            figure2.points.Add(new MyPoint(center.X + 1, center.Y + 1));

            figure2.Number = 2;

            figure1.next = figure2;
            figure2.next = figure1;

            return figure1;

        }
    }
    public struct FigureL : IFigure
    {
        public FigurePoints CreateList(MyPoint center)
        {
            FigurePoints figure1 = new FigurePoints();
            figure1.points.Add(new MyPoint(center.X, center.Y));
            figure1.points.Add(new MyPoint(center.X, center.Y - 1));
            figure1.points.Add(new MyPoint(center.X, center.Y + 1));
            figure1.points.Add(new MyPoint(center.X + 1, center.Y + 1));

            figure1.Number = 1;

            FigurePoints figure2 = new FigurePoints();
            figure2.points.Add(new MyPoint(center.X, center.Y));
            figure2.points.Add(new MyPoint(center.X - 1, center.Y));
            figure2.points.Add(new MyPoint(center.X + 1, center.Y));
            figure2.points.Add(new MyPoint(center.X - 1, center.Y + 1));

            figure2.Number = 2;

            FigurePoints figure3 = new FigurePoints();
            figure3.points.Add(new MyPoint(center.X, center.Y));
            figure3.points.Add(new MyPoint(center.X, center.Y - 1));
            figure3.points.Add(new MyPoint(center.X, center.Y + 1));
            figure3.points.Add(new MyPoint(center.X - 1, center.Y - 1));

            figure3.Number = 3;

            FigurePoints figure4 = new FigurePoints();
            figure4.points.Add(new MyPoint(center.X, center.Y));
            figure4.points.Add(new MyPoint(center.X - 1, center.Y));
            figure4.points.Add(new MyPoint(center.X + 1, center.Y));
            figure4.points.Add(new MyPoint(center.X + 1, center.Y - 1));

            figure4.Number = 4;

            figure1.next = figure2;
            figure2.next = figure3;
            figure3.next = figure4;
            figure4.next = figure1;


            return figure1;
        }
    }

    public class ForKeyLeftUp : IMove
    {
        public char Move(MyPoint center)
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
    public class ForKeyASDC : IMove
    {
        public char Move(MyPoint center)
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
}
