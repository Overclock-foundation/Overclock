package search_test

import (
	searchalg "github.com/Overclock-foundation/Overclock/algorithms/Search/Go"
	"testing"
)

func TestLinearSearch(t *testing.T) {
	tests := []struct {
		name   string
		arr    []int
		target int
		want   int
	}{
		{name: "finds first element", arr: []int{4, 2, 9}, target: 4, want: 0},
		{name: "finds middle element", arr: []int{4, 2, 9}, target: 2, want: 1},
		{name: "finds last element", arr: []int{4, 2, 9}, target: 9, want: 2},
		{name: "missing value", arr: []int{4, 2, 9}, target: 7, want: -1},
		{name: "single element found", arr: []int{42}, target: 42, want: 0},
		{name: "single element missing", arr: []int{42}, target: 7, want: -1},
		{name: "empty array", arr: []int{}, target: 1, want: -1},
		{name: "nil array", arr: nil, target: 1, want: -1},
		{name: "negative values", arr: []int{-3, -1, 0}, target: -1, want: 1},
	}

	for _, tt := range tests {
		t.Run(tt.name, func(t *testing.T) {
			if got := searchalg.LinearSearch(tt.arr, tt.target); got != tt.want {
				t.Fatalf("LinearSearch(%v, %d) = %d, want %d", tt.arr, tt.target, got, tt.want)
			}
		})
	}
}

func TestLinearSearchReturnsFirstMatchingIndex(t *testing.T) {
	if got := searchalg.LinearSearch([]int{5, 5, 5}, 5); got != 0 {
		t.Fatalf("LinearSearch() = %d, want 0", got)
	}
}

func TestLinearSearchWorksOnUnsortedInput(t *testing.T) {
	if got := searchalg.LinearSearch([]int{9, 1, 7, 3}, 3); got != 3 {
		t.Fatalf("LinearSearch() = %d, want 3", got)
	}
}

func TestLinearSearchDoesNotMutateArray(t *testing.T) {
	arr := []int{3, 1, 2}
	snapshot := []int{3, 1, 2}

	searchalg.LinearSearch(arr, 1)

	for i := range arr {
		if arr[i] != snapshot[i] {
			t.Fatalf("LinearSearch() mutated the array: got %v, want %v", arr, snapshot)
		}
	}
}
