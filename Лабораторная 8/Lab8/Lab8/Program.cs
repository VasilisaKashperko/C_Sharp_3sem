using System;
//Обобщение означает параметризированный тип. Особая роль 
//параметризированных типов состоит в том, что они позволяют создавать 
//классы, структуры, интерфейсы, методы и делегаты, в которых 
//обрабатываемые данные указываются в виде параметра

namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                GetSet<object> set1 = new GetSet<object>();
                set1.Add(3);
                set1.Add(6);
                set1.Add(8);

                Console.WriteLine($"Множество: ");
                set1.Show();

                Console.WriteLine("\nИщем элемент 2");
                set1.Search(2);

                Console.WriteLine("Ищем элемент 3");
                set1.Search(3);

                Console.WriteLine("Пытаемся удалить элемент 13");
                set1.Remove(13);

                Console.WriteLine("\nУдаляем элемент 8");
                set1.Remove(8);

                Console.WriteLine("\nВыводим множество заново:");
                set1.Show();
                Console.ReadKey();

                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - -");

                GetSet<Object> set2 = new GetSet<Object>();
                set2.Add("Never");
                set2.Add("Give");
                set2.Add("Up");
                set2.Add(".");
                set2.Add("You");
                set2.Add("Are");
                set2.Add("Amasing");

                Console.WriteLine($"Множество со строками: ");
                set2.Show();

                Console.WriteLine("\nИщем слово 'Привет'");
                set2.Search("Привет");

                Console.WriteLine("Ищем слово 'Up'");
                set2.Search("Up");

                Console.WriteLine("Пытаемся удалить слово 'Пока'");
                set2.Remove("Пока");

                Console.WriteLine("\nУдаляем слово 'Are'");
                set2.Remove("Are");

                Console.WriteLine("\nВыводим множество со строками заново:");
                set2.Show();
                Console.ReadKey();

                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - -");

                Console.WriteLine("Сохраняю в файл...");
                System.Threading.Thread.Sleep(2000);
                set2.Save("saving.txt");
                Console.WriteLine("Множество сохранено в файл!");

                System.Threading.Thread.Sleep(2000);
                Console.WriteLine("Создаю новое множество из записанного файла...");
                GetSet<Object> set3 = new GetSet<Object>();
                System.Threading.Thread.Sleep(2000);
                Console.WriteLine("Готово! Можно посмотреть:");
                System.Threading.Thread.Sleep(2000);

                set3.Upload("saving.txt");
                set3.Show();
            }
            finally
            {
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("\nПрограмма завершена!\n");
            }
        }
    }
}
