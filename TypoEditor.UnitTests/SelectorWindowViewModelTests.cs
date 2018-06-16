namespace TypoEditor.UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;

    [TestClass]
    public class SelectorWindowViewModelTests
    {
        [TestMethod]
        public void TestConstructorWithNullView()
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
            IProcessLauncher fakeProcessLauncher = new FakeProcessLauncher();
            ISelectorWindow fakeSelectorWindow = new FakeSelectorWindow(fakeProcessLauncher);
            SelectorWindowViewModel viewModel = new SelectorWindowViewModel(fakeSelectorWindow);
            TypoAnalyzerResult typoAnalyzerResult = new TypoAnalyzerResult();
            typoAnalyzerResult.AddOccurrence("Hello", "a.cs");
            viewModel.SetTypoAnalyzerResult(typoAnalyzerResult);
            Assert.AreEqual(1, viewModel.Keywords.Count());
        }

        [TestMethod]
        public void TestOccurrences()
        {
            IProcessLauncher fakeProcessLauncher = new FakeProcessLauncher();
            ISelectorWindow fakeSelectorWindow = new FakeSelectorWindow(fakeProcessLauncher);
            SelectorWindowViewModel viewModel = new SelectorWindowViewModel(fakeSelectorWindow);
            viewModel.Occurrences = null;
            string name = null;
            viewModel.PropertyChanged += (sender, e) => { name = e.PropertyName; };
            viewModel.Occurrences = new OccurrenceItemViewModel[] { new OccurrenceItemViewModel(fakeSelectorWindow) { } };
            Assert.AreEqual(nameof(viewModel.Occurrences), name);
        }
    }
}
