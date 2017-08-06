namespace TypoEditor
{
    using System;
    using System.Collections.Generic;

    public class TypoAnalyzer : ITypoAnalyzer
    {
        private IFileSystem fileSystem;

        public TypoAnalyzer(IFileSystem fileSystem)
        {
            if (fileSystem == null)
            {
                throw new ArgumentNullException("fileSystem");
            }

            this.fileSystem = fileSystem;
        }

        public void Analyze(string folder, string pattern)
        {
            IEnumerable<string> files = this.fileSystem.EnumerateFiles(folder, pattern);
        }
    }
}
