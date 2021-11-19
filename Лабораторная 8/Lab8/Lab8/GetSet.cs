using System;
using System.Collections.Generic;
using System.Text;

namespace Lab8
{
    public partial class GetSet<T> : ICollectionType<T> where T : new()
    {
        private List<T> storage;

        public List<T> Storage
        {
            get
            {
                return this.storage;
            }
        }

        public GetSet()
        {
            this.storage = new List<T>();
        }

        public GetSet(List<T> storage)
        {
            this.storage = storage;
        }

        public void Add(T elem)
        {
            this.storage.Add(elem);
        }

        public void Remove(T delem)
        {
            if (Storage.Contains(delem))
            {
                this.storage.Remove(delem);
                Console.WriteLine("Элемент удалён!");
            }

            else
            {
                Console.WriteLine("Элемент не найден!");
            }
        }

        public void Show()
        {
            foreach (T str in storage)
            {
                Console.Write(str + " ");
            }
            Console.WriteLine();
        }

        public void Search(T selem)
        {
            if (Storage.Contains(selem))
            {
                Console.WriteLine("Элемент найден!");
            }

            else
            {
                Console.WriteLine("Элемент не найден!");
            }
            Console.WriteLine();
        }

    }
}
