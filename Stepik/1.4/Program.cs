using System;
using System.Collections.Generic;

public class MainClass
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        Stack<int> stack = new Stack<int>();
        Stack<int> maxStack = new Stack<int>();

        for (int i = 0; i < n; i++)
        {
            string request = Console.ReadLine();
            string[] parts = request.Split(' ');

            if (parts[0] == "push")
            {
                int value = int.Parse(parts[1]);
                stack.Push(value);

                // Обновляем стек максимумов
                if (maxStack.Count == 0 || value >= maxStack.Peek())
                {
                    maxStack.Push(value);
                }
            }
            else if (parts[0] == "pop")
            {
                if (stack.Count > 0)
                {
                    int poppedValue = stack.Pop();

                    // Если удаляемое значение было максимумом, удаляем его из стека максимумов
                    if (maxStack.Count > 0 && poppedValue == maxStack.Peek())
                    {
                        maxStack.Pop();
                    }
                }
            }
            else if (parts[0] == "max")
            {
                if (maxStack.Count > 0)
                {
                    Console.WriteLine(maxStack.Peek());
                }
            }
        }
    }
}