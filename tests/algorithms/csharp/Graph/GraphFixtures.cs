using System.Collections.Generic;

namespace Overclock.Algorithms.Tests.Graph
{
    internal static class GraphFixtures
    {
        // 0 -> (1, 2), 1 -> (3, 4), 2 -> (5)
        public static Dictionary<int, List<int>> TreeGraph() => new()
        {
            [0] = new() { 1, 2 },
            [1] = new() { 3, 4 },
            [2] = new() { 5 },
            [3] = new(),
            [4] = new(),
            [5] = new(),
        };

        // Directed cycle: 0 -> 1 -> 2 -> 0
        public static Dictionary<int, List<int>> CyclicGraph() => new()
        {
            [0] = new() { 1 },
            [1] = new() { 2 },
            [2] = new() { 0 },
        };

        // Two separate components: 0 -> 1 and 2 -> 3
        public static Dictionary<int, List<int>> DisconnectedGraph() => new()
        {
            [0] = new() { 1 },
            [1] = new(),
            [2] = new() { 3 },
            [3] = new(),
        };

        // Cheapest path to 3 is 0 -> 2 -> 1 -> 3
        public static Dictionary<int, List<(int neighbor, int weight)>> WeightedGraph() => new()
        {
            [0] = new() { (1, 4), (2, 1) },
            [1] = new() { (3, 1) },
            [2] = new() { (1, 2), (3, 5) },
            [3] = new(),
        };

        /// <summary>Returns every node reachable from a start node in an adjacency list.</summary>
        public static HashSet<int> ReachableFrom(Dictionary<int, List<int>> graph, int startNode)
        {
            var reachable = new HashSet<int> { startNode };
            var pending = new Stack<int>();
            pending.Push(startNode);

            while (pending.Count > 0)
            {
                if (!graph.TryGetValue(pending.Pop(), out var neighbors))
                    continue;

                foreach (int neighbor in neighbors)
                {
                    if (reachable.Add(neighbor))
                        pending.Push(neighbor);
                }
            }

            return reachable;
        }

        /// <summary>Returns every node reachable from a start node in a weighted adjacency list.</summary>
        public static HashSet<int> ReachableFrom(
            Dictionary<int, List<(int neighbor, int weight)>> graph,
            int startNode)
        {
            var reachable = new HashSet<int> { startNode };
            var pending = new Stack<int>();
            pending.Push(startNode);

            while (pending.Count > 0)
            {
                if (!graph.TryGetValue(pending.Pop(), out var edges))
                    continue;

                foreach (var (neighbor, _) in edges)
                {
                    if (reachable.Add(neighbor))
                        pending.Push(neighbor);
                }
            }

            return reachable;
        }
    }
}
