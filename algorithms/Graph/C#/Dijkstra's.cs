using System.Collections.Generic;

namespace Overclock.Algorithms.Graph
{
    /// <summary>Provides Dijkstra's shortest-path operations.</summary>
    public static class DijkstraAlgorithm
    {
        /// <summary>Returns the shortest distance from a start node to every reachable node.</summary>
        /// <param name="graph">
        /// The adjacency list mapping each node to its outgoing <c>(neighbor, weight)</c> edges.
        /// Weights must be non-negative.
        /// </param>
        /// <param name="startNode">The node to measure distances from.</param>
        /// <returns>
        /// A map from each reachable node to its total distance from
        /// <paramref name="startNode"/>. Unreachable nodes are absent, and
        /// <paramref name="startNode"/> always maps to 0.
        /// </returns>
        /// <remarks>The graph is not modified.</remarks>
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

        /// <summary>Finds the unvisited node with the smallest known distance.</summary>
        /// <param name="shortestDistances">The distances discovered so far.</param>
        /// <param name="visitedNodes">The set of already finalized nodes.</param>
        /// <returns>The closest unvisited node, or <see langword="null"/> if all are visited.</returns>
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
