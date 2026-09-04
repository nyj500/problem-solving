using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static Constants;

class Program
{
    static void Main()
    {
        string csvPath = CSV_PATH;
        var subway = new Subway(CSVReader.ReadCSV(csvPath));
        var pathFinder = new PathFinder(subway);

        // subway.PrintEdges();
        // subway.PrintStations();
        // subway.PrintEdgeInfo();

        Console.Write("출발역: ");
        string? start = Console.ReadLine();
        while (subway.FindStation(start) == null) 
        {
            Console.WriteLine($"{start}을(를) 찾을 수 없습니다.");
            Console.Write("출발역: ");
            start = Console.ReadLine();
        }

        Console.Write("도착역: ");
        string? end = Console.ReadLine();
        while (subway.FindStation(end) == null)
        {
            Console.WriteLine($"{end}을(를) 찾을 수 없습니다.");
            Console.Write("도착역: ");
            end = Console.ReadLine();
        }

        pathFinder.FindShortestPath(start, end);
    }
}