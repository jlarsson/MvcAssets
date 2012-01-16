using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using WebAssets;

namespace MvcAssets.AjaxMin
{
    public abstract class CompressorBase
    {
        protected abstract string CompressedExtension { get; }
        protected abstract string VirtualCachePath { get; }
        protected abstract IAssetLinkResolver LinkResolver { get; }
        protected abstract string Compress(string source);

        public IEnumerable<IAssetSource> Compress(IEnumerable<IAssetSource> sources)
        {
            List<string> compressList = null;
            foreach (var source in sources)
            {
                if (File.Exists(source.PhysicalPath))
                {
                    if (compressList == null)
                    {
                        compressList = new List<string> {source.PhysicalPath};
                    }
                    else
                    {
                        compressList.Add(source.PhysicalPath);
                    }
                    continue;
                }

                if (compressList != null)
                {
                    yield return Compress(compressList);
                    compressList = null;
                }
                yield return source;
            }
            if (compressList != null)
            {
                yield return Compress(compressList);
            }
        }

        private IAssetSource Compress(List<string> paths)
        {
            var outputAsset = GetCombinedOutputPath(paths);
            if (File.Exists(outputAsset.PhysicalPath))
            {
                return outputAsset;
            }

            var writer = new StringWriter();
            foreach (var path in paths)
            {
                writer.WriteLine(Compress(File.ReadAllText(path)));
            }
            File.WriteAllText(outputAsset.PhysicalPath, writer.ToString());
            return outputAsset;
        }

        private IAssetSource GetCombinedOutputPath(IEnumerable<string> paths)
        {
            var infos = from path in paths
                        select new FileInfo(path);
            using (var writer = new StringWriter())
            {
                foreach (var fileInfo in infos)
                {
                    writer.WriteLine(fileInfo.FullName);
                    writer.WriteLine(fileInfo.LastWriteTimeUtc.ToBinary());
                }

                var hash = BitConverter.ToString(
                    new SHA1CryptoServiceProvider().ComputeHash(
                        Encoding.Unicode.GetBytes(writer.ToString())
                        )).Replace("-", "");


                return LinkResolver.Resolve(new LinkAsset {Link = VirtualCachePath + hash + CompressedExtension});
            }
        }
    }
}