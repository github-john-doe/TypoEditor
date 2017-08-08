namespace TypoEditor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Windows.Input;

    public class Item
    {
        public string Name { get; set; }

        public ICommand ShowDetailCommand
        {
            get
            {
                return new Command(this);
            }
        }

        class Command : ICommand
        {
            private Item item;

            public Command(Item item)
            {
                this.item = item;
            }

            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                Process process = new Process();
                ProcessStartInfo processStartInfo = new ProcessStartInfo();
                processStartInfo.FileName = @"C:\windows\system32\notepad.exe";
                processStartInfo.Arguments = item.Name;
                process.StartInfo = processStartInfo;
                process.Start();
            }
        }
    }

    public class SelectorWindowViewModel : INotifyPropertyChanged
    {
        private ISelectorWindow view;
        private int selectedKeywordIndex;
        private KeywordOccurrences[] keywordOccurrences;
        private IEnumerable<Item> occurrences;

        public SelectorWindowViewModel(ISelectorWindow view)
        {
            this.view = view ?? throw new ArgumentNullException(nameof(view));
            this.selectedKeywordIndex = 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public IEnumerable<string> Keywords
        {
            get
            {
                return this.keywordOccurrences.Select(t => t.Keyword);
            }
        }

        public IEnumerable<Item> Occurrences
        {
            get
            {
                return this.occurrences;
            }

            set
            {
                this.occurrences = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Occurrences)));
            }
        }

        public int SelectedKeywordIndex
        {
            get
            {
                return this.selectedKeywordIndex;
            }

            set
            {
                this.selectedKeywordIndex = value;
                this.Occurrences = this.keywordOccurrences[this.selectedKeywordIndex].Occurrences.Select(o => new Item { Name = o });
            }
        }

        public void SetTypoAnalyzerResult(TypoAnalyzerResult result)
        {
            this.keywordOccurrences = result.Keywords.ToArray();
            this.occurrences = this.keywordOccurrences[0].Occurrences.Select(o => new Item { Name = o });
        }
    }
}
