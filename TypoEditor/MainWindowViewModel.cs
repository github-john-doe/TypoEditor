namespace TypoEditor
{
    using System;
    using System.ComponentModel;

    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private IMainWindow view;
        private string pathToAnalyze;

        public MainWindowViewModel(IMainWindow view)
        {
            if (view == null)
            {
                throw new ArgumentNullException("view");
            }

            this.view = view;
        }

        public event PropertyChangedEventHandler PropertyChanged;

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
    }
}
