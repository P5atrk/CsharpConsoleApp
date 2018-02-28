using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Megszerkeszthető-e a háromszög?
 * 
 */
namespace _018.Szerkeszthető_e_a_háromszög
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numArr = { int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()) }; // 3 oldal megadása
            int max = numArr.Max(); // legnagyobb oldal
            numArr = numArr.Where(item => item != max).ToArray(); // legnagyobb oldal kivétele az array-ből
            if (numArr[0] + numArr[1] < max) // másik 2 oldal nagyobb-e a 3.-nál?
            {
                Console.WriteLine("NEM"); 
            }
            else
            {
                Console.WriteLine("IGEN");
            }
            Console.ReadKey();
        }
    }
}
