namespace TypoEditor
{
    using System.Windows;
    using System.Windows.Forms;
    using System.Windows.Interop;

    public partial class MainWindow : Window, IMainWindow
    {
        private MainWindowViewModel viewModel;

        public MainWindow()
        {
            this.InitializeComponent();
            this.DataContext = this.viewModel = new MainWindowViewModel(this, new TypoAnalyzer(new FileSystem()));
        }

        public string SelectFolder()
        {
            return WpfHelpers.ShowSelectfFolderDialog(PresentationSource.FromVisual(this) as HwndSource);
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
