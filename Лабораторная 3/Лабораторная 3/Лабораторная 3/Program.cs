using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Создать класс Customer: id, Фамилия, Имя, Отчество, 
    Адрес, Номер кредитной карточки, баланс. Свойства и 
    конструкторы должны обеспечивать проверку 
    корректности. Добавить методы зачисления и списания
    сумм на счет.
     Создать массив объектов. Вывести:
    a) список покупателей в алфавитном порядке;
    b) список покупателей, у которых номер кредитной карточки 
    находится в заданном интервале.
*/

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Customer customer1 = new Customer(Guid.NewGuid(), "Игоренко", "Николай", "Васильевич", "г.Могилёв, ул. Крестьянская, д. 21, кв. 52", 7340930482768764, 36229);

                Customer customer2 = new Customer();

                Customer[] customers = new Customer[7];
                customers[0] = new Customer(Guid.NewGuid(), "Смирнов", "Павел", "Валентинович", "г.Гомель, ул. Советская, д. 25а, кв. 24", 2343253487549364, 26439);
                customers[1] = new Customer(Guid.NewGuid(), "Павлов", "Игорь", "Сергеевич", "г.Минск, ул. Белорусская, д. 21, кв. 36", 6284275630582759, 14256);
                customers[2] = new Customer(Guid.NewGuid(), "Миронов", "Владислав", "Николаевич", "г.Брест, ул. Клермон Ферран, д. 2, кв. 1", 1038472837502758, 1223145);
                customers[3] = new Customer(Guid.NewGuid(), "Тимонович", "Прохор", "Викторович", "г.Витебск, ул. Чижова, д. 115, кв. 95", 4839164727361847, 6432);
                customers[4] = new Customer(Guid.NewGuid(), "Даниленко", "Кирилл", "Александрович", "г.Новополоцк, ул. Владимирская, д. 52б, кв. 83", 2847293827460192, 162423);
                customers[5] = customer1;
                customers[6] = customer2;

                Array.Sort(customers, (x, y) => String.Compare(x.Surname, y.Surname));

                Console.WriteLine("\t\t\tСписок клиентов в алфавитном порядке:\n");
                foreach (Customer customer in customers)
                {
                    Console.WriteLine(customer.ToString());
                }

                Console.WriteLine("\t\tСписок клиентов, у которых номер кредитной карточки");
                Console.WriteLine("\t\t\tнаходится в заданном интервале:\n");

                foreach (var customer in customers)
                {
                    if ( 3000000000000000 < customer.NumOfCard && customer.NumOfCard < 9000000000000000 )
                    {
                        customer.PrintIt();
                    }
                }

            }
            catch (Exception excpt)
            {
                Console.WriteLine(excpt);
            }
        }
    }
}
