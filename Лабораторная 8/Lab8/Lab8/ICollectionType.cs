using System;
using System.Collections.Generic;
using System.Text;

namespace Lab8
{
    interface ICollectionType<T> where T : new()
    {
        void Add(T elem);
        void Remove(T delem);
        void Show();
    }
}
