using System;
using System.Collections.Generic;

namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                GetSet<int> set1 = new GetSet<int>();
                set1.Add(3);
                set1.Add(6);
                set1.Add(8);

                set1.Show();

                Console.WriteLine("Ищем элемент 2");
                set1.Search(2);

                Console.WriteLine("Ищем элемент 3");
                set1.Search(3);

                Console.WriteLine("Пытаемся удалить элемент 13");
                set1.Remove(13);

                Console.WriteLine("\nУдаляем элемент 8");
                set1.Remove(8);

                Console.WriteLine("\nВыводим множество заново:");
                set1.Show();
            }
            finally
            {
                Console.WriteLine("\nПрограмма завершена!\n");
            }
        }
    }
}
