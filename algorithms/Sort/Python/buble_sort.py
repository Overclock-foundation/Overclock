"""Bubble sort implementation."""


def bubble_sort(arr: list[int]) -> list[int]:
    """Sort ``arr`` in place with bubble sort and return it.

    The sort is stable and stops early once a pass makes no swaps.
    """
    n = len(arr)

    for i in range(n - 1):
        swapped = False

        for j in range(n - 1 - i):
            if arr[j] > arr[j + 1]:
                arr[j], arr[j + 1] = arr[j + 1], arr[j]
                swapped = True

        if not swapped:
            break

    return arr
