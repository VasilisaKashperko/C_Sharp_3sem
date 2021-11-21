using System;
using System.Collections.Generic;
using System.Text;

namespace Lab9
{
    public class Director
    {
        public delegate void Info(string message);
        public event Info Notify;

        public Director(int pay, string position)
        {
            Pay = pay;
            Position = position;
        }
        public int Pay { get; private set; }

        public string Position { get; private set; }

        public override string ToString()
        {
            return $"Текущая зарплата {Position} составляет {Pay} рублей";
        }

        public void ToPromote(int good)
        {
            Pay += good;
            Notify?.Invoke($"Повышение! Специалисту добавили к зарплате {good} рублей");   // Вызов события + проверка, на null
        }

        public void Fine(int bad)
        {
            if (Pay >= bad)
            {
                Pay -= bad;
                Notify?.Invoke($"Штраф: {bad}");   // Вызов события
            }
            else
            {
                Notify?.Invoke($"Уволен!"); ;
                Pay = 0;
            }
        }
    }
}
