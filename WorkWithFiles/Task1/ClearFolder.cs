using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    //Класс для очистки указанной папки
    public class ClearFolder
    {
        private TimeSpan Interval;
        private DirectoryInfo InitialDir;

        public ClearFolder(string folderPath, double minutes)
        {
            this.Interval = TimeSpan.FromMinutes(minutes);
            this.InitialDir = new DirectoryInfo(folderPath);
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
                        //Console.WriteLine("Папка {0} с датой изменения {1} устарела и будет удалена!", dir.Name, dir.LastWriteTime);
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
                        //Console.WriteLine("Файл {0} с датой изменения {1} устарел и будет удален!", file.Name, file.LastWriteTime);
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
