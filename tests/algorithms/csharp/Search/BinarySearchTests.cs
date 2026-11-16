using System.Linq;
using Xunit;
using Overclock.Algorithms.Search;

namespace Overclock.Algorithms.Tests.Search
{
    public class BinarySearchTests
    {
        [Theory]
        [InlineData(new[] { 1, 3, 5, 7, 9 }, 1, 0)]
        [InlineData(new[] { 1, 3, 5, 7, 9 }, 5, 2)]
        [InlineData(new[] { 1, 3, 5, 7, 9 }, 9, 4)]
        [InlineData(new[] { 1, 3, 5, 7, 9 }, 4, -1)]
        [InlineData(new[] { 1, 3, 5, 7, 9 }, 0, -1)]
        [InlineData(new[] { 1, 3, 5, 7, 9 }, 10, -1)]
        [InlineData(new[] { 42 }, 42, 0)]
        [InlineData(new[] { 42 }, 7, -1)]
        [InlineData(new int[] { }, 1, -1)]
        public void ReturnsIndexOrMinusOne(int[] arr, int target, int expected)
        {
            Assert.Equal(expected, BinarySearchAlgorithm.BinarySearch(arr, target));
        }

        [Fact]
        public void FindsTargetInEvenLengthArray()
        {
            Assert.Equal(2, BinarySearchAlgorithm.BinarySearch(new[] { 2, 4, 6, 8 }, 6));
        }

        [Fact]
        public void FindsTargetInLargeArray()
        {
            int[] arr = Enumerable.Range(0, 1000).Select(i => i * 2).ToArray();

            Assert.Equal(999, BinarySearchAlgorithm.BinarySearch(arr, 1998));
        }

        [Fact]
        public void HandlesDuplicatesByReturningAMatchingIndex()
        {
            int[] arr = { 1, 2, 2, 2, 3 };

            Assert.Equal(2, arr[BinarySearchAlgorithm.BinarySearch(arr, 2)]);
        }

        [Fact]
        public void HandlesNegativeValues()
        {
            Assert.Equal(1, BinarySearchAlgorithm.BinarySearch(new[] { -9, -5, -1 }, -5));
        }

        [Fact]
        public void DoesNotMutateTheArray()
        {
            int[] arr = { 1, 3, 5, 7 };

            BinarySearchAlgorithm.BinarySearch(arr, 5);

            Assert.Equal(new[] { 1, 3, 5, 7 }, arr);
        }
    }
}