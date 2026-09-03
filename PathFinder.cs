using System;
using System.Collections.Generic;
using System.Linq;

class PathFinder
{
    private Subway subway;

    public PathFinder(Subway subway)
    {
        this.subway = subway;
    }

    public void FindShortestPath(Subway.Station s, Subway.Station e)
    {
        var g = subway.edges;
        int n = subway.stations.Count;
        int m = subway.edges.Count;
        Dictionary<Subway.Station, int> d = InitVertexWeightDic();
        d[s] = 0;
        PriorityQueue<Subway.Station, int> pq = new PriorityQueue<Subway.Station, int>();
        pq.Enqueue(s, 0);
        int w = 0;
        HashSet<Subway.Edge> edges = subway.edgeInfo[s];
        while (pq.Count > 0)
        {
            edges = subway.edgeInfo[pq.Peek()];
            w = d[pq.Peek()];
            pq.Dequeue();
            foreach (var edge in edges)
            {
                if (w + edge.Weight < d[edge.To])
                {
                    d[edge.To] = w + edge.Weight;
                    pq.Enqueue(edge.To, d[edge.To]);
                }         
            }
        }

        PrintD(d);
        // return list of stations;
    }

    private Dictionary<Subway.Station, int> InitVertexWeightDic()
    {
        Dictionary<Subway.Station, int> dic = new Dictionary<Subway.Station, int>();
        foreach(var station in subway.stations)
        {
            dic[station] = int.MaxValue;
        }

        return dic;
    }

    private void PrintD(Dictionary<Subway.Station, int> d) // 시작점으로부터 각 모든 점(arg1)까지 걸리는 시간(arg2)
    {
        foreach(var kv in d)
        {
            Console.WriteLine($"ToStation: {kv.Key.Name}, Weight: {kv.Value}");
        }
    }
}