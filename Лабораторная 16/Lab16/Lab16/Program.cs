using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using static System.Console;

namespace Lab16
{
    public partial class Program
    {
        private static void Main(string[] args)
        {
            #region [ The 1st task ]
            WriteLine("\t\t\tЗадание 1");
            Action action1 = new Action(SieveOfEratosthenes);
            Stopwatch watch = Stopwatch.StartNew();
            task1 = Task.Factory.StartNew(action1);
            task1.Wait();
            task1.Dispose();
            watch.Stop();
            WriteLine("Таск выполнен: " + task1.IsCompleted.ToString());
            WriteLine("Статус: " + task1.Status.ToString());
            WriteLine("Время выполнения для таска: " + watch.Elapsed);
            #endregion

            #region [ The 2nd task ]
            WriteLine("\n\t\t\tЗадание 2");
            CancellationTokenSource token = new CancellationTokenSource();
            (task1 = new Task(action1, token.Token)).Start();
            token.Cancel();
            WriteLine("Токен отмены сработал!");
            #endregion

            #region [ The 3rd task ]
            WriteLine("\n\t\t\tЗадание 3");

            Task<int> rand1 = new Task<int>(RandomFor10),
                      rand2 = new Task<int>(RandomFor20),
                      rand3 = new Task<int>(RandomFor30);

            rand1.Start();
            WriteLine("First Value: " + rand1.Result);

            rand2.Start();
            WriteLine("Second Value: " + rand2.Result);

            rand3.Start();
            WriteLine("Third Value: " + rand3.Result);

            Task<int> avg = new Task<int>(() => AverageValue(rand1.Result, rand2.Result, rand3.Result));
            avg.Start();

            WriteLine("Average: " + avg.Result);
            #endregion

            #region [ The 4th task ]
            WriteLine("\n\t\t\tЗадание 4");
            WriteLine("Таск продолжения: ");
            Task<int> contTask1 = new Task<int>(RandomFor10);
            // Планировка на основе завершения множества предшествующих задач
            Task<int> contTask2 = contTask1.ContinueWith((task) => RandomFor20());
            Task<int> contTask3 = contTask2.ContinueWith((task) => RandomFor30());
            Task<int> contTask4 = contTask3.ContinueWith((task) => AverageValue(contTask1.Result, contTask2.Result, contTask3.Result));
            contTask1.Start();

            WriteLine("Первое значение: " + contTask1.Result);
            WriteLine("Второе значение: " + contTask2.Result);
            WriteLine("Третье значение: " + contTask3.Result);
            WriteLine("Среднее значение: " + contTask4.Result);

            contTask1.Dispose();
            contTask2.Dispose();
            contTask3.Dispose();
            contTask4.Dispose();

            WriteLine("Ожидающий");
            Task<int> wait = Task.Run(() => Enumerable.Range(1, 100000).Count(n => (n % 2 == 0)));
            TaskAwaiter<int> awaiter = wait.GetAwaiter();
            awaiter.OnCompleted(() => { int res = awaiter.GetResult(); WriteLine(res); });
            #endregion

            #region [ The 5th task ]
            WriteLine("\n\t\t\tЗадание 5");

            Stopwatch stW = new Stopwatch();
            int[] arr1 = new int[10000000];
            int[] arr2 = new int[10000000];
            Random random = new Random();
            stW.Restart();

            for (int i = 0; i < arr1.Length; i++)
            {
                arr1[i] = random.Next(0, 300);
                arr2[i] = random.Next(0, 300);
            }
            stW.Stop();

            WriteLine("For: " + stW.Elapsed);
            stW.Restart();

            Parallel.For(0, arr1.Length, i =>
            {
                arr1[i] = random.Next(0, 300);
                arr2[i] = random.Next(0, 300);
            });
            stW.Stop();

            WriteLine("Параллельный for: " + stW.Elapsed);
            stW.Restart();

            Parallel.ForEach<int>(arr1, i =>
            {
                arr1[i] = random.Next(0, 300);
                arr2[i] = random.Next(0, 300);
            });
            stW.Stop();

            WriteLine("Параллельный foreach: " + stW.Elapsed);
            #endregion

            #region [ The 6th task ]
            WriteLine("\n\t\t\tЗадание 6");
            Parallel.Invoke(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    WriteLine("Параллельное выполнение блока 1 - " + i);
                }

                WriteLine("1 готов!");
            },
            () =>
            {
                for (int i = 0; i < 10; i++)
                {
                    WriteLine("Параллельное выполнение 2 - " + i);
                }

                WriteLine("2 готов!");
            });
            #endregion

            #region [ The 7th task ]
            WriteLine("\n\t\t\tЗадание 7");
            MyBlock = new BlockingCollection<string>(5);
            Task Shop = new Task(AddProduct);
            Task Clients = new Task(PurchasedProduct);
            Shop.Start();
            Clients.Start();
            Shop.Wait();
            Clients.Wait();
            
            #endregion

            #region [ The 8th task ]
            WriteLine("Задание 8");
            Async();
            string p = ReadLine();
            WriteLine(p + p + p + "Нажмите, чтобы закончить работу...");
            ReadKey();
            #endregion
        }
    }
}
