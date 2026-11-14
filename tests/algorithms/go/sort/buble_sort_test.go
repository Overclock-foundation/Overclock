package sort_test

import (
	sortalg "github.com/Overclock-foundation/Overclock/algorithms/Sort/Go"
	"reflect"
	"testing"
)

func TestBubbleSort(t *testing.T) {
	tests := []struct {
		name string
		arr  []int
		want []int
	}{
		{name: "sorts unsorted values", arr: []int{5, 1, 4, 2, 8}, want: []int{1, 2, 4, 5, 8}},
		{name: "keeps sorted values", arr: []int{1, 2, 3}, want: []int{1, 2, 3}},
		{name: "sorts reversed values", arr: []int{3, 2, 1}, want: []int{1, 2, 3}},
		{name: "single element", arr: []int{7}, want: []int{7}},
		{name: "empty slice", arr: []int{}, want: []int{}},
		{name: "nil slice", arr: nil, want: nil},
		{name: "duplicates", arr: []int{2, 2, 1, 1}, want: []int{1, 1, 2, 2}},
		{name: "negative values", arr: []int{-3, 0, -10, 5}, want: []int{-10, -3, 0, 5}},
	}

	for _, tt := range tests {
		t.Run(tt.name, func(t *testing.T) {
			if got := sortalg.BubbleSort(tt.arr); !reflect.DeepEqual(got, tt.want) {
				t.Fatalf("BubbleSort() = %v, want %v", got, tt.want)
			}
		})
	}
}

func TestBubbleSortSortsInPlace(t *testing.T) {
	arr := []int{3, 1, 2}

	got := sortalg.BubbleSort(arr)

	if &got[0] != &arr[0] {
		t.Fatal("BubbleSort() returned a different slice, want the input slice")
	}
	if !reflect.DeepEqual(arr, []int{1, 2, 3}) {
		t.Fatalf("BubbleSort() left arr = %v, want [1 2 3]", arr)
	}
}

func TestBubbleSortMatchesBuiltinSort(t *testing.T) {
	arr := []int{17, 4, 42, 8, 15, 4, 23, 16, 0, -5}
	want := []int{-5, 0, 4, 4, 8, 15, 16, 17, 23, 42}

	if got := sortalg.BubbleSort(arr); !reflect.DeepEqual(got, want) {
		t.Fatalf("BubbleSort() = %v, want %v", got, want)
	}
}
