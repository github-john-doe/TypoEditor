namespace TypoEditor
{
    using System;
    using System.Windows;

    public partial class SelectorWindow : Window, ISelectorWindow
    {
        private SelectorWindowViewModel viewModel;
        private IProcessLauncher processLauncher;

        public SelectorWindow()
        {
            this.InitializeComponent();
            this.DataContext = this.viewModel = new SelectorWindowViewModel(this);
            this.processLauncher = new ProcessLauncher();
        }

        public IProcessLauncher ProcessLauncher
        {
            get
            {
                return this.processLauncher;
            }
        }

        internal void SetTypoAnalyzerResult(TypoAnalyzerResult result)
        {
            this.viewModel.SetTypoAnalyzerResult(result);
        }
    }
}
