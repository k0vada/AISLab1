using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace AISLab1
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName; 
            string filePath;

            while (true)
            {
                Console.WriteLine("Введите название файла:");
                fileName = Console.ReadLine();// + ".csv";
                filePath = Path.Combine(Environment.CurrentDirectory, fileName);
                if (File.Exists(filePath) && Path.GetExtension(filePath).Equals(".csv", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Файл не существует или не является файлом формата CSV. Попробуйте еще раз.");
                }
            }
            var config = new CsvConfiguration(CultureInfo.InvariantCulture) // Используется для настройки библиотеки CsvHelper
            {
                ShouldUseConstructorParameters = type => false // Передача библиотеке разрешение на присваивание значений полям класса без наличия конструктора
            };

            List<Student> Students = null; //null для корректной обработки ошибки при чтении файла
            try
            {
                using (var reader = new StreamReader(filePath)) // Открытие файла в режиме чтения
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture)) // Чтение данных из csv файла с учетом указанных настроек CsvConfiguration.
                {
                    IEnumerable<Student> Records = csv.GetRecords<Student>(); // Базовый интерфейс для всех неуниверсальных коллекций
                    Students = Records.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при чтении файла: {ex.Message}");
            }

            while (true)
            {
                CallMenu(Students, filePath);
            }
        }

        public static void SaveRecords(List<Student> Students, string pathtofile)
        {
            try
            {


                using (var swriter = new StreamWriter(pathtofile)) // Запись данных в файл
                using (var csvwriter = new CsvWriter(swriter, CultureInfo.InvariantCulture)) // Запись данных в формат CSV.
                {
                    csvwriter.WriteRecords(Students);
                }
                Console.WriteLine("\n Данные успешно сохранены. \n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при сохранении файла: {ex.Message}");

            }
        }

        public static void CallMenu(List<Student> Students, string path)
        {
            StudentOperations studentOperations = new StudentOperations();
            #region TextMenu
            Console.WriteLine("\nМЕНЮ ДЕЙСТВИЙ");
            Console.WriteLine("Выберете действие и нажмите соответствующую клавишу");
            Console.WriteLine("     1. Вывод всех записей на экран");
            Console.WriteLine("     2. Вывод записи по ID");
            Console.WriteLine("     3. Сохранение данных в файл");
            Console.WriteLine("     4. Удаление записи по ID");
            Console.WriteLine("     5. Добавление записи в файл");
            Console.WriteLine("     Esc. Закрытие приложения");
            #endregion

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1: // Вывод всех записей на экран
                    Console.WriteLine("\n Список студентов:\n");
                    studentOperations.FullOutput(Students);
                    break;
                case ConsoleKey.D2: // Вывод записи по ID
                    studentOperations.OutputByID(Students);
                    break;
                case ConsoleKey.D3: // Сохранение данных в файл
                    SaveRecords(Students, path);
                    break;
                case ConsoleKey.D4: // Удаление записи по ID
                    studentOperations.DropRecord(Students);
                    break;
                case ConsoleKey.D5: // Добавление записи в файл
                    studentOperations.AddRecord(Students);
                    break;
                case ConsoleKey.Escape: // Закрытие приложения
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\nНажмите конкретную кнопку от 1 до 5 или Esc для выхода из приложения.");
                    break;
            }
        }
    }
}
//try
//{
//    path = Environment.CurrentDirectory + "\\studentsinfo.csv"; // Создание пути для csv файла
//}
//catch
//{
//    Console.WriteLine(" Файл по данному адресу отсутствует. Введите прямой адрес:");
//    path = Console.ReadLine();
//}