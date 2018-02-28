using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* Lottó Számok
 * Készítsünk konzol programot, mely bekér a felhasználotól 5 lottó számot
 * majd előállítja a lottó sorsolás számait!
 */
namespace _026.LottóSzámok
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo cki;
            Random r = new Random();
            int hit = 0;
            int[] userNums = new int[5], winNums = new int[5];

            Console.Clear();
            Console.WriteLine("5-ös lottó! Lottózzá'!");

            for (int i = 0; i < winNums.Length; i++) // nyerő számok sorsolás
            {
                winNums[i] = r.Next(1,91);
                for (int j = 0; j < winNums.Length; j++)
                {
                    if (winNums[i] == winNums[j] && i != j)
                    {
                        i--;
                    }
                }
            }

            for (int i = 0; i < userNums.Length; i++) // user input
            {
                Console.Write("A(z) {0}. számod: ", i+1);
                userNums[i] = int.Parse(Console.ReadLine());
                for (int j = 0; j <= i; j++)
                {
                    if (userNums[i] == userNums[j] && i != j)
                    {
                        Console.WriteLine("Egy szám csak egyszer szerepelhet a számaid között!");
                        i--;
                    }
                    if (userNums[i] < 1 || userNums[i] > 90)
                    {
                        Console.WriteLine("Kérlek csak 1 és 90 közötti számokat adj meg.");
                        i--;
                    }
                }
            }
            for (int i = 0; i < winNums.Length; i++) // nyerő számok, user számai összehasonlitása
            {
                for (int j = 0; j < userNums.Length; j++)
                {
                    if (winNums[i] == userNums[j])
                    {
                        hit++;
                    }
                }
            }

            Console.WriteLine("\nA nyerő számok: "); // kiíratás
            WriteArr(winNums);
            Console.WriteLine("\nA te számaid: ");
            WriteArr(userNums);
            Console.WriteLine("\n{0} találatod volt.", hit);
            switch (hit)
            {
                case 1:
                    Console.WriteLine("Majd talán legközelebb.");
                    break;
                case 2:
                    Console.WriteLine("Te már valamit elértél az életben!");
                    break;
                case 3:
                    Console.WriteLine("Ilyen kicsit kellett volna hozzá!");
                    break;
                case 4:
                    Console.WriteLine("Mondtam, hogy ne azt a számot jelöld meg... hanem a másikat");
                    break;
                case 5:
                    Console.WriteLine("Gratulálok, a nyereményed egy... Tesco gazdaságos ketchup! Yeey...");
                    break;
            }

            Console.WriteLine("\nÚjraindításhoz nyomd meg azt Space gombot, kilépéshez pedig... bármi mást."); // újraindítás, kilépés
            cki = Console.ReadKey(true);
            if (cki.Key == ConsoleKey.Spacebar)
            {
                Main(null);
            }
        }

        static void WriteArr(int[] array) // nyerő számok, a te számaid kiíratása
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }
        }
    }
}
