using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Assignment1
{
    public static class RegExpr
    {

        public static IEnumerable<string> SplitLine(IEnumerable<string> lines)
        {   
            var lineRegex = new Regex(@"[a-zA-Z0-9]*");
            foreach(var line in lines)
            {
                foreach(var match in lineRegex.Matches(line))
                {
                    if (match.ToString().Length > 0)
                    {
                        yield return match.ToString();
                    }
                }
            }
        }

        public static IEnumerable<(int width, int height)> Resolution(string resolutions)
        {
            var regex = new Regex(@"(?'width'\d+)x(?'height'\d+)\s*");

            foreach(Match match in regex.Matches(resolutions))
            {
                int width = int.Parse(match.Groups["width"].ToString());
                int height = int.Parse(match.Groups["height"].ToString());
                yield return (width, height);
            }
        }

        public static IEnumerable<string> InnerText(string html, string tag)
        {
            var regex = new Regex($"<{tag}.*?>(?'innertext'.*?)</{tag}>");
            
            // this matches all opening and closing tags
            // use it to clean out tags from matches
            var tagPattern = @"<(?!\/\/).*?>";

            foreach(Match match in regex.Matches(html))
            {
                string innertext = match.Groups["innertext"].ToString();
                yield return Regex.Replace(innertext, tagPattern, "");   
            }
        }
    }
}
