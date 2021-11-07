using System;
using System.Collections.Generic; // простанство имен, содержащее реализацию классов типа список, массив, очередь
using System.Linq;

// Коллекция, содержащая только отличающиеся элементы, называется множеством (set).
// Класс List<T> из пространства имен System.Collections.Generic представляет простейший список однотипных объектов.

namespace Lab4
{
    /// <summary>
    /// Множество
    /// </summary>
    /// <typeparam name="T"> Тип данных, хранимых во множестве. </typeparam>
    public partial class Set
    {
        public List<int> mySet;
        public Set(List<int> localSet)
        {

            this.mySet = localSet;
        }

        // Удаление элемента из множества
        public static Set operator -(Set set1, int item1)
        {
            set1.mySet.Remove(item1); // удаление из mySet (хранилища)
            return set1;
        }

        // Пересечение множеств
        public static Set operator *(Set set1, Set set2)
        {
            var concSet = new Set(new List<int>());
            foreach (var s in set1.mySet)
            {
                if (set2.mySet.Contains(s))
                {
                    concSet.mySet.Add(s);
                }
            }
            return concSet;
        }

        // Сравнение множеств
        public static bool operator <(Set set1, Set set2)
        {
            int amount1 = set1.mySet.Count;
            int amount2 = set2.mySet.Count;
            if (amount1 <= amount2)
            {
                Console.WriteLine("1 множество меньше 2");
                return false;
            }
            else
            {
                Console.WriteLine("1 множество больше 2");
                return true;
            }
        }

        // Проверка на подмножество
        public static bool operator >(Set set1, Set set2)
        { // 1-ый параметр - подмножесто, 2-ой - множество
            int c = set1.mySet.Count;
            int counter = 0;
            foreach (var s in set1.mySet)
            {
                if (set2.mySet.Contains(s))
                {
                    counter++;
                }
            }
            if (counter == c)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Добавление элемента в множество
        public static Set operator &(Set set1, int q)
        {
            if (set1.mySet.Contains(q))
            { 
                Console.WriteLine("Такой элемент уже есть в множестве."); 
            }
            else
            {
                set1.mySet.Add(q);
            }
            return set1;
        }

        public void Print()
        {
            this.mySet.ForEach(i => Console.Write(i + " "));
            Console.WriteLine();
        }

        public static void SetTest()
        {
            var set1 = new Set(new List<int>() { 0, 1, 2, 3, 5, 6, 7, 9 });
            var set2 = new Set(new List<int>() { 1, 2, 3, 5, 7 });
            
            set1.Print();
            set2.Print();

            Console.WriteLine("Удаляем из первого множества 5");
            var test = set1 - 5;
            test.Print();

            Console.WriteLine("Добавляем в первое множество 10");
            test = set1 & 10;
            test.Print();

            Console.WriteLine("Пересечение множеств: ");
            set1.Print();
            set2.Print();
            Console.WriteLine("Результат");
            test = set2 * set1;
            test.Print();

            Console.WriteLine("Сравниваем два множества");
            Console.WriteLine(set1 < set2);

            Console.WriteLine("Включает ли первое множество в себе второе");
            set1.Print();
            set2.Print();
            Console.WriteLine(set2 > set1);

            test = set2 - 5;
            set1.Print();
            set2.Print();
            Console.WriteLine(set2 > set1);
        }
    }

    public static class StatisticOperation
    {
        public static string AddPoint(this string str)
        {
            str += '.';
            return str;
        }

        public static Set RemoveZero(this Set set1)
        {
            while (set1.mySet.Remove(0))
            {

            }
            return set1;
        }

        public static int Sum(Set set1, Set set2)
        {
            return set1.mySet.Count + set2.mySet.Count;
        }

        public static int Diff(Set set1)
        {
            return set1.mySet.Max() - set1.mySet.Min();
        }

        public static int Length(Set set1)
        {
            return set1.mySet.Count;
        }
    }
}