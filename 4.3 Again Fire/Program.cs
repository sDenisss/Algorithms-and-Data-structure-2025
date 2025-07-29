using System;
using System.Collections.Generic;
using System.IO;                              // для StreamReader/StreamWriter

class Program
{
    static void Main()
    {
        // Открываем файлы для чтения/записи :contentReference[oaicite:0]{index=0}
        using var reader = new StreamReader("input.txt");
        using var writer = new StreamWriter("output.txt");

        // Читаем размеры леса
        var parts = reader.ReadLine().Split();
        int n = int.Parse(parts[0]), m = int.Parse(parts[1]);

        // Число начальных источников огня
        int k = int.Parse(reader.ReadLine());

        // Очередь для BFS и массив расстояний (время возгорания)
        var q = new Queue<(int x, int y)>();
        int[,] dist = new int[n, m];

        // Инициализируем dist = -1 (не посещено) :contentReference[oaicite:1]{index=1}
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                dist[i, j] = -1;

        // Читаем координаты источников огня (1‑индекс → 0‑индекс)
        parts = reader.ReadLine().Split();
        for (int i = 0; i < k; i++)
        {
            int x = int.Parse(parts[2*i]) - 1;
            int y = int.Parse(parts[2*i + 1]) - 1;
            dist[x, y] = 0;
            q.Enqueue((x, y));
        }

        // Вектора движений: вверх, вниз, влево, вправо :contentReference[oaicite:2]{index=2}
        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };

        // Многореждный BFS
        while (q.Count > 0)
        {
            var (x, y) = q.Dequeue();
            int d = dist[x, y];
            for (int dir = 0; dir < 4; dir++)
            {
                int nx = x + dx[dir];
                int ny = y + dy[dir];
                if (nx >= 0 && nx < n && ny >= 0 && ny < m && dist[nx, ny] == -1)
                {
                    dist[nx, ny] = d + 1;
                    q.Enqueue((nx, ny));
                }
            }
        }

        // Ищем клетку с максимальным временем возгорания
        int bestX = 0, bestY = 0, bestD = -1;
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                if (dist[i, j] > bestD)
                {
                    bestD = dist[i, j];
                    bestX = i;
                    bestY = j;
                }

        // Пишем ответ в файл (возвращаем 1‑индекс) :contentReference[oaicite:3]{index=3}
        writer.Write((bestX + 1) + " " + (bestY + 1));
    }
}
