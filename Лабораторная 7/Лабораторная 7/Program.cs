using System;
using System.Diagnostics;

namespace Лабораторная_7
{
    interface IRemove
    {
        void Recycle();
    }

    class Printer
    {
        public void IAmPrinting(Plant obj)
        {
            Console.WriteLine(obj.ToString());
        }
    }

    enum Season : short
    {
        Winter = 1,
        Spring,
        Summer,
        Fall,
    }

    struct Buyer : IRemove
    {

        public string Name;
        public short Age;
        public bool HasDiscount;
        public Buyer(string name, short age)
        {
            Name = name;
            Age = age;
            // HasDiscount = discount;
            HasDiscount = true;
        }

        public void Recycle()
        {
            throw new NotImplementedException();
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Покупатель {Name} {Age} \t Скидка: {HasDiscount}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //lab7 exceptions
            Flower testFlower = new Flower("Тюльпан", "Лес", "Желтый", 6, 9.9);

            //e1
            try
            {
                testFlower.Cost = 0;
            }
            catch (FlowerExceptions.CostIsZeroException e)
            {
                Console.WriteLine("Цена присвоена неверно " + e);
                Console.WriteLine(e.Message);
                //Console.WriteLine(e.Source);
                //Console.WriteLine(e.StackTrace);
                //Console.WriteLine(e.TargetSite);
            }

            //e2
            try
            {
                testFlower.Cost = -15.6;
            }
            catch (FlowerExceptions.CostLessThanZeroException e)
            {
                Console.WriteLine(e.Message);
            }

            //e3
            try
            {
                testFlower.Color = "Черный";
            }
            catch (FlowerExceptions.CantBeBlackException e)
            {
                Console.WriteLine(e.Message);
            }

            //e4
            try
            {
                int a = 0;
                int b = 7 / a;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }

            //e5
            try
            {
                int[] nums = new int[2];
                nums[3] = 15;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

            //e6
            try
            {
                checked
                {
                    int c = int.MaxValue;
                    c++;
                }
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }

            //try-catch-finally
            try
            {
                int a = 0;
                int d = 10 / a;
            }
            catch (Exception e)
            {
                Console.WriteLine("Возникла непредвиденная ошибка, описание ошибки:");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.TargetSite);
                Console.WriteLine(e.Source);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Console.WriteLine("Finally выполняется всегда!");
            }
        }
    }
}
