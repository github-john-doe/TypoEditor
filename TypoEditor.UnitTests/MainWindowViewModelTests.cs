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

        private class FakeMainWindow : IMainWindow
        {
            public string SelectFolder()
            {
                return UserSelectedPath;
            }
        }
    }
}
