using System;
using System.Collections.Generic;
using System.IO;
//Содержит типы, позволяющие выполнять чтение и запись в файлы и потоки данных,
//а также типы, обеспечивающие базовую поддержку файлов и каталогов.
using System.Text;
//поток – это некая независимая последовательность инструкций для выполнения
//того или иного действия в программе.

namespace Lab13
{
    public class VKLog
    {
        readonly DateTime DateNow = DateTime.Now;
        public void WriteFile(string action, string path = @"D:\Учеба в БГТУ\Пацей Н.В. ООП\Лабораторная 13\Lab13\Lab13\bin\Debug\netcoreapp3.1\VKLog.txt", string fileName = "VKLog.txt")
        {
            using (StreamWriter sw = new StreamWriter(path, true, Encoding.UTF8))
            {
                sw.WriteLine("Имя файла: " + fileName);
                sw.WriteLine("Путь к файлу " + path);
                sw.WriteLine("Дата создания: " + DateNow);
                sw.WriteLine(action);
                sw.WriteLine("------------------------------------------");
            }
        }

        private string actionOne;
        public string FreeSpace()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                actionOne = "Свободное место на диске в байтах: " + drive.AvailableFreeSpace.ToString();
            }
            return actionOne;
        }
        public string FileSystem()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                actionOne = "Файловая система: " + drive.DriveFormat.ToString();
            }
            return actionOne;
        }
        public string Disk()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                actionOne = "Имя диска: " + drive.Name + ". ";
                actionOne += "Объём: " + drive.TotalFreeSpace + "байт. ";
                actionOne += "Доступный объём: " + drive.AvailableFreeSpace + "байт. ";
                actionOne += "Метка тома: " + drive.VolumeLabel + ". ";
            }
            return actionOne;
        }
    }
}
