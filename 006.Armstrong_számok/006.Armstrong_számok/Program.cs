using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006.Armstrong_számok
{
    class Program
    {
        static void Main(string[] args)
        {
            int s, t, e;
            for (int i = 152; i < 1000; i++)
            {
                s = i / 100;
                t = i / 10 % 10; // nem i % 10 / 10, el van ronta a segítségnél. (csak fél óra az életemből erre ment el.)
                e = i % 10;
                if (i == s * s * s + t * t * t + e * e * e) Console.WriteLine(i);
            }
            Console.ReadLine();
        }
    }
}
