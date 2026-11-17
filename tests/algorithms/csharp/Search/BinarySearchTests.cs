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
        public void ReturnsIndexOrMinusOne(int[] values, int targetValue, int expectedIndex)
        {
            Assert.Equal(expectedIndex, BinarySearchAlgorithm.BinarySearch(values, targetValue));
        }

        [Fact]
        public void FindsTargetInEvenLengthArray()
        {
            Assert.Equal(2, BinarySearchAlgorithm.BinarySearch(new[] { 2, 4, 6, 8 }, 6));
        }

        [Fact]
        public void FindsTargetInLargeArray()
        {
            int[] values = Enumerable.Range(0, 1000).Select(index => index * 2).ToArray();

            Assert.Equal(999, BinarySearchAlgorithm.BinarySearch(values, 1998));
        }

        [Fact]
        public void HandlesDuplicatesByReturningAMatchingIndex()
        {
            int[] values = { 1, 2, 2, 2, 3 };

            int index = BinarySearchAlgorithm.BinarySearch(values, 2);

            Assert.InRange(index, 1, 3);
            Assert.Equal(2, values[index]);
        }

        [Fact]
        public void HandlesNegativeValues()
        {
            Assert.Equal(1, BinarySearchAlgorithm.BinarySearch(new[] { -9, -5, -1 }, -5));
        }

        [Fact]
        public void DoesNotMutateTheArray()
        {
            int[] values = { 1, 3, 5, 7 };

            BinarySearchAlgorithm.BinarySearch(values, 5);

            Assert.Equal(new[] { 1, 3, 5, 7 }, values);
        }
    }
}
