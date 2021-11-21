using System;

namespace Lab9
{
    class Program
    {
        public delegate int LambdaExpression(int x, int y); // делегат без параметров

        static void Main(string[] args)
        {
            Director programmer1 = new Director(1400, "Программист_1");
            Director programmer2 = new Director(1000, "Программист_2");
            Director teacher1 = new Director(800, "Учитель_1");
            Director teacher2 = new Director(300, "Учитель_2");
            Director assistant1 = new Director(700, "Ассистент_1");
            Director assistant2 = new Director(200, "Ассистент_2");

            Console.WriteLine(programmer1.ToString());
            programmer1.Notify += DisplayGreenMessage;// добавляем обработчик события
            programmer1.ToPromote(600);
            programmer1.Notify -= DisplayGreenMessage;
            Console.WriteLine(programmer1.ToString());
            Console.WriteLine("\n- - - - - - - - - - - - - - -\n");

            Console.WriteLine(teacher2.ToString());
            teacher2.Notify += DisplayRedMessage;
            teacher2.Fine(400);
            teacher2.Notify -= DisplayRedMessage;
            Console.WriteLine(teacher2.ToString());
            Console.WriteLine("\n- - - - - - - - - - - - - - -\n");

            Console.WriteLine(assistant1.ToString());
            assistant1.Notify += DisplayRedMessage;
            assistant1.Fine(400);
            assistant1.Notify -= DisplayRedMessage;
            assistant1.Notify += DisplayGreenMessage;// добавляем обработчик события
            assistant1.ToPromote(600);
            assistant1.Notify -= DisplayGreenMessage;
            Console.WriteLine(assistant1.ToString());
            Console.WriteLine("\n- - - - - - - - - - - - - - -\n");

            Console.WriteLine("Сумма зарплат Программиста_1 и Ассистента_1 при помощи лямбда-выражения:");
            LambdaExpression sum = (x, y) => x + y;
            Console.WriteLine(sum(programmer1.Pay, assistant1.Pay));

            // обработчики событий
            static void DisplayGreenMessage(string message)
            {
                // Устанавливаем красный цвет символов
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(message);
                // Сбрасываем настройки цвета
                Console.ResetColor();
            }
            static void DisplayRedMessage(String message)
            {
                // Устанавливаем красный цвет символов
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                // Сбрасываем настройки цвета
                Console.ResetColor();
            }
            Console.WriteLine("\n- - - - - - - - - - - - - - -\n");

            Console.ReadKey();

            string myString = "Never give up and everything will be OK";

            Console.WriteLine($"Делаем все буквы строчными\n{ChangingStrings.TaskToLower(myString)}\n");
            Console.WriteLine($"Добавляем в конце точку\n{ChangingStrings.AddChar(myString, '.')}\n");
            Console.WriteLine($"Меняем i на I\n{ChangingStrings.Change(myString)}\n");
            Console.WriteLine($"Делаем все буквы заглавными\n{ChangingStrings.TaskToUpper(myString)}\n");
            Console.WriteLine($"Добавляем в конце восклицательный знак\n{ChangingStrings.AddExclamation(myString)}");

            Console.WriteLine("\n- - - - - - - - - - - - - - -\n");

            Console.ReadKey();

            // встроенные делегаты

            // Делегат Action является обобщенным, принимает параметры (от 0 до 16) и возвращает значение void
            // Делегат Predicate<T> используется для сравнения, сопоставления некоторого объекта T определенному условию.
            // Делегат Func возвращает результат действия и может принимать параметры. Также часто используется в качестве параметра в методах.

            Console.WriteLine("Обработка строки с использованием стандартных типов делегатов:");

            Action<string> Operation = Lower;
            Action<string, char> Operation1 = DelegateAddChar;
            Func<string, string> Operation2 = Upper;
            Operation += Add;
            Operation += Chng;

            Operation(myString);
            Operation1(myString,'.');
            Console.WriteLine(Operation2(myString));
            Console.WriteLine();
        }

        // для встроенных делегатов
        static void Lower(string a)
        {
            Console.WriteLine(a.ToLower());
        }

        static void DelegateAddChar(string a, char letter)
        {
            Console.WriteLine(a += letter);
        }

        static void Add(string a)
        {
            Console.WriteLine(a += "!");
        }

        static string Upper(string str)
        {
            return str.ToUpper();
        }

        static void Chng(string a)
        {
            Console.WriteLine(a.Replace("i", "I"));
        }
    }
}
