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

        [Fact]
        public void Filter_given_1_2_3_4_filter_greater_than_2_expect_3_4()
        {
            var items = new int[] {1, 2, 3, 4};

            var filtered = Iterators.Filter<int>(items, x => x > 2);

            Assert.Equal(new int[] {3, 4}, filtered);
        }

        [Fact]
        public void Filter_given_1_to_10_inclusive_filter_even_numbers_expect_only_uneven_numbers()
        {
            var items = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            var filtered = Iterators.Filter<int>(items, x => x % 2 != 0);

            Assert.Equal(new int[] {1, 3, 5, 7, 9}, filtered);
        }
    }
}
