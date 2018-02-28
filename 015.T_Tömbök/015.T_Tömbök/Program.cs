using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _015.GG_Tömbök
{
    class Program
    {
        static void Main(string[] args)
        {
            //random
            Random random = new Random();
            //tömbök
            //vektor
            int[] vektor = new int[7];
            for (int i = 0; i < vektor.Length; i++)
            {
                vektor[i] = random.Next(10, 20);
            }
            foreach (int item in vektor)
            {
                Console.Write("{0} ", item);
            }

            Console.WriteLine();
            //mátrix
            int[,] matrix = new int[4, 6];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(10, 30);
                    Console.Write("{0} ", matrix[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            // mutatóvektor
            int[][] mutatovektor = new int[][] 
            {
                new int[3],
                new int[5],
                new int[6],
                new int[2],
                new int[9],
            };
            for (int i = 0; i < mutatovektor.Length; i++)
            {
                for (int j = 0; j < mutatovektor[i].Length; j++)
                {
                    mutatovektor[i][j] = random.Next(10, 30);
                    Console.Write("{0} ", mutatovektor[i][j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            // string
            // string char
            char[] s = new char[3] { 'a', 'b', 'c' };
            Console.WriteLine(s);
            Console.WriteLine("{0}_{1}", s[0], s[2]);
            // string string
            string st = "árvíztűrő tükörfúrógép";
            for (int i = 0; i < st.Length; i++)
            {
                Console.Write(st[i]);
            }
            Console.ReadLine();
        }
    }
}