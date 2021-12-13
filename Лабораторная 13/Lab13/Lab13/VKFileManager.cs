using System;
using System.IO;
using System.IO.Compression;

namespace Lab13
{
    static class VKFileManager
    {
        public static void AllAboutDrive(string disk)
        {
            Console.WriteLine("\t\t\t\tЗадание 5");
            string path;
            if (disk.ToLower() == "d")
            {
                path = @"D:\";
            }
            else
            {
                throw new Exception("Неверный ввод.");
            }

            DirectoryInfo dir = new DirectoryInfo(path);

            Console.WriteLine("\nСписок папок диска:");
            foreach (DirectoryInfo name in dir.GetDirectories())
            {
                Console.WriteLine(name.Name);
            }

            Console.WriteLine("\nСписок файлов диска:");
            foreach (FileInfo name in dir.GetFiles())
            {
                Console.WriteLine(name.Name);
            }
            Console.WriteLine("--------------------------------------");
        }

        public static void FileDirCreate(string dirName, string fileName, string fileName2)
        {
            string dirPath = @"D:\" + dirName;
            DirectoryInfo dirInfo = new DirectoryInfo(dirPath);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            string filePath = dirPath + "\\" + fileName + ".txt";
            FileInfo fileInf = new FileInfo(filePath);
            if (!fileInf.Exists)
            {
                fileInf.Create();
            }

            try
            {
                using StreamWriter sw = new StreamWriter(filePath, false, System.Text.Encoding.Default);
                sw.WriteLine("Информация!!!");
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            string filePath2 = dirPath + "\\" + fileName2 + ".txt";
            File.Copy(filePath, filePath2, true);
            File.Delete(filePath);
        }

        public static void VKFiles(string path, string ext)
        {
            string dirPath = @"D:\VKFiles";
            DirectoryInfo dirInfo = new DirectoryInfo(dirPath);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            DirectoryInfo userDirInfo = new DirectoryInfo(path);
            foreach (FileInfo file in userDirInfo.GetFiles())
            {
                if (file.Extension == ("." + ext))
                    file.CopyTo(dirPath + "\\" + file.Name, true);
            }
            dirInfo.MoveTo(@"D:\VKInspect\VKFiles");
        }
        public static void Zip()
        {

            DirectoryInfo source = new DirectoryInfo(@"D:\VKInspect\VKFiles");

            ZipFile.CreateFromDirectory(source.FullName, source.FullName + ".zip");
            Console.WriteLine("Архив создан!");
        }
        public static void UnZip(string FolderName)
        {

            DirectoryInfo source = new DirectoryInfo(@"D:\VKInspect\VKFiles");

            ZipFile.ExtractToDirectory(source.FullName + ".zip", FolderName);
            Console.WriteLine("Архив разархивирован!");
        }
    }
}
