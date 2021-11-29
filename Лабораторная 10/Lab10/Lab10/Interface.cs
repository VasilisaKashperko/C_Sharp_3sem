using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab10
{
    interface IEnumerable<T>
    {
        void AddElem(T el);
        void DelElem(int key);
        void Find(int key);
        void Print();
    }

    public class Person
    {
        public string firstname;
        public string lastname;

        public Person(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }
    }

    // создаем перечисляемую коллекцию работников реализуемую интерфейсом IEnumerable
    public class Workers : IEnumerable
    {
        // создаем массив с элементами типа Person, где коллекция будет хранить свои элементы
        private Person[] _workers;

        // конструктор принимает массив в качестве аргумента
        public Workers(Person[] pArray)
        {
            // копируем массив из аргумента в собственный массив коллекции
            _workers = new Person[pArray.Length];
            for(int i=0; i<pArray.Length; i++)
            {
                _workers[i] = pArray[i];
            }
        }

        // явная реализация интерфейса IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            // возвращаем перечислитель по коллекции
            return (IEnumerator)GetEnumerator();
        }

        // перечислитель - объект класса WorkersEnum
        public WorkersEnum GetEnumerator()
        {
            // возвращаем перечислитель
            return new WorkersEnum(_workers);
        }

        // класс перечислителя для коллекции Workers
        public class WorkersEnum : IEnumerator
        {
            // массив с элементами типа Person
            public Person[] _workers;

            // (Enumenators позиционированны перед первым элементом)
            // определяет позицию перечислителя
            int position = -1;

            // инициализация массива
            public WorkersEnum(Person[] list)
            {
                _workers = list;
            }

            // реализация интерфейсов из IEnumerator

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public Person Current
            {
                get
                {
                    // попытка получить элемент коллекции, на который указывает указатель перечислителя
                    try
                    {
                        return _workers[position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            // перемещает указатель на следующую позицию
            // возвращает булевое значение, дошли мы до конца коллекции или нет
            public bool MoveNext()
            {
                position++;
                return (position < _workers.Length);
            }

            // указатель возвращается в первоначальную позицию
            public void Reset()
            {
                position = -1;
            }
        }
    }
}
