using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _022.NapszakhozIllőKöszönés
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime CurrentDate = new DateTime(1999, 1, 9, 3, 57, 32, 11);
            string DatePMAM = CurrentDate.ToString("tt");
            switch (DatePMAM)
            {
                case "de.":
                    Console.WriteLine("REGGEL");
                    break;
                case "du.":
                    Console.WriteLine("DÉLUTÁN");
                    break;
            }
            Console.WriteLine(DatePMAM);

            Console.ReadKey();
        }
    }
}
