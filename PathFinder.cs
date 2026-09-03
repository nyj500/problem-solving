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

    public void FindShortestPath(Subway.Station startStation, Subway.Station endStation)
    {
        string s = startStation.Name;
        string e = endStation.Name;
        var g = subway.edges;
        int n = subway.stations.Count;
        int m = subway.edges.Count;
        Dictionary<string, int> d = InitVertexWeightDic();
        d[s] = 0;
        PriorityQueue<string, int> pq = new PriorityQueue<string, int>();
        pq.Enqueue(s, 0);
        int w = 0;
        List<Subway.Edge> edges = subway.edgeInfo[s];
        while (pq.Count > 0)
        {
            edges = subway.edgeInfo[pq.Peek()];
            w = d[pq.Peek()];
            pq.Dequeue();
            foreach (var edge in edges)
            {
                if (w + edge.Weight < d[edge.To.Name])
                {
                    d[edge.To.Name] = w + edge.Weight;
                    pq.Enqueue(edge.To.Name, d[edge.To.Name]);
                }         
            }
        }

        PrintD(d);
        // return list of stations;
    }

    private Dictionary<string, int> InitVertexWeightDic()
    {
        Dictionary<string, int> dic = new Dictionary<string, int>();
        foreach(var station in subway.stations)
        {
            dic[station.Name] = int.MaxValue;
        }

        return dic;
    }

    private void PrintD(Dictionary<string, int> d) // 시작점으로부터 각 모든 점(arg1)까지 걸리는 시간(arg2)
    {
        foreach(var kv in d)
        {
            Console.WriteLine($"ToStation: {kv.Key}, Weight: {kv.Value}");
        }
    }
}