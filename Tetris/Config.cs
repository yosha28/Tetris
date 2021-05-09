using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ClassLibraryFigures;

namespace Tetris
{
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
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.Write($"{record} ");
                }
            }
            else
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    record = int.Parse(sr.ReadToEnd());
                   
                }

            }
            return record;
        }

    }
}
