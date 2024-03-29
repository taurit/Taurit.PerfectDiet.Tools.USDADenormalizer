﻿using System.IO;

namespace Taurit.USDADenormalizer.ImportModules
{
    /// <summary>
    ///     This interface allows to delegate basic IO operations to the calling process.
    ///     It allows to publish this library as Portable Library (targeting many platforms).
    ///     IO Operations are platform-specific, and must be defined outside of the library.
    /// </summary>
    public interface ITextReader
    {
        TextReader OpenTextReader(string fileName);
    }
}