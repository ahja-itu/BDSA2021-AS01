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

        [Fact]
        public void Resolution_given_list_of_resolutions_give_formatted_resolutions()
        {
            var resolutions = "1920x1080 " +
                               "1024x768, 800x600, 640x480 " +
                               "320x200, 320x240, 800x600 " +
                               "1280x960";

            var results = RegExpr.Resolution(resolutions);

            var expected = new int[][] {
                new int[] {1920, 1080},
                new int[] {1024, 768},
                new int[] {800, 600},
                new int[] {640, 480},
                new int[] {320, 200},
                new int[] {320, 240},
                new int[] {800, 600},
                new int[] {1280, 960}};

            int counter = 0;
            foreach(var result in results)
            {
                var (width, height) = result;

                Assert.Equal(expected[counter][0], width);
                Assert.Equal(expected[counter][1], height);
                counter++;
            }
            
        }
    }
}
