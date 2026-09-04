using System;
using System.Collections.Generic;
using System.Linq;

class PathFinder
{
    private Subway subway;

    public PathFinder(Subway subway)
    {
        this.subway = subway;
        path = new Dictionary<string, string>();
        pathLine = new Dictionary<string, int>();
    }

    private Dictionary<string, string> path; // 다음 역(경로)을 저장
    private Dictionary<string, int> pathLine; // 다음 역의 호선을 저장
    private int totalTime = 0;
    private string startStationName = null;
    private string endStationName = null;

    public void FindShortestPath(Subway.Station startStation, Subway.Station endStation)
    {
        startStationName = startStation.Name;
        endStationName = endStation.Name;
        Dictionary<string, int> d = InitVertexWeightDic();
        PriorityQueue<string, int> pq = new PriorityQueue<string, int>();
  
        List<Subway.Edge> edges = subway.edgeInfo[startStationName];
        int w = 0;
        
        d[startStationName] = 0;
        pq.Enqueue(startStationName, 0);
        
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
                    
                    path[edge.To.Name] = edge.From.Name; // 이전 최소 루트 저장
                    pathLine[edge.To.Name] = edge.LineNumber; 
                    // Console.WriteLine($"{edge.From.Name} -> {edge.To.Name}");
                }         
            }
        }
        totalTime = d[endStationName];
        // PrintD(d);

        List<string> result = new List<string>();
        string currentPath = endStationName;
        // 역방향 추적, result에는 목적지까지의 최단 루트만 담기 (출발지는 제외)
        while (!(currentPath == startStationName))
        {
            if (path.ContainsKey(currentPath))
            {
                result.Add(currentPath);
                currentPath = path[currentPath];
            }
        }
        result.Reverse(); // 정방향
        PrintResult(result);
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

    private void PrintResult(List<string> result)
    {
        Console.WriteLine($"[탐색 결과], {startStationName} -> {endStationName}");
        Console.Write($"{startStationName} -> ");
        for (int i = 0; i < result.Count - 1; i++)
        {
            Console.Write(result[i]);
            if (pathLine[result[i]] != pathLine[result[i+1]])
            {
                Console.Write("(환승)");
                totalTime += 180;
            }
            Console.Write("->");
        }
        Console.WriteLine(endStationName);
        Console.WriteLine($"총 소요 시간: {totalTime/60} 분 {totalTime % 60} 초\n");
    }
}