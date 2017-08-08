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

        [TestMethod]
        public void TestOccurences()
        {
            SelectorWindowViewModel viewModel = new SelectorWindowViewModel(new FakeSelectorWindow());
            viewModel.Occurrences = null;
            string name = null;
            viewModel.PropertyChanged += (sender, e) => { name = e.PropertyName; };
            viewModel.Occurrences = new Item[] { new Item { } };
            Assert.AreEqual(nameof(viewModel.Occurrences), name);
        }
    }
}
