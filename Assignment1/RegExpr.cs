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
            throw new NotImplementedException();
        }

        public static IEnumerable<string> InnerText(string html, string tag)
        {
            throw new NotImplementedException();
        }
    }
}
