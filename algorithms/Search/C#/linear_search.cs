namespace Overclock.Algorithms.Search
{
    /// <summary>Provides linear search operations.</summary>
    public static class LinearSearchAlgorithm
    {
        /// <summary>Returns the index of the first matching value in an array.</summary>
        /// <param name="arr">The array to search.</param>
        /// <param name="target">The value to find.</param>
        /// <returns>The first matching index, or -1 if the value is absent.</returns>
        public static int LinearSearch(int[] arr, int target)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == target)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}