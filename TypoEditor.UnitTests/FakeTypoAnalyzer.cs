namespace TypoEditor.UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public class FakeTypoAnalyzer : ITypoAnalyzer
    {
        private string folder;
        private string pattern;

        public TypoAnalyzerResult Analyze(string folder, string pattern)
        {
            this.folder = folder;
            this.pattern = pattern;
            return null;
        }

        public void Verify(string expectedFolder, string expectedPattern)
        {
            Assert.AreEqual(expectedFolder, folder);
            Assert.AreEqual(expectedPattern, pattern);
        }
    }
}