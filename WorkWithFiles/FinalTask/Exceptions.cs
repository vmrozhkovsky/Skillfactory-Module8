using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask
{
    //Класс для проверки входных данных
    public class Checks
    {
        private DirectoryInfo? InitialDir;

        //Метод для проверки существования введенного пути до папки или его соответствия null. На выходе - true или false и переменная defaultdir.
        public bool DirNotExist(string? folderPath, out bool defaultdir)
        {
            if (folderPath == "")
            { 
                defaultdir = true;
                return false;
            }
            else
            {
                InitialDir = new DirectoryInfo(folderPath);
                if (!InitialDir.Exists)
                {
                    defaultdir = false;
                    return true;
                }
                else
                {
                    defaultdir = false;
                    return false;
                }
            }

        }

        //Метод для проверки введенного значения подтверждения. На выходе true или false соответствия формату и вариант, выбранный пользователем. 
        public bool YesNoNotExist(string? useranwser, out bool yesOrNo)
        {
            switch (useranwser)
            {
                case "y":
                    yesOrNo = true;
                    return false;
                    break;
                case "n":
                    yesOrNo = false;
                    return false;
                    break;
                default:
                    yesOrNo = false;
                    return true;
                    break;

            }
        }
    }
}
