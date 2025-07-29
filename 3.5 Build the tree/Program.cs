using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] a = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        int[] parent = new int[n];
        List<int> result = new List<int>();

        for (int i = 1; i < n; i++)
        {
            int cur = 0; // начинаем от корня (индекс 0)
            while (true)
            {
                if (a[i] > a[cur])
                {
                    if (parent[cur] == -1 || a[parent[cur]] < a[i])
                    {
                        parent[i] = cur;
                        break;
                    }
                    cur = parent[cur];
                }
                else
                {
                    if (parent[cur] == -1 || a[parent[cur]] > a[i])
                    {
                        parent[i] = cur;
                        break;
                    }
                    cur = parent[cur];
                }
            }
        }

        // По факту, правильный способ — простой спуск, как в твоём изначальном коде:
        Node root = new Node(a[0]);
        for (int i = 1; i < n; i++)
        {
            int current = a[i];
            Node node = root;
            while (true)
            {
                if (current > node.Value)
                {
                    if (node.Right == null)
                    {
                        node.Right = new Node(current);
                        result.Add(node.Value);
                        break;
                    }
                    else
                    {
                        node = node.Right;
                    }
                }
                else
                {
                    if (node.Left == null)
                    {
                        node.Left = new Node(current);
                        result.Add(node.Value);
                        break;
                    }
                    else
                    {
                        node = node.Left;
                    }
                }
            }
        }

        Console.WriteLine(string.Join(" ", result));
    }

    class Node
    {
        public int Value;
        public Node Left, Right;
        public Node(int value)
        {
            Value = value;
        }
    }
}
