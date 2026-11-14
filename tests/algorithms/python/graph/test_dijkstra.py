"""Tests for ``algorithms/Graph/Python/Dijkstra's.py``."""

import math

import pytest


class TestDijkstra:
    def test_finds_cheapest_paths(self, dijkstra_module, weighted_graph):
        assert dijkstra_module.dijkstra(weighted_graph, 0) == {
            0: 0,
            1: 3,
            2: 1,
            3: 4,
        }

    def test_start_distance_is_zero(self, dijkstra_module, weighted_graph):
        assert dijkstra_module.dijkstra(weighted_graph, 0)[0] == 0

    def test_omits_unreachable_nodes(self, dijkstra_module, disconnected_graph):
        distances = dijkstra_module.dijkstra(
            {0: [(1, 1)], 1: [], 2: [(3, 1)], 3: []}, 0
        )

        assert distances == {0: 0, 1: 1}
        assert 2 not in distances
        assert 3 not in distances

    def test_returns_only_start_for_isolated_node(self, dijkstra_module):
        assert dijkstra_module.dijkstra({7: []}, 7) == {7: 0}

    def test_returns_start_when_graph_is_empty(self, dijkstra_module):
        assert dijkstra_module.dijkstra({}, 42) == {42: 0}

    def test_prefers_direct_edge_over_longer_detour(self, dijkstra_module):
        graph = {0: [(1, 1)], 1: [(2, 1)], 2: []}

        assert dijkstra_module.dijkstra(graph, 0) == {0: 0, 1: 1, 2: 2}

    def test_handles_zero_weight_edges(self, dijkstra_module):
        graph = {0: [(1, 0)], 1: [(2, 5)], 2: []}

        assert dijkstra_module.dijkstra(graph, 0) == {0: 0, 1: 0, 2: 5}

    def test_handles_cycle_without_looping_forever(self, dijkstra_module):
        graph = {0: [(1, 2)], 1: [(2, 3)], 2: [(0, 1)]}

        assert dijkstra_module.dijkstra(graph, 0) == {0: 0, 1: 2, 2: 5}

    def test_does_not_mutate_the_graph(self, dijkstra_module, weighted_graph):
        snapshot = {node: list(edges) for node, edges in weighted_graph.items()}

        dijkstra_module.dijkstra(weighted_graph, 0)

        assert weighted_graph == snapshot

    def test_distances_are_finite_numbers(self, dijkstra_module, weighted_graph):
        distances = dijkstra_module.dijkstra(weighted_graph, 0)

        assert all(not math.isinf(distance) for distance in distances.values())

    @pytest.mark.parametrize("start", [0, 1, 2, 3])
    def test_every_distance_is_reachable_from_start(
        self, dijkstra_module, weighted_graph, start
    ):
        distances = dijkstra_module.dijkstra(weighted_graph, start)

        assert distances[start] == 0
        assert all(distance >= 0 for distance in distances.values())
