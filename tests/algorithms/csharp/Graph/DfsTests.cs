using System.Collections.Generic;
using System.Linq;
using Xunit;
using Overclock.Algorithms.Graph;

namespace Overclock.Algorithms.Tests.Graph
{
    public class DfsTests
    {
        [Fact]
        public void VisitsDeepestBranchFirst()
        {
            List<int> visitedOrder = DfsAlgorithm.Dfs(GraphFixtures.TreeGraph(), 0);

            Assert.Equal(new[] { 0, 1, 3, 4, 2, 5 }, visitedOrder);
        }

        [Fact]
        public void VisitsEachNodeOfACycleOnce()
        {
            List<int> visitedOrder = DfsAlgorithm.Dfs(GraphFixtures.CyclicGraph(), 0);

            Assert.Equal(new[] { 0, 1, 2 }, visitedOrder);
        }

        [Fact]
        public void IgnoresUnreachableComponents()
        {
            List<int> visitedOrder = DfsAlgorithm.Dfs(GraphFixtures.DisconnectedGraph(), 0);

            Assert.Equal(new[] { 0, 1 }, visitedOrder);
        }

        [Fact]
        public void ReturnsOnlyStartForIsolatedNode()
        {
            var graph = new Dictionary<int, List<int>> { [7] = new() };

            List<int> visitedOrder = DfsAlgorithm.Dfs(graph, 7);

            Assert.Equal(new[] { 7 }, visitedOrder);
        }

        [Fact]
        public void ReturnsStartWhenGraphIsEmpty()
        {
            var emptyGraph = new Dictionary<int, List<int>>();

            List<int> visitedOrder = DfsAlgorithm.Dfs(emptyGraph, 42);

            Assert.Equal(new[] { 42 }, visitedOrder);
        }

        [Fact]
        public void HandlesStartMissingFromGraph()
        {
            List<int> visitedOrder = DfsAlgorithm.Dfs(GraphFixtures.TreeGraph(), 99);

            Assert.Equal(new[] { 99 }, visitedOrder);
        }

        [Fact]
        public void DoesNotMutateTheGraph()
        {
            var graph = GraphFixtures.TreeGraph();
            var graphSnapshot = graph.ToDictionary(
                entry => entry.Key,
                entry => entry.Value.ToList());

            DfsAlgorithm.Dfs(graph, 0);

            foreach (var (node, neighbors) in graphSnapshot)
                Assert.Equal(neighbors, graph[node]);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void EveryNodeIsVisitedExactlyOnce(int startNode)
        {
            List<int> visitedOrder = DfsAlgorithm.Dfs(GraphFixtures.TreeGraph(), startNode);

            Assert.Equal(visitedOrder.Count, visitedOrder.Distinct().Count());
            Assert.Equal(startNode, visitedOrder[0]);
        }
    }
}