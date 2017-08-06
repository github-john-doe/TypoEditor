namespace TypoEditor
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class FileSystem : IFileSystem
    {
        public IEnumerable<string> EnumerateFiles(string directory, string searchPattern)
        {
            return Directory.EnumerateFiles(directory, searchPattern, SearchOption.AllDirectories);
        }
    }
}