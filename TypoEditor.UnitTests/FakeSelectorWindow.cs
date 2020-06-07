namespace TypoEditor.UnitTests
{
    internal class FakeSelectorWindow : ISelectorWindow
    {
        private IProcessLauncher processLauncher;
        private IConfiguration configuration;
        private IFileSystem fileSystem;
        private IErrorReporter errorReporter;

        public FakeSelectorWindow(IProcessLauncher processLauncher, IConfiguration configuration, IFileSystem fileSystem, IErrorReporter errorReporter)
        {
            this.processLauncher = processLauncher;
            this.configuration = configuration;
            this.fileSystem = fileSystem;
            this.errorReporter = errorReporter;
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

        public IFileSystem FileSystem
        {
            get
            {
                return this.fileSystem;
            }
        }

        public IErrorReporter ErrorReporter
        {
            get
            {
                return this.errorReporter;
            }
        }
    }
}