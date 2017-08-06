using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TypoEditor.UnitTests
{
    public class FakeTypoAnalyzer : ITypoAnalyzer
    {
        private string folder;
        private string pattern;

        public void Analyze(string folder, string pattern)
        {
            this.folder = folder;
            this.pattern = pattern;
        }

        public void Verify(string expectedFolder, string expectedPattern)
        {
            Assert.AreEqual(expectedFolder, folder);
            Assert.AreEqual(expectedPattern, pattern);
        }
    }
}