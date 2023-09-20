using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISLab1
{
    using System;
    using System.Text.RegularExpressions;

    public class Check
    {
        public static string StringCheck()
        {
            string input;
            while (true)
            {
                input = Console.ReadLine();
                if (IsAllLetters(input))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("\nОшибка. Используйте только буквы кириллицы.");
                }
            }
        }

        public static bool IsAllLetters(string input)
        {
            return Regex.IsMatch(input, @"^[А-яа-я]+$");
        }

        public static string DateCheck()
        {
            string input;
            while (true)
            {
                input = Console.ReadLine();
                if (IsDateValid(input))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("\nОшибка. Используйте формат ГГГГ-ММ-ДД и вводите только цифры.");
                }
            }
        }

        public static bool IsDateValid(string input)
        {
            return Regex.IsMatch(input, @"^\d{4}-\d{2}-\d{2}$") && DateTime.TryParseExact(input, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out _);
        }

        public static bool BoolCheck()
        {
            int varbool = 0;
            bool exit = false;
            while (!exit)
            {
                varbool = Convert.ToInt32(IntCheck());
                if (varbool == 0 || varbool == 1)
                {
                    exit = true;
                }
                else Console.WriteLine("\nОшибка. Используйте только цифры 0 или 1");
            }
            if (varbool == 0) return true;
            return false;
        }

        public static uint IntCheck()
        {
            uint varint = 0;
            bool exit = false;
            while (!exit)
            {
                try
                {
                    varint = uint.Parse(Console.ReadLine());
                    exit = true;
                }
                catch
                {
                    Console.WriteLine("\nОшибка. Используйте целые положительные числа");
                }
            }
            return varint;
        }
    }

}






//singlton