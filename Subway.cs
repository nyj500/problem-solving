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

    public List<Station> stations;
    public List<Edge> edges;
    public Dictionary<Station, List<Edge>> edgeInfo;

    public Subway()
    {
        this.stations = new List<Station>();
        this.edges = new List<Edge>();
        this.edgeInfo = new Dictionary<Station, List<Edge>>();
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
        if (!edgeInfo.ContainsKey(from))
        {
            edgeInfo[from] = new List<Edge>();
        }
        this.edgeInfo[from].Add(edge1);
        var edge2 = new Edge(to, from, weight);
        this.edges.Add(edge2);
        if (!edgeInfo.ContainsKey(to))
        {
            edgeInfo[to] = new List<Edge>();
        }
        this.edgeInfo[to].Add(edge2);
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
}