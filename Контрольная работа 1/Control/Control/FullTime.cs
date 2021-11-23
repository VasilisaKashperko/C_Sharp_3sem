using System;
using System.Collections.Generic;
using System.Text;

namespace Control
{
    interface ICheck 
    {
        void Check();
    }
    public class FullTime : Time, ICheck
    {
        public FullTime() : base()
        {
        }

        public new void Check()
        {
                uint vh = 24 - h;
                uint vmin = 60 - m;
                uint vsec = 60 - s;

                Console.WriteLine($"Осталось до полуночи: {vh}:{vmin}:{vsec}");
        }
    }
}
