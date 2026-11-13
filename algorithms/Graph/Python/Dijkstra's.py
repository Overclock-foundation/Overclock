import math


def dijkstra(graph: dict[int, list[tuple[int, int]]], start: int) -> dict[int, float]:
    """Return the shortest distance from ``start`` to every reachable node.

    ``graph`` maps a node to a list of ``(neighbor, weight)`` pairs.
    Unreachable nodes keep a distance of ``math.inf``.
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
