using System;
using System.Collections.Generic;
using System.Text;

namespace Лабораторная_6
{
    public static class Controller
    {
        public static void SortByName(Bouquet bouquet)
        {
            bouquet.Flowers.Sort();
        }

        public static void FindByColor(Bouquet bouquet, string color)
        {
            foreach (var s in bouquet.Flowers)
            {
                if (s.Color == color)
                {
                    Console.WriteLine(s);
                }
            }
        }
    }
}
