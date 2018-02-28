using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _008.Szám_N_esek
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = Convert.ToInt32(Console.ReadLine()), x_first = x;
            for (int i = 0; i < 16; i++)
            {
                x *= x_first;
                if (x_first == x % 10 || x_first == x % 100 || x_first == x % 1000) Console.WriteLine(x);
            }
            Console.ReadLine();
        }
    }
}
