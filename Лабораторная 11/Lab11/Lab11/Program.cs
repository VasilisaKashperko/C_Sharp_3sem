using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab11
{
    class Program
    {
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            #region [The first task]

            Console.WriteLine("\t\t\t\tЗадание 1");
            string[] year = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

            Console.WriteLine("\t\t\tСортировка по алфавиту");
            var alphabeth = from month in year orderby month select month;
            foreach (string months in alphabeth)
            {
                Console.WriteLine(months);
            }

            Console.WriteLine("\n\t\tВыборка из месяцев по длине строки, равной 4");
            int n = 8;
            var length = from month in year where month.Length == n select month;
            foreach (string months in length)
            {
                Console.WriteLine(months);
            }

            Console.WriteLine("\n\t\t\tВыборка из месяцев с буквой 'u' ");
            var u = from month in year where month.Contains('u') && month.Length >= 4 select month;

            foreach (string months in u)
            {
                Console.WriteLine(months);
            }

            Console.WriteLine("\n\t\tВыборка из месяцев: зимние и летние месяцы");
            var WinterSummer = from month in year
                               where month == year[0] || month == year[1] || month == year[7] || month == year[11] || month == year[5] || month == year[6]
                               select month;
            foreach (string months in WinterSummer)
            {
                Console.WriteLine(months);
            }

            Console.ReadKey();

            #endregion
            #region [The second task]

            Console.WriteLine("\t\t\t\tЗадание 2");
            var collection = new List<Customer>();
            for (char i = 'А'; i != 'Ж'; i++)
            {
                var customer = new Customer
                {
                    Name = "Покупатель " + i,
                    Balance = rnd.Next(10, 2500)
                };
                collection.Add(customer);
            }

            // вывод всей коллекции
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\tСписок покупателей, расположенных по возрастанию баланса: ");
            var sortCollectionByCash = collection.OrderBy(item => item.Balance);
            foreach (var item in sortCollectionByCash)
            {
                Console.WriteLine($"{item}");
            }

            Console.WriteLine("\tСписок покупателей, у которых баланс больше, чем 500 рублей," +
                "\n\t\t\tно меньше, чем 1500: \n");
            var sortCollectionByBalance = collection.Where(item => item.Balance < 1500 && item.Balance > 500).OrderBy(item => item.Balance);
            foreach (var item in sortCollectionByBalance)
            {
                Console.WriteLine($"{item}");
            }

            Console.WriteLine("\t\t\tМаксимальный покупатель (по балансу): ");
            int max = collection.Max(a => a.Balance);
            var sortCollectionMax = collection.Where(item => item.Balance == max).OrderBy(item => item.Balance);
            foreach (var item in sortCollectionMax)
            {
                Console.WriteLine($"{item}");
            }

            Console.WriteLine("\tПервые пять покупателей с максимальной суммой на карте: ");
            var sortCollection5 = collection.Where(item => item.Balance <= max).OrderBy(item => item.Balance);
            var unsortedCollection5 = sortCollection5.Reverse();
            var sortedCollection5 = unsortedCollection5.Take(5);

            foreach (var item in sortedCollection5)
            {
                Console.WriteLine($"{item}");
            }

            Console.ReadKey();

            #endregion
            #region [The third task]

            List<Game> teams = new List<Game>()
            {       new Game { Name = "DOTA2", Developer ="Valve" },
                    new Game { Name = "Genshin Impact", Developer ="miHoYo" }
            };

            List<Player> players = new List<Player>()
            {
                    new Player {Name="Василиса", Team="DOTA2"},
                    new Player {Name="Полина", Team="DOTA2"},
                    new Player {Name="Лиза", Team="Genshin Impact"}
            };

            var result = from pl in players
                         join t in teams on pl.Team equals t.Name
                         select new { Name = pl.Name, Team = pl.Team, Country = t.Developer };

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Name} - {item.Team} ({item.Country})");
            }

            #endregion
        }
    }
}
