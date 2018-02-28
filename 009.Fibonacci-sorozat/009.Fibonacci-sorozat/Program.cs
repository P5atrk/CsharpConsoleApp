using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _009.Fibonacci_sorozat
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 0, y = 1;
            for (int i = 0; i <= 20; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine("{0}. {1}", i , x);
                    x += y;
                }
                else
                {
                    Console.WriteLine("{0}. {1}", i, y);
                    y += x;
                }
            }
            Console.ReadLine();
        }
    }
}
