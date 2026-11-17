using System.Collections.Generic;
using System.Linq;
using Xunit;
using Overclock.Algorithms.Graph;

namespace Overclock.Algorithms.Tests.Graph
{
    public class DijkstraTests
    {
        [Fact]
        public void FindsCheapestPaths()
        {
            Dictionary<int, int> shortestDistances =
                DijkstraAlgorithm.Dijkstra(GraphFixtures.WeightedGraph(), 0);

            Assert.Equal(0, shortestDistances[0]);
            Assert.Equal(3, shortestDistances[1]);
            Assert.Equal(1, shortestDistances[2]);
            Assert.Equal(4, shortestDistances[3]);
        }

        [Fact]
        public void StartDistanceIsZero()
        {
            Dictionary<int, int> shortestDistances =
                DijkstraAlgorithm.Dijkstra(GraphFixtures.WeightedGraph(), 0);

            Assert.Equal(0, shortestDistances[0]);
        }

        [Fact]
        public void OmitsUnreachableNodes()
        {
            var graph = new Dictionary<int, List<(int neighbor, int weight)>>
            {
                [0] = new() { (1, 1) },
                [1] = new(),
                [2] = new() { (3, 1) },
                [3] = new(),
            };

            Dictionary<int, int> shortestDistances = DijkstraAlgorithm.Dijkstra(graph, 0);

            Assert.Equal(0, shortestDistances[0]);
            Assert.Equal(1, shortestDistances[1]);
            Assert.False(shortestDistances.ContainsKey(2));
            Assert.False(shortestDistances.ContainsKey(3));
        }

        [Fact]
        public void ReturnsOnlyStartForIsolatedNode()
        {
            var graph = new Dictionary<int, List<(int neighbor, int weight)>> { [7] = new() };

            Dictionary<int, int> shortestDistances = DijkstraAlgorithm.Dijkstra(graph, 7);

            Assert.Single(shortestDistances);
            Assert.Equal(0, shortestDistances[7]);
        }

        [Fact]
        public void ReturnsStartWhenGraphIsEmpty()
        {
            var emptyGraph = new Dictionary<int, List<(int neighbor, int weight)>>();

            Dictionary<int, int> shortestDistances = DijkstraAlgorithm.Dijkstra(emptyGraph, 42);

            Assert.Single(shortestDistances);
            Assert.Equal(0, shortestDistances[42]);
        }

        [Fact]
        public void PrefersDirectEdgeOverLongerDetour()
        {
            var graph = new Dictionary<int, List<(int neighbor, int weight)>>
            {
                [0] = new() { (1, 1) },
                [1] = new() { (2, 1) },
                [2] = new(),
            };

            Dictionary<int, int> shortestDistances = DijkstraAlgorithm.Dijkstra(graph, 0);

            Assert.Equal(0, shortestDistances[0]);
            Assert.Equal(1, shortestDistances[1]);
            Assert.Equal(2, shortestDistances[2]);
        }

        [Fact]
        public void HandlesZeroWeightEdges()
        {
            var graph = new Dictionary<int, List<(int neighbor, int weight)>>
            {
                [0] = new() { (1, 0) },
                [1] = new() { (2, 5) },
                [2] = new(),
            };

            Dictionary<int, int> shortestDistances = DijkstraAlgorithm.Dijkstra(graph, 0);

            Assert.Equal(0, shortestDistances[0]);
            Assert.Equal(0, shortestDistances[1]);
            Assert.Equal(5, shortestDistances[2]);
        }

        [Fact]
        public void HandlesCycleWithoutLoopingForever()
        {
            var graph = new Dictionary<int, List<(int neighbor, int weight)>>
            {
                [0] = new() { (1, 2) },
                [1] = new() { (2, 3) },
                [2] = new() { (0, 1) },
            };

            Dictionary<int, int> shortestDistances = DijkstraAlgorithm.Dijkstra(graph, 0);

            Assert.Equal(0, shortestDistances[0]);
            Assert.Equal(2, shortestDistances[1]);
            Assert.Equal(5, shortestDistances[2]);
        }

        [Fact]
        public void HandlesNegativeNodeIds()
        {
            var graph = new Dictionary<int, List<(int neighbor, int weight)>>
            {
                [-1] = new() { (0, 2) },
                [0] = new() { (1, 3) },
                [1] = new(),
            };

            Dictionary<int, int> shortestDistances = DijkstraAlgorithm.Dijkstra(graph, -1);

            Assert.Equal(3, shortestDistances.Count);
            Assert.Equal(0, shortestDistances[-1]);
            Assert.Equal(2, shortestDistances[0]);
            Assert.Equal(5, shortestDistances[1]);
        }

        [Fact]
        public void DoesNotMutateTheGraph()
        {
            var graph = GraphFixtures.WeightedGraph();
            var graphSnapshot = graph.ToDictionary(
                entry => entry.Key,
                entry => entry.Value.ToList());

            DijkstraAlgorithm.Dijkstra(graph, 0);

            Assert.Equal<int>(graphSnapshot.Keys.OrderBy(node => node), graph.Keys.OrderBy(node => node));
            foreach (var (node, edges) in graphSnapshot)
                Assert.Equal(edges, graph[node]);
        }

        [Fact]
        public void DistancesAreNonNegative()
        {
            Dictionary<int, int> shortestDistances =
                DijkstraAlgorithm.Dijkstra(GraphFixtures.WeightedGraph(), 0);

            Assert.All(shortestDistances.Values, distance => Assert.True(distance >= 0));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void ReturnsExactlyTheReachableNodes(int startNode)
        {
            var graph = GraphFixtures.WeightedGraph();

            Dictionary<int, int> shortestDistances = DijkstraAlgorithm.Dijkstra(graph, startNode);

            Assert.Equal<int>(
                GraphFixtures.ReachableFrom(graph, startNode).OrderBy(node => node),
                shortestDistances.Keys.OrderBy(node => node));
            Assert.Equal(0, shortestDistances[startNode]);
        }
    }
}
