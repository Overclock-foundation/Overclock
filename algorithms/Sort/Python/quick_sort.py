import random


def quick_sort(arr: list[int]) -> list[int]:
    """Sort ``arr`` in place with quick sort and return it."""
    _quick_sort(arr, 0, len(arr) - 1)
    return arr


def _quick_sort(arr: list[int], low: int, high: int) -> None:
    if low >= high:
        return

    pivot_index = _partition(arr, low, high)

    _quick_sort(arr, low, pivot_index - 1)
    _quick_sort(arr, pivot_index + 1, high)


def _partition(arr: list[int], low: int, high: int) -> int:
    rand_idx = random.randint(low, high)
    arr[rand_idx], arr[high] = arr[high], arr[rand_idx]
    
    pivot = arr[high]
    i = low - 1

    for j in range(low, high):
        if arr[j] < pivot:
            i += 1
            arr[i], arr[j] = arr[j], arr[i]

    arr[i + 1], arr[high] = arr[high], arr[i + 1]
    return i + 1
