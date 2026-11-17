using System.Collections.Generic;

namespace Overclock.Algorithms.Graph
{
    /// <summary>Provides depth-first search operations.</summary>
    public static class DfsAlgorithm
    {
        /// <summary>Returns the nodes of a graph in depth-first order from a start node.</summary>
        /// <param name="graph">The adjacency list mapping each node to its neighbors.</param>
        /// <param name="startNode">The node to start the traversal from.</param>
        /// <returns>
        /// The visited nodes in depth-first order. Nodes unreachable from
        /// <paramref name="startNode"/> are omitted, and <paramref name="startNode"/> is always
        /// the first element, even when it is absent from <paramref name="graph"/>.
        /// </returns>
        /// <remarks>The graph is not modified.</remarks>
        public static List<int> Dfs(Dictionary<int, List<int>> graph, int startNode)
        {
            var visitedNodes = new HashSet<int>();
            var visitedOrder = new List<int>();

            Visit(graph, startNode, visitedNodes, visitedOrder);

            return visitedOrder;
        }

        /// <summary>Visits a node and, recursively, all of its unvisited neighbors.</summary>
        /// <param name="graph">The adjacency list mapping each node to its neighbors.</param>
        /// <param name="currentNode">The node to visit.</param>
        /// <param name="visitedNodes">The set of already visited nodes.</param>
        /// <param name="visitedOrder">The list collecting nodes in visit order.</param>
        private static void Visit(
            Dictionary<int, List<int>> graph,
            int currentNode,
            HashSet<int> visitedNodes,
            List<int> visitedOrder)
        {
            if (!visitedNodes.Add(currentNode))
                return;

            visitedOrder.Add(currentNode);

            if (!graph.TryGetValue(currentNode, out var neighbors))
                return;

            foreach (int neighbor in neighbors)
            {
                Visit(graph, neighbor, visitedNodes, visitedOrder);
            }
        }
    }
}
