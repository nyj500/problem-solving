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
    public Dictionary<string, List<Edge>> edgeInfo;

    private bool isInStations = false;
   
    public Subway()
    {
        this.stations = new List<Station>();
        this.edges = new List<Edge>();
        this.edgeInfo = new Dictionary<string, List<Edge>>();
    }

    public Station AddStation(int lineNumber, string name)
    {
        Station station = FindStation(name);
        if (!isInStations)
        {
            station = new Station(lineNumber, name);
            this.stations.Add(station);
            this.edgeInfo.Add(name, new List<Edge>());
        }
        return station;
    }

    public void RemoveStation(Station station)
    {
        this.stations.Remove(station);
    }

    public void AddEdge(Station from, Station to, int weight)
    {
        if (from == null || to == null) return;
        
        var edge1 = new Edge(from, to, weight);
        this.edges.Add(edge1);
        this.edgeInfo[from.Name].Add(edge1);
        
        var edge2 = new Edge(to, from, weight);
        this.edges.Add(edge2);
        this.edgeInfo[to.Name].Add(edge2);
    }

    public void RemoveEdge(Edge edge)
    {
        this.edges.Remove(edge);
    }

    public void PrintStations()
    {
        foreach (var station in stations)
        {
            Console.WriteLine($"Station: {station.Name}, line: {station.LineNumber}");
        }
    }

    public void PrintEdges()
    {
        foreach (var edge in edges)
        {
            Console.WriteLine($"Edge: {edge.From.Name} -> {edge.To.Name}, Weight: {edge.Weight}");
        }
    }

    public void PrintEdgeInfo()
    {
        foreach (var infos in edgeInfo)
        {
            Console.Write($"EdgeInfo: {infos.Key}, ");
            foreach (Edge edge in infos.Value)
                Console.Write($"{edge.To.Name}, ");
            Console.WriteLine();
        }
    }

    public Station FindStation(string name)
    {
        isInStations = false;
        foreach (var s in stations)
        {
            if (s.Name == name)
            {
                isInStations = true;
                return s;
            }                
        }

        return null;
    }

    public void WriteSubwayInfo(List<string[]> values)
    {
        int lineNumber = 0;
        string stationA = null;
        string stationB = null;
        int weight = 0;

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