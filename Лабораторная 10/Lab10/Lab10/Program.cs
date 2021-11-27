using System;

namespace Lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            Worker theFirst = new Worker("Иван Кузьмич","Лектор",2400);
            Worker theSecond = new Worker("Валерий Владимирович","Лаборант",1400);
            Worker theThird = new Worker("Арина Николаевна","Лаборант",1500);
            Worker theFourth = new Worker("Надежда Александровна","Лектор",1900);

            Console.WriteLine(theFirst.ToString());
            Console.WriteLine(theSecond.ToString());
            Console.WriteLine(theThird.ToString());
            Console.WriteLine(theFourth.ToString());
            
            //theFirst.GetEnumerator();
        }
    }
}
