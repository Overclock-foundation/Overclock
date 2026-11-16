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
            var distances = DijkstraAlgorithm.Dijkstra(GraphFixtures.WeightedGraph(), 0);

            Assert.Equal(0, distances[0]);
            Assert.Equal(3, distances[1]);
            Assert.Equal(1, distances[2]);
            Assert.Equal(4, distances[3]);
        }

        [Fact]
        public void StartDistanceIsZero()
        {
            Assert.Equal(0, DijkstraAlgorithm.Dijkstra(GraphFixtures.WeightedGraph(), 0)[0]);
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

            var distances = DijkstraAlgorithm.Dijkstra(graph, 0);

            Assert.Equal(0, distances[0]);
            Assert.Equal(1, distances[1]);
            Assert.False(distances.ContainsKey(2));
            Assert.False(distances.ContainsKey(3));
        }

        [Fact]
        public void ReturnsOnlyStartForIsolatedNode()
        {
            var graph = new Dictionary<int, List<(int neighbor, int weight)>> { [7] = new() };

            var distances = DijkstraAlgorithm.Dijkstra(graph, 7);

            Assert.Single(distances);
            Assert.Equal(0, distances[7]);
        }

        [Fact]
        public void ReturnsStartWhenGraphIsEmpty()
        {
            var distances = DijkstraAlgorithm.Dijkstra(
                new Dictionary<int, List<(int neighbor, int weight)>>(),
                42);

            Assert.Single(distances);
            Assert.Equal(0, distances[42]);
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

            var distances = DijkstraAlgorithm.Dijkstra(graph, 0);

            Assert.Equal(0, distances[0]);
            Assert.Equal(1, distances[1]);
            Assert.Equal(2, distances[2]);
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

            var distances = DijkstraAlgorithm.Dijkstra(graph, 0);

            Assert.Equal(0, distances[0]);
            Assert.Equal(0, distances[1]);
            Assert.Equal(5, distances[2]);
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

            var distances = DijkstraAlgorithm.Dijkstra(graph, 0);

            Assert.Equal(0, distances[0]);
            Assert.Equal(2, distances[1]);
            Assert.Equal(5, distances[2]);
        }

        [Fact]
        public void DoesNotMutateTheGraph()
        {
            var graph = GraphFixtures.WeightedGraph();
            var snapshot = graph.ToDictionary(
                pair => pair.Key,
                pair => pair.Value.ToList());

            DijkstraAlgorithm.Dijkstra(graph, 0);

            foreach (var (node, edges) in snapshot)
                Assert.Equal(edges, graph[node]);
        }

        [Fact]
        public void DistancesAreNonNegative()
        {
            var distances = DijkstraAlgorithm.Dijkstra(GraphFixtures.WeightedGraph(), 0);

            Assert.All(distances.Values, distance => Assert.True(distance >= 0));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void EveryDistanceIsReachableFromStart(int start)
        {
            var distances = DijkstraAlgorithm.Dijkstra(GraphFixtures.WeightedGraph(), start);

            Assert.Equal(0, distances[start]);
            Assert.All(distances.Values, distance => Assert.True(distance >= 0));
        }
    }
}