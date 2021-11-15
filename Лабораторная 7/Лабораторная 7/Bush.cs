using System;
using System.Collections.Generic;
using System.Text;

namespace Лабораторная_7
{
    public class Bush : Plant, IRemove
    {
        public string GrowLocation
        {
            get; set;
        }

        public Bush(string name, string growLocation, string lifeForm = "Кустарник") : base(name, lifeForm)
        {
            GrowLocation = growLocation;
        }

        void IRemove.Recycle()
        {
            Console.WriteLine($"Куст {Name} переработали! *Интерфейс*");
        }
        public override void Recycle()
        {
            Console.WriteLine($"Куст {Name} переработали! *Абстрактный класс*");
        }

        virtual public void Uproot()
        {
            Console.WriteLine($"Куст {Name} был выкорчеван.");
        }

        public override string ToString()
        {
            return $"{this.GetType()} {Name} {LifeForm} {GrowLocation}";
        }
    }
}
