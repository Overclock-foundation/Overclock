"""Dijkstra's shortest-path algorithm for non-negative edge weights."""

import math


def dijkstra(graph: dict[int, list[tuple[int, int]]], start: int) -> dict[int, float]:
    """Return the shortest distance from ``start`` to every reachable node.

    ``graph`` maps a node to a list of ``(neighbor, weight)`` pairs, where
    ``weight`` must be non-negative. The result maps each reachable node to its
    total distance from ``start``; unreachable nodes are absent from it, and
    ``start`` always maps to ``0``.
    """
    distances: dict[int, float] = {start: 0}
    visited: set[int] = set()

    while True:
        current: int | None = None
        for node, distance in distances.items():
            if node in visited:
                continue
            if current is None or distance < distances[current]:
                current = node

        if current is None:
            break

        visited.add(current)

        for neighbor, weight in graph.get(current, []):
            candidate = distances[current] + weight
            if candidate < distances.get(neighbor, math.inf):
                distances[neighbor] = candidate

    return distances
