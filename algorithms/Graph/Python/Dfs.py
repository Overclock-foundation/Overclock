"""Depth-first search over an adjacency-list graph."""


def dfs(graph: dict[int, list[int]], start: int) -> list[int]:
    """Return the nodes of ``graph`` in depth-first order from ``start``.

    ``graph`` maps a node to the list of its neighbors. Nodes that are not
    reachable from ``start`` are omitted, and ``start`` itself is always the
    first element of the result, even when it is absent from ``graph``.
    """
    visited: set[int] = set()
    order: list[int] = []

    def visit(node: int) -> None:
        if node in visited:
            return

        visited.add(node)
        order.append(node)

        for neighbor in graph.get(node, []):
            visit(neighbor)

    visit(start)
    return order
