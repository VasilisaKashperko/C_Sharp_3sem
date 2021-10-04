using System;

/* Литерал — запись в исходном коде компьютерной программы,
представляющая собой фиксированное значение.
Литералами также называют представление значения некоторого типа данных. */

namespace Лабораторная_2
{
    class Program
    {
        static void Main(string[] args)
        {
            ////////// ЗАДАНИЕ 1 //////////

            Console.WriteLine($"size of int = {sizeof(int)}");
            Console.WriteLine($"size of bool = {sizeof(bool)}");

            bool valueBool = true;
            Console.WriteLine(valueBool ? "Checked" : "Not checked" + " " + valueBool.GetType());
            Console.WriteLine(true ? "Checked" + "\n" : "Not checked"+"\n");

            sbyte valueSByte = 110; //От -128 до 127. Знаковое 8-битное целое число
            Console.WriteLine(valueSByte + " " + valueSByte.GetType()+"\n");

            byte valueByte = 255; // От 0 до 255. Беззнаковое 8-битное целое число
            Console.WriteLine(valueByte + " " + valueByte.GetType());
            Console.WriteLine(valueByte + " " + Convert.ToInt32(valueByte).GetType());
            Console.WriteLine(valueByte + " " + valueByte.GetType() + "\n");

            short valueShort = 31700;//От -32 768 до 32 767. Знаковое 16-битное целое число
            Console.WriteLine(valueShort + " "+ valueShort.GetType()+"\n");

            ushort valueUShort = 65535;//От 0 до 65 535. Беззнаковое 16-битное целое число
            Console.WriteLine(valueUShort + " " + valueUShort.GetType()+"\n");

            int valueInt = -2147483647;//От - 2 147 483 648 до 2 147 483 647. 32 - битное целое со знаком
            Console.WriteLine(valueInt + " " + valueInt.GetType() + "\n");

            uint valueUInt = 0;//От 0 до 4 294 967 295. Беззнаковое 32-битное целое число
            Console.WriteLine(valueUInt + " " + valueUInt.GetType() + "\n");

            long valueLong = -930492842343423; //От -9,223,372,036,854,775,808 до 9,223,372,036,854,775,807.	64-битное целое число со знаком
            Console.WriteLine(valueLong + " " + valueLong.GetType() + "\n");

            ulong valueUlong = 2322222222222222222; //От 0 до 18 446 744 073 709 551 615. Беззнаковое 64-битное целое число
            Console.WriteLine(valueUlong + " " + valueUlong.GetType() + "\n");

            char valueChar = 'A'; // хранит одиночный символ в кодировке Unicode и занимает 2 байта.
            char valueChar1 = '\u0420'; // \u - юникод, четырехсимвольное шестнадцатеричное представление символьного кода; \x - шестнадцатиричное значение
            Console.WriteLine(valueChar + " " + valueChar.GetType() + " "+ valueChar1 + " " + valueChar1.GetType() + "\n");

            double valueDouble = 12.3;
            Console.WriteLine(valueDouble + " " + valueDouble.GetType() + "\n");

            decimal valueDecimal = 0.251m;
            Console.WriteLine(valueDecimal + " " + valueDecimal.GetType() + "\n");

            float valueFloat = 3.1456789234f;
            Console.WriteLine(valueFloat + " " + valueFloat.GetType() + "\n");

            /*
            nint valueNInt = 8; //Зависит от платформы. 32 - битное или 64 - битное целое число со знаком
            Console.WriteLine($"size of nint = {sizeof(nint)}");
            Console.WriteLine($"size of nuint = {sizeof(nuint)}");
            // Использование версии языка preview.
            */

            object valueObject = "Hello";
            object valueObject1 = 3.14;
            Console.WriteLine($"Объект 1: {valueObject}\nОбъект 2: {valueObject1}");
            Console.WriteLine(valueObject.GetType() + " " + valueObject1.GetType() + "\n");

            var valueVar = 93;
            Console.WriteLine(valueVar + " " + valueVar.GetType());
            valueVar = 100;
            //valueVar = 100.9;
            Console.WriteLine(valueVar + " " + valueVar.GetType());
            //valueVar = "Hi";
            Console.WriteLine(valueVar + " " + Convert.ToSingle(valueVar).GetType());
            Console.WriteLine(valueVar + " " + valueVar.GetType() + "\n");

            dynamic valueDynamic = "Hi";
            Console.WriteLine(valueDynamic + " " + valueDynamic.GetType());
            valueDynamic = 93;
            Console.WriteLine(valueDynamic + " " + valueDynamic.GetType() + "\n");

            dynamic dyn = 1;
            object obj = 1;
            dyn = dyn + 3;
            Console.WriteLine(dyn+"\n");
            //obj = obj + 3;

            ////////// ЗАДАНИЕ 2 //////////

            byte a = 4;
            int b = a + 70;

            //byte a = 4;
            //byte b = a + 70;  // ошибка

            byte c = 4;
            byte d = (byte)(c + 70);

            ushort e = 4;
            byte f = (byte)e; // для сужающего преобразования

            int g = 4;
            int h = 6;
            byte i = (byte)(g + h);

            var j = (dynamic)"Привет";
            bool k = (bool)true;
            double l = double.Parse("23,56");
            float m = 392.222f;
            dynamic o = 9.333333m;
            int r = (int)1.34;

            var p = "Строчка";
            double q = 23.4;
            int ar = 1;
            long s = 1;
            ushort t = 42;

            Console.WriteLine($"a = {a}, b = {b}, c = {c}, d = {d}," +
                              $"e = {e}, f = {f}, g = {g}, h = {h}, " +
                              $"i = {i}, j = {j},\nk = {k}, l = {l}, " +
                              $"m = {m}, o = {o}, p = {p}, q = {q}, " +
                              $"ar = {r},\ns = {s}, t = {t}\n");

            Console.WriteLine(valueVar + " " + valueVar.GetType() + "\n");
            Console.WriteLine(valueVar + " " + Convert.ToSingle(valueVar).GetType());

            int n = Convert.ToInt32("46");

            string dateString = "05/01/1996";
            Convert.ToDateTime(dateString);


        }
    }
}
