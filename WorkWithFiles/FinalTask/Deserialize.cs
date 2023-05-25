using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using FinalTask;

namespace FinalTask
{
    public class Deserialize
    {
        //Метод формирования массива объектов студентов
        public Student[] DeserializeFile(string file)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (var fs = new FileStream(file, FileMode.OpenOrCreate))
            {
                Student[] students = (Student[])formatter.Deserialize(fs);
                return students;
            }
        }
    }
}
