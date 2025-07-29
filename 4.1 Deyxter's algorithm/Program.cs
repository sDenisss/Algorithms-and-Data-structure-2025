using System;
using System.Collections.Generic;

class Program
{
    class Edge { public int To; public int W; public Edge(int t,int w){To=t;W=w;} }

    static void Main()
    {
        var parts = Console.ReadLine().Split();
        int n = int.Parse(parts[0]), m = int.Parse(parts[1]);

        var graph = new List<Edge>[n+1];
        for(int i=1;i<=n;i++) graph[i] = new List<Edge>();

        for(int i=0;i<m;i++)
        {
            parts = Console.ReadLine().Split();
            int u=int.Parse(parts[0]), v=int.Parse(parts[1]), w=int.Parse(parts[2]);
            graph[u].Add(new Edge(v,w));
            graph[v].Add(new Edge(u,w));
        }

        const long INF = long.MaxValue;
        var dist = new long[n+1];
        var prev = new int[n+1];
        for(int i=1;i<=n;i++){ dist[i]=INF; prev[i]=-1; }
        dist[1]=0;

        var pq = new MinHeap();
        pq.Push(new PQItem(1,0));

        while(pq.Count>0)
        {
            var cur = pq.Pop();
            int u=cur.Vertex; long d=cur.Dist;
            if(d>dist[u]) continue;           // устаревшая запись

            foreach(var e in graph[u])
            {
                int v=e.To; long nd=d+e.W;
                if(nd<dist[v])
                {
                    dist[v]=nd;
                    prev[v]=u;
                    pq.Push(new PQItem(v,nd));
                }
            }
        }

        if(dist[n]==INF)
        {
            Console.WriteLine(-1);
            return;
        }

        var stack = new Stack<int>();
        for(int v=n; v!=-1; v=prev[v]) stack.Push(v);
        Console.WriteLine(string.Join(" ", stack));
    }
}


/// <summary>Элемент очереди: вершина + её текущее расстояние.</summary>
struct PQItem
{
    public int Vertex;
    public long Dist;
    public PQItem(int v, long d) { Vertex = v; Dist = d; }
}

/// <summary>Мини‑куча (priority queue) для PQItem по полю Dist.</summary>
class MinHeap
{
    private List<PQItem> _data = new List<PQItem>();
    public int Count => _data.Count;

    public void Push(PQItem item)
    {
        _data.Add(item);
        int i = _data.Count - 1;
        while (i > 0)
        {
            int p = (i - 1) >> 1;
            if (_data[p].Dist <= _data[i].Dist) break;
            (_data[p], _data[i]) = (_data[i], _data[p]);
            i = p;
        }
    }

    public PQItem Pop()
    {
        var root = _data[0];
        var last = _data[_data.Count - 1];
        _data.RemoveAt(_data.Count - 1);
        if (_data.Count > 0)
        {
            _data[0] = last;
            Heapify(0);
        }
        return root;
    }

    private void Heapify(int i)
    {
        int n = _data.Count;
        while (true)
        {
            int l = (i << 1) + 1, r = l + 1, smallest = i;
            if (l < n && _data[l].Dist < _data[smallest].Dist) smallest = l;
            if (r < n && _data[r].Dist < _data[smallest].Dist) smallest = r;
            if (smallest == i) break;
            (_data[i], _data[smallest]) = (_data[smallest], _data[i]);
            i = smallest;
        }
    }
}
