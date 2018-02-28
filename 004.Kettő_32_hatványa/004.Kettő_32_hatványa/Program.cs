using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004.Kettő_32_hatványa
{
    class Program
    {
        static void Main(string[] args)
        {
            long x = 2;
            for (byte i = 0; i < 32; i++)
			{
                Console.WriteLine(x);
                x = x * 2;
            }

            Console.ReadLine();
        }
    }
}
