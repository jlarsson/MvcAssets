using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace MvcAssets
{
    public class SectionMarkupMatch
    {
        public string Section { get; set; }
        public int Position { get; set; }
        public int Length { get; set; }
    }
    public static class AssetsMarkupHook
    {
        private static readonly Regex SectionMatch = new Regex(@"\<\!\-\-MvcAssets\.Render\((\w*)\)\-\-\>");

        public static MvcHtmlString GetMarkupForSection(string sectionName)
        {
            return new MvcHtmlString(string.Format("<!--MvcAssets.Render({0})-->", sectionName));
        }

        public static IEnumerable<SectionMarkupMatch> GetSections(string content)
        {
            return SectionMatch.Matches(content).Cast<Match>()
                .Select(m => new SectionMarkupMatch() {Position = m.Index, Length = m.Length, Section = m.Groups[1].Value});
        }
    }
}