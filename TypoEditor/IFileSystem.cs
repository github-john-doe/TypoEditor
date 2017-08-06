namespace TypoEditor
{
    using System.Collections.Generic;

    public interface IFileSystem
    {
        IEnumerable<string> EnumerateFiles(string directory, string searchPattern);
    }
}
