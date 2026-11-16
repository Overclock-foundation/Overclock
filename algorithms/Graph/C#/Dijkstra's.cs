using System.Collections.Generic;

namespace Overclock.Algorithms.Graph
{
    public static class DijkstraAlgorithm
    {
        public static Dictionary<int, int> Dijkstra(
            Dictionary<int, List<(int neighbor, int weight)>> graph,
            int start)
        {
            var distances = new Dictionary<int, int> { [start] = 0 };
            var visited = new HashSet<int>();

            while (true)
            {
                int? current = null;
                foreach (var (node, distance) in distances)
                {
                    if (visited.Contains(node))
                        continue;

                    if (current is null || distance < distances[current.Value])
                        current = node;
                }

                if (current is null)
                    break;

                visited.Add(current.Value);

                if (!graph.TryGetValue(current.Value, out var edges))
                    continue;

                foreach (var (neighbor, weight) in edges)
                {
                    int candidate = distances[current.Value] + weight;
                    if (!distances.TryGetValue(neighbor, out int known) || candidate < known)
                        distances[neighbor] = candidate;
                }
            }

            return distances;
        }
    }
}