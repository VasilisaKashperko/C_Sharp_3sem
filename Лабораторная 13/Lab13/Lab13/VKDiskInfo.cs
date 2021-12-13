using System;
using System.IO;

namespace Lab13
{
    static class VKDiskInfo
    {
        public static void DiskInfo()
        {
            Console.WriteLine("\t\t\t\tЗадание 2");
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine($"Имя: {drive.Name}");
                Console.WriteLine($"Файловая система: {drive.DriveFormat}");
                Console.WriteLine($"Свободное место на диске: {Math.Round(drive.AvailableFreeSpace * 1e-9, 2)} ГБайт");
                Console.WriteLine($"Всего места на диске: {Math.Round(drive.TotalSize * 1e-9, 2)} ГБайт");
                Console.WriteLine($"Метка: {drive.VolumeLabel}\n");
            }
            Console.WriteLine("--------------------------------------");
        }
    }
}
