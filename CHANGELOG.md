# Changelog

Changelog for the full-stack polyglot benchmarking platform which visualizes Big O notation, measures execution speed, and load-tests algorithms across Python, C#, and Go.

## 2026-11-17 - Algorithm documentation and correctness review

- Added module-level and function-level docstrings to every Python, Go, and C# algorithm.
- Documented the C# graph algorithms (`Bfs`, `Dfs`, `Dijkstra`) with XML documentation comments.
- Fixed the Go `Dijkstra` implementation, which used `-1` as a "no node" sentinel and therefore
  mishandled graphs containing the node `-1`; the closest-node lookup now reports presence explicitly.
- Corrected the Python `dijkstra` docstring, which claimed unreachable nodes keep `math.inf` while
  the implementation omits them.
- Fixed `tests/conftest.py` resolving `algorithms/` one directory too high, which made every Python
  algorithm test fail during fixture setup.
- Removed trailing whitespace in `quick_sort` sources and added missing final newlines to C# files.

## 2026-11-13 - Main project structure and initial implementation

- Search algorithms in Python, C#, and Go: binary search and linear search.
- Sort algorithms in Python, C#, and Go: bubble sort, merge sort, and quick sort.
- Graph algorithms in Python and Go: BFS, DFS, and Dijkstra.
- Added pytest, Go, and xUnit coverage for the implemented algorithms. Go tests are organized under `tests/go/`.