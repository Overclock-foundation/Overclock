def dfs(graph: dict[int, list[int]], start: int) -> list[int]:
    """Return the nodes of ``graph`` in depth-first order from ``start``."""
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
