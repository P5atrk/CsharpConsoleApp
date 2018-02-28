using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* Mátrix Térkép
 * A felhasználó bediktálja a mátrix összes elemét elöszőr a sor majd az oszlop
 * és végül magának az értéknek megadja az értékét (nyelvtanPls). Figyeljünk arra,
 * hogy egy értéket csak egyszer adhat meg a felhasználó, de mindig adjunk neki
 * lehetőséget arra, hogy ujrakezdje a dolgot, ill. felhasználó adhat rossz 
 * értéket bármire, ezeket kezelnünk kell tudni.
 * - oszlop- és sorérték - érték értéke (omg) - eldöntendő kérdés rosszul válaszolása
 * több funkció hozzáadása. pl
 * - sor, oszlop értékeinek összeadása - hány soros, oszlopos legyen a mátrix
 * - hozzon létre véletlen számos mátrixot felhasználónak eleget téve
 * - a mátrix megadása előtti eldöntös képernyő, mint az az utáni
 */
namespace _025.MátrixTérképe
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[2, 2];
            bool triedAssignTwice = false;
            string[,] checker = new string[matrix.GetLength(0), matrix.GetLength(1)];
            int row, col, marked = 0;
            do
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (String.IsNullOrEmpty(checker[i, j]))
                        {
                            Console.Write(".");
                        }
                        else
                        {
                            Console.Write("*");
                            marked++;
                        }
                    }
                    Console.WriteLine();
                }
                if (marked == matrix.GetLength(0) * matrix.GetLength(1))
                {
                    Console.Clear();
                    Question(matrix);
                    break;
                }
                marked = 0;
                if (triedAssignTwice == true)
                {
                    Console.WriteLine("You can only assign a value once!");
                    triedAssignTwice = false;
                }
                else
                {
                    Console.WriteLine("----");
                }
                DataEntry(out row, out col);
                if (String.IsNullOrEmpty(checker[row, col]))
                {
                    matrix[row, col] = int.Parse(Console.ReadLine());
                    checker[row, col] = "*";
                }
                else
                {
                    triedAssignTwice = true;
                }

                Console.Clear();

            } while (true);

            Console.ReadKey();
        }

        static void Question(int[,] matrix)
        {
            Console.WriteLine("Show numbers: show\nExit: exit");
            string quest = Console.ReadLine().ToLower().Trim();
            switch (quest)
            {
                case "show":
                    Console.Clear();
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            Console.Write("{0} ", matrix[i, j]);
                        }
                        Console.WriteLine();
                    }
                    Question(matrix);
                    break;
                case "exit":
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Question(matrix);
                    break;
            }
        }
        static void DataEntry(out int row, out int col)
        {
            try
            {
                Console.Write("Data Entry\nRow: ");
                row = int.Parse(Console.ReadLine().Trim()) - 1;
                Console.Write("Column: ");
                col = int.Parse(Console.ReadLine().Trim()) - 1;
                Console.Write("Value: ");
            }
            catch (Exception)
            {
                Console.WriteLine("Only numbers!");
                DataEntry(out row, out col);
            }
        }
    }
}
