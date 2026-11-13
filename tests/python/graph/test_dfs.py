"""Tests for ``algorithms/Graph/Python/Dfs.py``."""

import pytest


class TestDepthFirstSearch:
    def test_visits_deepest_branch_first(self, dfs_module, tree_graph):
        assert dfs_module.dfs(tree_graph, 0) == [0, 1, 3, 4, 2, 5]

    def test_visits_each_node_of_a_cycle_once(self, dfs_module, cyclic_graph):
        assert dfs_module.dfs(cyclic_graph, 0) == [0, 1, 2]

    def test_ignores_unreachable_components(self, dfs_module, disconnected_graph):
        assert dfs_module.dfs(disconnected_graph, 0) == [0, 1]

    def test_returns_only_start_for_isolated_node(self, dfs_module):
        assert dfs_module.dfs({7: []}, 7) == [7]

    def test_returns_start_when_graph_is_empty(self, dfs_module):
        assert dfs_module.dfs({}, 42) == [42]

    def test_handles_start_missing_from_graph(self, dfs_module, tree_graph):
        assert dfs_module.dfs(tree_graph, 99) == [99]

    def test_does_not_mutate_the_graph(self, dfs_module, tree_graph):
        snapshot = {node: list(neighbors) for node, neighbors in tree_graph.items()}

        dfs_module.dfs(tree_graph, 0)

        assert tree_graph == snapshot

    @pytest.mark.parametrize("start", [0, 1, 2, 3, 4, 5])
    def test_every_node_is_visited_exactly_once(self, dfs_module, tree_graph, start):
        order = dfs_module.dfs(tree_graph, start)

        assert len(order) == len(set(order))
        assert order[0] == start
