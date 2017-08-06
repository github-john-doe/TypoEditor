namespace TypoEditor
{
    using System.Windows;
    using System.Windows.Forms;
    using System.Windows.Interop;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainWindow
    {
        private MainWindowViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this.viewModel = new MainWindowViewModel(this);
        }

        public string SelectFolder()
        {
            return WpfHelpers.ShowSelectfFolderDialog(PresentationSource.FromVisual(this) as HwndSource);
        }

        private void OnBrowseButtonClicked(object sender, RoutedEventArgs e)
        {
            this.viewModel.OnBrowseButtonClicked();
        }
    }
}
