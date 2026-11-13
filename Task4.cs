using System;
using System.Collections.Generic;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введіть вираз (наприклад: 5 + 5 * 10 + 4 / 2 - 3):");
            string input = Console.ReadLine();

            try
            {
                double result = Calculate(input);
                Console.WriteLine("Відповідь: " + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка: " + ex.Message);
            }

            Console.ReadLine();
        }

        static double Calculate(string input)
        {
            // Розбиваємо рядок на частини по пробілах
            string[] parts = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length % 2 == 0)
                throw new Exception("неправильний вираз.");

            List<double> numbers = new List<double>();
            List<string> ops = new List<string>();

            for (int i = 0; i < parts.Length; i++)
            {
                if (i % 2 == 0)
                {
                    double n;
                    if (!double.TryParse(parts[i], out n))
                        throw new Exception("'" + parts[i] + "' - це не число.");
                    numbers.Add(n);
                }
                else
                {
                    if (parts[i] != "+" && parts[i] != "-" && parts[i] != "*" && parts[i] != "/")
                        throw new Exception("невідома операція '" + parts[i] + "'.");
                    ops.Add(parts[i]);
                }
            }

            // Перший прохід: множення і ділення
            int k = 0;
            while (k < ops.Count)
            {
                if (ops[k] == "*" || ops[k] == "/")
                {
                    if (ops[k] == "/" && numbers[k + 1] == 0)
                        throw new Exception("на нуль ділити не можна.");

                    if (ops[k] == "*")
                        numbers[k] = numbers[k] * numbers[k + 1];
                    else
                        numbers[k] = numbers[k] / numbers[k + 1];

                    numbers.RemoveAt(k + 1);
                    ops.RemoveAt(k);
                }
                else
                {
                    k++;
                }
            }

            // Другий прохід: додавання і віднімання
            double result = numbers[0];
            for (int i = 0; i < ops.Count; i++)
            {
                if (ops[i] == "+")
                    result += numbers[i + 1];
                else
                    result -= numbers[i + 1];
            }

            return result;
        }
    }
}
