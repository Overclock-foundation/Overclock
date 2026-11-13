"""Tests for ``algorithms/Search/Python/linear_search.py``."""

import pytest


class TestLinearSearch:
    @pytest.mark.parametrize(
        ("arr", "target", "expected"),
        [
            ([4, 2, 9], 4, 0),
            ([4, 2, 9], 2, 1),
            ([4, 2, 9], 9, 2),
            ([4, 2, 9], 7, -1),
            ([42], 42, 0),
            ([42], 7, -1),
            ([], 1, -1),
        ],
    )
    def test_returns_index_or_minus_one(
        self, linear_search_module, arr, target, expected
    ):
        assert linear_search_module.linear_search(arr, target) == expected

    def test_returns_first_matching_index(self, linear_search_module):
        assert linear_search_module.linear_search([5, 5, 5], 5) == 0

    def test_works_on_unsorted_input(self, linear_search_module):
        assert linear_search_module.linear_search([9, 1, 7, 3], 3) == 3

    def test_handles_negative_values(self, linear_search_module):
        assert linear_search_module.linear_search([-3, -1, 0], -1) == 1

    def test_does_not_mutate_the_array(self, linear_search_module):
        arr = [3, 1, 2]

        linear_search_module.linear_search(arr, 1)

        assert arr == [3, 1, 2]
