using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Конвертатор
{
    internal class Files
    {
        public static List<Employee> Main(string path, int choose, string[] data_text = null)
        {
            if (choose == 1)
            {
                return ReadFile(path);
            }
            else
            {
                return SaveFile(path, data_text);
            }
        }
        private static List<Employee> ReadFile(string path)
        {
            List<Employee> data = new List<Employee>();
            if (path.EndsWith(".xml"))
            {
                XmlSerializer xs = new XmlSerializer(typeof(List<Employee>));
                try
                {
                    using (FileStream fs = new FileStream(path, FileMode.Open))
                    {
                        data = (List<Employee>)xs.Deserialize(fs);
                    }
                }
                catch
                {
                    Console.WriteLine("Файл не найден");
                    return null;
                }
            }
            else if (path.EndsWith(".json"))
            {
                string file;
                try
                {
                    file = File.ReadAllText(path);
                }
                catch
                {
                    Console.WriteLine("Файл не найден");
                    return null;
                }
                data = JsonConvert.DeserializeObject<List<Employee>>(file);
            }
            else if (path.EndsWith(".txt"))
            {
                string[] file;
                try
                {
                    file = File.ReadAllLines(path);
                }
                catch
                {
                    Console.WriteLine("Файл не найден");
                    return null;
                }
                int a = 1;
                Employee emp = new Employee();
                foreach (var i in file)
                {
                    switch (a)
                    {
                        case 1:
                            emp.FullName = i;
                            a++;
                            break;
                        case 2:
                            emp.Age = i;
                            a++;
                            break;
                        case 3:
                            emp.Post = i;
                            a++;
                            break;
                        case 4:
                            emp.Salary = i;
                            a++;
                            break;
                        case 5:
                            emp.Experience = i;
                            a = 1;
                            data.Add(emp);
                            emp = new Employee();
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Неверный формат файла");
                return null;
            }
            return data;
        }

        private static List<Employee> SaveFile(string path, string[] data_text)
        {
            int a = 1;
            Employee emp = new Employee();
            List<Employee> data = new List<Employee>();
            foreach (var item in data_text)
            {
                switch(a)
                {
                    case 1:
                        emp.FullName = item;
                        a++;
                        break;
                    case 2:
                        emp.Age = item;
                        a++;
                        break;
                    case 3:
                        emp.Post = item;
                        a++;
                        break;
                    case 4:
                        emp.Salary = item;
                        a++;
                        break;
                    case 5:
                        emp.Experience = item;
                        a = 1;
                        data.Add(emp);
                        emp = new Employee();
                        break;
                }
            }
            if (path.EndsWith(".xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Employee>));
                try
                {
                    using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                    {
                        serializer.Serialize(fs, data);
                    }
                }
                catch
                {
                    Console.WriteLine("Путь не найден");
                    return null;
                }
            }
            else if (path.EndsWith(".json"))
            {
                string json = JsonConvert.SerializeObject(data);
                File.WriteAllText(path, json);
            }
            else if (path.EndsWith(".txt"))
            {
                string data1 = "";
                foreach (Employee emp1 in data)
                {
                    data1 += $"{emp1.FullName}\n{emp1.Age}\n{emp1.Post}\n{emp1.Salary}\n{emp1.Experience}\n";
                }
                try
                {
                    File.WriteAllText(path, data1);
                }
                catch
                {
                    Console.WriteLine("Файл не найден");
                    return null;
                }
            }
            else
            {
                Console.WriteLine("Неверный формат файла");
                return null;
            }
            return data;
        }
    }
}
