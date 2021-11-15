using System;
using System.Collections.Generic;
using System.Text;

namespace Лабораторная_6
{
    public class Bouquet : IRemove
    {
        public string BouquetName { set; get; }
        public Paper BouquetPaper { set; get; }
        public List<Flower> Flowers { set; get; } = new List<Flower>();
        public Bouquet(string bouquetName, Paper myPaper, params Flower[] flowers)
        {
            BouquetName = bouquetName;
            BouquetPaper = myPaper;
            foreach (Flower s in flowers)
            {
                Flowers.Add(s);
            }
        }

        public Bouquet()
        {
            BouquetName = "Не задано";
            BouquetPaper = null;
        }

        public void AddFlower(Flower f)
        {
            Flowers.Add(f);
        }

        public void RemFlower(Flower f)
        {
            Flowers.Remove(f);
        }

        public void GetInfo()
        {
            Console.WriteLine($"\n {BouquetName} \n {BouquetPaper}");
            foreach (var s in this.Flowers)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();
        }

        public void Recycle()
        {
            Console.WriteLine($"Букет {BouquetName} отправлен в переработку. ");
        }
    }
}
