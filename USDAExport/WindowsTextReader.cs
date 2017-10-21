using System.IO;
using Taurit.USDADenormalizer.ImportModules;

namespace USDAExport
{
    /// <summary>
    ///     Helper class exporting basic IO functions for windows platform.
    ///     USDADenormalizer library is a portable type library (targeting more than one platform)
    ///     and all platform-specific operations, like filesystem IO, need to be implemented outside of the library
    /// </summary>
    internal class WindowsTextReader : ITextReader
    {
        public TextReader OpenTextReader(string fileName)
        {
            return File.OpenText(fileName);
        }
    }
}