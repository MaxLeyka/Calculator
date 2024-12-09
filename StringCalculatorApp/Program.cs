using System;
using StringCalculator;

namespace StringCalculatorApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Добро пожаловать в String Calculator!");
            Console.WriteLine("Введите математическое выражение для вычисления (или введите 'exit' для выхода):");

            while (true)
            {

                string input = Console.ReadLine();


                if (input.ToLower() == "exit")
                {
                    break;
                }

                try
                {

                    double result = Calculator.Calculate(input);

                    Console.WriteLine($"Результат: {result}");
                }
                catch (FormatException ex)
                {

                    Console.WriteLine($"Ошибка: {ex.Message}");
                }

                Console.WriteLine("\nВведите другое выражение (или введите 'exit' для выхода):");
            }

            Console.WriteLine("До свидания!");
        }
    }
}
