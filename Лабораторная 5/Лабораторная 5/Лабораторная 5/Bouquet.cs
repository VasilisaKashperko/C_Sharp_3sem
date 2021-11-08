using System;
using System.Collections.Generic;
using System.Text;

namespace Лабораторная_5
{
    interface IRemove
    {
        void Recycle();
    }
    class Bouquet : IRemove
    {
        public string BouquetName { set; get; }
        public Paper BouquetPaper { set; get; }
        public Flower[] Flowers = new Flower[3];
        public Bouquet(string bouquetName, Paper myPaper, Rose myRose, Glasiolus myGlasiolus, Cactus myCactus)
        {
            BouquetName = bouquetName;
            BouquetPaper = myPaper;
            Flowers[0] = myRose;
            Flowers[1] = myGlasiolus;
            Flowers[2] = myCactus;
        }

        public override string ToString()
        {
            return $"{GetType()} {BouquetName} {BouquetPaper} {Flowers[0]} {Flowers[1]} {Flowers[2]}";
        }

        public void Recycle()
        {
            Console.WriteLine($"Букет {BouquetName} отправлен в переработку. ");
        }
    }
}
