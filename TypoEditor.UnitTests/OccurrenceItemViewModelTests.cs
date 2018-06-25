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
            FakeConfiguration fakeConfiguration = new FakeConfiguration();
            FakeProcessLauncher fakeProcessLauncher = new FakeProcessLauncher();
            ISelectorWindow fakeSelectorWindow = new FakeSelectorWindow(fakeProcessLauncher, fakeConfiguration);
            OccurrenceItemViewModel viewModel = new OccurrenceItemViewModel(fakeSelectorWindow);
            viewModel.Name = "abc";
            fakeConfiguration.Editor = "def";
            viewModel.DoubleClickCommand.Execute(null);
            Assert.AreEqual("def", fakeProcessLauncher.Executable);
            Assert.AreEqual(@"""abc""", fakeProcessLauncher.Argument);
        }
    }
}
