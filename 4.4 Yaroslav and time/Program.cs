using System;
using System.IO;
using System.Linq;

class Program
{
    static int n;
    static long d;
    static long[] a;
    static int[] x, y;
    static long[,] cost;

    static void Main()
    {
        var reader = Console.In;
        var writer = Console.Out;

        var parts = reader.ReadLine().Split();
        n = int.Parse(parts[0]);
        d = long.Parse(parts[1]);

        // Read a2..a[n-1], set a[0]=a[n-1]=0
        a = new long[n];
        if (n > 2)
        {
            var arr = reader.ReadLine().Split().Select(long.Parse).ToArray();
            for (int i = 1; i < n - 1; i++)
                a[i] = arr[i - 1];
        }
        else
        {
            // consume line if exists
            if ((n - 2) == 1) reader.ReadLine();
        }

        x = new int[n];
        y = new int[n];
        for (int i = 0; i < n; i++)
        {
            parts = reader.ReadLine().Split();
            x[i] = int.Parse(parts[0]);
            y[i] = int.Parse(parts[1]);
        }

        // Precompute travel cost between every pair
        cost = new long[n, n];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                cost[i, j] = d * (Math.Abs(x[i] - x[j]) + Math.Abs(y[i] - y[j]));

        long low = 0;
        long high = cost[0, n - 1]; // direct travel cost is an upper bound
        // binary search minimal initial time
        while (low < high)
        {
            long mid = (low + high) >> 1;
            if (Check(mid)) high = mid;
            else low = mid + 1;
        }

        writer.WriteLine(low);
    }

    // returns true if, starting with initial time = T, station n-1 reachable
    static bool Check(long T)
    {
        var best = new long[n];
        var used = new bool[n];
        for (int i = 0; i < n; i++) best[i] = -1;
        best[0] = T;

        for (int iterate = 0; iterate < n; iterate++)
        {
            // select unused u with maximal best[u] >= 0
            int u = -1;
            long bv = -1;
            for (int i = 0; i < n; i++)
            {
                if (!used[i] && best[i] >= 0 && best[i] > bv)
                {
                    bv = best[i];
                    u = i;
                }
            }
            if (u == -1) break;
            if (u == n - 1) return true;
            used[u] = true;

            // relax edges from u
            for (int v = 0; v < n; v++)
            {
                if (used[v] || u == v) continue;
                long c = cost[u, v];
                if (best[u] >= c)
                {
                    long nt = best[u] - c + a[v];
                    if (nt > best[v])
                        best[v] = nt;
                }
            }
        }

        return best[n - 1] >= 0;
    }
}
