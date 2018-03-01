using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _034.SzövegTükrözése
{
    class Program
    {
        static void Main(string[] args)
        {
            string inp = Console.ReadLine();
            string half = "";
            for (int i = inp.Length/2 - 1; i >= 0; i--)
            {
                half += inp[i];
            }
            Console.WriteLine("{0}{1}",inp.Remove(inp.Length/2), half);

            Console.ReadKey();
        }
    }
}
