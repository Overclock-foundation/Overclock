"""Tests for ``algorithms/Sort/Python/quick_sort.py``."""

import pytest


class TestQuickSort:
    @pytest.mark.parametrize(
        ("arr", "expected"),
        [
            ([5, 1, 4, 2, 8], [1, 2, 4, 5, 8]),
            ([1, 2, 3], [1, 2, 3]),
            ([3, 2, 1], [1, 2, 3]),
            ([7], [7]),
            ([], []),
            ([2, 2, 1, 1], [1, 1, 2, 2]),
            ([-3, 0, -10, 5], [-10, -3, 0, 5]),
        ],
    )
    def test_sorts_values(self, quick_sort_module, arr, expected):
        assert quick_sort_module.quick_sort(arr) == expected

    def test_sorts_in_place(self, quick_sort_module):
        arr = [3, 1, 2]

        result = quick_sort_module.quick_sort(arr)

        assert result is arr
        assert arr == [1, 2, 3]

    def test_handles_all_equal_values(self, quick_sort_module):
        assert quick_sort_module.quick_sort([4, 4, 4, 4]) == [4, 4, 4, 4]

    def test_matches_builtin_sort_on_random_data(self, quick_sort_module):
        arr = [17, 4, 42, 8, 15, 4, 23, 16, 0, -5]

        assert quick_sort_module.quick_sort(arr) == sorted(arr)
