﻿namespace TypoEditor.UnitTests
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
            IConfiguration fakeConfiguration = new FakeConfiguration();
            IProcessLauncher fakeProcessLauncher = new FakeProcessLauncher();
            IFileSystem fakeFileSystem = new FakeFileSystem();
            IErrorReporter fakeErrorReporter = new FakeErrorReporter();
            ISelectorWindow fakeSelectorWindow = new FakeSelectorWindow(fakeProcessLauncher, fakeConfiguration, fakeFileSystem, fakeErrorReporter);
            SelectorWindowViewModel viewModel = new SelectorWindowViewModel(fakeSelectorWindow);
            TypoAnalyzerResult typoAnalyzerResult = new TypoAnalyzerResult();
            typoAnalyzerResult.AddOccurrence("Hello", "a.cs");
            viewModel.SetTypoAnalyzerResult(typoAnalyzerResult);
            Assert.AreEqual(1, viewModel.Keywords.Count());
        }

        [TestMethod]
        public void TestOccurrences()
        {
            IConfiguration fakeConfiguration = new FakeConfiguration();
            IProcessLauncher fakeProcessLauncher = new FakeProcessLauncher();
            IFileSystem fakeFileSystem = new FakeFileSystem();
            IErrorReporter fakeErrorReporter = new FakeErrorReporter();
            ISelectorWindow fakeSelectorWindow = new FakeSelectorWindow(fakeProcessLauncher, fakeConfiguration, fakeFileSystem, fakeErrorReporter);
            SelectorWindowViewModel viewModel = new SelectorWindowViewModel(fakeSelectorWindow);
            viewModel.Occurrences = null;
            string name = null;
            viewModel.PropertyChanged += (sender, e) => { name = e.PropertyName; };
            viewModel.Occurrences = new OccurrenceItemViewModel[] { new OccurrenceItemViewModel(fakeSelectorWindow) { } };
            Assert.AreEqual(nameof(viewModel.Occurrences), name);
        }
    }
}
