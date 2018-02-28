using System;

namespace _032.TicTacToe
{
    class Program
    {
        static char[,] field;
        static int player = 1, cursorInFieldRow, cursorInFieldCol;
        static char emptySpace = '■';

        static void Main(string[] args)
        {
            Console.CursorSize = 100;

            bool win = false;
            bool cellFill = false;

            InitializeField();

            int count = field.GetLength(0) * field.GetLength(1);

            do
            {
                while (!cellFill)
                {
                    cursorInFieldRow = Console.CursorTop + 1;
                    cursorInFieldCol = Console.CursorLeft + 1;
                    Input(ref cellFill);
                }
                AnalizeLastCell(ref win);
                player = -player; // PlayerSymbol() változtatja
                count--; // lépések száma döntetlenig
                cellFill = false;
            } while (count > 0 && !win);

            Console.CursorTop = field.GetLength(1) - 2;
            Console.CursorLeft = 0;

            if (win) Console.Write("Player {0} won!", PlayerSymbol(-player));
            else Console.WriteLine("Draw!");

            Console.ReadKey();
        }

        static char PlayerSymbol(int pl)
        { // visszaadja a megfelelő szimbolumot, körönként változik
            if (pl == 1) return 'X'; else return 'O';
        }

        static void Input(ref bool cellFill)
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.UpArrow:
                    if (Console.CursorTop > 0) Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                    break;
                case ConsoleKey.LeftArrow:
                    if (Console.CursorLeft > 0) Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    break;
                case ConsoleKey.DownArrow:
                    if (Console.CursorTop < field.GetLength(0) - 1) Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 1);
                    break;
                case ConsoleKey.RightArrow:
                    if (Console.CursorLeft < field.GetLength(1) - 1) Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
                    break;
                case ConsoleKey.Spacebar:
                    if (field[cursorInFieldRow, cursorInFieldCol] == emptySpace)
                    {
                        field[cursorInFieldRow, cursorInFieldCol] = PlayerSymbol(player);
                        Console.Write("{0}\b", PlayerSymbol(player));
                        cellFill = true;
                    }
                    break;
                default:
                    break;
            }
        }

        static void AnalizeLastCell(ref bool win)
        { // megvizsgálja, hogy a lerakott cell-el lett-e amőbája a playernek.

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if ((i != 0 || j != 0) && field[cursorInFieldRow - i, cursorInFieldCol - j] == PlayerSymbol(player) &&
                        (field[cursorInFieldRow + i, cursorInFieldCol + j] == PlayerSymbol(player) ||
                        field[cursorInFieldRow - i * 2, cursorInFieldCol - j * 2] == PlayerSymbol(player)))
                    {
                        win = true;
                    }
                }
            }
        }

        static void InitializeField()
        { // felrajzolja az amőba területét, feltölti a mátrixot
            field = new char[int.Parse(Console.ReadLine()) + 2, int.Parse(Console.ReadLine()) + 2];
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = emptySpace;
                }
            }

            Console.Clear();
            for (int i = 1; i < field.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < field.GetLength(1) - 1; j++)
                {
                    Console.Write("{0}", field[i, j]);
                }
                Console.WriteLine();
            }

            Console.CursorLeft = 0;
            Console.CursorTop = 0;
        }
    }
}

