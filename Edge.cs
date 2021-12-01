using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    class Graph
    {
        public Dictionary<int, Dictionary<int, int>> neighbours;

        public Dictionary<int, int> ways;
        

        private bool CheckVisited(int vertex, List<int> visited)
        {
            foreach(int compare in visited)
                if (compare == vertex)
                    return false;
            return true;
        }

        public Graph() 
        {
            neighbours = new Dictionary<int, Dictionary<int, int>>();
            ways = new Dictionary<int, int>();
            
        }
        
        private void DiikstraSearch(int begin)
        {
            Queue<int> q = new Queue<int>();
            List<int> visited = new List<int>();
            int path = 0;
            q.Enqueue(begin);
            while (q.Count != 0)
            {
                int extracted = q.Peek();
                int min = int.MaxValue;
                int finding = int.MaxValue;
                path = ways[extracted];
                foreach (KeyValuePair<int, int> compared in neighbours[extracted])
                {
                    if (compared.Value <= min && CheckVisited(compared.Key, visited))
                    {
                        min = compared.Value;
                        finding = compared.Key;
                    }
                    if (compared.Value + path < ways[compared.Key])
                        ways[compared.Key] = compared.Value + path;
                }
                if(finding!=int.MaxValue)
                    q.Enqueue(finding);
                q.Dequeue();
                visited.Add(extracted);
            } 
        }

        public void ShowPath(int begin)
        {
            DiikstraSearch(begin);
            foreach (KeyValuePair<int, int> elements in ways)
            {
                Console.WriteLine("Вершина: {0} = {1}", elements.Key, elements.Value);
            }
        }

        public void Creating(int vertex, int neighbour, int path)
        {
            if(!neighbours.ContainsKey(vertex))
            {
                Dictionary<int, int> Second = new Dictionary<int, int>();
                Second.Add(neighbour, path);
                neighbours.Add(vertex, Second);
            }
            else
                neighbours[vertex].Add(neighbour, path);
        }

        public void AddConnection(int vertex, int neighbour, int path)
        {
            Creating(vertex, neighbour, path);
            Creating(neighbour, vertex, path);
        }

        public void Reset(int begin)
        {
            foreach (KeyValuePair<int, Dictionary<int, int>> vertexes in neighbours)
            {
                if (vertexes.Key == begin)
                    ways[vertexes.Key] = 0;
                else
                 ways[vertexes.Key] = int.MaxValue;
            }
        }
    }
}
