using System.Collections.Generic;
using System.Linq;
using Xunit;
using Overclock.Algorithms.Graph;

namespace Overclock.Algorithms.Tests.Graph
{
    public class BfsTests
    {
        [Fact]
        public void VisitsTreeLevelByLevel()
        {
            Assert.Equal(new[] { 0, 1, 2, 3, 4, 5 }, BfsAlgorithm.Bfs(GraphFixtures.TreeGraph(), 0));
        }

        [Fact]
        public void VisitsEachNodeOfACycleOnce()
        {
            Assert.Equal(new[] { 0, 1, 2 }, BfsAlgorithm.Bfs(GraphFixtures.CyclicGraph(), 0));
        }

        [Fact]
        public void IgnoresUnreachableComponents()
        {
            Assert.Equal(new[] { 0, 1 }, BfsAlgorithm.Bfs(GraphFixtures.DisconnectedGraph(), 0));
        }

        [Fact]
        public void ReturnsOnlyStartForIsolatedNode()
        {
            var graph = new Dictionary<int, List<int>> { [7] = new() };

            Assert.Equal(new[] { 7 }, BfsAlgorithm.Bfs(graph, 7));
        }

        [Fact]
        public void ReturnsStartWhenGraphIsEmpty()
        {
            Assert.Equal(new[] { 42 }, BfsAlgorithm.Bfs(new Dictionary<int, List<int>>(), 42));
        }

        [Fact]
        public void HandlesStartMissingFromGraph()
        {
            Assert.Equal(new[] { 99 }, BfsAlgorithm.Bfs(GraphFixtures.TreeGraph(), 99));
        }

        [Fact]
        public void DoesNotMutateTheGraph()
        {
            var graph = GraphFixtures.TreeGraph();
            var snapshot = graph.ToDictionary(pair => pair.Key, pair => pair.Value.ToList());

            BfsAlgorithm.Bfs(graph, 0);

            foreach (var (node, neighbors) in snapshot)
                Assert.Equal(neighbors, graph[node]);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void EveryNodeIsVisitedExactlyOnce(int start)
        {
            var order = BfsAlgorithm.Bfs(GraphFixtures.TreeGraph(), start);

            Assert.Equal(order.Count, order.Distinct().Count());
            Assert.Equal(start, order[0]);
        }
    }
}