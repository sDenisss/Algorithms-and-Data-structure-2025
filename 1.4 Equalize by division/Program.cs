using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int t = int.Parse(Console.ReadLine());
        
        while (t-- > 0)
        {
            Dictionary<long, long> ma = new Dictionary<long, long>();
            long n = long.Parse(Console.ReadLine());
            long f = 0;
            
            for (long i = 0; i < n; i++)
            {
                long b = long.Parse(Console.ReadLine());
                GetPrime(b, ma);
            }
            
            foreach (var entry in ma)
            {
                if (entry.Value % n != 0)
                {
                    f = 1;
                    break;
                }
            }
            
            Console.WriteLine(f == 0 ? "YES" : "NO");
        }
    }

    static void GetPrime(long p, Dictionary<long, long> ma)
    {
        while (p % 2 == 0)
        {
            if (!ma.ContainsKey(2))
                ma[2] = 0;
            ma[2]++;
            p /= 2;
        }
        
        for (long i = 3; i * i <= p; i += 2)
        {
            while (p % i == 0)
            {
                if (!ma.ContainsKey(i))
                    ma[i] = 0;
                ma[i]++;
                p /= i;
            }
        }
        
        if (p > 1)
        {
            if (!ma.ContainsKey(p))
                ma[p] = 0;
            ma[p]++;
        }
    }
    
    
}
