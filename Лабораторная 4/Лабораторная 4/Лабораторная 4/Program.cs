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


/*
             //// Создаем множество
            //SortedSet<char> set1 = new SortedSet<char>();

            ////Добавляем в него элементы
            //set1.Add('A');
            //set1.Add('B');
            //set1.Add('C');
            //set1.Add('D');
            //set1.Add('D');

            ////Исключаем симметричность (одинаковые элементы) при помощи метода
            //set1.SymmetricExceptWith(set1);

            //set1.Remove('A');

            Set set1 = new Set();
            set1.Item1 = 'A';
            set1.Item2 = 'B';
            set1.Item3 = 'C';
            set1.Item4 = 'D';
            set1.Item5 = 'E';
            set1.Item6 = 'F';

            Set set2 = new Set();
            set2.Item1 = 'E';
            set2.Item2 = 'F';
            set2.Item3 = 'G';
            set2.Item4 = 'H';
            set2.Item5 = 'I';
            set2.Item6 = 'J';

            Console.WriteLine(set1.ToString());
            Console.WriteLine(set2.ToString());
 */