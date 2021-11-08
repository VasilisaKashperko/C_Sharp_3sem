using System;
using System.Collections.Generic; // простанство имен, содержащее реализацию классов типа список, массив, очередь
using System.Linq;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Set.SetTest();

            string str = "Это новая строка";
            Console.WriteLine(str.AddPoint());
        }
    }
}


