using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using FinalTask;

    ReadData(out string DirPathString, out bool YesOrNo, out bool DefaultDir, out string FileToRead);
    if (YesOrNo)
    {
        CreateGroupFile groupFile = new CreateGroupFile(DirPathString, DefaultDir);
        Deserialize deserialize = new Deserialize();
        Student[] students = deserialize.DeserializeFile(FileToRead);
        foreach (Student student in students)
        {
            groupFile.AddInfoToFiles(student);
        }
    }
    else
    {
        Console.WriteLine("Операция отменена.");
    }

//Метод сбора данных от пользователя. На выходе - существующий адрес папки или папка по умолчанию, путь до файла базы со студентами и подтверждение пользователя.
    static void ReadData(out string DirPathString, out bool YesOrNo, out bool DefaultDir, out string FileToRead)
    {
        Checks check = new Checks();

        Console.WriteLine("Введите полный путь до файла базы данных студентов или оставьте пустым, чтобы искать students.dat на рабочем столе:");
        FileToRead = Console.ReadLine();
        if (FileToRead == "")
        {
            FileToRead = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\students.dat";
        }
        while (!File.Exists(FileToRead))
        {
            Console.WriteLine("Указанный файл не существует! Попробуйте снова:");
            FileToRead = Console.ReadLine();
        }

        Console.WriteLine("Введите полный путь к папке для создания файлов или оставьте пустым, чтобы создать на рабочем столе:");
        DirPathString = Console.ReadLine();
        DefaultDir = true;
        while (check.DirNotExist(DirPathString, out DefaultDir))
        {
            Console.WriteLine("Указанная папка не существует! Введите верный путь к папке:");
            DirPathString = Console.ReadLine();
        }

        if (DefaultDir)
        { 
            Console.WriteLine("На рабочем столе будет создана директория Students и туда будет загружена информация о студентах.");
            Console.WriteLine("Вы согласны? (y/n)");
            string YesNo = Console.ReadLine();
            YesOrNo = true;
            while (check.YesNoNotExist(YesNo, out YesOrNo))
            {
                Console.WriteLine("Неверный формат ответа. Выберите y или n!");
                YesNo = Console.ReadLine();
            }
        }
        else
        {
            Console.WriteLine("В папке {0} будет создана директория Students и туда будет загружена информация о студентах.", DirPathString);
            Console.WriteLine("Вы согласны? (y/n)");
            string YesNo = Console.ReadLine();
            YesOrNo = true;
            while (check.YesNoNotExist(YesNo, out YesOrNo))
            {
                Console.WriteLine("Неверный формат ответа. Выберите y или n!");
                YesNo = Console.ReadLine();
            }
        }
    }
