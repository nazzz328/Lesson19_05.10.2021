using System;

namespace ConsoleApp
{
    class Program
    {
        delegate T Operation<T>(T x, T y);
        static void Main(string[] args)
        {
            try
            {
                // Укажите тип, принимаемый делегатом:
                Operation<float> operation;

                // Укажите числа для вычисления:
                var v1 = 5.0f;
                var v2 = 0;

                bool cycle = true;
                while (cycle)
                {
                    Console.Write($"Выберите арифметическую операцию между числами {v1} и {v2}: \n1. Сложение.\n2. Вычитание.\n3.Умножение.\n4.Деление.\n5. Выход.\n\nВвод:  ");
                    int.TryParse(Console.ReadLine(), out var choice);
                    switch (choice)
                    {
                        case 1:
                            operation = Sum;
                            var result_sum = operation?.Invoke(v1, v2);
                            Console.WriteLine($"Результат операции: {result_sum}");
                            break;
                        case 2:
                            operation = Subtract;
                            var result_subt = operation?.Invoke(v1, v2);
                            Console.WriteLine($"Результат операции: {result_subt}");
                            break;
                        case 3:
                            operation = Multiply;
                            var result_mult = operation?.Invoke(v1, v2);
                            Console.WriteLine($"Результат операции: {result_mult}");
                            break;
                        case 4:
                            operation = Divide;
                            var result_div = operation?.Invoke(v1, v2);
                            Console.WriteLine($"Результат операции: {result_div}");
                            break;
                        case 5:
                            cycle = false;
                            break;
                        default:
                            Console.WriteLine("Неправильный ввод.");
                            break;
                    }
                    Console.WriteLine("Нажмите любую клавишу...");
                    Console.ReadKey();
                    Console.Clear();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static T Sum<T>(T x, T y)
        {
            return (dynamic)x + (dynamic)y;
        }
        static T Subtract<T>(T x, T y)
        {
            return (dynamic)x - (dynamic)y;
        }
        static T Multiply<T>(T x, T y)
        {
            return (dynamic)x * (dynamic)y;
        }
        static T Divide<T>(T x, T y)
        {
            if ((dynamic)y == 0)
            {
                return default(T);
            }
            return (dynamic)x / (dynamic)y;
        }

    }
}
