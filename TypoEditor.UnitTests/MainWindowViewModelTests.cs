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
            Recorder<IMainWindow> mainWindowRecorder = new Recorder<IMainWindow>();
            mainWindowRecorder.Record((m) => m.SelectFolder(), Constants.UserSelectedPath);
            IMainWindow mockMainWindow = mainWindowRecorder.Replay();
            Recorder<ITypoAnalyzer> typoAnalyzerRecorder = new Recorder<ITypoAnalyzer>();

            typoAnalyzerRecorder.Record((t) => t.Analyze(Constants.UserSelectedPath, "*.cs", /* 41a01ea348c4 this really should be mockMainWindow */null), null);
            ITypoAnalyzer mockTypoAnalyzer = typoAnalyzerRecorder.Replay();
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel(mockMainWindow, mockTypoAnalyzer);
            mainWindowViewModel.OnBrowseButtonClicked();
            mainWindowViewModel.OnAnalyzeButtonClickedWorker();
            
            // TODO: How about checking if the whole recording is over?
        }

        private MainWindowViewModel CreateViewModel()
        {
            this.fakeTypeAnalyzer = new FakeTypoAnalyzer();
            return new MainWindowViewModel(new FakeMainWindow(), fakeTypeAnalyzer);
        }
    }
}
