using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _023.Monogram
{
    class Program
    {
        static void Main(string[] args)
        {
            string nev = Console.ReadLine();
            for (int i = 0; i < nev.Length; i++)
            {
                if (i == 0 && nev[i + 1] != ' ')
                {
                    Console.Write(nev[i]);
                }
                if (nev[i] == ' ' && nev[i + 1] != ' ')
                {
                    Console.Write(nev[i + 1]);
                }
                switch (nev[i])
                {
                    case 'C':
                        if (nev[i + 1] == 's')
                        {
                            Console.Write(nev[i + 1]);
                        }
                        break;
                    case 'D':
                        if (nev[i + 1] == 'z')
                        {
                            Console.Write(nev[i + 1]);
                        }
                        break;
                    case 'S':
                        if (nev[i + 1] == 'z')
                        {
                            Console.Write(nev[i + 1]);
                        }
                        break;
                    case 'Z':
                        if (nev[i + 1] == 's')
                        {
                            Console.Write(nev[i + 1]);
                        }
                        break;
                }
            }
            
            Console.ReadKey();
        }
    }
}
