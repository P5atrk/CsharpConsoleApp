using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            double ossz = 0;
            Console.WriteLine("Első szám");
            double x = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Második szám");
            double y = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Művelet ( + - * / )");
            string jel = Console.ReadLine();
            switch (jel)
            {
                case "+":
                    ossz = x + y;
                    break;
                case "-":
                    ossz = x - y;
                    break;
                case "*":
                    ossz = x * y;
                    break;
                case "/":
                    ossz = x / y;
                    break;
                default:
                    break;
            }
            Console.WriteLine("{0} az összegük", ossz);
            Console.ReadLine();
        }
    }
}
