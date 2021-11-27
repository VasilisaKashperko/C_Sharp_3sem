using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;

namespace Lab10
{
    public class Worker// : IEnumerable//, IEnumerator<object>
    {
        public string Name { get; private set; }
        public string Post { get; private set; }
        public int Pay { get; private set; }

        public Worker(string name, string post, int pay)
        {
            this.Name = name;
            this.Post = post;
            this.Pay = pay;
        }

        public override String ToString()
        {
            return $"Имя работника: {Name}\n" +
                $"Должность работника: {Post}\n" +
                $"Зарплата работника: {Pay}\n\n";
        }

        // Реализуем интерфейс IEnumerable
        //public IEnumerator GetEnumerator()
        //{
        //    return this;
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
