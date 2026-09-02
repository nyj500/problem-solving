using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var subway = new Subway();
        var hongik = subway.AddStation(2, "홍대입구");
        var sinchon = subway.AddStation(2, "신촌");
        var ewha = subway.AddStation(2, "이대");
        var ahn = subway.AddStation(2, "아현");
        subway.AddEdge(hongik, sinchon, 5);
        subway.AddEdge(sinchon, ewha, 10);
        subway.AddEdge(ewha, ahn, 15);
        subway.PrintEdges();
    }
}