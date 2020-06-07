namespace TypoEditor.UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class OccurrenceItemViewModelTests
    {
        [TestMethod]
        public void TestConstructorWithNullView()
        {
            try
            {
                new OccurrenceItemViewModel(null);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("view", ex.ParamName);
                return;
            }
            Assert.Fail("Expected ArgumentNullException is not thrown.");
        }

        [TestMethod]
        public void TestLaunchExistingEditor()
        {
            FakeConfiguration fakeConfiguration = new FakeConfiguration();
            FakeProcessLauncher fakeProcessLauncher = new FakeProcessLauncher();
            FakeFileSystem fakeFileSystem = new FakeFileSystem();
            FakeErrorReporter fakeErrorReporter = new FakeErrorReporter();
            ISelectorWindow fakeSelectorWindow = new FakeSelectorWindow(fakeProcessLauncher, fakeConfiguration, fakeFileSystem, fakeErrorReporter);
            OccurrenceItemViewModel viewModel = new OccurrenceItemViewModel(fakeSelectorWindow);
            viewModel.Name = "abc";
            fakeConfiguration.Editor = "existingEditor";
            viewModel.DoubleClickCommand.Execute(null);
            Assert.AreEqual("existingEditor", fakeProcessLauncher.Executable);
            Assert.AreEqual(@"""abc""", fakeProcessLauncher.Argument);
        }

        [TestMethod]
        public void TestLaunchNonExistingEditor()
        {
            FakeConfiguration fakeConfiguration = new FakeConfiguration();
            FakeProcessLauncher fakeProcessLauncher = new FakeProcessLauncher();
            FakeFileSystem fakeFileSystem = new FakeFileSystem();
            FakeErrorReporter fakeErrorReporter = new FakeErrorReporter();
            ISelectorWindow fakeSelectorWindow = new FakeSelectorWindow(fakeProcessLauncher, fakeConfiguration, fakeFileSystem, fakeErrorReporter);
            OccurrenceItemViewModel viewModel = new OccurrenceItemViewModel(fakeSelectorWindow);
            viewModel.Name = "abc";
            fakeConfiguration.Editor = "nonExistingEditor";
            viewModel.DoubleClickCommand.Execute(null);
            Assert.AreEqual(fakeErrorReporter.ReportedError, "Configured editor 'nonExistingEditor' is not found.");
        }
    }
}
