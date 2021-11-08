using System;
using System.Collections.Generic;
using System.Text;

namespace Лабораторная_5
{
    class Flower : Bush, IRemove
    {
        public string Color
        {
            get; set;
        }

        public int Diameter
        {
            get; set;
        }

        public Flower(string name, string growLocation, string color, int diameter) : base(name, growLocation)
        {
            Color = color;
            Diameter = diameter;
        }

        public override void Uproot()
        {
            Console.WriteLine($"Цветок {Name} срезан для букета.");
        }

        public override void Recycle()
        {
            Console.WriteLine($"Цветок {Name} выбросили. Жаль. Получился бы отличный букет :(");
        }

        public override string ToString()
        {
            return $"{this.GetType()} {Name} {LifeForm} {GrowLocation} {Color} {Diameter}";
        }
    }
}
