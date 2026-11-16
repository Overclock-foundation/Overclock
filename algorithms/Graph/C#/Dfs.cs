using System.Collections.Generic;

namespace Overclock.Algorithms.Graph
{
    public static class DfsAlgorithm
    {
        public static List<int> Dfs(Dictionary<int, List<int>> graph, int start)
        {
            var visited = new HashSet<int>();
            var order = new List<int>();
            Visit(graph, start, visited, order);
            return order;
        }

        private static void Visit(
            Dictionary<int, List<int>> graph,
            int node,
            HashSet<int> visited,
            List<int> order)
        {
            if (!visited.Add(node))
                return;

            order.Add(node);

            if (!graph.TryGetValue(node, out var neighbors))
                return;

            foreach (int neighbor in neighbors)
            {
                Visit(graph, neighbor, visited, order);
            }
        }
    }
}