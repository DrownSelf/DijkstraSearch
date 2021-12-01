using System;

namespace Dijkstra
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph Five = new Graph();
            Five.AddConnection(1, 2, 7);
            Five.AddConnection(1, 3, 9);
            Five.AddConnection(1, 6, 14);
            Five.AddConnection(2, 3, 10);
            Five.AddConnection(2, 4, 15);
            Five.AddConnection(4, 3, 11);
            Five.AddConnection(3, 6, 2);
            Five.AddConnection(6, 5, 9);
            Five.AddConnection(4, 5, 6);
            Five.Reset(1);
            Five.ShowPath(1);
        }
    }
}
