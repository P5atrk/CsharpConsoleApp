using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _011.Számbarkochba
{
    class Program
    {
        static void Main(string[] args)
        {
            string ujra;
            do
            {
                Console.Clear();
                Random r = new Random();
                int be = 0;
                int szam = r.Next(1000);
                do
                {
                    be = Convert.ToInt32(Console.ReadLine());
                    if (be == szam)
                    {
                        Console.WriteLine("talált");
                    }
                    else if (be < szam)
                    {
                        Console.WriteLine("nagyobb");
                    }
                    else
                    {
                        Console.WriteLine("kisebb");
                    }
                } while (be != szam);
                Console.WriteLine("újra? igen/nem");
                ujra = Console.ReadLine();
            } while (ujra == "igen");
        }
    }
}
