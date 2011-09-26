using System.Linq;
using System.Text.RegularExpressions;

namespace MvcAssets
{
    public class HeaderAssetsInjector : AssetsInjectorBase
    {
        private static readonly Regex HeaderMatch = new Regex(@"\<\/head\>");

        public override string InjectAssets(string markup)
        {
            var match = HeaderMatch.Matches(markup).Cast<Match>().FirstOrDefault();
            return InjectAssets(markup, match);
        }
    }
}