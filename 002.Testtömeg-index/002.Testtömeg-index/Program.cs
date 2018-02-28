using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002.Testtömeg_index
{
    class Program
    {
        static void Main(string[] args)
        {
            double need_kg = 0, bmi = 0, m = 0, kg = 0;
            string szoveg = "";
            do
            {
                Console.Clear();
                Console.WriteLine("Testsúly kilogrammban:");
                kg = Math.Round(Convert.ToDouble(Console.ReadLine()), 2);
                Console.WriteLine("Magasság méterben:");
                m = Math.Round(Convert.ToDouble(Console.ReadLine()), 2);
                bmi = Math.Round(kg / (m * m), 2);
            } while (m <= 0 || kg <= 0);
            Console.WriteLine("BMI: {0}", bmi);
            if (bmi < 18)
            {
                need_kg = (18 * m * m) - kg;
                szoveg = "túlzottan sovány";
            }
            if (bmi >= 18 && bmi <= 25)
            {
                szoveg ="ideális (egészséges) testsúly";
            }
            if (bmi > 25 && bmi <= 30)
            {
                need_kg = kg - (25 * m * m);
                szoveg = "túlsúlyos";
            }
            if (bmi > 30) 
            {
                need_kg = kg - (30 * m * m);
                szoveg = "veszélyesen túlsúlyos";
            }

            need_kg = Math.Round(need_kg, 2);
            Console.WriteLine(szoveg + ", {0} kilogrammra az egészséges testsúlytól", need_kg);

            Console.ReadLine();
        }
    }
}
