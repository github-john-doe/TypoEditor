namespace TypoEditor
{
    using System;

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
            throw new NotImplementedException();
        }
    }
}
