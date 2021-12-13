using System;
using System.IO;

namespace Lab13
{
    static class VKDirInfo
    {
        public static void DirInfo(string dirName)
        {
            Console.WriteLine("\t\t\t\tЗадание 4");
            DirectoryInfo dir = new DirectoryInfo(dirName);
            Console.WriteLine($"Название каталога: {dir.Name}");
            Console.WriteLine($"Полный путь каталога: {dir.FullName}");
            Console.WriteLine($"Время создания каталога: {dir.CreationTime}");
            Console.WriteLine($"Количестве файлов: {dir.GetFiles().Length}");
            Console.WriteLine($"Количестве поддиректориев: {dir.GetDirectories().Length}");
            Console.WriteLine("--------------------------------------");
        }
    }
}
