using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    //Класс расчета размера папки
    public class FolderSize
    {
        private TimeSpan Interval;
        public DirectoryInfo InitialDir;
        private string FolderPath;
        double SizeOfFiles = 0;
        double SizeOfDeleteFiles = 0;

        public FolderSize(string FolderPath, double minutes)
        {
            Interval = TimeSpan.FromMinutes(minutes);
            InitialDir = new DirectoryInfo(FolderPath);
        }

        //Метод расчета размера файлов и вложенных папок.
        public double SizeOfDir(DirectoryInfo directory)
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
                    SizeOfFiles = SizeOfFiles + file.Length;
                }
                foreach (DirectoryInfo dir in subDirs)
                {
                    SizeOfDir(dir);
                }
            }
            return SizeOfFiles;
        }

        //Метод расчета размера файлов с датой изменения большей, чем заданная.
        public double SizeOfDeleteDir(DirectoryInfo directory)
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
                    if ((DateTime.Now - file.LastWriteTime) > Interval)
                    {
                        SizeOfDeleteFiles = SizeOfDeleteFiles + file.Length;
                    }
                }
                foreach (DirectoryInfo dir in subDirs)
                {
                    if ((DateTime.Now - dir.LastWriteTime) > Interval)
                    {
                        SizeOfDeleteDir(dir);
                    }
                }
            }
            return SizeOfDeleteFiles;
        }
    }
}
