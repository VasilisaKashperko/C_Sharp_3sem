using System;

// 1 - Flower
// 2 - Plant, Bush
// 3 - Paper
// 4 - Bush (интерфейс - Bouquet, абстрактный класс - Plant)
// 5 - Program (as, is)
// 6 - Во всех
// 7 - Program

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
            Bush myBush = new Bush("Шиповник", "Лес");

            Flower myFlower = new Flower("Тюльпан", "Поле", "Желтый", 6);

            Rose myRose = new Rose("Роза", "Поле", "Красный", 5, 2);

            Glasiolus myGlad = new Glasiolus("Гладиолус", "Лес", "Белый", 3, 4);

            Cactus myCactus = new Cactus("Алоэ", "Пустыня", "Зеленый", 3);

            Paper myPaper = new Paper("Розовый");

            Bouquet myBouquet = new Bouquet("Дар весны", myPaper, myRose, myGlad, myCactus);

            Console.WriteLine($"{myBush} \n {myFlower} \n {myRose} \n {myGlad} \n {myCactus} \n {myPaper} \n {myBouquet}");

            Plant myPlant = new Bush("Малина", "Лес"); // объект Plant создать нельзя, можно хранить объекты производных классов

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

            //Преобразование Rose в Flower
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
