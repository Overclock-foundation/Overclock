package sort

import "math/rand/v2"

// QuickSort sorts arr in place with quick sort and returns it.
func QuickSort(arr []int) []int {
	quickSort(arr, 0, len(arr)-1)
	return arr
}

func quickSort(arr []int, low, high int) {
	if low >= high {
		return
	}

	pivotIndex := partition(arr, low, high)

	quickSort(arr, low, pivotIndex-1)
	quickSort(arr, pivotIndex+1, high)
}

func partition(arr []int, low, high int) int {
	randIdx := low + rand.IntN(high-low+1)
	arr[randIdx], arr[high] = arr[high], arr[randIdx]
	
	pivot := arr[high]
	i := low - 1

	for j := low; j < high; j++ {
		if arr[j] < pivot {
			i++
			arr[i], arr[j] = arr[j], arr[i]
		}
	}

	arr[i+1], arr[high] = arr[high], arr[i+1]
	return i + 1
}
