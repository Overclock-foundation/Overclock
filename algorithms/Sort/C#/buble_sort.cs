namespace Overclock.Algorithms.Sort
{
    /// <summary>Provides bubble sort operations.</summary>
    public static class BubbleSortAlgorithm
    {
        /// <summary>Sorts an integer array in place using bubble sort.</summary>
        /// <param name="arr">The array to sort.</param>
        public static void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                bool swapped = false;

                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                        swapped = true;
                    }
                }

                if (!swapped) break;
            }
        }
    }
}
