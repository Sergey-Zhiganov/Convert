using Newtonsoft.Json;
using System.Xml.Serialization;
using Конвертатор;

namespace Конвертатор
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                List<Employee> data = new List<Employee>();
                Console.WriteLine("Введите путь к файлу с названием файла");
                do
                {
                    string path = Console.ReadLine();
                    data = Files.Main(path, 1);
                } while (data == null);

                string[] data_text = new string[data.Count * 5];
                int a = 0;
                foreach (var item in data)
                {
                    data_text[a] = item.FullName;
                    a++;
                    data_text[a] = item.Age;
                    a++;
                    data_text[a] = item.Post;
                    a++;
                    data_text[a] = item.Salary;
                    a++;
                    data_text[a] = item.Experience;
                    a++;
                }
                Print(data_text);
                Console.SetCursorPosition(0, 1);
                while (true)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.F1)
                    {
                        Console.Clear();
                        List<Employee> result;
                        do
                        {
                            Console.WriteLine("Введите путь конечного файла");
                            string path = Console.ReadLine();
                            result = Files.Main(path, 2, data_text);
                        } while (result == null);
                        Console.WriteLine("Файл сохранён");
                        break;
                    }
                    else if (key.Key == ConsoleKey.Escape)
                    {
                        Console.SetCursorPosition(0, data_text.Length+1);
                        return;
                    }
                    else
                    {
                        Arrow.Main(1, data.Count * 5, key, data_text);
                    }
                }
            }
        }
        public static void Print(string[] data_text)
        {
            Console.Clear();
            Console.WriteLine("Нажмите F1 для сохранение данных, Escape для завершения программы");
            foreach (var item in data_text)
            {
                Console.WriteLine(item);
            }
        }
    }
}
