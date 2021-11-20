using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Lab8
{
    [Serializable]
    public partial class GetSet<T> : ICollectionType<T> where T : new()
    {
        private readonly List<T> storage;

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

        //////////////////////////////

        // файл сохраняется в bin\Debug\netcoreapp*
        public void Save(string CurrentFile)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream(CurrentFile, FileMode.OpenOrCreate))
            {
                bf.Serialize(fs, Storage);
                fs.Close();
            }
        }

        // файл выгружается из bin\Debug\netcoreapp*
        public void Upload(string CurrentFile)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream(CurrentFile, FileMode.OpenOrCreate))
            {
                List<T> deser = (List<T>)bf.Deserialize(fs);
                foreach (T p in deser)
                {
                    if (p == null)
                        continue;
                    this.Add(p);
                }
                fs.Close();
            }
        }
    }
}
