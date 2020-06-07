namespace TypoEditor
{
    using System.Collections.Generic;
    using System.IO;

    public class FileSystem : IFileSystem
    {
        public IEnumerable<string> EnumerateFiles(string directory, string searchPattern)
        {
            return Directory.EnumerateFiles(directory, searchPattern, SearchOption.AllDirectories);
        }

        public bool Exists(string fullPath)
        {
            return File.Exists(fullPath) || Directory.Exists(fullPath);
        }

        public string ReadFile(string file)
        {
            return File.ReadAllText(file);
        }
    }
}