namespace TypoEditor.UnitTests
{
    internal class FakeSelectorWindow : ISelectorWindow
    {
        private IProcessLauncher processLauncher;

        public FakeSelectorWindow(IProcessLauncher processLauncher)
        {
            this.processLauncher = processLauncher;
        }

        public IProcessLauncher ProcessLauncher
        {
            get
            {
                return this.processLauncher;
            }
        }
    }
}