using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

// IEnumerable - интерфейс, предоставляет перечислитель,
// который поддерживает простой перебор элементов неуниверсальной коллекции.

// Коллекция представляет собой совокупность объектов. В среде 
// .NET Framework имеется немало интерфейсов и классов, в которых 
// определяются и реализуются различные типы коллекций. 
// Главное преимущество коллекций заключается в том, что они 
// стандартизируют обработку групп объектов в программе. 

namespace Lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            #region [ The first task ]

            Console.WriteLine("\t\t\t\tЗадание 1:\n");

            Person[] personArray =
            {
                new Person("Владимир","Распутин"),
                new Person("Михаил","Ждарин"),
                new Person("Виталий","Квазинский")
            };

            Workers workersCollection = new Workers(personArray);

            foreach (var person in workersCollection)
            {
                Console.WriteLine("Имя работника: {0}, фамилия работника: {1}", person.firstname, person.lastname);
            }

            Console.WriteLine("Количество элементов: " + personArray.Length);

            Console.ReadKey();

            #endregion

            #region [ The second task ]

            Console.WriteLine("\t\t\t\tЗадание 2:\n");

            Worker obj1 = new Worker(Guid.NewGuid(), "Павел Викторович", "декан", 3000);
            Worker obj2 = new Worker(Guid.NewGuid(), "Николай Львович", "ректор", 16030);
            Worker obj3 = new Worker(Guid.NewGuid(), "Иван Кузьмич", "лектор", 2400);
            Worker obj4 = new Worker(Guid.NewGuid(), "Валерий Владимирович", "лаборант", 1400);
            Worker obj5 = new Worker(Guid.NewGuid(), "Арина Николаевна", "лаборант", 1500);
            Worker obj6 = new Worker(Guid.NewGuid(), "Надежда Александровна", "лектор", 1900);

            Console.WriteLine($"{obj1.ToString()}\n" +
                $"{obj2.ToString()}\n" +
                $"{obj3.ToString()}\n" +
                $"{obj4.ToString()}\n" +
                $"{obj5.ToString()}\n" +
                $"{obj6.ToString()}\n");

            Hashtable workers = new Hashtable();

            workers.Add(obj1.ip, obj1);
            workers.Add(obj2.ip, obj2);
            workers.Add(obj3.ip, obj3);
            workers.Add(obj4.ip, obj4);
            workers.Add(obj5.ip, obj5);
            workers.Add(obj6.ip, obj6);

            ICollection keys = workers.Keys;

            foreach (int n in keys)
            {
                Console.WriteLine(n + ": " + workers[n]);
            }
            Console.ReadKey();

            #endregion

            #region [ The third task ]

            //Представляет коллекцию динамических данных,
            //обеспечивающих выдачу уведомлений при получении и удалении элементов
            //или при обновлении всего списка.
            //Коллекция предназначена для того, чтобы пользовательский интерфейс
            //мог получать информацию об изменениях коллекции.
            //Используется в случае если нужна информация о том, когда элементы коллекции удаляются или добавляются.


                        Console.WriteLine("\t\t\t\tЗадание 3\n");
            ObservableCollection<Worker> p = new ObservableCollection<Worker>();

            void p_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        Worker newWorker = e.NewItems[0] as Worker;
                        Console.WriteLine("Добавлен новый объект: " + newWorker.Name);
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        Worker oldWorker = e.OldItems[0] as Worker;
                        Console.WriteLine("Удален объект: " + oldWorker.Name);
                        break;
                }
            }

            p.CollectionChanged += p_CollectionChanged;

            p.Add(obj1);
            p.Add(obj2);
            p.Add(obj3);
            p.RemoveAt(1);
            Console.WriteLine("\n");
            
            foreach (Worker i in p)
            {
                Console.WriteLine(i.ToString());
            }

            #endregion
        }
    }
}
