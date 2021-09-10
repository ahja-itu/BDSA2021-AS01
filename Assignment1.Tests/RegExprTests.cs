using Xunit;

namespace Assignment1.Tests
{
    public class RegExprTests
    {


        [Fact]
        public void SplitLine_given_three_words_on_each_line_expect_collection_of_size_3()
        {
            var text = new string[] {"the quick brown fox", "jumps over the lazy dog"};

            var result = RegExpr.SplitLine(text);

            Assert.Equal(new string[] {"the", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog"}, result);
        }

        [Fact]
        public void SplitLine_given_empty_strings_return_no_words()
        {
            var text = new string[] {"", ""};
            
            var result = RegExpr.SplitLine(text);

            Assert.Equal(new string[] {}, result);
        }

        [Fact]
        public void SplitLine_given_two_strings_one_is_empty_return_words_from_nonempty_list()
        {
            var text = new string[] {"", "the quick brown fox"};

            var result = RegExpr.SplitLine(text);

            Assert.Equal(new string[] {"the", "quick", "brown", "fox"}, result);
        }
    }
}
