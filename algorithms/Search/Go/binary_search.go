// Package search provides search algorithms over integer slices.
package search

// BinarySearch returns the index of target in arr sorted in ascending order, or -1.
//
// When arr contains duplicates, any index holding target may be returned. The
// slice is not modified.
func BinarySearch(arr []int, target int) int {
	low, high := 0, len(arr)-1

	for low <= high {
		mid := low + (high-low)/2

		switch {
		case arr[mid] == target:
			return mid
		case arr[mid] > target:
			high = mid - 1
		default:
			low = mid + 1
		}
	}

	return -1
}
