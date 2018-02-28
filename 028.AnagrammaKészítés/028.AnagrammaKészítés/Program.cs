using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _028.AnagrammaKészítés
{
    class Program
    {
        static void Main(string[] args)
        {
            string ann = Console.ReadLine();
            int fact = ann.Length;
            int annNum = 0;

            do
            { // Az anagrammák száma
                annNum *= fact;
                fact--;
            } while (fact != 1);

            string[] sArr = new string[annNum];

            for (int i = 0; i < ann.Length; i++)
            {
                // still have no idea
            }



            Console.ReadKey();
        }
    }
}
