namespace TypoEditor.UnitTests
{
    using System;
    using System.Collections.Generic;

    public class FakeFileSystem : IFileSystem
    {
        private Dictionary<string, string> files;

        public FakeFileSystem()
        {
            this.files = new Dictionary<string, string>();
            files.Add("a.cs", "HelloWorld");
            files.Add("b.cs", "CruelWorld");
        }

        public IEnumerable<string> EnumerateFiles(string directory, string searchPattern)
        {
            return files.Keys;
        }

        public string ReadFile(string file)
        {
            return this.files[file];
        }
    }
}
