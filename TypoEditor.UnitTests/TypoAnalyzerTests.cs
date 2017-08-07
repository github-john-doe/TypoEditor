namespace TypoEditor.UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;

    [TestClass]
    public class TypoAnalyzerTests
    {
        [TestMethod]
        public void TestConstructorWithNull()
        {
            try
            {
                var analyzer = new TypoAnalyzer(null);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("fileSystem", ex.ParamName);
                return;
            }
            Assert.Fail("Expected ArgumentNullException is not thrown.");
        }

        [TestMethod]
        public void TestAnalyze()
        {
            var analyzer = new TypoAnalyzer(new FakeFileSystem());
            TypoAnalyzerResult result = analyzer.Analyze(@"c:\dev", "*.cs");
            KeywordOccurrences[] keywords = result.Keywords.ToArray();
            Assert.AreEqual("cruel", keywords[0].Keyword);
            Assert.AreEqual("hello", keywords[1].Keyword);
            Assert.AreEqual("world", keywords[2].Keyword);
            Assert.IsTrue(Enumerable.SequenceEqual(new string[] { "b.cs" }, keywords[0].Occurrences));
        }
    }
}
