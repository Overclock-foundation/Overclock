"""Tests for ``algorithms/Search/Python/binary_search.py``."""

import pytest


class TestBinarySearch:
    @pytest.mark.parametrize(
        ("arr", "target", "expected"),
        [
            ([1, 3, 5, 7, 9], 1, 0),
            ([1, 3, 5, 7, 9], 5, 2),
            ([1, 3, 5, 7, 9], 9, 4),
            ([1, 3, 5, 7, 9], 4, -1),
            ([1, 3, 5, 7, 9], 0, -1),
            ([1, 3, 5, 7, 9], 10, -1),
            ([42], 42, 0),
            ([42], 7, -1),
            ([], 1, -1),
        ],
    )
    def test_returns_index_or_minus_one(
        self, binary_search_module, arr, target, expected
    ):
        assert binary_search_module.binary_search(arr, target) == expected

    def test_finds_target_in_even_length_array(self, binary_search_module):
        assert binary_search_module.binary_search([2, 4, 6, 8], 6) == 2

    def test_finds_target_in_large_array(self, binary_search_module):
        arr = list(range(0, 2000, 2))

        assert binary_search_module.binary_search(arr, 1998) == 999

    def test_handles_duplicates_by_returning_a_matching_index(
        self, binary_search_module
    ):
        arr = [1, 2, 2, 2, 3]

        assert arr[binary_search_module.binary_search(arr, 2)] == 2

    def test_handles_negative_values(self, binary_search_module):
        assert binary_search_module.binary_search([-9, -5, -1], -5) == 1

    def test_does_not_mutate_the_array(self, binary_search_module):
        arr = [1, 3, 5, 7]

        binary_search_module.binary_search(arr, 5)

        assert arr == [1, 3, 5, 7]
