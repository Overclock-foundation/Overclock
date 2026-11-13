from collections import deque


def bfs(graph: dict[int, list[int]], start: int) -> list[int]:
    """Return the nodes of ``graph`` in breadth-first order from ``start``."""
    visited: set[int] = {start}
    order: list[int] = []
    queue: deque[int] = deque([start])

    while queue:
        node = queue.popleft()
        order.append(node)

        for neighbor in graph.get(node, []):
            if neighbor not in visited:
                visited.add(neighbor)
                queue.append(neighbor)

    return order
