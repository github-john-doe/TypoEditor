namespace TypoEditor.UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

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
            analyzer.Analyze(@"c:\dev", "*.cs");
        }
    }
}
