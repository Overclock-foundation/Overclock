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
        public void SortsValues(int[] values, int[] expectedValues)
        {
            MergeSortAlgorithm.MergeSort(values, 0, values.Length - 1);

            Assert.Equal(expectedValues, values);
        }

        [Fact]
        public void SortsInPlace()
        {
            int[] values = { 3, 1, 2 };

            MergeSortAlgorithm.MergeSort(values, 0, values.Length - 1);

            Assert.Equal(new[] { 1, 2, 3 }, values);
        }

        [Fact]
        public void SortsEvenLengthArray()
        {
            int[] values = { 4, 3, 2, 1 };

            MergeSortAlgorithm.MergeSort(values, 0, values.Length - 1);

            Assert.Equal(new[] { 1, 2, 3, 4 }, values);
        }

        [Fact]
        public void MatchesBuiltinSortOnRandomData()
        {
            int[] values = { 17, 4, 42, 8, 15, 4, 23, 16, 0, -5 };
            int[] expectedValues = (int[])values.Clone();
            Array.Sort(expectedValues);

            MergeSortAlgorithm.MergeSort(values, 0, values.Length - 1);

            Assert.Equal(expectedValues, values);
        }
    }
}