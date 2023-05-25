using Microsoft.Win32;
using Task3;


    ReadData(out string DirPathString, out double MinutesDouble, out bool YesOrNo);

    if (YesOrNo)
        {
        ClearFolder clearFolder = new ClearFolder(DirPathString, MinutesDouble);
        Console.WriteLine("Удаление папок...");
        clearFolder.DeleteOldDirs();
        Console.WriteLine("Выполнено.");
        Console.WriteLine("Удаление файлов...");
        clearFolder.DeleteOldFiles();
        Console.WriteLine("Выполнено.");
    }
    else
        {
            Console.WriteLine("Очистка папки отменена.");
        }

    //Метод сбора данных от пользователя. На выходе существующий адрес папки, проверенное количество минут и подтверждение пользователя.
    static void ReadData(out string DirPathString, out double MinutesDouble, out bool YesOrNo)
    {
            Checks check = new Checks();

            Console.WriteLine("Введите полный путь к папке для очистки:");
            string DirPath = Console.ReadLine();
            while (check.DirNotExist(DirPath))
            {
                Console.WriteLine("Указанная папка не существует! Введите верный путь к папке:");
                DirPath = Console.ReadLine();
            }
            DirPathString = DirPath;

            Console.WriteLine("Введите время изменения файлов и папок в минутах:");
            string Minutes = Console.ReadLine();
            double minutesDouble;
            while (check.MinutesNotExist(Minutes, out minutesDouble))
            {
                Console.WriteLine("Неверный формат числа или число равно нулю! Введите верное число:");
                Minutes = Console.ReadLine();
            }
            MinutesDouble = minutesDouble;

            Console.WriteLine("Идет проверка и расчет размера файлов и папок:");
            FolderSize FolderSize = new FolderSize(DirPathString, MinutesDouble);
            double DirSize = FolderSize.SizeOfDir(FolderSize.InitialDir);
            double DeleteFilesSize = FolderSize.SizeOfDeleteDir(FolderSize.InitialDir);
            Console.WriteLine("Текущий размер папки {0} - {1} байт ({2} мегабайт).", DirPathString, DirSize, DirSize / 1024 / 1024);
            Console.WriteLine("Общий размер устаревших файлов в папке {0} - {1} байт ({2} мегабайт).", DirPathString, DeleteFilesSize, DeleteFilesSize / 1024 / 1024);
            Console.WriteLine("Размер папки {0} после удаления устаревших файлов - {1} байт ({2} мегабайт).", DirPathString, DirSize - DeleteFilesSize, (DirSize - DeleteFilesSize) / 1024 / 1024);


            Console.WriteLine("ВНИМАНИЕ!!! Все файлы и папки в папке {0}, которые не изменялись в течении {1} минут будут удалены!", DirPathString, MinutesDouble.ToString());
            Console.WriteLine("Вы согласны? (y/n)");
            string YesNo = Console.ReadLine();
            bool yesOrNo;
            while (check.YesNoNotExist(YesNo, out yesOrNo))
            {
                Console.WriteLine("Неверный формат ответа. Выберите y или n!");
                YesNo = Console.ReadLine();
            }
            YesOrNo = yesOrNo;
    }

