using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _012.Véletlenszám_vektor
{
    class Program
    {
        static void Main(string[] args)
        {
            int temp, szam = 0, k;
            int[] vekt = new int[48];
            Random r = new Random();

            /*Feladat leírás*/ Console.WriteLine("\nÁllíts elő 48 véletlen számot 1 és 99 között! Jelöld meg közülük a lehető legtöbbet, amelyekre igaz, hogy az összegük nem több, mint 1000 !");
            Console.WriteLine("\n\nÖsszes szám:\n");
            for (int i = 0; i < vekt.Length; i++)
            {
                vekt[i] = r.Next(1,100);
                Console.Write(" " + vekt[i]);
            }
            for (int i = 0; i < vekt.Length; i++)
            {
                for (int j = 0; j < vekt.Length; j++)
                {
                    if (vekt[i] < vekt[j])
                    {
                        temp = vekt[i];
                        vekt[i] = vekt[j];
                        vekt[j] = temp;
                    }
                }
            }
            Console.WriteLine("\n\nLegtöbb olyan szám, melyet összeadva kevesebbet kapunk mint 1000:\n");
            for (k = 0; k < vekt.Length; k++)
            {
                if (szam + vekt[k] < 1000) 
                {
                    
                    szam += vekt[k];
                    Console.Write(vekt[k] + " ");
                }
            }
            Console.WriteLine("\n\nÖsszegük: " + szam);

            Console.ReadLine();
        }
    }
}
