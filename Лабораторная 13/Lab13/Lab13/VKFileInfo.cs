using System;
using System.IO;

namespace Lab13
{
    static class VKFileInfo
    {
        public static void FileInfo(string path)
        {
            Console.WriteLine("\t\t\t\tЗадание 3");
            FileInfo file = new FileInfo(path);
            Console.WriteLine($"Полный путь: {file.FullName}");
            Console.WriteLine($"Имя файла: {file.Name}");
            Console.WriteLine($"Расширение: {file.Extension}");
            Console.WriteLine($"Размер: {file.Length}");
            Console.WriteLine($"Дата создания: {file.CreationTime}\n");
            Console.WriteLine("--------------------------------------");
        }
    }

    class VKForFileInfo
    {
        private string action;
        public string FullPath(string path = @"D:\Учеба в БГТУ\Пацей Н.В. ООП\Лабораторная 13\Lab13\Lab13\bin\Debug\netcoreapp3.1\VKLog.txt")
        {
            FileInfo f = new FileInfo(path);
            action = "Полный путь к файлу: " + f.DirectoryName;
            return action;
        }
        public string Info(string path = @"D:\Учеба в БГТУ\Пацей Н.В. ООП\Лабораторная 13\Lab13\Lab13\bin\Debug\netcoreapp3.1\VKLog.txt")
        {
            FileInfo f = new FileInfo(path);
            action = "Размер: " + f.Length + "байт. ";
            action += "Расширение: " + f.Extension + ". ";
            action += "Имя: " + f.FullName + ". ";
            return action;
        }
        public string Dates(string path = @"D:\Учеба в БГТУ\Пацей Н.В. ООП\Лабораторная 13\Lab13\Lab13\bin\Debug\netcoreapp3.1\VKLog.txt")
        {
            FileInfo f = new FileInfo(path);
            action = "Дата создания: " + f.CreationTime + ". ";
            action += "Дата изменения: " + f.LastWriteTime + ". ";
            return action;
        }
    }
}
