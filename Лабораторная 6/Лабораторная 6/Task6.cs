using System;
using System.Collections.Generic;
using System.Text;

namespace Лабораторная_6
{
    // 6
    enum Season
    {
        Winter = 1,
        Spring,
        Summer,
        Autumn,
    }

    struct Buyer
    {
        public string Name;
        public short Age;
        public bool HasDiscount;
        public Buyer(string name, short age, bool discount)
        {
            Name = name;
            Age = age;
            HasDiscount = discount;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Покупатель {Name} {Age} \t Скидка: {HasDiscount}");
        }
    }
}
