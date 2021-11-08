using System;
using System.Collections.Generic;
using System.Text;

namespace Лабораторная_5
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

        public Rose(string name, string growLocation, string color, int diameter, int thornLength) : base(name, growLocation, color, diameter)
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
            return $"{this.GetType()} {Name} {GrowLocation} {Color} {Diameter} {HasThorns} {ThornLenth}";
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
