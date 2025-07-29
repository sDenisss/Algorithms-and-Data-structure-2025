using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Читаем входные данные
        int n = int.Parse(Console.ReadLine());
        int[] a = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int[] b = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        List<string> swaps = new List<string>();

        // Создаем индексный словарь: значение → список индексов в b
        Dictionary<int, Queue<int>> index_map = new Dictionary<int, Queue<int>>();
        
    }
}
