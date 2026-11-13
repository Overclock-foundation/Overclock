static int BinarySearch(int[] arr, int target)
{
    int low = 0;
    int high = arr.Length - 1;

    while (low <= high)
    {
        int mid = low + (high - low) / 2;
        if (arr[mid] == target) return mid;
        if (arr[mid] > target) high = mid - 1;
        else low = mid + 1;
    }
    return -1;
}