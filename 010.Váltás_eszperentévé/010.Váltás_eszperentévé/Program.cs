using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _010.Váltás_eszperentévé
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] maganh = { 'a', 'á', 'é', 'i', 'í', 'o', 'ó', 'ö', 'ő', 'u', 'ú', 'ü', 'ű' };
            char[] text = Console.ReadLine().ToCharArray();

            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < maganh.Length; j++)
                {
                    if (text[i] == maganh[j])
                    {
                        text[i] = 'e';
                    }
                }
            }

            Console.WriteLine(new string(text));
            Console.ReadLine();
        }
    }
}
