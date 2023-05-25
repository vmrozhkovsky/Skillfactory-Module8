using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using FinalTask;
using System.IO;

namespace FinalTask
{
    public class CreateGroupFile
    {
        string DirPath = "";

        //Конструктор создает папку Students в выбранном пользователем месте или на рабочем столе, в зависимости от значения defaultdir
        public CreateGroupFile(string dirpath, bool defaultdir)
        {
            if (defaultdir)
            { 
                DirPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\Students";
                DirectoryInfo dir = new DirectoryInfo(DirPath);
                Console.WriteLine(dir.FullName);
                dir.Create();
            }
            else
            {
                DirPath = dirpath + @"\Students";
                DirectoryInfo dir = new DirectoryInfo(DirPath);
                Console.WriteLine(dir.FullName);
                dir.Create();
            }
        }

        //Метод для добавления информации о студенте в соответствующий файл.
        public void AddInfoToFiles(Student student)
        {
            string FullFileName = DirPath + @"\" + student.Group + ".txt";
            Console.WriteLine($"Добавляем инфомацию о студенте {student.Name} из группы {student.Group} в файл {FullFileName}.");
            using (FileStream fs = new FileStream(FullFileName, FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                { 
                    sw.WriteLine($"{student.Name}, {student.DateOfBirth}");
                }
            }
        }
    }
}
