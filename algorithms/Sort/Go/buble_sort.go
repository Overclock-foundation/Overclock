// Package sort provides in-place sorting algorithms for integer slices.
package sort

// BubbleSort sorts arr in place with bubble sort and returns it.
//
// The sort is stable and stops early once a pass makes no swaps.
func BubbleSort(arr []int) []int {
	n := len(arr)

	for i := 0; i < n-1; i++ {
		swapped := false

		for j := 0; j < n-1-i; j++ {
			if arr[j] > arr[j+1] {
				arr[j], arr[j+1] = arr[j+1], arr[j]
				swapped = true
			}
		}

		if !swapped {
			break
		}
	}

	return arr
}
