"""Shared fixtures for the algorithm test suite.

The algorithm sources live under ``algorithms/<topic>/<language>/`` and are not
importable packages (some file names contain apostrophes), so they are loaded
directly from their file paths.
"""

import importlib.util
import sys
from pathlib import Path
from types import ModuleType

import pytest

ALGORITHMS_ROOT = Path(__file__).resolve().parents[2] / "algorithms"


def load_algorithm(relative_path: str) -> ModuleType:
    """Import an algorithm module from a path relative to ``algorithms/``."""
    path = ALGORITHMS_ROOT / relative_path
    if not path.is_file():
        raise FileNotFoundError(f"Algorithm source not found: {path}")

    module_name = "overclock_algorithms_" + path.stem.replace("'", "").replace(" ", "_")
    if module_name in sys.modules:
        return sys.modules[module_name]

    spec = importlib.util.spec_from_file_location(module_name, path)
    if spec is None or spec.loader is None:
        raise ImportError(f"Cannot load algorithm module from {path}")

    module = importlib.util.module_from_spec(spec)
    sys.modules[module_name] = module
    spec.loader.exec_module(module)
    return module


@pytest.fixture(scope="session")
def bfs_module() -> ModuleType:
    return load_algorithm("Graph/Python/Bfs.py")


@pytest.fixture(scope="session")
def dfs_module() -> ModuleType:
    return load_algorithm("Graph/Python/Dfs.py")


@pytest.fixture(scope="session")
def dijkstra_module() -> ModuleType:
    return load_algorithm("Graph/Python/Dijkstra's.py")


@pytest.fixture(scope="session")
def binary_search_module() -> ModuleType:
    return load_algorithm("Search/Python/binary_search.py")


@pytest.fixture(scope="session")
def linear_search_module() -> ModuleType:
    return load_algorithm("Search/Python/linear_search.py")


@pytest.fixture(scope="session")
def bubble_sort_module() -> ModuleType:
    return load_algorithm("Sort/Python/buble_sort.py")


@pytest.fixture(scope="session")
def merge_sort_module() -> ModuleType:
    return load_algorithm("Sort/Python/merge_sort.py")


@pytest.fixture(scope="session")
def quick_sort_module() -> ModuleType:
    return load_algorithm("Sort/Python/quick_sort.py")


@pytest.fixture
def tree_graph() -> dict[int, list[int]]:
    """A small branching tree: 0 -> (1, 2), 1 -> (3, 4), 2 -> (5)."""
    return {0: [1, 2], 1: [3, 4], 2: [5], 3: [], 4: [], 5: []}


@pytest.fixture
def cyclic_graph() -> dict[int, list[int]]:
    """A directed cycle 0 -> 1 -> 2 -> 0."""
    return {0: [1], 1: [2], 2: [0]}


@pytest.fixture
def disconnected_graph() -> dict[int, list[int]]:
    """Two components: 0 -> 1 and 2 -> 3."""
    return {0: [1], 1: [], 2: [3], 3: []}


@pytest.fixture
def weighted_graph() -> dict[int, list[tuple[int, int]]]:
    """Weighted graph where the cheapest path to 3 is 0 -> 2 -> 1 -> 3."""
    return {
        0: [(1, 4), (2, 1)],
        1: [(3, 1)],
        2: [(1, 2), (3, 5)],
        3: [],
    }
