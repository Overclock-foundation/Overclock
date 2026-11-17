package search

// LinearSearch returns the index of the first target in arr, or -1 if absent.
//
// arr does not need to be sorted and is not modified.
func LinearSearch(arr []int, target int) int {
	for i, value := range arr {
		if value == target {
			return i
		}
	}

	return -1
}
