using System;

public class Program
{
    public static void Main()
    {
        long n = long.Parse(Console.ReadLine());
        Console.WriteLine(SolveCountOfPair(n));
    }

    static int MaxNines(long x)
    {
        long c = x, digits = 0, i = 1;
        while (c != 0)
        {
            digits++;
            c /= 10;
            i *= 10;
        }
        return (x == i - 1) ? (int)digits : (int)(digits - 1);
    }

    static long F(long x)
    {
        return (x % 2 == 1) ? x + 1 : x;
    }

    static long SolveCountOfPair(long n)
    {
        int k = MaxNines(2 * n - 1);
        if (k == 0)
        {
            return n * (n - 1) / 2;
        }

        long num = 0, i = 1;
        for (int kCopy = 0; kCopy < k; kCopy++)
        {
            num = num * 10 + 9;
            i *= 10;
        }

        long ans = Math.Min(F(Math.Abs(num - n - n)) / 2, (num - 1) / 2);

        for (int j = 1; j < 10; j++)
        {
            // Console.WriteLine(ans);
            num += i;
            if (num > 2 * n - 1)
                break;

            ans += Math.Min(F(Math.Abs(num - n - n)) / 2, (num - 1) / 2);
        }
        return ans;
    }
}



// using System;
// using System.Collections.Generic;
// public class Program
// {
    
//     public static void Main()
//     {
//         int n = int.Parse(Console.ReadLine()); // Читаем количество



//         Console.WriteLine(SolveCountOfPair(n));

//     }

//     static int SolveCountOfPair(int n)
//     {
//         int sum = n + (n - 1);
//         if(IsOnlyNine(sum))
//         {
//             return 1;
//         }
//         else
//         {
//             var valuesWithNine = new List<int>();
//             int len = (int)Math.Floor(Math.Log10(sum) + 1);
//             int huy = 9;
//             int result = 0;
//             while(huy <= sum)
//             {
//                 valuesWithNine.Add(huy);
//                 huy+=10;
//             }

//             foreach (var p in valuesWithNine)
//             {
                
//                 // System.Console.WriteLine("d " + p);
//                 if (p <= (n+1))
//                 {
//                     result += p/2;   
//                 }
//                 else
//                 {
//                     result += (n-(p-n)+1)/2;
//                 }
//             }
//             return result; 
//         }
        
//     }

//     static bool IsOnlyNine(int sum)
//     {
//         string sumStr = sum.ToString();
//         char firstDigit = sumStr[0];

//         foreach (var item in sumStr)
//         {
//             if (item != firstDigit)
//             {
//                 return false;
//             }
//         }

//         return true;
        
//     }
// }
