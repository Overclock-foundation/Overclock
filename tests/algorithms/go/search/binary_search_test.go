package search_test

import (
	searchalg "github.com/Overclock-foundation/Overclock/algorithms/Search/Go"
	"testing"
)

func TestBinarySearch(t *testing.T) {
	tests := []struct {
		name   string
		arr    []int
		target int
		want   int
	}{
		{name: "finds first element", arr: []int{1, 3, 5, 7, 9}, target: 1, want: 0},
		{name: "finds middle element", arr: []int{1, 3, 5, 7, 9}, target: 5, want: 2},
		{name: "finds last element", arr: []int{1, 3, 5, 7, 9}, target: 9, want: 4},
		{name: "missing value between elements", arr: []int{1, 3, 5, 7, 9}, target: 4, want: -1},
		{name: "missing value below range", arr: []int{1, 3, 5, 7, 9}, target: 0, want: -1},
		{name: "missing value above range", arr: []int{1, 3, 5, 7, 9}, target: 10, want: -1},
		{name: "single element found", arr: []int{42}, target: 42, want: 0},
		{name: "single element missing", arr: []int{42}, target: 7, want: -1},
		{name: "empty array", arr: []int{}, target: 1, want: -1},
		{name: "nil array", arr: nil, target: 1, want: -1},
		{name: "negative values", arr: []int{-9, -5, -1}, target: -5, want: 1},
	}

	for _, tt := range tests {
		t.Run(tt.name, func(t *testing.T) {
			if got := searchalg.BinarySearch(tt.arr, tt.target); got != tt.want {
				t.Fatalf("BinarySearch(%v, %d) = %d, want %d", tt.arr, tt.target, got, tt.want)
			}
		})
	}
}

func TestBinarySearchFindsTargetInEvenLengthArray(t *testing.T) {
	arr := []int{2, 4, 6, 8}

	if got := searchalg.BinarySearch(arr, 6); got != 2 {
		t.Fatalf("BinarySearch() = %d, want 2", got)
	}
}

func TestBinarySearchFindsTargetInLargeArray(t *testing.T) {
	arr := make([]int, 0, 1000)
	for i := 0; i < 2000; i += 2 {
		arr = append(arr, i)
	}

	if got := searchalg.BinarySearch(arr, 1998); got != 999 {
		t.Fatalf("BinarySearch() = %d, want 999", got)
	}
}

func TestBinarySearchReturnsMatchingIndexForDuplicates(t *testing.T) {
	arr := []int{1, 2, 2, 2, 3}

	got := searchalg.BinarySearch(arr, 2)
	if got < 0 || arr[got] != 2 {
		t.Fatalf("BinarySearch() = %d, want an index holding 2", got)
	}
}

func TestBinarySearchDoesNotMutateArray(t *testing.T) {
	arr := []int{1, 3, 5, 7}
	snapshot := []int{1, 3, 5, 7}

	searchalg.BinarySearch(arr, 5)

	for i := range arr {
		if arr[i] != snapshot[i] {
			t.Fatalf("BinarySearch() mutated the array: got %v, want %v", arr, snapshot)
		}
	}
}
