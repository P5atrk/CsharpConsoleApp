using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _017.T_eljárások_függvények
{
    class Program
    {
        static void Main(string[] args)
        {
            Udvozles(Console.ReadLine()); // eljárás 
            Console.ReadKey();
        }
        static void Udvozles(string nev)
        {
            Console.WriteLine("eljárás, írt szöveg: " + nev);
        }
    }
}
