using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    //Класс для проверки входных данных
    public class Checks
    {
        private DirectoryInfo? InitialDir;

        //Метод для проверки существования введенного пути до папки и его отличия от null. На выходе - true или false.
        public bool DirNotExist(string? folderPath)
        {
            if (!(folderPath == ""))
            { 
                InitialDir = new DirectoryInfo(folderPath);
                if (!InitialDir.Exists)
                {
                    return true;
                }
                else
                { 
                    return false;
                }
            }
            else
            {
                return true;
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
