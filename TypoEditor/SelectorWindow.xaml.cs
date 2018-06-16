namespace TypoEditor
{
    using System;
    using System.Windows;

    public partial class SelectorWindow : Window, ISelectorWindow
    {
        private SelectorWindowViewModel viewModel;
        private IProcessLauncher processLauncher;
        private IConfiguration configuration;

        public SelectorWindow()
        {
            this.InitializeComponent();
            this.DataContext = this.viewModel = new SelectorWindowViewModel(this);
            this.processLauncher = new ProcessLauncher();
            this.configuration = new Configuration();
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

        internal void SetTypoAnalyzerResult(TypoAnalyzerResult result)
        {
            this.viewModel.SetTypoAnalyzerResult(result);
        }
    }
}
