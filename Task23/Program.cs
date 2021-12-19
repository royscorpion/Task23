using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task23
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вычисление факториала с помощью асинхронного метода\nДля сравнения используем синхронный метод итерационного возведения введенного числа в степень этого же числа");
            Console.Write("Введите целое положительное число: ");
            int n = InputIntNumber();
            _ = FactorialAsync(n);
            DegreeOf(n);
            Console.WriteLine("Нажмите любую клавишу для завершения...");
            Console.ReadKey();
        }
        static async Task FactorialAsync(int n)
        {
            Console.WriteLine($"{n}! = {await Task.Run(() => Factorial(n))}");
        }
        static int Factorial(int n)
        {
            int f = 1;
            for (int i = 2; i < n+1; i++)
            {
                Console.WriteLine($"Factorial. Итерация {i-1}: {f} * {i} = {f *= i}");
                Thread.Sleep(200);
            }
            return f;
        }
        static int DegreeOf(int n)
        {
            int d = n;
            for (int i = 2; i < n+1; i++)
            {
                Console.WriteLine($"DegreeOf. Итерация {i-1}: {d} * {n} = {d *= n}");
                Thread.Sleep(200);
            }
            Console.WriteLine($"{n}^{n} = {d}");
            return d;
        }
        //Проверка корректности введенных данных (integer)
        static int InputIntNumber()
        {
            int number = 0;
            bool x;
            do
            {
                try
                {
                    if((number = Convert.ToInt32(Console.ReadLine())) < 0)
                    {
                        Console.WriteLine("Ошибка! Число не должно быть отрицательным\nПопробуйте еще раз\n");
                        Console.Write("Введите целое число: ");
                        x = true;
                    }
                    else x = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка! {0}\nПопробуйте еще раз\n", ex.Message);
                    Console.Write("Введите целое число: ");
                    x = true;
                }
            } while (x);
            return number;
        }

    }
}
