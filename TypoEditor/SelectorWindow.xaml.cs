namespace TypoEditor
{
    using System;
    using System.Windows;

    public partial class SelectorWindow : Window, ISelectorWindow
    {
        private SelectorWindowViewModel viewModel;
        private IProcessLauncher processLauncher;
        private IConfiguration configuration;
        private IFileSystem fileSystem;
        private IErrorReporter errorReporter;

        public SelectorWindow()
        {
            this.InitializeComponent();
            
            this.processLauncher = new ProcessLauncher();
            this.configuration = new Configuration();
            this.fileSystem = new FileSystem();
            this.errorReporter = new ErrorReporter();
            this.DataContext = this.viewModel = new SelectorWindowViewModel(this);
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

        internal void SetTypoAnalyzerResult(TypoAnalyzerResult result)
        {
            this.viewModel.SetTypoAnalyzerResult(result);
        }
    }
}
