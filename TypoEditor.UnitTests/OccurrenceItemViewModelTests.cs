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
        public void TestLaunchEditor()
        {
            FakeProcessLauncher fakeProcessLauncher = new FakeProcessLauncher();
            ISelectorWindow fakeSelectorWindow = new FakeSelectorWindow(fakeProcessLauncher);
            OccurrenceItemViewModel viewModel = new OccurrenceItemViewModel(fakeSelectorWindow);
            viewModel.Name = "abc";
            viewModel.DoubleClickCommand.Execute(null);
            Assert.AreEqual(@"C:\Program Files\Sublime Text 3\sublime_text.exe", fakeProcessLauncher.Executable);
            Assert.AreEqual("abc", fakeProcessLauncher.Argument);
        }
    }
}
