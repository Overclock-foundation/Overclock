using System;
using Xunit;
using Overclock.Algorithms.Sort;

namespace Overclock.Algorithms.Tests.Sort
{
    public class MergeSortTests
    {
        [Theory]
        [InlineData(new[] { 5, 1, 4, 2, 8 }, new[] { 1, 2, 4, 5, 8 })]
        [InlineData(new[] { 1, 2, 3 }, new[] { 1, 2, 3 })]
        [InlineData(new[] { 3, 2, 1 }, new[] { 1, 2, 3 })]
        [InlineData(new[] { 7 }, new[] { 7 })]
        [InlineData(new int[] { }, new int[] { })]
        [InlineData(new[] { 2, 2, 1, 1 }, new[] { 1, 1, 2, 2 })]
        [InlineData(new[] { -3, 0, -10, 5 }, new[] { -10, -3, 0, 5 })]
        public void SortsValues(int[] arr, int[] expected)
        {
            MergeSortAlgorithm.MergeSort(arr, 0, arr.Length - 1);

            Assert.Equal(expected, arr);
        }

        [Fact]
        public void SortsInPlace()
        {
            int[] arr = { 3, 1, 2 };

            MergeSortAlgorithm.MergeSort(arr, 0, arr.Length - 1);

            Assert.Equal(new[] { 1, 2, 3 }, arr);
        }

        [Fact]
        public void SortsEvenLengthArray()
        {
            int[] arr = { 4, 3, 2, 1 };

            MergeSortAlgorithm.MergeSort(arr, 0, arr.Length - 1);

            Assert.Equal(new[] { 1, 2, 3, 4 }, arr);
        }

        [Fact]
        public void MatchesBuiltinSortOnRandomData()
        {
            int[] arr = { 17, 4, 42, 8, 15, 4, 23, 16, 0, -5 };
            int[] expected = (int[])arr.Clone();
            Array.Sort(expected);

            MergeSortAlgorithm.MergeSort(arr, 0, arr.Length - 1);

            Assert.Equal(expected, arr);
        }
    }
}