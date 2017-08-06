namespace TypoEditor
{
    using System;
    using System.Windows;

    public partial class SelectorWindow : Window, ISelectorWindow
    {
        private SelectorWindowViewModel viewModel;

        public SelectorWindow()
        {
            this.InitializeComponent();
            this.DataContext = this.viewModel = new SelectorWindowViewModel(this);
        }

        internal void SetTypoAnalyzerResult(TypoAnalyzerResult result)
        {
            this.viewModel.SetTypoAnalyzerResult(result);
        }
    }
}
