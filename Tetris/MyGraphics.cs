using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryFigures;

namespace Tetris
{
    class MyGraphics:Tetris
    {     
            public MyPoint menuCenter;
            public MyGraphics(MyPoint center, Config config) : base(center, config)
            {
                menuCenter = new MyPoint(center.X + 13, center.Y + 3);

            }
            public void PrintFigure(List<MyPoint> figura)
            {
                Console.CursorVisible = false;
                foreach (MyPoint i in figura)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(i.X, i.Y);
                    Console.Write("*");
                    Console.SetCursorPosition(i.X, i.Y);
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
            public void PrintStaticElement(List<MyPoint> figure, int score, int level, int record)
            {
                Console.SetWindowSize(30, 35);

                for (int y = 0; y < 20; y++)
                {
                    Console.SetCursorPosition(leftWall, y + center.Y);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("|");
                    Console.SetCursorPosition(rightWall, y + center.Y);
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
            public void WipeOffFigure(List<MyPoint> figura)
            {
                foreach (MyPoint i in figura)
                {
                    Console.SetCursorPosition(i.X, i.Y);
                    Console.Write(" ");
                    Console.SetCursorPosition(i.X, i.Y);
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


    }

