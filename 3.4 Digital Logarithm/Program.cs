using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static int DigLog(int x) => x.ToString().Length;

    static void Main()
    {
        int t = int.Parse(Console.ReadLine());
        while (t-- > 0)
        {
            int n = int.Parse(Console.ReadLine());
            var a = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var b = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            var pqA = new MaxHeap();
            var pqB = new MaxHeap();
            foreach (var x in a) pqA.Push(x);
            foreach (var x in b) pqB.Push(x);

            int ops = 0;
            while (pqA.Count > 0 && pqB.Count > 0)
            {
                int x = pqA.Peek(), y = pqB.Peek();
                if (x == y)
                {
                    pqA.Pop();
                    pqB.Pop();
                }
                else if (x > y)
                {
                    pqA.Pop();
                    pqA.Push(DigLog(x));
                    ops++;
                }
                else
                {
                    pqB.Pop();
                    pqB.Push(DigLog(y));
                    ops++;
                }
            }

            Console.WriteLine(ops);
        }
    }
}

/// <summary>Куча для int с извлечением максимума.</summary>
class MaxHeap
{
    private List<int> data = new List<int>();

    public int Count => data.Count;

    public void Push(int x)
    {
        data.Add(x);
        int i = data.Count - 1;
        while (i > 0)
        {
            int p = (i - 1) >> 1;
            if (data[p] >= data[i]) break;
            (data[p], data[i]) = (data[i], data[p]);
            i = p;
        }
    }

    public int Pop()
    {
        int root = data[0];
        int last = data[data.Count - 1];
        data.RemoveAt(data.Count - 1);
        if (data.Count > 0)
        {
            data[0] = last;
            Heapify(0);
        }
        return root;
    }

    public int Peek() => data[0];

    private void Heapify(int i)
    {
        int n = data.Count;
        while (true)
        {
            int l = (i << 1) + 1, r = l + 1, largest = i;
            if (l < n && data[l] > data[largest]) largest = l;
            if (r < n && data[r] > data[largest]) largest = r;
            if (largest == i) break;
            (data[i], data[largest]) = (data[largest], data[i]);
            i = largest;
        }
    }
}


// using System;
// using System.Collections.Generic;
// using System.Linq;

// class Program
// {
//     static void Main()
//     {
//         int t = int.Parse(Console.ReadLine()); // Количество тестов
//         while (t-- > 0)
//         {
//             int n = int.Parse(Console.ReadLine()); // Количество элементов
//             int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
//             int[] b = Console.ReadLine().Split().Select(int.Parse).ToArray();

//             Console.WriteLine(Solve(n, a, b)); // Решаем каждый тест
//         }
//     }

//     static int Solve(int n, int[] a, int[] b)
//     {
//         Dictionary<int, int> cntA = new Dictionary<int, int>();
//         Dictionary<int, int> cntB = new Dictionary<int, int>();

//         // Считаем количество каждого числа в a и b
//         foreach (var x in a)
//         {
//             if (!cntA.ContainsKey(x))
//                 cntA[x] = 0;
//             cntA[x]++;
//         }
//         foreach (var x in b)
//         {
//             if (!cntB.ContainsKey(x))
//                 cntB[x] = 0;
//             cntB[x]++;
//         }

//         int operations = 0;

//         // Сначала вычтем совпадающие элементы
//         foreach (var key in cntA.Keys.ToList())
//         {
//             if (cntB.ContainsKey(key))
//             {
//                 int common = Math.Min(cntA[key], cntB[key]);
//                 cntA[key] -= common;
//                 cntB[key] -= common;
//                 if (cntB[key] == 0) cntB.Remove(key);
//                 if (cntA[key] == 0) cntA.Remove(key);
//             }
//         }

//         // Теперь для всех оставшихся элементов превращаем числа в длину
//         List<int> listA = new List<int>();
//         List<int> listB = new List<int>();

//         foreach (var pair in cntA)
//         {
//             for (int i = 0; i < pair.Value; i++)
//                 listA.Add(pair.Key);
//         }
//         foreach (var pair in cntB)
//         {
//             for (int i = 0; i < pair.Value; i++)
//                 listB.Add(pair.Key);
//         }

//         cntA.Clear();
//         cntB.Clear();

//         // Переводим числа >9 в их длину
//         foreach (var x in listA)
//         {
//             if (x >= 10)
//             {
//                 int fx = f(x);
//                 if (!cntA.ContainsKey(fx))
//                     cntA[fx] = 0;
//                 cntA[fx]++;
//                 operations++;
//             }
//             else
//             {
//                 if (!cntA.ContainsKey(x))
//                     cntA[x] = 0;
//                 cntA[x]++;
//             }
//         }

//         foreach (var x in listB)
//         {
//             if (x >= 10)
//             {
//                 int fx = f(x);
//                 if (!cntB.ContainsKey(fx))
//                     cntB[fx] = 0;
//                 cntB[fx]++;
//                 operations++;
//             }
//             else
//             {
//                 if (!cntB.ContainsKey(x))
//                     cntB[x] = 0;
//                 cntB[x]++;
//             }
//         }

//         // Вычитаем совпадающие элементы снова
//         foreach (var key in cntA.Keys.ToList())
//         {
//             if (cntB.ContainsKey(key))
//             {
//                 int common = Math.Min(cntA[key], cntB[key]);
//                 cntA[key] -= common;
//                 cntB[key] -= common;
//                 if (cntB[key] == 0) cntB.Remove(key);
//                 if (cntA[key] == 0) cntA.Remove(key);
//             }
//         }

//         // Остались только числа 1..9
//         // Все несовпавшие теперь нужно будет ещё раз обработать
//         int remaining = 0;
//         foreach (var pair in cntA)
//             remaining += pair.Value;
//         foreach (var pair in cntB)
//             remaining += pair.Value;

//         operations += remaining;

//         return operations;
//     }

//     // Функция f(x) — длина числа
//     static int f(int x)
//     {
//         return x.ToString().Length;
//     }
// }
