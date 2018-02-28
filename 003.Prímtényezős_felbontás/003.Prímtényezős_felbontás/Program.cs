using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003.Prímtényezős_felbontás
{
    class Program
    {
        static void Main(string[] args)
        {
            string p_num = System.IO.File.ReadAllText(@"C:\Users\Patrik\Documents\Visual Studio 2013\Projects\003.Prímtényezős_felbontás\003.Prímtényezős_felbontás\prime_numbers.txt");
            string[] split = p_num.Split(' ');
            int[] p = new int[split.Length];

            for (int i = 0; i < split.Length; i++)
            {
                p[i] = int.Parse(split[i]);
            }
            int j, y, x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("__");
            for (j = 0; j < p.Length; j++)
			{
			    if (0 == x % p[j])
                {
                    y = x;
                    x = x / p[j];
                    Console.WriteLine(y + " " + p[j]);
                    j = -1;
                }
			}
            Console.WriteLine("1");
            Console.ReadLine();
        }
    }
}