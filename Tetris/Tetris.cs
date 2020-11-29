using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryFigures;

namespace Tetris
{
    class Tetris
    {
        public int[,] field;
        public int leftWall;
        public int rightWall;
        public int floor;
        public int roof;
        public MyPoint center;

        int amtFigure = 0;
        public int level = 1;
        public double time = 2.7;
        public int record;
        public int score;

        public Tetris(MyPoint center, Config config)
        {
            this.center = center;
            roof = center.Y - 1;
            floor = center.Y + 20;
            leftWall = center.X - 5;
            rightWall = center.X + 6;
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

        public void DownFly(MyPoint point)
        {
            point.Y = point.Y + 1;
        }

        public bool TouchFieldOrFloor(List<MyPoint> figure)
        {
            foreach (MyPoint point in figure)
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
                            if (point.Y >= floor || point.X >= rightWall || point.X <= leftWall/* || point.Y <= roof*/)
                            {
                                return false;
                            }
                        }

                    }
                }

            }
            return true;
        }
        public bool LimitedRoof(List<MyPoint> figure)
        {
            foreach (MyPoint point in figure)
            {
                if (point.Y <= roof)
                {
                    return false;
                }
            }
            return true;
        }
        public void FillingField(List<MyPoint> figure)
        {
            foreach (MyPoint point in figure)
            {
                field[point.X - 1, point.Y - center.Y] = 1;

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
}
