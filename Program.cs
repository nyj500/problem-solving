using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        string csvPath = "/Users/nyj500/coding-test/subway-graph/subway-info.csv";
        CSVReader.ReadCSV(csvPath);
        var subway = new Subway();
        subway.WriteSubwayInfo(CSVReader.ReadCSV(csvPath));
        // var hongik = subway.AddStation(2, "홍대입구");
        // var sinchon = subway.AddStation(2, "신촌");
        // var ewha = subway.AddStation(2, "이대");
        // var ahn = subway.AddStation(2, "아현");
        // var test1 = subway.AddStation(1, "1");
        // subway.AddEdge(hongik, sinchon, 5);
        // subway.AddEdge(sinchon, ewha, 10);
        // subway.AddEdge(ewha, ahn, 15);
        // subway.AddEdge(test1, hongik, 10);
        // subway.AddEdge(test1, ahn, 10);

        subway.PrintEdges();

        // var pathFinder = new PathFinder(subway);

        // Console.WriteLine("출발역을 입력하세요: ");
        // string stationA = Console.ReadLine();

        // Console.WriteLine("도착역을 입력하세요: ");
        // string stationB = Console.ReadLine();

        
        // pathFinder.FindShortestPath(hongik, ahn);
    }
}