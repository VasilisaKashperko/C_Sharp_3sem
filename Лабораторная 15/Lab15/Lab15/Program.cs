using System;
using System.Reflection;
using System.Diagnostics;
using System.Threading;
using System.IO;
using static System.Console;

namespace Lab15
{
    #region [ The fourth task ]
    public class MyNumbers
    {
        private int n;
        public StreamWriter file = new StreamWriter("result.txt", false);
        public MyNumbers(int _n)
        {
            n = _n;
        }
        ~MyNumbers()
        {
            try { file.Close(); }
            catch { };
        }

        public void OddNumbers()  // нечетные
        {
            if (file.BaseStream == null)
                file = new StreamWriter("result.txt", true);
            for (int i = 1; i < n; i++)
            {
                Thread.Sleep(30);
                if (i % 2 != 0)
                {
                    if (file.BaseStream == null)
                        file = new StreamWriter("result.txt", true);
                    file.WriteLine(i);
                    WriteLine("Нечетное число " + i);
                }
            }
            if (file.BaseStream != null)
                file.Close();
        }
        public void EvenNumbers() // четные
        {
            lock (this) 
                // Как только поток войдет в контекст lock, маркер блокировки (в данном случае — текущий объект)
                // станет недоступным другим потокам до тех пор, пока блокировка не будет снята по выходе из контекста lock.
            {
                for (int i = 1; i < n; i++)
                {
                    if (i % 2 == 0)
                    {
                        if (file.BaseStream == null)
                            file = new StreamWriter("result.txt", true);
                        file.WriteLine(i);
                        WriteLine("Четное число " + i);
                    }
                    if (file.BaseStream != null)
                        file.Close();
                }
            }
        }
        public void OddNumbers1()
        {
            Monitor.Enter(this);
            // Наряду с оператором lock для синхронизации потоков мы можем использовать мониторы
            {
                if (file.BaseStream == null)
                    file = new StreamWriter("result.txt", true);
                for (int i = 1; i < n; i++)
                {

                    if (i % 2 != 0)
                    {

                        if (file.BaseStream == null)
                            file = new StreamWriter("result.txt", true);
                        file.WriteLine(i);
                        WriteLine("Нечетное " + i);
                        Monitor.Pulse(this);
                        Monitor.Wait(this);
                    }
                }
                if (file.BaseStream != null)
                    file.Close();
                Monitor.Exit(this);
            }
        }
        public void EvenNumbers1()
        {
            Monitor.Enter(this);
            {
                if (file.BaseStream == null)
                    file = new StreamWriter("result.txt", true);
                for (int i = 1; i < n; i++)
                {
                    if (i % 2 == 0)
                    {
                        if (file.BaseStream == null)
                            file = new StreamWriter("result.txt", true);
                        file.WriteLine(i);
                        WriteLine("Четное " + i);
                        Monitor.Pulse(this);
                        Monitor.Wait(this);
                    }
                }
                if (file.BaseStream != null)
                    file.Close();
                Monitor.Exit(this);
            }
        }
        public void ForTimer(object obj)
        {
            Console.Clear();
            Console.WriteLine("\u2665 Текущее время:  " + DateTime.Now.ToLongTimeString() + " \u2665");
        }
    }
    #endregion

    class Program
    {
        #region [ The third task ]
        public static void begin(object n)
        {
            WriteLine("Имя потока: " + Thread.CurrentThread.Name);
            WriteLine("Приоритет потока: " + Thread.CurrentThread.Priority.ToString());
            WriteLine("Id потока: " + Thread.CurrentThread.ManagedThreadId.ToString());
            WriteLine("Статус потока: " + Thread.CurrentThread.ThreadState.ToString());
            StreamWriter fileOut = new StreamWriter("myResult.txt");
            bool check;
            for (int i = 1; i < (int)n + 1; i++)
            {
                Thread.Sleep(10);
                check = true;
                for (int j = i; j > 0; j--)
                    if ((i % j == 0) && (j != 1) && (j != i))
                    {
                        check = false;
                        break;
                    }
                if (check == true)
                {
                    fileOut.WriteLine(i.ToString());
                    WriteLine("Простые числа " + i.ToString());
                }
            }
            fileOut.Close();
        }
        #endregion

        static void Main(string[] args)
        {
            #region [ The first task ]
            Process[] proc = Process.GetProcesses();
            foreach (Process p in proc)
            {
                try
                {
                    WriteLine("Id процесса: " + p.Id.ToString());
                    WriteLine("Имя процесса: " + p.ProcessName);
                    WriteLine("Приоритет процесса: " + p.BasePriority.ToString() + " " + p.PriorityClass.ToString());
                    WriteLine("Время запуска: " + p.StartTime.ToString());
                    WriteLine("Время использования процессором: " + p.TotalProcessorTime.ToString());
                    if (p.StartTime.ToString() != null)
                        WriteLine("Текущее состояние: запущен");
                    WriteLine();
                }
                catch
                {
                    WriteLine();
                }
            }
            #endregion

            #region [ The second task ]
            AppDomain domain = AppDomain.CurrentDomain;

            WriteLine($"Имя домена: {domain.FriendlyName}");
            WriteLine($"Базовая директория: {domain.BaseDirectory}");
            WriteLine($"Информация: {domain.SetupInformation}");
            WriteLine();
            Assembly buf = null;
            foreach (Assembly x in domain.GetAssemblies())
            {
                if (x.GetName().Name == "Lab15")
                    buf = x;
                WriteLine(x.ToString());
            }

            AppDomain myNewDomain = AppDomain.CreateDomain("Мой новый домен");
            Assembly buf2 = myNewDomain.Load(buf.GetName());
            AppDomain.Unload(myNewDomain);
            WriteLine(buf2.ToString());
            #endregion

            #region [The third task]
            int n;
            bool check;
            while (true)
            {
                WriteLine("Введите n:");
                check = int.TryParse(ReadLine(), out n);

                if (check == false)
                    WriteLine("Неверно введено значение. Введите снова");
                else break;
            }

            Thread myThread = new Thread(new ParameterizedThreadStart(begin));
            myThread.Name = "Абсолютно новый поток";
            myThread.Priority = ThreadPriority.Highest;
            myThread.Start(n);
            #endregion

            #region [The fourth task]
            Thread thread1, thread2;
            MyNumbers numbers = new MyNumbers(n);

            thread1 = new Thread(numbers.OddNumbers);
            thread2 = new Thread(numbers.EvenNumbers);

            thread1.IsBackground = true;
            thread2.IsBackground = true;

            thread1.Priority = ThreadPriority.AboveNormal;

            thread1.Start();
            thread2.Start();

            Thread.Sleep(900);

            Thread thread3 = new Thread(numbers.OddNumbers1);
            Thread thread4 = new Thread(numbers.EvenNumbers1);

            thread3.IsBackground = true;
            thread4.IsBackground = true;

            thread3.Priority = ThreadPriority.AboveNormal;

            thread3.Start();
            thread4.Start();
            #endregion

            #region [The fifth task]
            Thread.Sleep(600);
            WriteLine("\n\t\tТАЙМЕР! СЕЙЧАС ВЫ ЗАБУДЕТЕ ВСЁ, ЧТО БЫЛО РАНЬШЕ...");
            Thread.Sleep(5000);

            // Делегат для типа Timer
            TimerCallback a = new TimerCallback(numbers.ForTimer);
            Timer timer = new Timer(a, null, 0, 1000);

            WriteLine("Нажмите чтоб выйти");
            ReadLine();
            #endregion
        }
    }
}
