using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] question = new string[]
            {
                "Питання 1, скільки кольорів у веселки?",
                "Питання 2, яка планета найближча до Сонця?",
                "Питання 3, яке місто є столицею Польщі?",
                "Питання 4, скільки градусів у прямому куті?",
                "Питання 5, яке море омиває південь України?"
            };

            string[][] option = new string[][]
            {
                new string[] { "1.5", "2.6", "3.7", "4.8" },
                new string[] { "1.Венера", "2.Меркурій", "3.Марс", "4.Земля" },
                new string[] { "1.Краків", "2.Гданськ", "3.Варшава", "4.Вроцлав" },
                new string[] { "1.45", "2.90", "3.180", "4.360" },
                new string[] { "1.Балтійське", "2.Північне", "3.Червоне", "4.Чорне" }
            };

            int[] correctAnswers = new int[] { 3, 2, 3, 2, 4 };

            int score = 0;

            for (int i = 0; i < question.Length; i++)
            {
                Console.WriteLine("Current User Score: " + score);
                Console.WriteLine(question[i]);
                for (int j = 0; j < option[i].Length; j++)
                {
                    Console.WriteLine(option[i][j]);
                }

                Console.Write("Ваша відповідь: ");
                int answer;
                int.TryParse(Console.ReadLine(), out answer);

                if (answer == correctAnswers[i])
                {
                    score += 100;
                    Console.WriteLine("Correct answer");
                }
                else
                {
                    Console.WriteLine("Wrong Answer");
                    Console.WriteLine("Кінець програми.");
                    Console.ReadLine();
                    return;
                }
                Console.WriteLine();
            }

            Console.WriteLine("Current User Score: " + score);
            Console.WriteLine("Вітаємо, ви відповіли на всі питання!");
            Console.ReadLine();
        }
    }
}
