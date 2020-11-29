using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.IO;
using ClassLibraryFigures;



namespace Tetris
{
 
class Program
{
    static void Main(string[] args)
    {
        MyPoint center = new MyPoint(5, 1);
        Config config = new Config();
        Tetris tetris = new Tetris(center, config);
        MyGraphics graphics = new MyGraphics(center, config);

        Ingineer game = new Ingineer(config, tetris);

        game.StartGame();
    }
}
}
