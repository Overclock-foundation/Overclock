using System.Collections.Generic;

namespace Overclock.Algorithms.Graph
{
    public static class BfsAlgorithm
    {
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