using System;
using System.Collections.Generic;
using System.Text;

namespace Лабораторная_5
{
    class Glasiolus : Flower
    {
        public int FlowersOnStem
        {
            get; set;
        }

        public Glasiolus(string name, string growLocation, string color, int diameter, int flowersOnStem) : base(name, growLocation, color, diameter)
        {
            FlowersOnStem = flowersOnStem;
        }

        public override string ToString()
        {
            return $"{this.GetType()} {Name} {LifeForm} {GrowLocation} {Color} {Diameter} {FlowersOnStem}";
        }
    }
}
