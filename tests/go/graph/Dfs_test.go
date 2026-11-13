package graph_test

import (
	graphalg "github.com/Overclock-foundation/Overclock/algorithms/Graph/Go"
	"reflect"
	"testing"
)

func TestDfs(t *testing.T) {
	tests := []struct {
		name  string
		graph map[int][]int
		start int
		want  []int
	}{
		{
			name:  "visits deepest branch first",
			graph: map[int][]int{0: {1, 2}, 1: {3, 4}, 2: {5}, 3: {}, 4: {}, 5: {}},
			start: 0,
			want:  []int{0, 1, 3, 4, 2, 5},
		},
		{
			name:  "visits each node of a cycle once",
			graph: map[int][]int{0: {1}, 1: {2}, 2: {0}},
			start: 0,
			want:  []int{0, 1, 2},
		},
		{
			name:  "ignores unreachable components",
			graph: map[int][]int{0: {1}, 1: {}, 2: {3}, 3: {}},
			start: 0,
			want:  []int{0, 1},
		},
		{
			name:  "returns only start for isolated node",
			graph: map[int][]int{7: {}},
			start: 7,
			want:  []int{7},
		},
		{
			name:  "returns start when graph is empty",
			graph: map[int][]int{},
			start: 42,
			want:  []int{42},
		},
		{
			name:  "handles start missing from graph",
			graph: map[int][]int{0: {1}},
			start: 99,
			want:  []int{99},
		},
	}

	for _, tt := range tests {
		t.Run(tt.name, func(t *testing.T) {
			if got := graphalg.Dfs(tt.graph, tt.start); !reflect.DeepEqual(got, tt.want) {
				t.Fatalf("Dfs() = %v, want %v", got, tt.want)
			}
		})
	}
}

func TestDfsVisitsEveryNodeExactlyOnce(t *testing.T) {
	graph := map[int][]int{0: {1, 2}, 1: {3, 4}, 2: {5}, 3: {}, 4: {}, 5: {}}

	for start := range graph {
		order := graphalg.Dfs(graph, start)
		seen := make(map[int]bool, len(order))

		for _, node := range order {
			if seen[node] {
				t.Fatalf("Dfs(%d) visited node %d twice: %v", start, node, order)
			}
			seen[node] = true
		}

		if len(order) == 0 || order[0] != start {
			t.Fatalf("Dfs(%d) = %v, want it to start with %d", start, order, start)
		}
	}
}

func TestDfsDoesNotMutateGraph(t *testing.T) {
	graph := map[int][]int{0: {1, 2}, 1: {3}, 2: {}, 3: {}}
	snapshot := map[int][]int{0: {1, 2}, 1: {3}, 2: {}, 3: {}}

	graphalg.Dfs(graph, 0)

	if !reflect.DeepEqual(graph, snapshot) {
		t.Fatalf("Dfs() mutated the graph: got %v, want %v", graph, snapshot)
	}
}
