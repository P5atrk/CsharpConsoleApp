using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _031.TheGameOfLife
{
    class Program
    {
        static int rows = 20;
        static int cols = 50;
        static int[,] arr = new int[rows, cols];
        static int[,] tempArr;
        static int generation = 0;
        static int cursorTop;
        static int cursorLeft;
        static bool colorful = false;
        static int[,] sums = new int[rows, cols];

        static void Main(string[] args)
        {

            Console.CursorSize = 100;
            Console.WindowWidth = cols;
            Console.WindowHeight = rows + 1;

            bool done = false;
            bool write = true;

            Menu();

            do
            {
                CellNeighbourCheck(out sums);
                WriteAllCells();
                do
                {
                    ConsoleKey consoleKey = Console.ReadKey(true).Key;
                    if (consoleKey.ToString().Length != 1)
                    {
                        switch (consoleKey)
                        {
                            case ConsoleKey.UpArrow:
                                if (Console.CursorTop > 0) Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                                break;
                            case ConsoleKey.LeftArrow:
                                if (Console.CursorLeft > 0) Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                                break;
                            case ConsoleKey.DownArrow:
                                if (Console.CursorTop < Console.WindowHeight - 1) Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 1);
                                break;
                            case ConsoleKey.RightArrow:
                                if (Console.CursorLeft < Console.WindowWidth - 1) Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
                                break;
                            case ConsoleKey.Spacebar:
                                done = true;
                                break;
                            case ConsoleKey.Escape:
                                Menu();
                                CellNeighbourCheck(out sums);
                                WriteAllCells();
                                break;
                        }
                    }
                    else
                    {
                        switch (consoleKey)
                        {
                            case ConsoleKey.A:
                                if (Console.CursorTop < Console.WindowHeight - 2 && Console.CursorTop > 0 &&
                                    Console.CursorLeft < Console.WindowWidth - 1 && Console.CursorLeft > 0)
                                {
                                    arr[Console.CursorTop, Console.CursorLeft] = 1;
                                }
                                break;
                            case ConsoleKey.D:
                                if (Console.CursorTop < Console.WindowHeight - 2 && Console.CursorTop > 0 &&
                                    Console.CursorLeft < Console.WindowWidth - 1 && Console.CursorLeft > 0)
                                {
                                    arr[Console.CursorTop, Console.CursorLeft] = 0;
                                }
                                break;
                            case ConsoleKey.C:
                                Array.Clear(arr, 0, arr.Length);
                                generation = 0;
                                break;
                            case ConsoleKey.R:
                                Randomize();
                                generation = 0;
                                break;
                            case ConsoleKey.T:
                                colorful = !colorful;
                                break;
                            default:
                                write = false;
                                break;
                        }
                        if (write)
                        {
                            CellNeighbourCheck(out sums);
                            WriteAllCells();
                        }
                        else
                        {
                            write = true;
                        }
                    }
                } while (!done);

                RuleApply();
                generation++;
                done = false;

            } while (true);
        }

        static void Menu()
        {
            Console.Clear();
            Console.WindowWidth = cols;
            Console.WindowHeight = rows + 1;

            Console.WriteLine("The Game of Life by P5atrk\nPress Any key to start.\n\nKeyboard layout:\nA - add cell\nD - delete cell\nT - toggle between colormodes\nR - randomize board\nC - clear board\nEsc - menu");
            Console.ReadKey();
            Console.CursorLeft = 12;
            Console.CursorTop = 0;
        }

        static void CellNeighbourCheck(out int[,] sums)
        { // megnézni azt, hogy minden egyes cellának hány szomszédja van, ezt a sum[,]-ban tárolja el
            sums = new int[rows, cols];
            for (int i = 1; i < rows - 1; i++)
            {
                for (int j = 1; j < cols - 1; j++)
                {
                    for (int k = -1; k < 2; k++)
                    {
                        for (int l = -1; l < 2; l++)
                        {
                            sums[i, j] += arr[(i + k + rows) % rows, (j + l + cols) % cols];
                        }
                    }
                    sums[i, j] -= arr[i, j];
                }
            }
        }

        static void WriteAllCells()
        { // kiiratja a cellákat, megörzi a cursor helyét
            cursorLeft = Console.CursorLeft;
            cursorTop = Console.CursorTop;

            Console.Clear();
            Console.Write("generation: {0}", generation);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (arr[i, j] == 0)
                    {
                        if (colorful)
                        {
                            if (sums[i, j] == 3)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                    }
                    else
                    {
                        if (colorful)
                        {
                            if (sums[i, j] < 2 || sums[i, j] > 3)
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Yellow;
                            }
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                        }
                    }
                    Console.Write(" ");
                }
                if (i < rows - 1) Console.WriteLine();
            }
            Console.CursorLeft = cursorLeft;
            Console.CursorTop = cursorTop;
        }

        static void RuleApply()
        { // megnézi, azt hogy túléli-e a cell vagy nem
            tempArr = arr;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {

                    if (tempArr[i, j] == 1)
                    {
                        if (sums[i, j] < 2 || sums[i, j] > 3)
                        {
                            arr[i, j] = 0;
                        }
                        else
                        {
                            arr[i, j] = 1;
                        }
                    }
                    else
                    {
                        if (sums[i, j] == 3)
                        {
                            arr[i, j] = 1;
                        }
                        else
                        {
                            arr[i, j] = 0;
                        }
                    }
                    sums[i, j] = 0;
                }
            }
        }

        static void Randomize()
        { // véletlenszerű cellakiosztás
            Random random = new Random();
            for (int i = 1; i < rows - 1; i++)
            {
                for (int j = 1; j < cols - 1; j++)
                {
                    arr[i, j] = random.Next(2);
                }
            }
        }
    }
}
