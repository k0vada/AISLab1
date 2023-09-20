using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISLab1
{
    public class StudentOperations
    {
        public void SingleOutput(Student student)
        {
            Console.WriteLine($"\nID: {student.StudentId}");
            Console.WriteLine($"ФИО: {student.FirstName} {student.LastName} {student.MiddleName}");
            Console.WriteLine($"Пол: {ConvertGender(student.Gender)}");
            Console.WriteLine($"Дата рождения: {student.Birthday}\n");
        }

        public void FullOutput(List<Student> Students)
        {
            foreach (Student student in Students)
            {
                SingleOutput(student);
            }
        }        

        public void OutputByID(List<Student> Students)
        {
            Console.WriteLine("\nВведите ID: ");
            uint searchId = Check.IntCheck();
            if (searchId <= 0 && searchId > Students.Count())
            {
                Console.WriteLine("\nОшибка.Студента с данным ID не существует");
                return;
            }

            foreach (Student student in Students)
            {
                if (student.StudentId == searchId)
                {
                    Console.WriteLine($"\nСтудент с ID = {searchId}");
                    SingleOutput(student);
                    return;
                }
                Console.WriteLine("\nОшибка.Студента с данным ID не существует");
                return;
            }
        }

        public void DropRecord(List<Student> Students)
        {

            Console.WriteLine("\nВведите ID студента, запись о котором хотите удалить.");
            uint deleteId = Check.IntCheck();
            if (deleteId <= 0 && deleteId > Students.Count())
            {
                Console.WriteLine("\nОшибка.Студента с данным ID не существует");
                return;
            }

            foreach (Student student in Students)
            {
                if (student.StudentId == deleteId)
                {
                    Students.Remove(student);
                    Console.WriteLine("\nЗапись успешно удалена.");
                    return;
                }
            }
            Console.WriteLine("\nОшибка.Студента с данным ID не существует");
            return;
        }

        public void AddRecord(List<Student> Students)
        {
            Console.WriteLine("\nВведите ID");
            uint varstudentid = Check.IntCheck();

            Console.WriteLine("Введите имя:");
            string varfirstname = Check.StringCheck();

            Console.WriteLine("Введите фамилию: ");
            string varlastname = Check.StringCheck();

            Console.WriteLine("Введите Отчество: ");
            string varmiddlename = Check.StringCheck();

            Console.WriteLine("Введите пол (0 - Женский, 1 - Мужской): ");
            bool vargender = Check.BoolCheck();

            Console.WriteLine("Введите дату рождения (ГГГГ-ММ-ДД): ");
            string varbirthday = Check.DateCheck();

            Student varstudent = new Student(varstudentid, varfirstname, varlastname, varmiddlename, vargender, varbirthday);
            Students.Add(varstudent);
            Console.WriteLine("\nЗапись успешно добавлена.");
        }

        public string ConvertGender(bool tmpgender)
        {
            if (tmpgender == true) { return "М"; }
            return "Ж"; 
        }
    }
}







//public static void OutputByID(List<Student> Students)
//{
//    Console.WriteLine("\nВведите ID: ");
//    uint searchId = Check.IntCheck();
//    foreach (Student student in Students)
//    {
//        if (student.StudentId == searchId)
//        {
//            Console.WriteLine($"\nСтудент с ID = {searchId}");
//            SingleOutput(student);
//            break;
//        }
//        else if (student.StudentId < searchId || searchId == 0)
//        {
//            Console.WriteLine("\nОшибка. Студента с данным ID не существует");
//            break;
//        }
//    }
//}