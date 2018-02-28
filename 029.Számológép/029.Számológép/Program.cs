using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _029.Számológép
{
    class Program
    {
        static void Main(string[] args)
        {
            string equation = Console.ReadLine();
            int[] num = new int[equation.Length];
            char[] sign = new char[equation.Length];
            char[] signOrder = {'*', '/', '+', '-'};

            int number; // temp

            for (int i = 0; i < equation.Length; i++)
            {
                if (int.TryParse(equation[i].ToString(), out number) == true)
                {
                    num[i] = int.Parse(equation[i].ToString());
                }
                else
                {
                    sign[i] = equation[i];
                }
            }

            for (int i = 0; i < sign.Length; i++)
			{
                if (sign[i] != 0)
                {
                    switch (sign[i])
                    {
                        case '*':
                            num[i - 1] *= num[i + 1];
                            break;
                        case '/':
                            num[i - 1] /= num[i + 1];
                            break;
                        case '+':
                            num[i - 1] += num[i + 1];
                            break;
                        case '-':
                            num[i - 1] -= num[i + 1];
                            break;
                    }
                    Console.WriteLine(num[i - 1]);
                    for (int j = 1; j < num.Length + 1; j++)
                    {
                        if (num[j - 1] != num[i - 1])
                        {
                            num[j - 1] = num[i - 1];
                        }
                        else
                        {
                            num[j - 1] = 0;
                        }
                    }
                }
			}

            Console.ReadKey();
        }
    }
}
