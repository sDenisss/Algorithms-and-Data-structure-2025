using System;

public class Program
{
    public static void Main()
    {
        int t = int.Parse(Console.ReadLine()); // Читаем количество тестов
        while (t-- > 0)
        {
            int n = int.Parse(Console.ReadLine()); // Читаем длину строки (не используется)
            string s = Console.ReadLine(); // Читаем строку

            Console.WriteLine(MinMovesToCorrectSequence(s));
        }
    }

    static int MinMovesToCorrectSequence(string s)
    {
        int balance = 0, minBalance = 0;

        foreach (char c in s)
        {
            if (c == '(')
                balance++;
            else
                balance--;

            minBalance = Math.Min(minBalance, balance);
        }

        return -minBalance; // Количество перемещений равно модулю минимального баланса
    }
}


// public class Program 
// {
    // static int s = 0;
    // static int n = 0;

    // public static void Main(string[] args)
    // {
        
        // char[] parenthenes = new char[]{
        //     ')', ')', ')', '(', '(', '(', '(', '(', ')', ')'
        // };

        // char[] parenthenes = new char[]{
        //      '(', ')',  '(',')'
        // };
        // string[] parenthenes = {")))((((())"};

        // foreach (var item in parenthenes)
        // {
        //     System.Console.WriteLine(ReturnCountOfStepsString(item));
            
        // }
    // }

    // static int ReturnCountOfStepsString(string parenthenes)
    // {
    //     int balance = 0, minBalance = 0;

    //     foreach (char c in parenthenes)
    //     {
    //         if (c == '(')
    //             balance++;
    //         else
    //             balance--;

    //         minBalance = Math.Min(minBalance, balance);
    //     }

    //     return -minBalance; // Количество перемещений равно модулю минимального баланса
    // }

    // static int ReturnCountOfStepsArray(char[] parenthenes)
    // {
    //     int openPCount = 0;
    //     int closePCount = 0;
        
    //     for(int i = 0; i < parenthenes.Length; i++)
    //     {
    //         System.Console.WriteLine(openPCount + " " + closePCount);
    //         System.Console.WriteLine("N" + n);
    //         if (parenthenes[i] == '(')
    //         {
    //             if(SolveDifference(openPCount, closePCount) < 0)
    //             {
    //                 n++;
    //             }
    //             openPCount++;
    //         }
    //         else
    //         {
    //             closePCount++;
    //         }
    //     }
    //     return n;
    // }
    // static int SolveDifference(int openPCount, int closePCount)
    // {
    //     s = openPCount - closePCount;
    //     return s;
    // }
// }