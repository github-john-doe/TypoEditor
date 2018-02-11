namespace TypoEditor
{
    using System;
    using System.Windows;
    using System.Windows.Forms;
    using System.Windows.Interop;
    using System.Windows.Threading;

    public partial class MainWindow : Window, IMainWindow
    {
        private MainWindowViewModel viewModel;
        private Dispatcher dispatcher;

        public MainWindow()
        {
            this.InitializeComponent();
            this.DataContext = this.viewModel = new MainWindowViewModel(this, new TypoAnalyzer(new FileSystem(), new CorrectWords()));
            this.viewModel.PathToAnalyze = @"C:\Dev\TypoEditor";
            this.dispatcher = Dispatcher.CurrentDispatcher;
        }

        public string SelectFolder()
        {
            return WpfHelpers.ShowSelectFolderDialog(PresentationSource.FromVisual(this) as HwndSource);
        }

        public void ShowAnalyzeResult(TypoAnalyzerResult result)
        {
            this.dispatcher.BeginInvoke(new Action(() =>
            {
                SelectorWindow selectorWindow = new SelectorWindow();
                selectorWindow.SetTypoAnalyzerResult(result);
                selectorWindow.Show();
                this.Close();
            }));
        }

        private void OnBrowseButtonClicked(object sender, RoutedEventArgs e)
        {
            this.viewModel.OnBrowseButtonClicked();
        }

        private void OnAnalyzeButtonClicked(object sender, RoutedEventArgs e)
        {
            this.viewModel.OnAnalyzeButtonClicked();
        }
    }
}
