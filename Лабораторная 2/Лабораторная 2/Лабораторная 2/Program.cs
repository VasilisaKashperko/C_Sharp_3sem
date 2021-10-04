using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool first = true;
            Console.WriteLine(first ? "Checked" : "Not checked");
            Console.WriteLine(true ? "Checked" + "\n" : "Not checked"+"\n");

            byte second = 255;
            Console.WriteLine(second + " " + second.GetType());
            Console.WriteLine(second + " " + Convert.ToInt32(second).GetType()+"\n");

            object third = "Hello";
            object fourth = 3.14;
            Console.WriteLine($"Объект 1: {third}\nОбъект 2: {fourth}\n");

            var fifth = 93;
            fifth = 100;
            //fifth = "Hi";

            dynamic sixth = "Hi";
            sixth = 93;
        }
    }
}
