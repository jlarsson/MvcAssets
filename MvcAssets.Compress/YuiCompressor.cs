using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using com.yahoo.platform.yui.compressor;
using java.io;
using File = System.IO.File;
using StringReader = java.io.StringReader;
using StringWriter = java.io.StringWriter;

namespace MvcAssets.Compress
{
    public class YuiCompressor : ICompressor
    {
        public string VirtualCachePath { get; set; }
        public IAssetLinkResolver LinkResolver { get; set; }

        #region ICompressor Members

        public IEnumerable<IAssetSource> CompressJavascript(IEnumerable<IAssetSource> sources)
        {
            return Compress(sources, HandleJavascript);
        }

        public IEnumerable<IAssetSource> CompressCss(IEnumerable<IAssetSource> sources)
        {
            return Compress(sources, HandleCss);
        }

        #endregion

        private IAssetSource HandleJavascript(List<string> paths)
        {
            var outputAsset = GetCompinedOutputPath(paths, ".min.js");
            if (File.Exists(outputAsset.PhysicalPath))
            {
                return outputAsset;
            }

            var writer = new StringWriter();
            foreach (var path in paths)
            {
                Reader reader = new FileReader(path);

                var compressor = new JavaScriptCompressor(reader, null);
                compressor.compress(writer, 0, true, false, true, false);
                reader.close();
            }
            File.WriteAllText(outputAsset.PhysicalPath, writer.toString());
            return outputAsset;
        }

        private IAssetSource HandleCss(List<string> paths)
        {
            var outputAsset = GetCompinedOutputPath(paths, ".min.css");
            if (File.Exists(outputAsset.PhysicalPath))
            {
                return outputAsset;
            }

            var writer = new StringWriter();
            foreach (var path in paths)
            {
                Reader reader = new StringReader(File.ReadAllText(path));

                var compressor = new CssCompressor(reader);
                compressor.compress(writer, 0);
            }
            var text = writer.toString();
            File.WriteAllText(outputAsset.PhysicalPath, text);
            return outputAsset;
        }

        private IAssetSource GetCompinedOutputPath(IEnumerable<string> paths, string ext)
        {
            var infos = from path in paths
                        select new FileInfo(path);
            using (var writer = new System.IO.StringWriter())
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


                return LinkResolver.Resolve(new LinkAsset {Link = VirtualCachePath + hash + ext});
            }
        }

        private IEnumerable<IAssetSource> Compress(IEnumerable<IAssetSource> sources,
                                                   Func<List<string>, IAssetSource> compressor)
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
                    yield return compressor(compressList);
                    compressList = null;
                }
                yield return source;
            }
            if (compressList != null)
            {
                yield return compressor(compressList);
            }
        }
    }
}