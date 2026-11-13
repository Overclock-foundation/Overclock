package search

// LinearSearch returns the index of target in arr, or -1 if it is absent.
func LinearSearch(arr []int, target int) int {
	for i, value := range arr {
		if value == target {
			return i
		}
	}

	return -1
}
