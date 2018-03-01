using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 0   kék
 * 100 sárga
 * 200 zöld
 * 300 kék
 * 400 piros
 */

namespace _037.SzigetGenerálása
{
    class Program
    {
        class Tile
        {
            bool filled = false;

            int depth = 0;
            public int Depth
            {
                get { return depth; }
                set
                {
                    if (!filled)
                    {
                        depth = value;
                        filled = true;
                    }

                }
            }
        }

        static Tile[,] field = new Tile[15, 30]; // maga az empty field

        static void Main(string[] args)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            { // elkészíti a fieldet
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = new Tile();
                }
            }

            Random random = new Random();

            // 'kráter' lerakása a field közepén (random -1, 0, +1 'irányba')
            field[field.GetLength(0) / 2 + random.Next(0, 3) - 1, field.GetLength(1) / 2 + random.Next(0, 3) - 1].Depth = 200;
            DrawField();
             
            for (int i = 0; i < field.GetLength(0); i++)
            { // a szintezés
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    for (int k = -1; k <= 1; k++)
                    {
                        for (int l = -1; l <= 1; l++)
                        {
                            if (i + k > 0 && j + l > 0 && i + k < field.GetLength(0) && j + l < field.GetLength(1)) // szélsőértékek
                            {
                                if (field[i + k, j + l].Depth == 200)
                                {
                                    if (random.Next(100) > 30)
                                    {
                                        field[i, j].Depth = 100;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            DrawField();

            Console.ReadKey();
        }

        static void DrawField()
        { // lerajzolja a fieldet
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    switch (field[i, j].Depth)
                    {
                        case 0:
                            Console.BackgroundColor = ConsoleColor.White;
                            break;
                        case 100:
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            break;
                        case 200:
                            Console.BackgroundColor = ConsoleColor.Green;
                            break;
                        case 300:
                            Console.BackgroundColor = ConsoleColor.Blue;
                            break;
                        case 400:
                            Console.BackgroundColor = ConsoleColor.Red;
                            break;
                    }
                    Console.Write("#");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.ReadKey(true);
        }
    }

}
