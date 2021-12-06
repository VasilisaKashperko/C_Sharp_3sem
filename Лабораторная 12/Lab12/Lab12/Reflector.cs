using System;
using System.IO;
using System.Reflection;

namespace Lab12
{
    static class Reflector
    {
        // Метод записи в файл
        static void Write(string text)
        {
            string path = "output.txt";
            File.AppendAllText(path, text);
        }

        // Определение имени сборки, в которой определен класс
        public static void GetAssemblyName<T>(T obj)
        {
            Assembly a = typeof(T).Assembly; // класс, представляющий сборку и позволяющий манипулировать этой сборкой
            Write("Имя сборки, в которой определен класс: " + a.FullName + "\n\n");
            Console.WriteLine("Имя сборки, в которой определен класс: " + a.FullName + "\n");
        }

        // MemberInfo: базовый абстрактный класс,
        // определяющий общий функционал для классов EventInfo, FieldInfo, MethodInfo и PropertyInfo

        // Есть ли публичные конструкторы?
        public static void IsPublicConstructors<T>(T obj)
        {
            ConstructorInfo[] constructorInfo = typeof(T).GetConstructors(); //класс, представляющий конструктор
            for (int i = 0; i < constructorInfo.Length; i++)
                if ((constructorInfo[i].IsPublic))
                {
                    Console.WriteLine("Класс Worker имеет публичный конструктор " + (i+1) + "\n");
                    Write("Класс Worker имеет публичный конструктор " + (i+1) + "\n");
                }
                else
                {
                    Console.WriteLine("Класс Worker не имеет публичный конструктор \n");
                    Write("Класс Worker не имеет публичный конструктор\n");
                }
        }

        // Извлекает все общедоступные публичные методы класса
        public static void GetAllMethods<T>(T obj)
        {
            MethodInfo[] methodInfo = typeof(T).GetMethods(); // хранит информацию об определенном методе
            Console.Write($"Извлекает все общедоступные публичные методы класса: \n");
            Write($"\nИзвлекает все общедоступные публичные методы класса: \n");
            foreach (MethodInfo method in methodInfo)
            {
                string modificator = "";
                if (method.IsStatic)
                    modificator += "static ";
                if (method.IsVirtual)
                    modificator += "virtual";
                Console.Write($"{modificator} {method.ReturnType.Name} {method.Name} \n");
                Write($"{modificator} {method.ReturnType.Name} {method.Name} \n");
            }
        }

        // Информация о полях и свойствах класса
        public static void GetFieldsProp<T>(T obj)
        {
            FieldInfo[] fieldInfo = typeof(T).GetFields(); // хранит информацию об определенном поле типа
            PropertyInfo[] propertyInfo = typeof(T).GetProperties(); // хранит информацию о свойстве
            Console.WriteLine("\nИнформация о полях:");
            Write("\nИнформация о полях:\n");
            foreach (FieldInfo field in fieldInfo)
            {
                Console.WriteLine($"{field.FieldType} {field.Name}");
                Write($"{field.FieldType} {field.Name}\n");
            }

            Console.WriteLine("\nСвойства класса:");
            Write("\nСвойства класса:\n");
            foreach (PropertyInfo prop in propertyInfo)
            {
                Console.WriteLine($"{prop.PropertyType} {prop.Name}\n");
                Write($"{prop.PropertyType} {prop.Name}\n");
            }
        }

        // Получаем все реализованные классом интерфейсы
        public static void GetAllInterfaces<T>(T obj)
        {
            Type[] interfacesInfo = typeof(T).GetInterfaces();
            Console.WriteLine("Все реализованные классом интерфейсы:");
            Write("\nВсе реализованные классом интерфейсы:\n");
            foreach (Type i in interfacesInfo)
            {
                Console.WriteLine(i.Name);
                Write(i.Name);
            }
        }

        // Выводит по имени класса имена методов, которые содержат заданный пользователем тип параметра
        public static void GetSpecialMethod<T>(T obj, string type)
        {
            MethodInfo[] methodInfo = typeof(T).GetMethods();
            Console.WriteLine("Выводит по имени класса имена методов, которые содержат заданный пользователем тип параметра:");
            Write("\n\nВыводит по имени класса имена методов, которые содержат заданный пользователем тип параметра:\n");
            foreach (MethodInfo method in methodInfo)
            {
                ParameterInfo[] parameters = method.GetParameters();
                string modificator = "";
                if (method.IsStatic)
                    modificator += "static ";
                if (method.IsVirtual)
                    modificator += "virtual";
                for (int i = 0; i < parameters.Length; i++)
                {
                    if (parameters[i].ParameterType.Name == type)
                    {
                        Console.Write($"{modificator} {method.ReturnType.Name} {method.Name} \n");
                        Write($"{modificator} {method.ReturnType.Name} {method.Name}\n");
                        break;
                    }
                }
            }
        }

        // Метод Invoke, который вызывает метод класса
        // 1) прочитать из текстового файла (имя класса и имя метода передаются в качестве аргументов)
        // 2) сгенерировать, используя генератор значений для каждого типа.
        public static void Invoke<S>(string methodName, string className, S parametrs)
        {
            //Чтобы динамически загрузить сборку в приложение, надо использовать статические методы Assembly.LoadFrom() или Assembly.Load().
            //Метод LoadFrom() принимает в качестве параметра путь к сборке.
            //Метод Load() в качестве его параметра передается дружественное имя сборки, которое нередко совпадает с именем приложения.

            Assembly asm = Assembly.LoadFrom("Lab12.dll");
            Type t = asm.GetType("Lab12." + className, true, true);

            object obj = Activator.CreateInstance(t);
            MethodInfo method = t.GetMethod(methodName);

            object result = method.Invoke(obj, new object[] { parametrs });
            Console.WriteLine(result);
        }

        // Метод Create создает объект переданного типа
        public static object Create(string className)
        {
            Assembly asm = Assembly.LoadFrom("Lab12.dll");
            Type t = asm.GetType("Lab12." + className, true, true);

            return Activator.CreateInstance(t);
        }

    }
}
