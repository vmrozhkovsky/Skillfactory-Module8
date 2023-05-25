using Microsoft.Win32;
using Task2;


    ReadData(out string DirPathString, out bool YesOrNo);

    if (YesOrNo)
    {
        Console.WriteLine("Идет проверка и расчет размера файлов и папок:");
        FolderSize FolderSize = new FolderSize(DirPathString);
    }
    else
    {
        Console.WriteLine("Расчет размера отменен.");
    }

    //Метод сбора данных от пользователя. На выходе существующий адрес папки и подтверждение пользователя.
static void ReadData(out string DirPathString, out bool YesOrNo)
    {
        Checks check = new Checks();

        Console.WriteLine("Введите полный путь к папке для расчета размера:");
        DirPathString = Console.ReadLine();
        while (check.DirNotExist(DirPathString))
        {
            Console.WriteLine("Указанная папка не существует! Введите верный путь к папке:");
            DirPathString = Console.ReadLine();
        }

        Console.WriteLine("Будет произведен расчет размера всех файлов и папок в {0}.", DirPathString);
        Console.WriteLine("Вы согласны? (y/n)");
        string YesNo = Console.ReadLine();
        while (check.YesNoNotExist(YesNo, out YesOrNo))
        {
            Console.WriteLine("Неверный формат ответа. Выберите y или n!");
            YesNo = Console.ReadLine();
        }
}

