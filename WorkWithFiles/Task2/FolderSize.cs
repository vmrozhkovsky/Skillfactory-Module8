using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    //Класс расчета размера папки
    public class FolderSize
    {
        private DirectoryInfo InitialDir;
        private string FolderPath;
        double SizeOfFiles = 0;

        public FolderSize(string FolderPath)
        {
            this.InitialDir = new DirectoryInfo(FolderPath);
            SizeOfDir(InitialDir);
            Console.WriteLine("Общий размер файлов в папке {0} - {1} байт ({2} мегабайт).", FolderPath, SizeOfFiles, SizeOfFiles / 1024 / 1024);
        }

        //Метод расчета размера файлов и вложенных папок.
        public void SizeOfDir(DirectoryInfo directory)
        {
            DirectoryInfo[] subDirs = null;
            FileInfo[] files = null;
            try
            {
                subDirs = directory.GetDirectories();
                files = directory.GetFiles();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (files != null)
            {
                foreach (FileInfo file in files)
                {
                    //Console.WriteLine("{0} - {1}",file.FullName, file.Length);
                    SizeOfFiles = SizeOfFiles + file.Length;
                }
                foreach (DirectoryInfo dir in subDirs)
                {
                    //Console.WriteLine("Папка {0}:", dir.Name);
                    SizeOfDir(dir);
                }
            }
        }
    }
}
