using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Считываем входные данные
        var input = Console.ReadLine().Split();
        int n = int.Parse(input[0]);
        int k = int.Parse(input[1]);

        string[] numbers = new string[n];
        for (int i = 0; i < n; i++)
        {
            numbers[i] = Console.ReadLine();
        }

        // Генерируем все перестановки индексов от 0 до k-1
        var permutations = GetPermutations(Enumerable.Range(0, k).ToArray());

        int minDifference = int.MaxValue;

        // Пробуем все перестановки
        foreach (var perm in permutations)
        {
            List<int> transformedNumbers = new List<int>();

            // Преобразуем все числа по текущему порядку цифр
            foreach (string num in numbers)
            {
                char[] newNumber = new char[k];
                for (int i = 0; i < k; i++)
                {
                    newNumber[i] = num[perm[i]];
                }
                transformedNumbers.Add(int.Parse(new string(newNumber)));
            }

            // Вычисляем min и max
            int minNum = transformedNumbers.Min();
            int maxNum = transformedNumbers.Max();
            int diff = maxNum - minNum;

            // Обновляем минимальную разницу
            minDifference = Math.Min(minDifference, diff);
        }

        // Выводим минимальную разницу
        Console.WriteLine(minDifference);
    }

    // Функция генерации всех перестановок массива (рекурсивный backtracking)
    static List<int[]> GetPermutations(int[] arr)
    {
        var result = new List<int[]>();
        Generate(arr, 0, result);
        return result;
    }

    static void Generate(int[] arr, int index, List<int[]> result)
    {
        if (index == arr.Length - 1)
        {
            result.Add((int[])arr.Clone());
            return;
        }

        for (int i = index; i < arr.Length; i++)
        {
            Swap(arr, index, i);
            Generate(arr, index + 1, result);
            Swap(arr, index, i); // Возвращаем обратно
        }
    }

    static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
}
