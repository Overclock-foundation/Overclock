namespace Overclock.Algorithms.Search
{
    /// <summary>Provides binary search operations.</summary>
    public static class BinarySearchAlgorithm
    {
        /// <summary>Returns the index of a target in an ascendingly sorted array.</summary>
        /// <param name="arr">The array to search.</param>
        /// <param name="target">The value to find.</param>
        /// <returns>The index of <paramref name="target"/>, or -1 if it is absent.</returns>
        public static int BinarySearch(int[] arr, int target)
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
    }
}