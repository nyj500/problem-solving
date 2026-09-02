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

    private List<Station> stations;
    private List<Edge> edges;

    public Subway()
    {
        this.stations = new List<Station>();
        this.edges = new List<Edge>();
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

    public Edge AddEdge(Station from, Station to, int weight)
    {
        var edge = new Edge(from, to, weight);
        this.edges.Add(edge);
        return edge;
    }

    public void RemoveEdge(Edge edge)
    {
        this.edges.Remove(edge);
    }

    public void PrintEdges()
    {
        foreach (var edge in edges)
        {
            Console.Write($"Edge: {edge.From.Name} -> {edge.To.Name}, Weight: {edge.Weight}");
        }
    }
}