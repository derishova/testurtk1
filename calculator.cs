using System;
using System.Globalization;

class Calculator
{
    static void Main(string[] args)
    {
        Console.WriteLine("Консольный калькулятор");
        while (true)
        {
            Console.WriteLine("Введите выражение (например: 5 + 3):");

            string? input = Console.ReadLine();

            if (input?.ToLower() == "exit")
                break;

            try
            {
                double result = Calculate(input);
                Console.WriteLine($"Результат: {result:F2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.WriteLine("Для выхода введите 'exit'");
        }
    }

    static double Calculate(string input)
    {
        string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length != 3)
        {
            throw new ArgumentException("Неверный формат ввода. Используйте: число оператор число");
        }
        if (!double.TryParse(parts[0], NumberStyles.Any, CultureInfo.InvariantCulture, out double num1))
        {
            throw new ArgumentException("Неверный формат первого числа");
        }
        if (!double.TryParse(parts[2], NumberStyles.Any, CultureInfo.InvariantCulture, out double num2))
        {
            throw new ArgumentException("Неверный формат второго числа");
        }

        string operation = parts[1];

        return operation switch
        {
            "+" => Add(num1, num2),
            "-" => Subtract(num1, num2),
            "*" => Multiply(num1, num2),
            "/" => Divide(num1, num2),
            _ => throw new ArgumentException($"Неизвестная операция: {operation}")
        };
    }

    static double Add(double a, double b)
    {
        return a + b;
    }
    static double Subtract(double a, double b)
    {
        return a - b;
    }

    static double Multiply(double a, double b)
    {
        return a * b;
    }

    static double Divide(double a, double b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Деление на ноль невозможно");
        }
        return a / b;
    }
}