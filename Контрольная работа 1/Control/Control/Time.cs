using System;
using System.Collections.Generic;
using System.Text;

namespace Control
{
    public enum PM_AM : uint
    { PM = 1, AM = 0}

    public class Time : ICheck
    {
        public uint h { get; set; }
        public uint m { get; set; }
        public uint s { get; set; }
        public PM_AM someTime;

        // переопределение ToString
        public override string ToString()
        {
            string ss = s.ToString();
            string sm = m.ToString();
            string sh = h.ToString();
            string some = someTime.ToString();
            string time = "Сейчас " + sh + ":" + sm + ":" + ss + " " + some;
            return time;
        }
        public static bool operator >(Time a, Time b)
        {
            if (a.m > b.m || ((a.m == b.m) && (a.s > b.s)))
                return true;
            else return false;
        }

        public static bool operator <(Time a, Time b)
        {
            if (b > a) return true;
            else return false;
        }

        public Time(uint h, uint m, uint s)
        {
            this.h = h;
            this.m = m;
            this.s = s;
        }
        public Time() { someTime = new PM_AM(); }

        public void Check()
        {
            if (h >= 21 && h <= 24 || h>=0 && h<=4)
            {
                Console.WriteLine("Ночь");
            }
            if (h >= 17 && h <= 21)
            {
                Console.WriteLine("Вечер");
            }
            if (h >= 10 && h <= 17)
            {
                Console.WriteLine("День");
            }
            if (h >= 4 && h <= 10)
            {
                Console.WriteLine("Утро");
            }
        }
    }
}
