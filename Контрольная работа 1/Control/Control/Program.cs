using System;

namespace Control
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1
            Console.WriteLine((int)char.MaxValue);

            string str = "-885";
            int inegerVal = Int32.Parse(str);
            Console.WriteLine(inegerVal + "\n");

            // 2
            Time myTime = new Time(5,43,12);
            myTime.someTime = (PM_AM)1;
            Console.WriteLine(myTime.ToString()+"\n");

            Time myTime1 = new Time();
            myTime1.h = 10;
            myTime1.m = 10;
            myTime1.s = 10;
            myTime1.someTime = (PM_AM)1;
            Console.WriteLine(myTime1.ToString() + "\n");

            Time myTime2 = new Time(7, 43, 12);
            var test = myTime > myTime2;
            Console.WriteLine(test + "\n");

            // 3
            Time test1 = new Time();
            test1.h = 16;
            test1.m = 20;
            test1.s = 45;
            test1.someTime = (PM_AM)1;
            Console.WriteLine(test1.ToString());

            FullTime test2 = new FullTime();
            test2.h = 6;
            test2.m = 7;
            test2.s = 42;
            test2.someTime = (PM_AM)0;
            Console.WriteLine(test2.ToString() + "\n");

            test1.Check();
            test2.Check();

        }
    }
}
