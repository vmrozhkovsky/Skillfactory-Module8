using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using FinalTask;

#pragma warning disable SYSLIB0011
BinaryFormatter formatter = new BinaryFormatter();
using (var fs = new FileStream(@"c:\test\students.dat", FileMode.OpenOrCreate))
{
    var newStudent = (Student)formatter.Deserialize(fs);
    Console.WriteLine("Объект десериализован");
    Console.WriteLine($"Имя: {newStudent.Name} Группа: {newStudent.Group} День рождения: {newStudent.DateOfBirth.ToString()}");
}
#pragma warning restore SYSLIB0011
