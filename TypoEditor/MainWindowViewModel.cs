namespace TypoEditor
{
    using System;
    using System.ComponentModel;
    using System.Threading;
    using System.Windows.Threading;

    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private const string DefaultExtensionToAnalyze = "*.cs";

        private IMainWindow view;
        private ITypoAnalyzer analyzer;
        private string pathToAnalyze;
        private string extensionToAnalyze;

        public MainWindowViewModel(IMainWindow view, ITypoAnalyzer analyzer)
        {
            this.view = view ?? throw new ArgumentNullException(nameof(view));
            this.analyzer = analyzer ?? throw new ArgumentNullException(nameof(analyzer));
            this.extensionToAnalyze = DefaultExtensionToAnalyze;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string ExtensionToAnalyze
        {
            get
            {
                return this.extensionToAnalyze;
            }

            set
            {
                this.extensionToAnalyze = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.ExtensionToAnalyze)));
            }
        }

        public string PathToAnalyze
        {
            get
            {
                return this.pathToAnalyze;
            }

            set
            {
                this.pathToAnalyze = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.PathToAnalyze)));
            }
        }

        public void OnBrowseButtonClicked()
        {
            this.PathToAnalyze = this.view.SelectFolder();
        }

        public void OnAnalyzeButtonClicked()
        {
            Dispatcher d = Dispatcher.CurrentDispatcher;
            ThreadPool.QueueUserWorkItem((x) =>
            {
                ((TypoAnalyzer)this.analyzer).SetMainWindowViewModel(this);
                TypoAnalyzerResult result = this.analyzer.Analyze(this.PathToAnalyze, this.ExtensionToAnalyze);
                d.BeginInvoke(new Action(() =>
                {
                    this.view.ShowAnalyzeResult(result);
                }));
            });
        }

        int current; public int Current { get { return this.current; } set { this.current = value; this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Current))); } }
        int maximum; public int Maximum { get { return this.maximum; } set { this.maximum = value; this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Maximum))); } }
    }
}
