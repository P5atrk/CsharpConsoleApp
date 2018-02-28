using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Bekér egy mondatot, majd kiírja szóközök nélkül. */
namespace _020.SzóközökNélkül
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != ' ')
                {
                    Console.Write(s[i]);
                }
            }
            Console.ReadKey();
        }
    }
}
