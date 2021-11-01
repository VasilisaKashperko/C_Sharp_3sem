using System;
using System.Linq; //LINQ (Language-Integrated Query) представляет простой и удобный язык запросов к источнику данных.
/*Локальные функции — это закрытые методы типа, 
 * вложенные в другой член. Они могут быть вызваны только из содержащего их члена.*/
namespace LocalFunction
{
    class LocalFunction
    {
        static void Main(string[] args)
        {
            (int, int, int, char) localFun(int[] mass, string st)
            {
                int max = mass.Max();
                int min = mass.Min();
                int sum = mass.Sum();
                char sim = st.First();
                return (max, min, sum, sim);
            }
            int[] mass = { 1, 2, 3, 4, 5 };
            string st = "Hello, World";
            Console.WriteLine(localFun(mass, st));
        }
    }
}
