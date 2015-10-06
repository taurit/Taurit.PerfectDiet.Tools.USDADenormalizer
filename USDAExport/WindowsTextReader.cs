using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USDADenormalizer.ImportModules;

namespace USDAExport
{
    /// <summary>
    /// Helper class exporting basic IO functions for windows platform.
    /// USDADenormalizer library is a portable type library (targeting more than one platform)
    /// and all platform-specific operations, like filesystem IO, need to be implemented outside of the library
    /// </summary>
    class WindowsTextReader : ITextReader
    {
        public TextReader OpenTextReader(string fileName)
        {
            return File.OpenText(fileName);
        }
    }
}
