def linear_search(arr: list[int], target: int) -> int:
    """Return the index of ``target`` in ``arr``, or -1 if it is absent."""
    for index, value in enumerate(arr):
        if value == target:
            return index

    return -1
