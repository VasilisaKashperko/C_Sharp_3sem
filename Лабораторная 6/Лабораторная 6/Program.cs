using System;

namespace Лабораторная_6
{
    class Printer
    {
        public void IAmPrinting(Plant obj)
        {
            Console.WriteLine(obj.ToString());
        }
    }

    interface IRemove
    {
        void Recycle();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Bush myBush = new Bush("Шиповник", "Равнина");
            Flower myFlower = new Flower("Тюльпан", "Лес", "Желтый", 6);
            Rose myRoze = new Rose("Роза голандская", "Равнина", "Красный", 5, 2);
            Glasiolus myGlad = new Glasiolus("Гладиолус", "Лес", "Белый", 3, 4, Season.Autumn);
            Cactus myCactus = new Cactus("Алоэ", "Пустыня", "Салатовый", 3);
            Paper myPaper = new Paper("Розовый");

            Plant myPlant = new Bush("Малина", "Лес"); // объект Plant создать нельзя, может хранить объекты производных классов

            //lab6
            Console.WriteLine($"{Season.Winter}, {Season.Spring}, {Season.Summer}, {Season.Autumn}");
            Console.WriteLine($"{(int)Season.Winter}, {(int)Season.Spring}, {(int)Season.Summer}, {(int)Season.Autumn}");

            Buyer person1;
            //person1.ShowInfo();  Вызвать метод объекта нельзя, нужно проинициализировать поля.
            person1.Name = "Lisi";
            person1.Age = 19;
            person1.HasDiscount = true;
            person1.ShowInfo();

            Buyer person2 = new Buyer();
            person2.Name = "Jack";
            person2.Age = 29;
            person2.HasDiscount = false;
            person2.ShowInfo();

            Buyer person3 = new Buyer("Tom", 22, true);
            person3.ShowInfo();

            Bouquet myBouquet = new Bouquet("Букет Рассвет", myPaper, myRoze, myGlad, myCactus);
            myBouquet.GetInfo();

            Flower myTulpan = new Flower("Тюльпан", "Лес", "Желтый", 6);
            myBouquet.AddFlower(myTulpan);
            myBouquet.GetInfo();

            Controller.SortByName(myBouquet);
            myBouquet.GetInfo();

            Controller.FindByColor(myBouquet, "Желтый");
        }
    }
}
