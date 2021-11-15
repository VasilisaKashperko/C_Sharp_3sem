using System;
using System.Collections.Generic;
using System.Text;

namespace Лабораторная_6
{
    public class Flower : Bush, IRemove, IComparable<Flower>
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

        public int CompareTo(Flower f)
        {
            return this.Name.CompareTo(f.Name);
        }

        public override void Uproot()
        {
            Console.WriteLine($"Цветок {Name} срезан для букета.");
        }

        public override void Recycle()
        {
            Console.WriteLine($"Цветок {Name} выбросили. Жаль. Получился бы отличный букет.");
        }

        public override string ToString()
        {
            return $"{this.GetType()} {Name} {LifeForm} {GrowLocation} {Color} {Diameter}";
        }
    }
}
