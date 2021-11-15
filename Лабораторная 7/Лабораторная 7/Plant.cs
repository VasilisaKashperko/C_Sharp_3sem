using System;
using System.Collections.Generic;
using System.Text;

namespace Лабораторная_7
{
    public abstract class Plant
    {
        public abstract void Recycle();
        public string Name
        {
            get; set;
        }

        public string LifeForm
        {
            get; set;
        }

        public Plant(string name, string lifeForm)
        {
            Name = name;
            LifeForm = lifeForm;
        }

        public override string ToString()
        {
            return $"{this.GetType()} {Name} {LifeForm}";
        }
    }
}
