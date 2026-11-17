"""Binary search over a sorted sequence."""


def binary_search(arr: list[int], target: int) -> int:
    """Return the index of ``target`` in ``arr`` sorted in ascending order, or -1.

    When ``arr`` contains duplicates, any index holding ``target`` may be
    returned. The input is not modified.
    """
    low, high = 0, len(arr) - 1

    while low <= high:
        mid = low + (high - low) // 2
        if arr[mid] == target:
            return mid
        if arr[mid] > target:
            high = mid - 1
        else:
            low = mid + 1

    return -1
