using Xunit;
using Overclock.Algorithms.Search;

namespace Overclock.Algorithms.Tests.Search
{
    public class LinearSearchTests
    {
        [Theory]
        [InlineData(new[] { 4, 2, 9 }, 4, 0)]
        [InlineData(new[] { 4, 2, 9 }, 2, 1)]
        [InlineData(new[] { 4, 2, 9 }, 9, 2)]
        [InlineData(new[] { 4, 2, 9 }, 7, -1)]
        [InlineData(new[] { 42 }, 42, 0)]
        [InlineData(new[] { 42 }, 7, -1)]
        [InlineData(new int[] { }, 1, -1)]
        public void ReturnsIndexOrMinusOne(int[] values, int targetValue, int expectedIndex)
        {
            Assert.Equal(expectedIndex, LinearSearchAlgorithm.LinearSearch(values, targetValue));
        }

        [Fact]
        public void ReturnsFirstMatchingIndex()
        {
            Assert.Equal(0, LinearSearchAlgorithm.LinearSearch(new[] { 5, 5, 5 }, 5));
        }

        [Fact]
        public void WorksOnUnsortedInput()
        {
            Assert.Equal(3, LinearSearchAlgorithm.LinearSearch(new[] { 9, 1, 7, 3 }, 3));
        }

        [Fact]
        public void HandlesNegativeValues()
        {
            Assert.Equal(1, LinearSearchAlgorithm.LinearSearch(new[] { -3, -1, 0 }, -1));
        }

        [Fact]
        public void DoesNotMutateTheArray()
        {
            int[] values = { 3, 1, 2 };

            LinearSearchAlgorithm.LinearSearch(values, 1);

            Assert.Equal(new[] { 3, 1, 2 }, values);
        }
    }
}