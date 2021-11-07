using System;

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
    public partial class Customer //Частичные классы (partial classes) – конструкция, которая позволяет определить один класс в нескольких файлах.
    {
        public static string about = "Этот класс о клиентах.";

        private static int count; //Ключевое слово static - объявление константы или типа неявно является членом static. На член static невозможно ссылаться через экземпляр, а можно только через имя типа. 

        private readonly Guid id;
        private string surname;
        private string name;
        private string patronymic;
        private string address;
        private ulong numOfCard;
        private ulong balance;

        // Свойства

        public Guid Id { get => id; }
        public string Surname { get => surname; set { surname = value; } }
        public string Name { get => name; set { name = value; } }
        public string Patronymic { get => patronymic; set { patronymic = value; } }
        public string Address { get => address; set { address = value; } }
        public ulong NumOfCard
        {
            get { return numOfCard; }
            set
            {
                if (value > 0000000000000001 && value <= 9999999999999999)
                    numOfCard = value;
                else
                    Console.WriteLine("Неверный номер карты!");
            }
        }
        public ulong Balance { get => balance; set { balance = value; } }

        //Конструкторы
        // с параметрами
        public Customer(Guid id, string surname, string name, string patronymic, string address, ulong numOfCard, ulong balance)
        {
            if (numOfCard > 0000000000000001 && numOfCard <= 9999999999999999)
            {
                this.id = id;
                this.surname = surname;
                this.name = name;
                this.patronymic = patronymic;
                this.address = address;
                this.numOfCard = numOfCard;
                this.balance = balance;
                Customer.count++;
            }
            else
                throw new Exception("Некорректный ввод данных! Проверьте номер карты или id клиента.");
        }

        // без параметров
        public Customer()
        {
            surname = "Котов";
            name = "Николай";
            patronymic = "Алексеевич";
            address = "г.Гродно, ул. Партизанская, д. 62, кв. 1";
            numOfCard = 1111111111111111;
            balance = 88727319918;
        }

        // с параметрами по умолчанию
        public Customer(Guid id, string patronymic, ulong numOfCard, ulong balance, string surname = "Мышович", string name = "Игорь")
        {
            this.id = id;
            this.surname = surname;
            this.name = name;
            this.patronymic = patronymic;
            this.numOfCard = numOfCard;
            this.balance = balance;
        }

        // статический
        //static Customer()
        //{
        //    Console.WriteLine("Ваши данные:");
        //}

        // закрытый
        private Customer(Guid id, string surname) 
        {
            this.id = id;
            this.surname = surname;
        }
        // предотвращает для создания объекта класса из-вне. Используется в синглтонах и фабриках.

        public override string ToString() // переопределение метода ToString
        {
            return  $"ID: {this.id}\n" +
                    $"Фамилия: {this.surname}\n" +
                    $"Имя: {this.name}\n" +
                    $"Отчество: {this.patronymic}\n" +
                    $"Адрес: {this.address}\n" +
                    $"Номер карты: {this.numOfCard}\n" +
                    $"Баланс: {this.balance} рублей\n";
        }

        // Метод вывода фамилии клиента
        public void Print(ref Customer customer, out string printSurname)
        {
            printSurname = customer.surname;
            Console.WriteLine(printSurname);
        }
        // Метод вывода информации о классе
        public static string GetInfoAboutClass()
        {
            return about;
        }

        public void PrintIt()
        {
            Console.WriteLine(this.ToString());
        }
    }
}
