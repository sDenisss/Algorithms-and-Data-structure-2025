using System;
using System.Collections.Generic;

class Program
{
    static int n;
    static int[] a;
    static bool[] visited;
    static int[] indexInPath;
    static List<int> cycleLengths;

    static void Main()
    {
        var t = int.Parse(Console.ReadLine());
        while (t-- > 0)
        {
            n = int.Parse(Console.ReadLine());
            a = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            visited = new bool[n];
            indexInPath = new int[n];
            Array.Fill(indexInPath, -1);
            cycleLengths = new List<int>();

            // находим все циклы
            for (int i = 0; i < n; i++)
                if (!visited[i])
                    FindCycle(i);

            int cnt2 = 0, cntGe3 = 0, min, max = 0;
            foreach (int len in cycleLengths)
            {
                if (len == 2) cnt2++;
                else if (len >= 3) cntGe3++;
                max += (len % 2 == 0 ? len / 2 : 1);
            }
            min = cntGe3 + (cnt2 > 0 ? 1 : 0);

            Console.WriteLine(min + " " + max);
        }
    }

    static void FindCycle(int start)
    {
        var path = new List<int>();
        int u = start;
        while (!visited[u])
        {
            visited[u] = true;
            indexInPath[u] = path.Count;
            path.Add(u);
            u = a[u] - 1;
        }
        if (indexInPath[u] != -1)
        {
            int len = path.Count - indexInPath[u];
            cycleLengths.Add(len);
        }
        // сброс меток
        foreach (var v in path)
            indexInPath[v] = -1;
    }
}
