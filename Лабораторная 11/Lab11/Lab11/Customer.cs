using System;
using System.Collections.Generic;
using System.Text;

namespace Lab11
{
    public class Player
    {
        public string Name { get; set; }
        public string Team { get; set; }
    }
    public class Game
    {
        public string Name { get; set; }
        public string Developer { get; set; }
    }

    public partial class Customer //Частичные классы (partial classes) – конструкция, которая позволяет определить один класс в нескольких файлах.
    {
        public static string about = "Этот класс о клиентах.";

        private static int count; //Ключевое слово static - объявление константы или типа неявно является членом static. На член static невозможно ссылаться через экземпляр, а можно только через имя типа. 

        private string name;
        private int balance;

        // Свойства

        public string Name { get => name; set { name = value; } }

        public int Balance { get => balance; set { balance = value; } }

        //Конструкторы
        // с параметрами
        public Customer(string name, int balance)
        {

                this.name = name;
                this.balance = balance;
                Customer.count++;
        }

        // без параметров
        public Customer()
        {
            name = "Николай";
            balance = 88727;
        }

        // с параметрами по умолчанию
        public Customer(int balance, string name = "Игорь")
        {
            this.name = name;
            this.balance = balance;
        }

        public override string ToString() // переопределение метода ToString
        {
            return  $"Имя: {this.name}\n" +
                    $"Баланс: {this.balance} рублей\n";
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
