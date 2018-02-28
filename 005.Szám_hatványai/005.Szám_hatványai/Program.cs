using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005.Szám_hatványai
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Az első szám a hatványozni kivánt szám.\nA második szám a kitevő lesz.\nA harmadik sorba írd('n'), ha csak az utolsót hatványát\nszeretnéd megnézni a számnak. Ha mindet megakarod csak nyomj egy Entert.");

            int x_first = Convert.ToInt32(Console.ReadLine());
            long x = x_first;

            int hatv = Convert.ToInt32(Console.ReadLine());

            string mind_e = Console.ReadLine();
            for (int i = 0; i < hatv; i++)
            {
                if (mind_e != "n") Console.WriteLine(x);
                x *= x_first;
            }
            if (mind_e == "n") Console.WriteLine(x);
            Console.ReadLine();
        }
    }
}
