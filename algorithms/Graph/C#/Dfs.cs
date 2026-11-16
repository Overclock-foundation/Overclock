using System.Collections.Generic;

namespace Overclock.Algorithms.Graph
{
    public static class DfsAlgorithm
    {
        public static List<int> Dfs(Dictionary<int, List<int>> graph, int startNode)
        {
            var visitedNodes = new HashSet<int>();
            var visitedOrder = new List<int>();

            Visit(graph, startNode, visitedNodes, visitedOrder);

            return visitedOrder;
        }

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