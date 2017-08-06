namespace TypoEditor.UnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MainWindowViewModelTests
    {
        private const string UserSelectedPath = @"c:\dev";

        [TestMethod]
        public void TestConstructorWithNullArgument()
        {
            try
            {
                new MainWindowViewModel(null);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("view", ex.ParamName);
                return;
            }
            Assert.Fail("Expected ArgumentNullException is not thrown.");
        }

        [TestMethod]
        public void TestBrowseForFile()
        {
            var viewModel = new MainWindowViewModel(new FakeMainWindow());
            viewModel.OnBrowseButtonClicked();
            Assert.AreEqual(UserSelectedPath, viewModel.PathToAnalyze);
        }

        [TestMethod]
        public void TestPathToAnalyze()
        {
            var viewModel = new MainWindowViewModel(new FakeMainWindow());
            viewModel.PathToAnalyze = "a";
            string name = null;
            viewModel.PropertyChanged += (sender, e) => { name = e.PropertyName; };
            viewModel.PathToAnalyze = "b";
            Assert.AreEqual(nameof(viewModel.PathToAnalyze), name);
        }

        [TestMethod]
        public void TestExtensionToAnalyze()
        {
            var viewModel = new MainWindowViewModel(new FakeMainWindow());
            viewModel.ExtensionToAnalyze = "a";
            string name = null;
            viewModel.PropertyChanged += (sender, e) => { name = e.PropertyName; };
            viewModel.ExtensionToAnalyze = "b";
            Assert.AreEqual(nameof(viewModel.ExtensionToAnalyze), name);
        }

        private class FakeMainWindow : IMainWindow
        {
            public string SelectFolder()
            {
                return UserSelectedPath;
            }
        }
    }
}
