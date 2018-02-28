using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* Feladat leírás
 * Kérjük be egy 2x2-es (esetleg egy 3x3-as) mátrix
 * elemeit, majd „rajzoljuk” ki a mátrixot a konzol képernyőre, végül számítsuk ki és írjuk
 * ki a determinánsát.*/
namespace _014.Mátrix_bekérése
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[2, 2];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0},{1} ",i, j);
                    matrix[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            int x = matrix[0, 0] * matrix[0, 1] - matrix[1, 0] * matrix[1, 1];
            Console.WriteLine("\n{0} {1}\n{2} {3}\n{4}", matrix[0, 0], matrix[0, 1], matrix[1, 0], matrix[1, 1], x);

            Console.ReadLine();
        }
    }
}
