using System;
using System.Collections.Generic;
using System.Text;

namespace Лабораторная_7
{
    class Glasiolus : Flower
    {
        public int FlowersOnStem
        {
            get; set;
        }

        public Season Season { set; get; }

        public Glasiolus(string name, string growLocation, string color, int diameter, int flowersOnStem, double cost, Season season) : base(name, growLocation, color, diameter, cost)
        {
            FlowersOnStem = flowersOnStem;
            Season = season;
        }

        public override string ToString()
        {
            return $"{this.GetType()} {Name} {LifeForm} {GrowLocation} {Color} {Diameter} {FlowersOnStem} {(int)Season}  \t Цена: {Cost}";
        }
    }
}
