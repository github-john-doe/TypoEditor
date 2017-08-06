using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypoEditor
{
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

        public string PathToAnalyze
        {
            get
            {
                return this.pathToAnalyze;
            }
            set
            {
                this.pathToAnalyze = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PathToAnalyze)));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnBrowseButtonClicked()
        {
            this.PathToAnalyze = this.view.SelectFolder();
        }
    }
}
