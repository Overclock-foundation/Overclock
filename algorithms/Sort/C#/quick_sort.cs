using System;

namespace Overclock.Algorithms.Sort
{
    /// <summary>Provides quick sort operations.</summary>
    public static class QuickSortAlgorithm
    {
        /// <summary>Sorts an entire integer array in place using quick sort.</summary>
        /// <param name="arr">The array to sort.</param>
        public static void QuickSort(int[] arr)
        {
            if (arr is null || arr.Length <= 1)
                return;

            QuickSort(arr, 0, arr.Length - 1);
        }

        /// <summary>Sorts an inclusive range of an integer array in place using quick sort.</summary>
        /// <param name="arr">The array containing the range to sort.</param>
        /// <param name="low">The inclusive start index.</param>
        /// <param name="high">The inclusive end index.</param>
        /// <remarks>Pass 0 and <c>arr.Length - 1</c> to sort the whole array.</remarks>
        public static void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(arr, low, high);

                QuickSort(arr, low, pivotIndex - 1);
                QuickSort(arr, pivotIndex + 1, high);
            }
        }

        /// <summary>Partitions a range around a random pivot and returns the pivot's final index.</summary>
        /// <param name="arr">The array containing the range to partition.</param>
        /// <param name="low">The inclusive start index.</param>
        /// <param name="high">The inclusive end index.</param>
        /// <returns>The pivot's final index.</returns>
        private static int Partition(int[] arr, int low, int high)
        {
            int randIdx = Random.Shared.Next(low, high + 1);
            (arr[randIdx], arr[high]) = (arr[high], arr[randIdx]);

            int pivot = arr[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    (arr[i], arr[j]) = (arr[j], arr[i]);
                }
            }

            (arr[i + 1], arr[high]) = (arr[high], arr[i + 1]);
            return i + 1;
        }
    }
}
