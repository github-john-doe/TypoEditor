namespace TypoEditor.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FakeFileSystem : IFileSystem
    {
        private Dictionary<string, string> files;

        public FakeFileSystem()
        {
            this.files = new Dictionary<string, string>();
            files.Add("a.cs", "HelloWorld");
            files.Add("b.cs", "CruelWorld");
            files.Add("existingEditor", null);
            files.Add("c:\\dev", null);
        }

        public IEnumerable<string> EnumerateFiles(string directory, string searchPattern)
        {
            return files.Keys.Where(f => f.EndsWith("cs"));
        }

        public bool Exists(string fullPath)
        {
            return this.files.ContainsKey(fullPath);
        }

        public string ReadFile(string file)
        {
            return this.files[file];
        }
    }
}
