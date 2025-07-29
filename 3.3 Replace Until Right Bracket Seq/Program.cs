using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string s = Console.ReadLine(); // Считываем строку
        Stack<char> stack = new Stack<char>(); // Стек для проверки правильности
        int replacements = 0; // Количество замен

        foreach (char c in s)
        {
            if (IsOpening(c))
            {
                stack.Push(c); // Открывающая скобка — добавляем в стек
            }
            else
            {
                if (stack.Count == 0)
                {
                    Console.WriteLine("Impossible");
                    return; // Закрывающая скобка без соответствующей открывающей
                }

                char top = stack.Pop(); // Достаём последнюю открывающую скобку

                if (!Matches(top, c))
                {
                    replacements++; // Если скобки не совпадают, нужна замена
                }
            }
        }

        // В конце стек должен быть пустой
        if (stack.Count != 0)
        {
            Console.WriteLine("Impossible");
        }
        else
        {
            Console.WriteLine(replacements);
        }
    }

    // Проверка: является ли скобка открывающей
    static bool IsOpening(char c)
    {
        return c == '(' || c == '[' || c == '{' || c == '<';
    }

    // Проверка: совпадают ли открывающая и закрывающая скобки
    static bool Matches(char open, char close)
    {
        return (open == '(' && close == ')') ||
               (open == '[' && close == ']') ||
               (open == '{' && close == '}') ||
               (open == '<' && close == '>');
    }
}
