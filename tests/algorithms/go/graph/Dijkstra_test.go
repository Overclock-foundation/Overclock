package graph_test

import (
	graphalg "github.com/Overclock-foundation/Overclock/algorithms/Graph/Go"
	"reflect"
	"testing"
)

func TestDijkstra(t *testing.T) {
	tests := []struct {
		name  string
		graph map[int][]graphalg.Edge
		start int
		want  map[int]float64
	}{
		{
			name: "finds cheapest paths",
			graph: map[int][]graphalg.Edge{
				0: {{To: 1, Weight: 4}, {To: 2, Weight: 1}},
				1: {{To: 3, Weight: 1}},
				2: {{To: 1, Weight: 2}, {To: 3, Weight: 5}},
				3: {},
			},
			start: 0,
			want:  map[int]float64{0: 0, 1: 3, 2: 1, 3: 4},
		},
		{
			name:  "omits unreachable nodes",
			graph: map[int][]graphalg.Edge{0: {{To: 1, Weight: 1}}, 1: {}, 2: {{To: 3, Weight: 1}}, 3: {}},
			start: 0,
			want:  map[int]float64{0: 0, 1: 1},
		},
		{
			name:  "returns only start for isolated node",
			graph: map[int][]graphalg.Edge{7: {}},
			start: 7,
			want:  map[int]float64{7: 0},
		},
		{
			name:  "returns start when graph is empty",
			graph: map[int][]graphalg.Edge{},
			start: 42,
			want:  map[int]float64{42: 0},
		},
		{
			name:  "handles zero weight edges",
			graph: map[int][]graphalg.Edge{0: {{To: 1, Weight: 0}}, 1: {{To: 2, Weight: 5}}, 2: {}},
			start: 0,
			want:  map[int]float64{0: 0, 1: 0, 2: 5},
		},
		{
			name:  "handles cycle without looping forever",
			graph: map[int][]graphalg.Edge{0: {{To: 1, Weight: 2}}, 1: {{To: 2, Weight: 3}}, 2: {{To: 0, Weight: 1}}},
			start: 0,
			want:  map[int]float64{0: 0, 1: 2, 2: 5},
		},
	}

	for _, tt := range tests {
		t.Run(tt.name, func(t *testing.T) {
			if got := graphalg.Dijkstra(tt.graph, tt.start); !reflect.DeepEqual(got, tt.want) {
				t.Fatalf("Dijkstra() = %v, want %v", got, tt.want)
			}
		})
	}
}

func TestDijkstraStartDistanceIsZero(t *testing.T) {
	graph := map[int][]graphalg.Edge{0: {{To: 1, Weight: 4}}, 1: {}}

	if got := graphalg.Dijkstra(graph, 0)[0]; got != 0 {
		t.Fatalf("Dijkstra()[0] = %v, want 0", got)
	}
}

func TestDijkstraDoesNotMutateGraph(t *testing.T) {
	graph := map[int][]graphalg.Edge{0: {{To: 1, Weight: 4}, {To: 2, Weight: 1}}, 1: {}, 2: {}}
	snapshot := map[int][]graphalg.Edge{0: {{To: 1, Weight: 4}, {To: 2, Weight: 1}}, 1: {}, 2: {}}

	graphalg.Dijkstra(graph, 0)

	if !reflect.DeepEqual(graph, snapshot) {
		t.Fatalf("Dijkstra() mutated the graph: got %v, want %v", graph, snapshot)
	}
}
