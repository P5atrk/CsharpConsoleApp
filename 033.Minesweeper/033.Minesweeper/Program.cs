using System;

namespace _033.Minesweeper
{
    class Tile
    {

        static int notMines = 0;
        static public int NotMines
        { // számolja mennyi nem bomba mező van
            get { return notMines; }
            set { notMines = value; }
        }

        static int revealCount = 0; // számolja mennyi mező van felfedve
        static public int RevealCount
        { // visszaadja a felfedett mezők számát
            get { return revealCount; }
        }

        bool revealed = false;
        public bool Revealed
        { // felfedi a mezőt
            get { return revealed; }
            set
            {
                if (revealed == false)
                {
                    revealed = value;
                    revealCount++;
                }
            }
        }

        int mines = 0;
        public int Mines
        { // bombává "teszi" azt adott mezőt
            get { return mines; }
            set
            {
                mines = value;
            }
        }
    }

    class Program
    {

        static int mines;
        static int rows;
        static int cols;
        static Tile[,] field;

        static void Main(string[] args)
        {
            Console.WriteLine("Difficulty: 'easy' 'normal' 'hard' 'harder'");
            Console.Write("Rows: ");
            rows = int.Parse(Console.ReadLine());
            Console.Write("Cols: ");
            cols = int.Parse(Console.ReadLine());
            Console.Write("Mines/Difficulty: ");
            MineNumb(ref mines);

            Random random = new Random();

            field = new Tile[rows, cols];

            for (int i = 0; i < rows; i++)
            { // mezők létrehozása
                for (int j = 0; j < cols; j++)
                {
                    field[i, j] = new Tile();
                    Tile.NotMines++; // mezők száma, később kivonva a bombák számával
                }
            }

            for (int i = 0; i < mines; i++)
            { // bombák "lerakása"
                int newRow = random.Next(field.GetLength(0));
                int newCol = random.Next(field.GetLength(1));

                if (field[newRow, newCol].Mines != -1)
                { // megnézi, hogy azon a random helyen a táblán már van-e bomba
                    field[newRow, newCol].Mines = -1;
                    Tile.NotMines--; // kivonja azt a mennyiséget, ahány bomba van
                }
                else
                {
                    i--;
                }
            }

            for (int i = 0; i < field.GetLength(0); i++)
            { // megadja azon mezők értékét, amik nem bombák (a körzetében lévő bombaszám)
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i,j].Mines != -1)
                    {
                        for (int k = -1; k <= 1; k++)
                        {
                            for (int l = -1; l <= 1; l++)
                            {
                                if (i + k != -1 && i + k != field.GetLength(0) &&
                                    j + l != -1 && j + l != field.GetLength(1))
                                {
                                    if (field[i + k, j + l].Mines == -1)
                                    {
                                        field[i, j].Mines++;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            DrawField();

            Console.CursorSize = 100; // kurzor előkészítése, a mezőn való mozgásra #graphics
            Console.CursorLeft = 0;
            Console.CursorTop = 0; // ez és az ez előtti teendők, mind a mező előkészítése

            Input();
        }

        static void MineNumb(ref int mines)
        { // mennyi bomba legyen a mezőn
            string x = Console.ReadLine();
            bool y = int.TryParse(x, out mines);
            if (y)
            {
                if (mines > rows * cols)
                {
                    mines = rows * cols;
                }
            }
            else
            {
                if (x == "easy") mines = rows * cols / 7;
                if (x == "" || x == "normal") mines = rows * cols / 5;
                if (x == "hard") mines = rows * cols / 3;
                if (x == "harder") mines = rows * cols / 2;
            }

        }

        static void Space(int x, int y)
        { // ha a mező .Mines = 0, akkor lefut, amivel felfedi a mező körzetét (8 db mezőt fed fel)
            for (int i = -1; i <= 1; i++)
            { // ha az a mező (amit felfedett) .Mines-ja is 0, akkor annak is felfedi a körzetét
                for (int j = -1; j <= 1; j++)
                {
                    if (x + i != -1 && x + i != field.GetLength(0) &&
                        y + j != -1 && y + j != field.GetLength(1))
                    {
                        if (field[x + i, y + j].Mines != 0 && field[x + i, y + j].Revealed == false)
                            field[x + i, y + j].Revealed = true;
                        if (field[x + i, y + j].Mines == 0 && field[x + i, y + j].Revealed == false)
                        {
                            field[x + i, y + j].Revealed = true;
                            for (int k = -1; k <= 1; k++)
                            {
                                for (int l = -1; l <= 1; l++)
                                {
                                    if (x + i + k != -1 && x + i + k != field.GetLength(0) &&
                                        y + j + l != -1 && y + j + l != field.GetLength(1))
                                    {
                                        if (field[x + i + k, y + j + l].Mines != -1 &&
                                            field[x + i + k, y + j + l].Revealed == false &&
                                            field[x + i + k, y + j + l].Mines != 0)
                                        {
                                            field[x + i + k, y + j + l].Revealed = true;
                                        }
                                    }
                                }
                            }
                            Space(x + i, y + j);
                        }
                    }
                }
            }
        }

        static void Input()
        { // navigálás a táblán, space lenyomásával felfedés
            do
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow: // mozgás a táblán
                        if (Console.CursorTop > 0)
                            Console.CursorTop -= 1;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (Console.CursorLeft > 0)
                            Console.CursorLeft -= 1;
                        break;
                    case ConsoleKey.DownArrow:
                        if (Console.CursorTop < field.GetLength(0) - 1)
                            Console.CursorTop += 1;
                        break;
                    case ConsoleKey.RightArrow:
                        if (Console.CursorLeft < field.GetLength(1) - 1)
                            Console.CursorLeft += 1;
                        break;

                    case ConsoleKey.Spacebar:
                        int cursorTop = Console.CursorTop; // megőrzi a cursor helyét
                        int cursorLeft = Console.CursorLeft; // -

                        field[Console.CursorTop, Console.CursorLeft].Revealed = true; // felfedi, azt amire rákattintott

                        if (field[Console.CursorTop, Console.CursorLeft].Mines == 0)
                            Space(Console.CursorTop, Console.CursorLeft);

                        DrawField(); // mitán kész vannak a számítások arra nézve, hogy melyik lesz felfedve, talált-e bombát.

                        Console.CursorTop = cursorTop; // visszahelyezi a kurzort a helyére, ahol volt, mivel újra rajzolodott a tábla
                        Console.CursorLeft = cursorLeft; // -

                        if (field[Console.CursorTop, Console.CursorLeft].Mines == -1)
                        { // megvizsgálja, hogy a felfedett mező ey bomba volt-e, ha igen vége a játéknak.
                            Lose();
                        }

                        if (Tile.RevealCount == Tile.NotMines)
                        { // megvizsgálja, hogy a nem bomba típusú mezők száma megegyezik-e a már felfedett mezőkkel
                            Win();
                        }
                        break;
                    default:
                        break;
                }
            } while (true);
        }

        static void Lose()
        {
            Console.CursorLeft = 0;
            Console.CursorTop = rows;
            RevealAll();
            DrawField();
            Console.Write("Game over!");
            Console.ReadKey(true);
            Environment.Exit(0);
        }

        static void Win()
        {
            Console.CursorLeft = 0;
            Console.CursorTop = rows;
            RevealAll();
            DrawField();
            Console.WriteLine("You win!");
            Console.ReadKey(true);
            Environment.Exit(0);
        }

        static void RevealAll()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    field[i, j].Revealed = true;
                }
                Console.WriteLine();
            }
        }

        static void DrawField()
        { // "lerajzolja" a táblát
            Console.Clear();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (field[i, j].Revealed == true)
                    {
                        if (field[i, j].Mines != -1) Console.Write(field[i, j].Mines);
                        else Console.Write("x");
                    }
                    else Console.Write("■");
                }
                Console.WriteLine();
            }
        }
    }
}
