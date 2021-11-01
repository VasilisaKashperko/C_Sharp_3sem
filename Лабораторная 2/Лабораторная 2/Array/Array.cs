using System;

namespace Array
{
    class Array
    {
        static void Main(string[] args)
        {
            // двумерный массив и вывод в виде матрицы
                Console.WriteLine("Двумерный массив и вывод в виде матрицы");
                int[,] mas = { { 1, 2 }, { 2, 1 } };
                int rows = mas.GetUpperBound(0) + 1; //Получает Индекс последнего элемента заданного измерения в массиве.
                int columns = mas.Length / rows;
                for (int ii = 0; ii < rows; ii++)
                {
                    for (int ij = 0; ij < columns; ij++)
                    {
                        Console.Write($"{mas[ii, ij]} ");
                    }
                    Console.WriteLine();
                }

            //одномерный массив строк
            Console.WriteLine("Одномерный массив строк");
                string[] items = { "ноутбук", "мышь", "система", "экран", "клавиатура" };
                for (int ij = 0; ij < items.Length; ++ij)
                {
                    Console.WriteLine(items[ij] + " ");
                }
                Console.WriteLine($"Длина массива: { items.Length}");

                Console.Write("Введите позицию элемента массива, который вы хотите заменить: ");
                int position = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите значение элемента массива: ");
                string value = Console.ReadLine();
                items[position] = value;
                for (int ij = 0; ij < items.Length; ++ij)
                {
                    Console.Write(items[ij] + " ");
                }
                Console.WriteLine();

            //ступенчатый массив вещественных чисел с 3-мя строками
                /*Если требуется очень длинный двумерный массив,
                 * который заполняется не полностью,
                 * т.е. такой массив, в котором используются не все,
                 * а лишь отдельные его элементы. */
            Console.WriteLine($"\nСтупенчатый массив вещественных чисел с 3-мя строками");

            int[][] arr = new int[3][];
            arr[0] = new int[2];
            arr[1] = new int[3];
            arr[2] = new int[4];

            Console.WriteLine("Введите 9 элементов массива через пробел: ");
            string[] arrayNumber = Console.ReadLine().Split(' ');
            int j = 0;
            do
            {

                Console.WriteLine();
                for (int li = 0; li < 2; ++li, j++)
                {
                    arr[0][li] = int.Parse(arrayNumber[j]);
                    Console.Write(arr[0][li] + "  ");
                }
                Console.WriteLine();
                for (int li = 0; li < 3; ++li, j++)
                {
                    arr[1][li] = int.Parse(arrayNumber[j]);
                    Console.Write(arr[1][li] + "  ");
                }
                Console.WriteLine();
                for (int li = 0; li < 4; ++li, j++)
                {

                    arr[2][li] = int.Parse(arrayNumber[j]);
                    Console.Write(arr[2][li] + "  ");
                }
            } while (j < arrayNumber.Length);

            // неявно типизированные переменные для хранения массива и строки
            var array3 = new[] { "1", "2", "3", "4", "5" };
            var string3 = "Abcdefg";
            Console.WriteLine("\nНеявно типизированные переменные для хранения массива и строки:" + array3 + " и " + string3);
        }
    }
}
