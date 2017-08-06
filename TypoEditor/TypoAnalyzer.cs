namespace TypoEditor
{
    using System;
    using System.Collections.Generic;

    public class TypoAnalyzer : ITypoAnalyzer
    {
        private IFileSystem fileSystem;

        public TypoAnalyzer(IFileSystem fileSystem)
        {
            this.fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
        }

        public TypoAnalyzerResult Analyze(string folder, string pattern)
        {
            IEnumerable<string> files = this.fileSystem.EnumerateFiles(folder, pattern);
            return new TypoAnalyzerResult();
        }
    }
}
