using System;
using System.Text;
using System.Collections.Generic;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("\n--- МЕНЮ ---");
                Console.WriteLine("1. Закодувати (Encode)");
                Console.WriteLine("2. Декодувати (Decode)");
                Console.WriteLine("3. Найдовший підрядок без повторень");
                Console.WriteLine("0. Вихід");
                Console.Write("\nВаш вибір: ");

                string choice = Console.ReadLine();
                if (choice == "0") break;

                switch (choice)
                {
                    case "1":
                        Console.Write("Введіть текст: ");
                        Console.WriteLine("Результат: " + Encode(Console.ReadLine() ?? ""));
                        break;
                    case "2":
                        Console.Write("Введіть код: ");
                        Console.WriteLine("Результат: " + Decode(Console.ReadLine() ?? ""));
                        break;
                    case "3":
                        Console.Write("Введіть рядок: ");
                        string input = Console.ReadLine() ?? "";
                        int length = LengthOfLongestSubstring(input);
                        Console.WriteLine($"Довжина найдовшого підрядка: {length}");
                        break;
                    default:
                        Console.WriteLine("Невірний вибір.");
                        break;
                }
            }
        }

        public static string Encode(string str)
        {
            if (string.IsNullOrEmpty(str)) return "";
            StringBuilder sb = new StringBuilder();
            int count = 1;
            for (int i = 0; i < str.Length; i++)
            {
                if (i + 1 < str.Length && str[i] == str[i + 1]) count++;
                else
                {
                    sb.Append(count).Append(str[i]);
                    count = 1;
                }
            }
            return sb.ToString();
        }

        public static string Decode(string str)
        {
            if (string.IsNullOrEmpty(str)) return "";
            StringBuilder sb = new StringBuilder();
            string numBuf = "";
            foreach (char c in str)
            {
                if (char.IsDigit(c)) numBuf += c;
                else
                {
                    if (int.TryParse(numBuf, out int count))
                    {
                        sb.Append(new string(c, count));
                        numBuf = "";
                    }
                    else sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public static int LengthOfLongestSubstring(string str)
        {
            if (string.IsNullOrEmpty(str)) return 0;
            HashSet<char> set = new HashSet<char>();
            int max = 0, left = 0;
            for (int right = 0; right < str.Length; right++)
            {
                while (set.Contains(str[right]))
                {
                    set.Remove(str[left]);
                    left++;
                }
                set.Add(str[right]);
                max = Math.Max(max, right - left + 1);
            }
            return max;
        }
    }
}
