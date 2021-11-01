using System;

/*Так, если требуется указать, что выражение будет проверяться на переполнение,
 * следует использовать ключевое слово checked,
 * а если требуется проигнорировать переполнение — ключевое слово unchecked.
 * В последнем случае результат усекается, чтобы не выйти за пределы диапазона представления чисел для целевого типа выражения. */

namespace CheckedUnchecked
{
    class CheckedUnchecked
    {
        static void Main(string[] args)
        {
            int Fun1()
            {
                checked
                {
                    int x = int.MaxValue;
                    try
                    {
                        return x + 1;
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Переполнение");
                        return x;
                    }
                }
            }

            int Fun2()
            {
                unchecked
                {
                    int x = int.MaxValue;
                    try
                    {
                        return x + 1;
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Переполнение");
                        return x;
                    }
                }
            }
            Console.WriteLine(Fun1());
            Console.WriteLine(Fun2());
        }
    }
}
