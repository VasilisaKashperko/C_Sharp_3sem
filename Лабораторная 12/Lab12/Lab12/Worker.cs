using System;
using System.Collections;

namespace Lab12
{
    public class Worker : IEnumerable<Worker>
    {
        private Guid id;
        public Guid Id { get => id; }
        public string Name { get; set; }
        public string Post { get; set; }
        public int Pay { get; set; }
        public static int Ip = 0;
        public int ip = 0;

        public Worker(Guid id, string name, string post, int pay)
        {
            this.id = id;
            Name = name;
            Post = post;
            Pay = pay;
            Ip++;
            ip = Ip;
        }

        public Worker()
        {
            Name = "Неизвестно";
            Post = "неизвестно";
            Pay = 0;
            Ip++;
            ip = Ip;
        }

        Hashtable hashList = new Hashtable();

        public void GetHash()
        {
            Console.WriteLine(GetHashCode());
        }

        public override string ToString()
        {
            return $"{Name} - {Post}" +
                $" с зарплатой {Pay}" +
                $"\nId работника: {Id}\n\n";
        }

        public void AddElem(Worker el)
        {
            Ip++;
            hashList.Add(Ip, el);
        }
        public void DelElem(int key)
        {
            hashList.Remove(key);
        }
        public void Find(int key)
        {
            ICollection keys = hashList.Keys;
            foreach (int s in keys)
            {
                if (s == key)
                {
                    Console.WriteLine($"Был найден ключ: {s} со значением {hashList[s]}");
                }
                else
                {
                    Console.WriteLine("Не найден ключ!");
                }
            }
        }
        public void Print()
        {
            ICollection keys = hashList.Keys;

            foreach (int s in keys)
                Console.WriteLine(s + ": " + hashList[s]);
        }
    }
}
