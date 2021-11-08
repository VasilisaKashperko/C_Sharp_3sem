using System;

namespace Лабораторная_5
{
    class Printer
    {
        public void IAmPrinting(Plant obj)
        {
            Console.WriteLine(obj.ToString());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Bush myBush = new Bush("Шиповник", "Равнина");

            Flower myFlower = new Flower("Тюльпан", "Лес", "Желтый", 6);

            Rose myRose = new Rose("Роза голандская", "Равнина", "Красный", 5, 2);

            Glasiolus myGlad = new Glasiolus("Гладиолус обычкновенный", "Лес", "Белый", 3, 4);

            Cactus myCactus = new Cactus("Кактус великий", "Пустыня", "Салатовый", 3);

            Paper myPaper = new Paper("Розовый");

            Bouquet myBouquet = new Bouquet("Прелесть", myPaper, myRose, myGlad, myCactus);

            Console.WriteLine($"{myBush} \n {myFlower} \n {myRose} \n {myGlad} \n {myCactus} \n {myPaper} \n {myBouquet}");

            Plant myPlant = new Bush("Малина", "Лес"); // объект Plant создать нельзя, может хранить объекты производных классов

            //Преобразование Plant в Bush
            Console.WriteLine(myBush.Name);
            Console.WriteLine(myPlant.Name + " " + myPlant.LifeForm); // не можем вывести myPlant.growLocation, нужно преобразовать к Bush
            myBush = myPlant as Bush;
            if (myBush == null)
            {
                Console.WriteLine("Преобразование НЕ удалось");
            }
            else
            {
                Console.WriteLine(myBush.Name + " " + myBush.GrowLocation);
            }

            //Преобразование Roze в Flower
            Console.WriteLine(myFlower.Name);
            if (myRose is Flower)
            {
                myFlower = (Flower)myRose;
                Console.WriteLine(myFlower.Name); //  Roze преобразован во Flower, получить доступ к .ThornsLength невозможно.
            }
            else
            {
                Console.WriteLine("Преобразование не допустимо");
            }

            //Ссылка на Bush типа IRemove
            IRemove theBush = new Bush("Смородина", "Лес");
            //Вызовется метод интерфейса т. к. ссылка типа IRemove
            theBush.Recycle();

            Plant newBush;
            //Преобразование IRemove в Plant
            newBush = theBush as Plant;
            if (newBush == null)
            {
                Console.WriteLine("Преобразование НЕ удалось");
            }
            else
            {
                Console.WriteLine(newBush.Name); //вывести поле growLocation не получится.
                //Вызовется метод Recycle() от Plant, т. к. ссылка типа Plant
                newBush.Recycle();
            }

            Printer myPrinter = new Printer();
            dynamic[] myArray = new dynamic[] { myPlant, myBush, myFlower, myRose, myGlad, myCactus };
            foreach (var s in myArray)
            {
                myPrinter.IAmPrinting(s);
            }
        }
    }
}
