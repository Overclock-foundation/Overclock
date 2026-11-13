def binary_search(arr: list[int], target: int) -> int:
    """Return the index of ``target`` in the sorted ``arr``, or -1."""
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
