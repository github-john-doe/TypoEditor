namespace TypoEditor.UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;

    [TestClass]
    public class SelectorWindowViewModelTests
    {
        [TestMethod]
        public void TestConstructorWithNull()
        {
            try
            {
                new SelectorWindowViewModel(null);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("view", ex.ParamName);
                return;
            }
            Assert.Fail("Expected ArgumentNullException is not thrown.");
        }

        [TestMethod]
        public void TestSetTypoAnalyzerResult()
        {
            SelectorWindowViewModel viewModel = new SelectorWindowViewModel(new FakeSelectorWindow());
            TypoAnalyzerResult typoAnalyzerResult = new TypoAnalyzerResult();
            typoAnalyzerResult.AddOccurrence("Hello", "a.cs");
            viewModel.SetTypoAnalyzerResult(typoAnalyzerResult);
            Assert.AreEqual(1, viewModel.Keywords.Count());
        }
    }
}
