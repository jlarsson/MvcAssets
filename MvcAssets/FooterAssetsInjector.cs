using System.Linq;
using System.Text.RegularExpressions;

namespace MvcAssets
{
    public class FooterAssetsInjector : AssetsInjectorBase
    {
        private static readonly Regex HeaderMatch = new Regex(@"\<\/html\>");

        public override string InjectAssets(string markup)
        {
            var match = HeaderMatch.Matches(markup).Cast<Match>().LastOrDefault();
            return InjectAssets(markup, match);
        }
    }
}