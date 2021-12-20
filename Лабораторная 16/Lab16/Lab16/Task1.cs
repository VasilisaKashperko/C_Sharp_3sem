using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Console;

namespace Lab16
{
    partial class Program
    {
        public static Task task1;

        public static void SieveOfEratosthenes()
        {
            int n = 1000;
            WriteLine("Текущий ID таска: " + Task.CurrentId.ToString());

            var numbers = new List<uint>();

            // Заполнение списка numbers числами от 2 до n-1

            for (var i = 2u; i < n; i++)
            {
                numbers.Add(i);
            }

            for (var i = 0; i < numbers.Count; i++)
            {
                for (var j = 2u; j < n; j++)
                {
                    numbers.Remove(numbers[i] * j);
                }
            }

            foreach (int a in numbers)
            {
                WriteLine(a);
            }
        }
    }
}
