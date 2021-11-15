using System;
using System.Collections.Generic;
using System.Text;

namespace Лабораторная_7
{
    class Rose : Flower
    {
        public bool HasThorns
        {
            get; set;
        }

        public int ThornLenth
        {
            get; set;
        }

        public Rose(string name, string growLocation, string color, int diameter, int thornLength, double cost) : base(name, growLocation, color, diameter, cost)
        {
            ThornLenth = thornLength;
            HasThorns = true;
        }

        public override void Recycle()
        {
            Console.WriteLine("Пожалуй розы лучше подарить, чем выбрасывать!");
        }

        public override string ToString()
        {
            return $"{this.GetType()} {Name} {LifeForm} {GrowLocation} {Color} {Diameter} {HasThorns} {ThornLenth} \t Цена: {Cost}";
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + ThornLenth.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                Rose m = obj as Rose; // возвращает null если объект нельзя привести к типу Roze
                if (m as Rose == null)
                    return false;

                return m.Name == this.Name && m.ThornLenth == this.ThornLenth;
            }
            else
            {
                return false;
            }

        }

    }
}
