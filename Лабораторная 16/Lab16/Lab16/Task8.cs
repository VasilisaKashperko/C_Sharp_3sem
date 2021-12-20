﻿using System;
using System.Threading.Tasks;
using System.Threading;

namespace Lab16
{
    partial class Program
    {
        public static void ForAsync()
        {
            for (int i = 0; i < 30; i++)
                if (i % 3 == 0)
                {
                    Console.Write(i + ", ");
                    Thread.Sleep(1000);
                }
        }
        public static async void Async()
        {
            Console.WriteLine("Асинхронная функция:");
            await Task.Run(() => ForAsync());
            Console.WriteLine("Готово!");
        }
    }
}
