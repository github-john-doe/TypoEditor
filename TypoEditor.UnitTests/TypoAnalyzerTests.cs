namespace TypoEditor.UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

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
    }
}
