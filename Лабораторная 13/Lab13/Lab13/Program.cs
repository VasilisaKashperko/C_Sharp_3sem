using System;

namespace Lab13
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\t\t\tЗадание 1");
            Console.WriteLine("Смотреть выполнение задания в файле VKLog.txt");
            VKLog log = new VKLog();

            VKForFileInfo fileInfo = new VKForFileInfo();

            log.WriteFile(fileInfo.FullPath());
            log.WriteFile(fileInfo.Info());
            log.WriteFile(fileInfo.Dates());
            Console.WriteLine("--------------------------------------");

            VKDiskInfo.DiskInfo();

            VKFileInfo.FileInfo("VKlog.txt");

            VKDirInfo.DirInfo(@"D:\Учеба в БГТУ\Пацей Н.В. ООП");

            VKFileManager.AllAboutDrive("D");

            VKFileManager.FileDirCreate("VKInspect", "VKdirinfo", "testFileCopy");

            VKFileManager.VKFiles(@"D:\Учеба в БГТУ\Пацей Н.В. ООП\Лабораторная 13", "xlsx");

            VKFileManager.Zip();

            VKFileManager.UnZip(@"D:\VKInspect\UnZip");
        }
    }
}
