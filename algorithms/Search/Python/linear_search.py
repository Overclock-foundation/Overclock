"""Linear search over an arbitrary sequence."""


def linear_search(arr: list[int], target: int) -> int:
    """Return the index of the first ``target`` in ``arr``, or -1 if absent.

    ``arr`` does not need to be sorted and is not modified.
    """
    for index, value in enumerate(arr):
        if value == target:
            return index

    return -1
