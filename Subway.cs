using System;
using System.Collections.Generic;
using System.Linq;
using static Constants;

class Subway
{
    public class Station
    {
        public List<int> LineNumber { get; private set; }
        public string Name { get; private set; }

        public Station(List<int> lineNumber, string name)
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
        public int LineNumber { get; private set;}

        public Edge(Station from, Station to, int weight, int lineNumber)
        {
            this.From = from;
            this.To = to;
            this.Weight = weight;
            this.LineNumber = lineNumber;
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

    public Subway(List<string[]> csvFile)
    {
        this.stations = new List<Station>();
        this.edges = new List<Edge>();
        this.edgeInfo = new Dictionary<string, List<Edge>>();
        
        WriteSubwayInfo(csvFile);
    }

    public Station AddStation(int lineNumber, string name)
    {
        Station station = FindStation(name);
        if (!isInStations)
        {
            List<int> lineNumbers = new List<int>(TOTAL_LINE)
            {
                lineNumber
            };
            station = new Station(lineNumbers, name);
            this.stations.Add(station);
            this.edgeInfo.Add(name, new List<Edge>());
        }
        else
        {
            if (!station.LineNumber.Contains(lineNumber))
                station.LineNumber.Add(lineNumber);
        }
        return station;
    }

    public void AddEdge(Station from, Station to, int weight, int lineNumber)
    {
        if (from == null || to == null) return;
        
        var edge1 = new Edge(from, to, weight, lineNumber);
        this.edges.Add(edge1);
        this.edgeInfo[from.Name].Add(edge1);
        
        var edge2 = new Edge(to, from, weight, lineNumber);
        this.edges.Add(edge2);
        this.edgeInfo[to.Name].Add(edge2);
    }

    public void PrintStations()
    {
        foreach (var station in stations)
        {
            Console.Write($"Station: {station.Name}, line: ");
            foreach (var line in station.LineNumber)
                Console.Write($"{line} ");
            Console.WriteLine();
        }
    }

    public void PrintEdges()
    {
        foreach (var edge in edges)
        {
            Console.WriteLine($"Edge: {edge.From.Name} -> {edge.To.Name}, Weight: {edge.Weight}, Line: {edge.LineNumber}");
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
            AddEdge(a, b, weight, lineNumber);
        }
    }
}