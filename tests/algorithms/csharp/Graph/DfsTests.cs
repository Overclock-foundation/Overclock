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
            Assert.Equal(new[] { 0, 1, 3, 4, 2, 5 }, DfsAlgorithm.Dfs(GraphFixtures.TreeGraph(), 0));
        }

        [Fact]
        public void VisitsEachNodeOfACycleOnce()
        {
            Assert.Equal(new[] { 0, 1, 2 }, DfsAlgorithm.Dfs(GraphFixtures.CyclicGraph(), 0));
        }

        [Fact]
        public void IgnoresUnreachableComponents()
        {
            Assert.Equal(new[] { 0, 1 }, DfsAlgorithm.Dfs(GraphFixtures.DisconnectedGraph(), 0));
        }

        [Fact]
        public void ReturnsOnlyStartForIsolatedNode()
        {
            var graph = new Dictionary<int, List<int>> { [7] = new() };

            Assert.Equal(new[] { 7 }, DfsAlgorithm.Dfs(graph, 7));
        }

        [Fact]
        public void ReturnsStartWhenGraphIsEmpty()
        {
            Assert.Equal(new[] { 42 }, DfsAlgorithm.Dfs(new Dictionary<int, List<int>>(), 42));
        }

        [Fact]
        public void HandlesStartMissingFromGraph()
        {
            Assert.Equal(new[] { 99 }, DfsAlgorithm.Dfs(GraphFixtures.TreeGraph(), 99));
        }

        [Fact]
        public void DoesNotMutateTheGraph()
        {
            var graph = GraphFixtures.TreeGraph();
            var snapshot = graph.ToDictionary(pair => pair.Key, pair => pair.Value.ToList());

            DfsAlgorithm.Dfs(graph, 0);

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
            var order = DfsAlgorithm.Dfs(GraphFixtures.TreeGraph(), start);

            Assert.Equal(order.Count, order.Distinct().Count());
            Assert.Equal(start, order[0]);
        }
    }
}