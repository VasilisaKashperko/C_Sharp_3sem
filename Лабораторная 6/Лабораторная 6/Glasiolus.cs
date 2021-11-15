using System;
using System.Collections.Generic;
using System.Text;

namespace Лабораторная_6
{
    class Glasiolus : Flower
    {
        public int FlowersOnStem
        {
            get; set;
        }

        public Season Season { set; get; }

        public Glasiolus(string name, string growLocation, string color, int diameter, int flowersOnStem, Season season) : base(name, growLocation, color, diameter)
        {
            FlowersOnStem = flowersOnStem;
            Season = season;
        }

        public override string ToString()
        {
            return $"{this.GetType()} {Name} {LifeForm} {GrowLocation} {Color} {Diameter} {FlowersOnStem} {(int)Season}";
        }
    }
}
