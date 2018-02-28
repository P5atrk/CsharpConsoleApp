using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _019.Majdnem_Lottó
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int x = 0, y = 0;
            for (int i = 0; i < 100; i++)
            {
                x = r.Next(7);
                if (x == 6)
                {
                    y++;
                }
            }
            Console.WriteLine("{0}x volt 6-os.", y);
            Console.ReadKey();
        }
    }
}
