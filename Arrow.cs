using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Конвертатор
{
    internal class Arrow
    {
        public static void Main(int min, int max, ConsoleKeyInfo key, string[] data_text)
        {
            if (key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.DownArrow || key.Key == ConsoleKey.RightArrow || key.Key == ConsoleKey.LeftArrow)
            {
                Arrow.Show(min, max, key, data_text);
            }
            else
            {
                Edit(key, data_text);
            }
        }
        private static void Show(int min, int max, ConsoleKeyInfo key, string[] data_text)
        {
            int x = Console.GetCursorPosition().Item1;
            int y = Console.GetCursorPosition().Item2;
            if (key.Key == ConsoleKey.UpArrow && y != min)
            {
                y--;
            }
            else if (key.Key == ConsoleKey.DownArrow && y != max)
            {
                y++;
            }
            else if (key.Key == ConsoleKey.LeftArrow && x != 0)
                x--;
            else if (key.Key == ConsoleKey.RightArrow && x != data_text[y-1].Length)
            {
                x++;
            }
            if (x > data_text[y-1].Length)
            {
                x = data_text[y-1].Length;
            }
            Console.SetCursorPosition(x, y);
            return;
        }
        private static void Edit(ConsoleKeyInfo key, string[] data_text)
        {
            int x = Console.GetCursorPosition().Item1;
            int y = Console.GetCursorPosition().Item2;
            if ((key.Key == ConsoleKey.Delete || key.Key == ConsoleKey.Backspace) && data_text.Length > 0)
            {
                data_text[y - 1] = data_text[y - 1].Remove(data_text[y - 1].Length - 1);
            }
            else
            {
                data_text[y - 1] += key.KeyChar;
            }
            Program.Print(data_text);
            Console.SetCursorPosition(x, y);
        }
    }
}
