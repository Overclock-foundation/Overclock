using System.Collections.Generic;

namespace Overclock.Algorithms.Graph
{
    public static class BfsAlgorithm
    {
        public static List<int> Bfs(Dictionary<int, List<int>> graph, int start)
        {
            var visited = new HashSet<int> { start };
            var order = new List<int>();
            var queue = new Queue<int>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                order.Add(node);

                if (!graph.TryGetValue(node, out var neighbors))
                    continue;

                foreach (int neighbor in neighbors)
                {
                    if (visited.Add(neighbor))
                        queue.Enqueue(neighbor);
                }
            }

            return order;
        }
    }
}