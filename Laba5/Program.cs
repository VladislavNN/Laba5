using System;

namespace Laba5
{
    class Program
    {
        public static void Main()
        {
            Task1();
            Task2();
            Task4();
        }

        public static void Task1()
        {
            Console.WriteLine("Введите число, либо \'q\' для завершения");
            var readLineString = "";
            var float1 = float.NaN;
            var float2 = float.NaN;
            while (readLineString != "q")
            {
                readLineString = Console.ReadLine();
                if (int.TryParse(readLineString, out int intNumber))
                {
                    Console.WriteLine((char)intNumber);
                    break;
                }
                else if (float.TryParse(readLineString, out float2))
                {
                    if (float2 == float1)
                        break;
                    else
                    {
                        float1 = float2;
                        float2 = float.NaN;
                    }
                }
            }
            Console.WriteLine("Ввод прекращён");
            Console.ReadKey();
        }

        public static void Task2()
        {
            Console.WriteLine("Введите число на проверку целочисленности");
            var readLineString = Console.ReadLine();
            var digitArray = readLineString.ToCharArray();
            var isIntNumberCorrect = true;
            if (digitArray.Length > 1 && (digitArray[0] == '-' || digitArray[0] == '+'))
                for (int i = 1; i < digitArray.Length; i++)
                {
                    if (!char.IsDigit(digitArray[i]))
                    {
                        isIntNumberCorrect = false;
                        Console.WriteLine("Число не является целым");
                        break;
                    }
                }
            else if (digitArray.Length > 0)
                for (int i = 0; i < digitArray.Length; i++)
                {
                    if (!char.IsDigit(digitArray[i]))
                    {
                        isIntNumberCorrect = false;
                        Console.WriteLine("Число не является целым");
                        break;
                    }
                }
            else
                Console.WriteLine("Пустая строка");
            if (isIntNumberCorrect)
                Console.WriteLine("Число является целым");
        }

        public static void Task4()
        {
            Console.WriteLine("Введите числа через пробел(дробные числа вводить через запятую)");
            var numbersArray = Console.ReadLine().Split(' ');
            var resultArray = new string[numbersArray.Length];
            var isArrayCorrect = true;
            for (int i = 0; i < numbersArray.Length; i++)
            {
                if (int.TryParse(numbersArray[i], out var intNumber))
                {
                    resultArray[i] = CountFactorial(intNumber).ToString();
                }
                else if (double.TryParse(numbersArray[i], out var doubleNumber))
                {
                    resultArray[i] = TransformDoubleNum(doubleNumber).ToString();
                }
                else
                {
                    isArrayCorrect = false;
                    break;
                }
            }
            if (isArrayCorrect)
            {
                Console.WriteLine("Изначальный массив: ");
                Console.Write(String.Join(", ", numbersArray));
                Console.WriteLine("\nИзменённый массив: ");
                Console.Write(String.Join(", ", resultArray));
            }
            else
            {
                Console.WriteLine("В массиве находится элемент, не являющийся числом");
            }
        }

        public static long CountFactorial(int number)
        {
            var result = 1;
            for (int i = 1; i <= number; i++)
            {
                result *= i;
            }
            return result;
        }

        public static int TransformDoubleNum(double number)
        {
            number = Math.Round(number, 2);
            var dotIndex = number.ToString().IndexOf(',');
            var resultNum = number.ToString().Substring(dotIndex + 1);
            return int.Parse(resultNum);
        }
    }
}