namespace TypoEditor
{
    using System;
    using System.ComponentModel;

    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private const string DefaultExtensionToAnalyze = "*.cs";

        private IMainWindow view;
        private ITypoAnalyzer analyzer;
        private string pathToAnalyze;
        private string extensionToAnalyze;

        public MainWindowViewModel(IMainWindow view, ITypoAnalyzer analyzer)
        {
            if (view == null)
            {
                throw new ArgumentNullException("view");
            }
            if (analyzer == null)
            {
                throw new ArgumentNullException("analyzer");
            }

            this.view = view;
            this.analyzer = analyzer;
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
            this.analyzer.Analyze(this.PathToAnalyze, this.ExtensionToAnalyze);
        }
    }
}
