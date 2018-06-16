namespace TypoEditor.UnitTests
{
    internal class FakeSelectorWindow : ISelectorWindow
    {
        private IProcessLauncher processLauncher;
        private IConfiguration configuration;

        public FakeSelectorWindow(IProcessLauncher processLauncher, IConfiguration configuration)
        {
            this.processLauncher = processLauncher;
            this.configuration = configuration;
        }

        public IProcessLauncher ProcessLauncher
        {
            get
            {
                return this.processLauncher;
            }
        }

        public IConfiguration Configuration
        {
            get
            {
                return this.configuration;
            }
        }
    }
}