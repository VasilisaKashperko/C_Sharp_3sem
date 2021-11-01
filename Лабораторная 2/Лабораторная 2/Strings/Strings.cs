using System;
using System.Text;

/*Шаблонными литералами называются строковые литералы,
 * допускающие использование выражений внутри,
 * обозначаемых знаком $ и фигурными скобками (${выражение}).
 * Позволяют использовать многострочные литералы и строковую интерполяцию.
*/
namespace Strings
{
    class Strings
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Введите номер задания (1-4), по которому нужно вывести результат:");
            string selection = Console.ReadLine();
            switch (selection)
            {
                case "1":
                    First();
                    break;
                case "2":
                    Second();
                    break;
                case "3":
                    Third();
                    break;
                case "4":
                    Fourth();
                    break;
                default:
                    Console.WriteLine("Вы ввели неправильную цифру!");
                    Environment.Exit(0);
                    break;
            }
            
        }

        static void First()
        {
            char[] a1 = { 'w', 'o', 'r', 'd' };
            string string1 = new string(a1);
            Console.WriteLine(string1);

            string string2 = new string('х', 20);
            Console.WriteLine(string2);

            string string3 = null;
            Console.WriteLine(string3);

            Console.WriteLine("Oh, hello");
            Console.WriteLine("Привет всем \"Вам\"");
            Console.WriteLine("Привет \nи мне\n");

        }

        static void Second()
        {
            // объединение //

            string s1 = "Конкан";
            string s2 = "тенация";
            string s3 = s1 + s2;
            Console.WriteLine(s1 + s2);
            Console.WriteLine(String.Concat(s3));//Метод Concat является статическим методом класса String

            string s5 = "Чисти";
            string s6 = "зубы";
            string s7 = "каждый";
            string s8 = "день";
            string s9 = "обязательно!";
            string[] values = new string[] { s5, s6, s7, s8, s9 };

            String s10 = String.Join(" ", values);
            Console.WriteLine(String.Join(" ", values) + " " + s10);

            Console.WriteLine($"{s1}{s2}");
            int x = 8;
            int y = 7;
            string result = $"{x} + {y} = {x + y}";
            Console.WriteLine(result); // 8 + 7 = 15
            //Интерполяция - форматирование строки - способ соединения строк через вставку значений переменных в строку-шаблон с помощью фигурных скобок.

            // копирование строк //
            // Clone - возвращает ссылку на данный экземпляр класса String.

            string p = s1;

            char[] charArr = new char[] { 'H', 'e', 'l', 'l', 'o', ' ', 'w', 'o', 'r', 'l', 'd' };
            string s11 = "string";
            s11.CopyTo(1, charArr, 0, 5);
            Console.WriteLine(charArr);

            //string s4 = "Hello";
            //string s54 = string.Copy(s4);
            //Console.WriteLine(s54);

            // выделение подстроки
            string newString = "Привет тебе и тебе";
            string subNewString = "тебе";
            int indexOfSub = newString.IndexOf(subNewString);
            int indexOfSub1 = newString.LastIndexOf(subNewString);
            Console.WriteLine("Первый индекс: " + indexOfSub + ", последний индекс: " + indexOfSub1);

            // разделение строки на слова//
            string s = "You win. You lose.";

            string[] subs = s.Split(' ');

            foreach (var sub in subs)
            {
                Console.WriteLine($"Substring: {sub}");
            }

            // вставка подстроки //
            string text = "Хороший день";
            string subString = "сегодня ";

            text = text.Insert(8, subString);
            Console.WriteLine(text);

            // удаление заданной подстроки //
            // индекс последнего символа
            int ind = text.Length - 3;
            // вырезаем последний символ
            text = text.Remove(ind);
            Console.WriteLine(text);
            // вырезаем первые два символа
            text = text.Remove(0, 2);
            Console.WriteLine(text);

            string phrase = "look at me now";
            Console.WriteLine("До: " + phrase);
            phrase = phrase.Replace(" now", "");
            Console.WriteLine("После: " + phrase);
        }
        static void Third()
        {
            string emptyString = "";
            string emptyString1 = string.Empty;
            string nullString = null;
            string notAnEmpty = "Не путая строка";

            string[] array = { emptyString, nullString };

            Console.WriteLine(String.IsNullOrEmpty(emptyString));
            Console.WriteLine(String.IsNullOrEmpty(emptyString1));
            Console.WriteLine(String.IsNullOrEmpty(nullString));
            Console.WriteLine(String.IsNullOrEmpty(notAnEmpty));

            string con = emptyString + nullString; //сцепление
            Console.WriteLine(con);
            Console.WriteLine("Equals: " + (emptyString.Equals(nullString)));
            Console.WriteLine("CompareTo: " + emptyString.CompareTo(nullString));
            Console.WriteLine("String.Concat: " + String.Concat(nullString, emptyString));
            Console.WriteLine("Interpolation: " + $"{nullString}{emptyString}");

        }

        static void Fourth()
        {
            //StringBuilder - класс - Предоставляет изменяемую строку символов. Этот класс не наследуется.
            StringBuilder sb = new StringBuilder("Hello, World");
            Console.WriteLine($"Удаление c 4 позиций 2-ух символов: {sb.Remove(4, 2)}");
            sb = sb.Insert(0, "!!!");
            sb = sb.Insert(13, "!!!");
            Console.WriteLine($"Добавление новых символов в начало и конец строки: {sb}");
        }
    }
}
