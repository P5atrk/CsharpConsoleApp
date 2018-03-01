using System;

namespace _035.MátrixTerületiFeltöltése
{
    class Program
    {
        static int[,] field = new int[5, 5];

        static void Main(string[] args)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            { // értékadás a mezőnek
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = 0;
                }
            }
            do
            {
                DrawField();
                AreaInp();
            } while (true);
        }

        static void AreaInp()
        {
            int val = int.Parse(Console.ReadLine()); // Az érték amivel feltöltöm a területet
            int x = int.Parse(Console.ReadLine()); // A terület első mezőjének helye
            int y = int.Parse(Console.ReadLine()); // -
            int xL = int.Parse(Console.ReadLine()); // A terület hossza
            int yL = int.Parse(Console.ReadLine()); // -
            if (x + xL > field.GetLength(0) || y + yL > field.GetLength(1))
            { // ha túl megy a terület a mező határain kivül lenne
                return;
            }
            for (int i = x; i < xL + x; i++)
            { // a terület mezőinek értékadása
                for (int j = y; j < yL + y; j++)
                {
                    field[i, j] = val;
                }
            }
        }

        static void DrawField()
        { // "lerajzolja" a mezőt
            Console.Clear();
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    Console.Write(field[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
