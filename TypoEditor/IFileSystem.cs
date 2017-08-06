using System.Collections.Generic;

namespace TypoEditor
{
    public interface IFileSystem
    {
        IEnumerable<string> EnumerateFiles(string directory, string searchPattern);
    }
}
