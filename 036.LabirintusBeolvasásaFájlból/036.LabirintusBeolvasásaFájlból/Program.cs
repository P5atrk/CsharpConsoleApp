using System;
using System.IO;
using System.Linq;

namespace _036.LabirintusBeolvasásaFájlból
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] field = File.ReadAllLines("../../labyrinth.txt");
            int fileLength = int.Parse(field[0]);
            field = field.Skip(1).ToArray();
            for (int i = 0; i < fileLength; i++)
            {
                for (int j = 0; j < field[i].Length; j++)
                {
                    if (field[i][j] == '*') Console.BackgroundColor = ConsoleColor.Red;
                    else Console.BackgroundColor = ConsoleColor.Green;
                    Console.Write(field[i][j]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
