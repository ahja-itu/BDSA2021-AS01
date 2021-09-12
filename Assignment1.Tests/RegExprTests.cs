using System;
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

        [Fact]
        public void InnerText_given_first_example_input_should_return_example_result()
        {
            var input = @"<div>
    <p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=""/wiki/Theoretical_computer_science"" title=""Theoretical computer science"">theoretical computer science</a> and <a href=""/wiki/Formal_language"" title=""Formal language"">formal language</a> theory, a sequence of <a href=""/wiki/Character_(computing)"" title=""Character (computing)"">characters</a> that define a <i>search <a href=""/wiki/Pattern_matching"" title=""Pattern matching"">pattern</a></i>. Usually this pattern is then used by <a href=""/wiki/String_searching_algorithm"" title=""String searching algorithm"">string searching algorithms</a> for ""find"" or ""find and replace"" operations on <a href=""/wiki/String_(computer_science)"" title=""String (computer science)"">strings</a>.</p>
</div>";
            var expected = new string[] {  
                "theoretical computer science",
                "formal language",
                "characters",
                "pattern",
                "string searching algorithms",
                "strings"
            };

            var results = RegExpr.InnerText(input, "a");

            Assert.Equal(expected, results);
        }

        [Fact]
        public void InnerText_given_example_nested_tags_return_example_result() 
        {
            string input = @"<div>
    <p>The phrase <i>regular expressions</i> (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing <u>patterns</u> that matching <em>text</em> need to conform to.</p>
</div>";
string expected = "The phrase regular expressions (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing patterns that matching text need to conform to.";

            var result = RegExpr.InnerText(input, "p");
            
            Assert.Equal(expected, string.Join(" ", result));
        }
    }
}
