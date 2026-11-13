namespace Overclock.Algorithms.Sort
{
    /// <summary>Provides merge sort operations.</summary>
    public static class MergeSortAlgorithm
    {
        /// <summary>Sorts an inclusive range of an integer array in place using merge sort.</summary>
        /// <param name="arr">The array containing the range to sort.</param>
        /// <param name="left">The inclusive start index.</param>
        /// <param name="right">The inclusive end index.</param>
        /// <remarks>Pass 0 and <c>arr.Length - 1</c> to sort the whole array.</remarks>
        public static void MergeSort(int[] arr, int left, int right)
        {
            if (left >= right) return;

            int mid = left + (right - left) / 2;

            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);
            Merge(arr, left, mid, right);
        }

        /// <summary>Merges two adjacent sorted ranges of an array.</summary>
        /// <param name="arr">The array containing both ranges.</param>
        /// <param name="left">The inclusive start index of the first range.</param>
        /// <param name="mid">The inclusive end index of the first range.</param>
        /// <param name="right">The inclusive end index of the second range.</param>
        private static void Merge(int[] arr, int left, int mid, int right)
        {
            int[] leftArr = new int[mid - left + 1];
            int[] rightArr = new int[right - mid];
            System.Array.Copy(arr, left, leftArr, 0, leftArr.Length);
            System.Array.Copy(arr, mid + 1, rightArr, 0, rightArr.Length);

            int i = 0, j = 0, k = left;

            while (i < leftArr.Length && j < rightArr.Length)
            {
                if (leftArr[i] <= rightArr[j])
                    arr[k++] = leftArr[i++];
                else
                    arr[k++] = rightArr[j++];
            }

            while (i < leftArr.Length) arr[k++] = leftArr[i++];
            while (j < rightArr.Length) arr[k++] = rightArr[j++];
        }
    }
}
