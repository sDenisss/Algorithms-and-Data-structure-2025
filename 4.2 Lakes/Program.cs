using System;
using System.Collections.Generic;

class Program
{
    static int n, m;
    static int[,] a;
    static bool[,] visited;
    // Четыре направления: вверх, вниз, влево, вправо
    static readonly int[] dx = { -1, 1, 0, 0 };
    static readonly int[] dy = { 0, 0, -1, 1 };

    static void Main()
    {
        var input = Console.ReadLine().Split();
        int t = int.Parse(input[0]);

        while (t-- > 0)
        {
            input = Console.ReadLine().Split();
            n = int.Parse(input[0]);
            m = int.Parse(input[1]);

            a = new int[n, m];
            visited = new bool[n, m];

            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine().Split();
                for (int j = 0; j < m; j++)
                    a[i, j] = int.Parse(input[j]);
            }

            long maxVolume = 0;

            for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
            {
                if (a[i, j] > 0 && !visited[i, j])
                {
                    long sum = DFS(i, j);
                    if (sum > maxVolume) 
                        maxVolume = sum;
                }
            }

            Console.WriteLine(maxVolume);
        }
    }

    // Рекурсивный DFS, возвращает сумму глубин в компоненте
    static long DFS(int x, int y)
    {
        var stack = new Stack<(int x, int y)>();
        stack.Push((x, y));
        visited[x, y] = true;
        long sum = 0;

        while (stack.Count > 0)
        {
            var (cx, cy) = stack.Pop();
            sum += a[cx, cy];

            for (int d = 0; d < 4; d++)
            {
                int nx = cx + dx[d], ny = cy + dy[d];
                if (nx >= 0 && nx < n && ny >= 0 && ny < m 
                    && !visited[nx, ny] && a[nx, ny] > 0)
                {
                    visited[nx, ny] = true;
                    stack.Push((nx, ny));
                }
            }
        }

        return sum;
    }
}
