"""Tests for ``algorithms/Graph/Python/Bfs.py``."""

import pytest


class TestBreadthFirstSearch:
    def test_visits_tree_level_by_level(self, bfs_module, tree_graph):
        assert bfs_module.bfs(tree_graph, 0) == [0, 1, 2, 3, 4, 5]

    def test_visits_each_node_of_a_cycle_once(self, bfs_module, cyclic_graph):
        assert bfs_module.bfs(cyclic_graph, 0) == [0, 1, 2]

    def test_ignores_unreachable_components(self, bfs_module, disconnected_graph):
        assert bfs_module.bfs(disconnected_graph, 0) == [0, 1]

    def test_returns_only_start_for_isolated_node(self, bfs_module):
        assert bfs_module.bfs({7: []}, 7) == [7]

    def test_returns_start_when_graph_is_empty(self, bfs_module):
        assert bfs_module.bfs({}, 42) == [42]

    def test_handles_start_missing_from_graph(self, bfs_module, tree_graph):
        assert bfs_module.bfs(tree_graph, 99) == [99]

    def test_does_not_mutate_the_graph(self, bfs_module, tree_graph):
        snapshot = {node: list(neighbors) for node, neighbors in tree_graph.items()}

        bfs_module.bfs(tree_graph, 0)

        assert tree_graph == snapshot

    @pytest.mark.parametrize("start", [0, 1, 2, 3, 4, 5])
    def test_every_node_is_visited_exactly_once(self, bfs_module, tree_graph, start):
        order = bfs_module.bfs(tree_graph, start)

        assert len(order) == len(set(order))
        assert order[0] == start
