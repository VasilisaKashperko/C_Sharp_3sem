using System;

namespace Tuple
{
    class Tuple
    {
        static void Main(string[] args)
        {
            (int, string, char, string, ulong) tuple1 = (19, "Василиса", 'ж', "Кашперко", 2001);

            Console.Write(tuple1.Item1 + " " + tuple1.Item2 + " " + tuple1.Item4);

            (var ar, var br) = ("2001", 2002);
            Console.WriteLine($"\n{ar} {br}" + "\n");

            var First = (ar, br);
            var Second = (ar, br);

            Console.WriteLine(First == Second);
        }
    }
}
