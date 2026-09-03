using System;
using System.Collections.Generic;
using System.Linq;

class Subway
{
    public class Station
    {
        public int LineNumber { get; set; }
        public string Name { get; private set; }

        public Station(int lineNumber, string name)
        {
            this.LineNumber = lineNumber;
            this.Name = name;
        }
    }

    public class Edge
    {
        public Station From { get; private set; }
        public Station To { get; private set; }
        public int Weight { get; private set; }

        public Edge(Station from, Station to, int weight)
        {
            this.From = from;
            this.To = to;
            this.Weight = weight;
        }
    }

    public HashSet<Station> stations;
    public HashSet<Edge> edges;
    public Dictionary<Station, HashSet<Edge>> edgeInfo;
   
    public Subway()
    {
        this.stations = new HashSet<Station>();
        this.edges = new HashSet<Edge>();
        this.edgeInfo = new Dictionary<Station, HashSet<Edge>>();
    }

    public Station AddStation(int lineNumber, string name)
    {
        var station = new Station(lineNumber, name);
        this.stations.Add(station);
        return station;
    }

    public void RemoveStation(Station station)
    {
        this.stations.Remove(station);
    }

    public void AddEdge(Station from, Station to, int weight)
    {
        // 양방향 경로 추가
        var edge1 = new Edge(from, to, weight);
        this.edges.Add(edge1);
        // Console.WriteLine($"Edge: {edge1.From.Name} -> {edge1.To.Name}, Weight: {edge1.Weight}");
        if (!edgeInfo.ContainsKey(from))
        {
            edgeInfo[from] = new HashSet<Edge>();
        }
        this.edgeInfo[from].Add(edge1);
        var edge2 = new Edge(to, from, weight);
        this.edges.Add(edge2);
        if (!edgeInfo.ContainsKey(to))
        {
            edgeInfo[to] = new HashSet<Edge>();
        }
        this.edgeInfo[to].Add(edge2);
        // Console.WriteLine($"Edge: {edge2.From.Name} -> {edge2.To.Name}, Weight: {edge2.Weight}");
    }

    public void RemoveEdge(Edge edge)
    {
        this.edges.Remove(edge);
    }

    public void PrintEdges()
    {
        foreach (var edge in edges)
        {
            Console.WriteLine($"Edge: {edge.From.Name} -> {edge.To.Name}, Weight: {edge.Weight}");
        }
    }

    public void WriteSubwayInfo(List<string[]> values)
    {
        int lineNumber = 0;
        string stationA = null;
        string stationB = null;
        int weight = 0;
        Console.WriteLine($"{values.Count}");

        foreach (var v in values)
        {
            lineNumber = int.Parse(v[0]);
            stationA = v[1];
            stationB = v[2];
            weight = int.Parse(v[3]);

            var a = AddStation(lineNumber, stationA);
            var b = AddStation(lineNumber, stationB);
            AddEdge(a, b, weight);
        }
    }
}