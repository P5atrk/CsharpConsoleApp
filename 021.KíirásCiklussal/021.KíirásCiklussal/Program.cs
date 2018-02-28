using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _021.KíirásCiklussal
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "*"; // szöveg, ami meg fog jelenni,
            int max = 10; // hányszor ismételje a szöveget
            int delay = 30; // késleltetés a sorok közt
            int i, j; // a 2 db for() változói

            if (text.Length > 39) // ha a 'text' nagyobb mint a max karakterek száma
            {
                Console.WriteLine("A Szöveg hossza meghaladja a maximumot, a 39 betűt!\nA beírt szöveg karaktereinek száma: {0}", text.Length);
                Console.ReadKey(); // kilépés
            }
            else
            {
                if (text.Length * max > 79) max = 79 / text.Length; // 79 karakter hósszú lehet a szöveg max + a(z) \n, 80+-nál 2 sorba rakná a szöveget

                do // örök loop
                {
                    for (i = 0; i < max; i++) // oszlop
                    {
                        for (j = 0; j < i; j++) // sor
                        {
                            Console.Write(text); // 1 db 'text' kiírása
                        }
                        Console.WriteLine(); // sortörés
                        Thread.Sleep(delay); // késleltetés
                    }
                    for (i = max; i > 0; i--) // ugyanaz, mint a fenti for()-nál, csak fordítva
                    {
                        for (j = i; j > 0; j--)
                        {
                            Console.Write(text);
                        }
                        Console.WriteLine();
                        Thread.Sleep(delay);
                    }
                } while (true);
            }
        }
    }
}
