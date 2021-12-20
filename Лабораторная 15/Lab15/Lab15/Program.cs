using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.IO;
using static System.Console;

namespace Lab15
{
    #region [ The fourth task ]
    public class Numbers
    {
        private int n;
        public StreamWriter file = new StreamWriter("result.txt", false);
        public Numbers(int _n)
        {
            n = _n;
        }
        ~Numbers()
        {
            try { file.Close(); }
            catch { };
        }

        public void Odd()  // нечетные
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
                    WriteLine("Odd number " + i);
                }
            }
            if (file.BaseStream != null)
                file.Close();
        }
        public void Even() // четные
        {
            lock (this)
            {
                for (int i = 1; i < n; i++)
                {
                    if (i % 2 == 0)
                    {
                        if (file.BaseStream == null)
                            file = new StreamWriter("result.txt", true);
                        file.WriteLine(i);
                        WriteLine("Even number " + i);
                    }
                    if (file.BaseStream != null)
                        file.Close();
                }
            }
        }
        public void Odd1()
        {
            Monitor.Enter(this);
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
                        WriteLine("MonitorOdd " + i);
                        Monitor.Pulse(this);
                        Monitor.Wait(this);
                    }
                }
                if (file.BaseStream != null)
                    file.Close();
                Monitor.Exit(this);
            }
        }
        public void Even1()
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
                        WriteLine("MonitorEven " + i);
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
            for (int i = 1; i < n; i++)
                Write('.');
            WriteLine();
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
                    WriteLine("Приоритет процесса: " + p.BasePriority.ToString()+" "+ p.PriorityClass.ToString());
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
            myThread.Name = "\"Vasilisa\'s thread\"";
            myThread.Priority = ThreadPriority.Highest;
            myThread.Start(n);
            #endregion

            #region [The fourth task]
            Thread thread1, thread2;
            Numbers numbers = new Numbers(n);

            thread1 = new Thread(numbers.Odd);
            thread2 = new Thread(numbers.Even);

            thread1.IsBackground = true;
            thread2.IsBackground = true;

            thread1.Priority = ThreadPriority.AboveNormal;

            thread1.Start();
            thread2.Start();

            Thread.Sleep(3000);

            Thread thread3 = new Thread(numbers.Odd1);
            Thread thread4 = new Thread(numbers.Even1);

            thread3.IsBackground = true;
            thread4.IsBackground = true;

            thread3.Priority = ThreadPriority.AboveNormal;

            thread3.Start();
            thread4.Start();
            #endregion

            #region [The fifth task]
            TimerCallback a = new TimerCallback(numbers.ForTimer);
            Timer timer = new Timer(a, 1, 10000, 200);
            WriteLine("sd");
            ReadKey();
            #endregion
        }
    }
}
