namespace TypoEditor.UnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MainWindowViewModelTests
    {
        private FakeTypoAnalyzer fakeTypeAnalyzer;

        [TestMethod]
        public void TestConstructorWithNullView()
        {
            try
            {
                new MainWindowViewModel(null, new FakeTypoAnalyzer());
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("view", ex.ParamName);
                return;
            }
            Assert.Fail("Expected ArgumentNullException is not thrown.");
        }

        [TestMethod]
        public void TestConstructorWithNullAnalyzer()
        {
            try
            {
                new MainWindowViewModel(new FakeMainWindow(), null);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("analyzer", ex.ParamName);
                return;
            }
            Assert.Fail("Expected ArgumentNullException is not thrown.");
        }

        [TestMethod]
        public void TestBrowseForFile()
        {
            var viewModel = this.CreateViewModel();
            viewModel.OnBrowseButtonClicked();
            Assert.AreEqual(Constants.UserSelectedPath, viewModel.PathToAnalyze);
        }

        [TestMethod]
        public void TestPathToAnalyze()
        {
            var viewModel = this.CreateViewModel();
            viewModel.PathToAnalyze = "a";
            string name = null;
            viewModel.PropertyChanged += (sender, e) => { name = e.PropertyName; };
            viewModel.PathToAnalyze = "b";
            Assert.AreEqual(nameof(viewModel.PathToAnalyze), name);
        }

        [TestMethod]
        public void TestExtensionToAnalyze()
        {
            var viewModel = this.CreateViewModel();
            viewModel.ExtensionToAnalyze = "a";
            string name = null;
            viewModel.PropertyChanged += (sender, e) => { name = e.PropertyName; };
            viewModel.ExtensionToAnalyze = "b";
            Assert.AreEqual(nameof(viewModel.ExtensionToAnalyze), name);
        }

        [TestMethod]
        public void TestCurrent()
        {
            var viewModel = this.CreateViewModel();
            viewModel.Current = 0;
            string name = null;
            viewModel.PropertyChanged += (sender, e) => { name = e.PropertyName; };
            viewModel.Current = 1;
            Assert.AreEqual(nameof(viewModel.Current), name);
        }

        [TestMethod]
        public void TestMaximum()
        {
            var viewModel = this.CreateViewModel();
            viewModel.Maximum = 0;
            string name = null;
            viewModel.PropertyChanged += (sender, e) => { name = e.PropertyName; };
            viewModel.Maximum = 1;
            Assert.AreEqual(nameof(viewModel.Maximum), name);
        }

        [TestMethod]
        public void TestAnalyze()
        {
            var viewModel = this.CreateViewModel();
            viewModel.OnBrowseButtonClicked();
            viewModel.OnAnalyzeButtonClicked();
            fakeTypeAnalyzer.Verify(@"c:\dev", @"*.cs");
        }

        private MainWindowViewModel CreateViewModel()
        {
            this.fakeTypeAnalyzer = new FakeTypoAnalyzer();
            return new MainWindowViewModel(new FakeMainWindow(), fakeTypeAnalyzer);
        }
    }
}
