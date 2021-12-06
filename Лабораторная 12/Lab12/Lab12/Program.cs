using System;

// Рефлексия - процесс выявления типов во время выполнения приложения.

namespace Lab12
{
    class Program
    {
        static void Main()
        {
            Worker obj1 = new Worker(Guid.NewGuid(), "Павел Викторович", "декан", 3000);
            Customer obj2 = new Customer(Guid.NewGuid(), "Игоренко", "Николай", "Васильевич", "г.Могилёв, ул. Крестьянская, д. 21, кв. 52", 7340930482768764, 36229);

            Console.WriteLine("Работает рефлектор...\n");

            Reflector.GetAssemblyName(obj1);
            Reflector.IsPublicConstructors(obj1);
            Reflector.GetAllMethods(obj1);
            Reflector.GetFieldsProp(obj1);
            Reflector.GetAllInterfaces(obj1);
            Reflector.GetSpecialMethod(obj2, "String");
            Reflector.Invoke("Repeat", "Customer", "\nТЕСТИРОВКА");
            Console.WriteLine(Reflector.Create("Customer").ToString());
        }
    }
}
