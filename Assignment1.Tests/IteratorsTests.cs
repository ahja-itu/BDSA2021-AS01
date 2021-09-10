using Xunit;

namespace Assignment1.Tests
{
    public class IteratorsTests
    {

        [Fact]
        public void Flatten_given_two_nested_lists_flatten_them()
        {
            var nestedItems = new int[][] { new int[]{1, 2}, new int[]{3, 4}};

            var flattenedResult = Iterators.Flatten<int>(nestedItems);

            Assert.Equal(new int[]{1, 2, 3, 4}, flattenedResult);
        }

        [Fact]
        public void Flatten_given_empty_list_return_empty_list()
        {
            var empty = new int[][] {};

            var flat = Iterators.Flatten<int>(empty);

            Assert.Equal(new int[]{}, flat);
        }
    }
}
