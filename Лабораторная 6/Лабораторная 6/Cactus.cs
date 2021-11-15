using System;
using System.Collections.Generic;
using System.Text;

namespace Лабораторная_6
{
    class Cactus : Flower
    {
        public bool HasSingleFlower
        {
            get; set;
        }

        public Cactus(string name, string growLocation, string color, int diameter) : base(name, growLocation, color, diameter)
        {
            HasSingleFlower = true;
        }

        public override string ToString()
        {
            return $"{this.GetType()} {Name} {LifeForm} {GrowLocation} {Color} {Diameter} {HasSingleFlower}";
        }
    }
}
