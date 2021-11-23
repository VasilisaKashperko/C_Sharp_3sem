using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab10
{
    public class Worker : IEnumerable<object>
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

        public IEnumerator<object> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
