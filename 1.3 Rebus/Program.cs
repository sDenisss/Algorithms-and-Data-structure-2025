using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        List<int> a = new List<int> { 1 };
        int now = 0, total = 1, n;
        
        string[] tokens = input.Split(' ');
        int index = 0;
        while (tokens[index] != "=")
        {
            if (tokens[index] == "+")
            {
                a.Add(1);
                total++;
            }
            else if (tokens[index] == "-")
            {
                a.Add(-1);
                total--;
            }
            index++;
        }
        n = int.Parse(tokens[index + 1]);
        
        for (int i = 0; i < a.Count; i++)
        {
            if (a[i] > 0)
            {
                while (a[i] < n && total < n)
                {
                    a[i]++;
                    total++;
                }
            }
            else
            {
                while (a[i] > -n && total > n)
                {
                    a[i]--;
                    total--;
                }
            }
        }
        
        if (total != n)
        {
            Console.WriteLine("Impossible");
        }
        else
        {
            Console.WriteLine("Possible");
            Console.Write(a[0]);
            for (int i = 1; i < a.Count; i++)
            {
                Console.Write(a[i] > 0 ? " + " : " - ");
                Console.Write(Math.Abs(a[i]));
            }
            Console.WriteLine(" = " + n);
        }
    }
}




// using System;
// using System.Runtime.InteropServices;

// public class Program
// {
//     public static void Main()
//     {
//         // string? str = Console.ReadLine();
//         // string? s = "? + ? - ? + ? + ? = 42";
//         // string? s = Console.ReadLine();
//         // string? s = "? - ? = 1";
//         // string? s = "? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? + ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? + ? - ? - ? - ? - ? + ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? = 32";
//         string? s = "? + ? - ? - ? - ? + ? + ? - ? + ? + ? - ? - ? - ? - ? - ? - ? + ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? - ? + ? - ? - ? - ? - ? + ? - ? - ? - ? + ? - ? - ? - ? + ? - ? - ? - ? - ? - ? + ? - ? - ? - ? + ? - ? - ? - ? - ? - ? - ? - ? - ? - ? + ? - ? - ? - ? + ? - ? - ? - ? + ? - ? - ? + ? - ? + ? - ? - ? - ? - ? + ? - ? - ? - ? - ? - ? - ? + ? - ? - ? - ? - ? - ? - ? - ? - ? = 5";
//         // string? s = "15 - 2 - 2 - 2 + 20 - 2 - 2 - 10 = 15";
//         // string? s = "? - ? - ? - ? + ? - ? - ? - ? = 15";
//         // string? s = "? = 1000000";
//         string[] parts = s.Split(' ');
//         // foreach (var item in parts)
//         // {
//         //     System.Console.WriteLine(item);
//         // }
//         BuildRebus(parts);

//         // foreach (var item in parts)
//         // {
//         //     System.Console.WriteLine(item);
//         // }
//     }

//     static void BuildRebus(string[] parts)
//     {
//         int n = int.Parse(parts[parts.Length - 1]);
//         int pos = 1;
//         int neg = 0;

//         for (int i = 1; i < parts.Length-3; i+=2)
//         {
//             if (parts[i] == "+")
//             {
//                 pos++;
//             }
//             else
//             {
//                 neg++;
//             }
//         }

//         // int min = GetMin(n, pos, neg);
//         // int max = GetMax(n, pos, neg);
     
//         if (IsPossible(GetMin(n, pos, neg), GetMax(n, pos, neg), n))
//         {
//             System.Console.WriteLine("Possible");
//             int neg_value = --pos;
//             int pos_value = neg;
//             if (parts.Length == 2)
//             {
//                 parts[0] = n.ToString();
//             }
//             else if (parts.Length == 4)
//             {
//                 if (parts[2] == "+")
//                 {
//                     parts[0] = (n-1).ToString();
//                     parts[4] = 1.ToString();
//                 }
//                 else
//                 {
//                     parts[0] = (n+1).ToString();
//                     parts[4] = 1.ToString();
//                 }
//             }
//             else
//             {
//                 parts[0] = n.ToString();
//                 int temp_for_neg = (pos_value-n)*pos;
//                 // System.Console.WriteLine(temp_for_neg);
//                 int temp_for_pos = (neg_value-n)*neg;
//                 bool isMinimized = false;
//                 System.Console.WriteLine(neg);
//                 System.Console.WriteLine(pos);
//                 for (int i = 2; i < parts.Length-2; i+=2)
//                 {
//                     if (parts[i-1] == "-")
//                     {
//                         if (temp_for_neg > 0 && temp_for_neg >= n)
//                         {
//                             parts[i] = 1.ToString();
//                             temp_for_neg -= n;
//                             pos_value = n;
//                             isMinimized = true;
//                             // neg_value = n;
//                             // neg_value = n;
//                             // System.Console.WriteLine(neg_value);
//                         }
//                         else if (temp_for_neg > 0 && temp_for_neg < n)
//                         {
//                             parts[i] = temp_for_neg.ToString();
//                             pos_value = n;
//                             neg_value = temp_for_neg;
//                             isMinimized = true;
//                         }
//                         else
//                         {
//                             if (isMinimized)
//                             {
//                                 parts[i] = 1.ToString();
//                             }
//                             else
//                             {
//                                 parts[i] = neg_value.ToString();
//                             }
//                             // System.Console.WriteLine(pos);
                            
//                         }
//                     }
//                     else
//                     {
//                         if (temp_for_pos > 0 && temp_for_pos >= n)
//                         {
//                             parts[i] = 1.ToString();
//                             temp_for_pos -= n;
//                             pos_value = n;
//                             isMinimized = true;
//                             // neg_value = n;
//                             // neg_value = n;
//                             // System.Console.WriteLine(neg_value);
//                         }
//                         else if (temp_for_pos > 0 && temp_for_pos < n)
//                         {
//                             parts[i] = temp_for_pos.ToString();
//                             pos_value = n;
//                             neg_value = temp_for_pos;
//                             isMinimized = true;
//                         }
//                         else
//                         {
//                             if (isMinimized)
//                             {
//                                 parts[i] = 1.ToString();
//                             }
//                             else
//                             {
//                                 parts[i] = pos_value.ToString();
//                             }
//                             // System.Console.WriteLine(pos);
                            
//                         }
//                         //////////////////
//                         parts[i] = pos_value.ToString();
//                     }
//                     // parts[i] = "s";
//                 }

//             }
//             Console.WriteLine(string.Join(" ", parts));
//             // foreach (var item in parts)
//             // {
//             //     System.Console.WriteLine("res " + item);
//             // }
            
//         }
//         else 
//         {
//             System.Console.WriteLine("Impossible");
//         }
//     }

//     static bool IsPossible(int min, int max, int n)
//     {
//         return (min <= n && n <= max) ? true : false;
//     }

//     static int GetMin(int n, int pos, int neg)
//     {
//         return 1 * pos - n * neg;
//     }

//     static int GetMax(int n, int pos, int neg)
//     {
//         return n * pos - 1 * neg;
//     }
// }


