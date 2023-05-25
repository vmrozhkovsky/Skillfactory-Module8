using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    //Класс для очистки указанной папки
    public class ClearFolder
    {
        private TimeSpan Interval;
        private DirectoryInfo InitialDir;

        public ClearFolder(string folderPath, double minutes)
        {
            Interval = TimeSpan.FromMinutes(minutes);
            InitialDir = new DirectoryInfo(folderPath);
        }

        //Метод удаления папок
        public void DeleteOldDirs()
        {
            DirectoryInfo[] dirs = InitialDir.GetDirectories();
            try
            {
                foreach (DirectoryInfo dir in dirs)
                {
                    if ((DateTime.Now - dir.LastWriteTime) > Interval)
                    { 
                        dir.Delete(true);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Метод удаления файлов
        public void DeleteOldFiles()
        { 
        FileInfo[] files = InitialDir.GetFiles();
            try
            { 
                foreach (FileInfo file in files) 
                {
                    if ((DateTime.Now - file.LastWriteTime) > Interval)
                    {     
                        file.Delete();
                    }
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
