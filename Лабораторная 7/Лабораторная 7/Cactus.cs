using System;
using System.Collections.Generic;
using System.Text;

namespace Лабораторная_7
{
    class Cactus : Flower
    {
        public bool HasSingleFlower
        {
            get; set;
        }

        public Cactus(string name, string growLocation, string color, int diameter, double cost) : base(name, growLocation, color, diameter, cost)
        {
            HasSingleFlower = true;
        }

        public override string ToString()
        {
            return $"{this.GetType()} {Name} {LifeForm} {GrowLocation} {Color} {Diameter} {HasSingleFlower} \t Цена: {Cost}";
        }
    }
}
