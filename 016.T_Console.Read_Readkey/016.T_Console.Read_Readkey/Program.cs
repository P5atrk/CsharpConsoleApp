using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _016.T_Console.Read_Readkey
{
    class Program
    {
        static void Main(string[] args)
        {
            // console.read
            int ascii = Console.Read();
            Console.WriteLine((char)ascii);

            Console.WriteLine();
            // console.readkey
            ConsoleKeyInfo cki = Console.ReadKey(true);
            Console.WriteLine("\n" + cki);
            Console.WriteLine(cki.Key); // speciális billentyűk (pl up-arrow)
            Console.WriteLine(cki.KeyChar);
            switch (cki.Key) // speciális karakterek "figyelése"
            {
                case ConsoleKey.Delete:
                    Console.WriteLine("delete");
                    break;
                case ConsoleKey.DownArrow:
                    Console.WriteLine("down_key");
                    break;
                case ConsoleKey.Enter:
                    Console.WriteLine("enter");
                    break;
                case ConsoleKey.Escape:
                    Console.WriteLine("escape");
                    break;
            }

            Console.ReadKey();
        }
    }
}
