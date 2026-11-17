using System.Collections.Generic;

namespace Overclock.Algorithms.Graph
{
    /// <summary>Provides breadth-first search operations.</summary>
    public static class BfsAlgorithm
    {
        /// <summary>Returns the nodes of a graph in breadth-first order from a start node.</summary>
        /// <param name="graph">The adjacency list mapping each node to its neighbors.</param>
        /// <param name="startNode">The node to start the traversal from.</param>
        /// <returns>
        /// The visited nodes in breadth-first order. Nodes unreachable from
        /// <paramref name="startNode"/> are omitted, and <paramref name="startNode"/> is always
        /// the first element, even when it is absent from <paramref name="graph"/>.
        /// </returns>
        /// <remarks>The graph is not modified.</remarks>
        public static List<int> Bfs(Dictionary<int, List<int>> graph, int startNode)
        {
            var queuedNodes = new Queue<int>();
            var visitedNodes = new HashSet<int> { startNode };
            var visitedOrder = new List<int>();

            queuedNodes.Enqueue(startNode);

            while (queuedNodes.Count > 0)
            {
                int currentNode = queuedNodes.Dequeue();
                visitedOrder.Add(currentNode);

                if (!graph.TryGetValue(currentNode, out var neighbors))
                    continue;

                foreach (int neighbor in neighbors)
                {
                    if (visitedNodes.Add(neighbor))
                        queuedNodes.Enqueue(neighbor);
                }
            }

            return visitedOrder;
        }
    }
}
