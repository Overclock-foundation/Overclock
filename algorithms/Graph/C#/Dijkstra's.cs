using System.Collections.Generic;

namespace Overclock.Algorithms.Graph
{
    public static class DijkstraAlgorithm
    {
        public static Dictionary<int, int> Dijkstra(
            Dictionary<int, List<(int neighbor, int weight)>> graph,
            int startNode)
        {
            var shortestDistances = new Dictionary<int, int> { [startNode] = 0 };
            var visitedNodes = new HashSet<int>();

            while (true)
            {
                int? currentNode = FindClosestUnvisitedNode(shortestDistances, visitedNodes);

                if (currentNode is null)
                    break;

                visitedNodes.Add(currentNode.Value);

                if (!graph.TryGetValue(currentNode.Value, out var edges))
                    continue;

                foreach (var (neighbor, weight) in edges)
                {
                    int distanceThroughCurrent = shortestDistances[currentNode.Value] + weight;

                    if (!shortestDistances.TryGetValue(neighbor, out int knownDistance)
                        || distanceThroughCurrent < knownDistance)
                    {
                        shortestDistances[neighbor] = distanceThroughCurrent;
                    }
                }
            }

            return shortestDistances;
        }

        private static int? FindClosestUnvisitedNode(
            Dictionary<int, int> shortestDistances,
            HashSet<int> visitedNodes)
        {
            int? closestNode = null;

            foreach (var (node, distance) in shortestDistances)
            {
                if (visitedNodes.Contains(node))
                    continue;

                if (closestNode is null || distance < shortestDistances[closestNode.Value])
                    closestNode = node;
            }

            return closestNode;
        }
    }
}