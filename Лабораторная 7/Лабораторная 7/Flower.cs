using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Лабораторная_7
{
    public class Flower : Bush, IRemove, IComparable<Flower>
    {
        private string color;
        public string Color
        {
            get
            {
                return color;
            }
            set
            {
                //Debug.Assert(value == "Черный");
                //try
                //{
                    if (value == "Черный")
                    {
                        throw new FlowerExceptions.CantBeBlackException("Черные цветы нам не нужны!");
                    }
                    else
                    {
                        color = value;
                    }
                //}
                //catch (FlowerExceptions.CantBeBlackException e)
                //{
                //    Console.WriteLine(e.Message);
                //    throw;
                //}
            }
        }

        public int Diameter
        {
            get; set;
        }

        private double cost;
        public double Cost
        {
            get { return cost; }
            set
            {

                    if (value < 0)
                    {
                        throw new FlowerExceptions.CostLessThanZeroException("Цена цветка не может быть отрицательной!");
                    }
                    else if (value == 0)
                    {
                        throw new FlowerExceptions.CostIsZeroException("Цветы не бесплатны!");
                    }
                    else
                    {
                        cost = value;
                    }

            }
        }

        public Flower(string name, string growLocation, string color, int diameter, double cost) : base(name, growLocation)
        {
            Color = color;
            Diameter = diameter;
            Cost = cost;
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
            return $"{this.GetType()} {Name} {LifeForm} {GrowLocation} {Color} {Diameter} \t Цена:  {Cost} р";
        }
    }
}
