﻿using Microsoft.Win32;
using Task1;


    ReadData(out string DirPathString, out double MinutesDouble, out bool YesOrNo);

    if (YesOrNo)
    {
        ClearFolder clearFolder = new ClearFolder(DirPathString, MinutesDouble);
        Console.WriteLine("Идет проверка и удаление папок...");
        clearFolder.DeleteOldDirs();
        Console.WriteLine("Выполнено.");
        Console.WriteLine("Идет проверка и удаление файлов...");
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
        DirPathString = Console.ReadLine();
        while (check.DirNotExist(DirPathString))
        {
            Console.WriteLine("Указанная папка не существует! Введите верный путь к папке:");
            DirPathString = Console.ReadLine();
        }

        Console.WriteLine("Введите время изменения файлов и папок в минутах:");
        string Minutes = Console.ReadLine();
        while (check.MinutesNotExist(Minutes, out MinutesDouble))
        {
            Console.WriteLine("Неверный формат числа или число равно нулю! Введите верное число:");
            Minutes = Console.ReadLine();
        }

        Console.WriteLine("ВНИМАНИЕ!!! Все файлы и папки в папке {0}, которые не изменялись в течении {1} минут будут удалены!", DirPathString, MinutesDouble.ToString());
        Console.WriteLine("Вы согласны? (y/n)");
        string YesNo = Console.ReadLine();
        while (check.YesNoNotExist(YesNo, out YesOrNo))
        {
            Console.WriteLine("Неверный формат ответа. Выберите y или n!");
            YesNo = Console.ReadLine();
        }
}

