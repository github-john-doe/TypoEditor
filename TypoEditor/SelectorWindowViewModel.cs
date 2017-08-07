namespace TypoEditor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    public class SelectorWindowViewModel : INotifyPropertyChanged
    {
        private ISelectorWindow view;
        private int selectedKeywordIndex;
        private KeywordOccurrences[] keywordOccurrences;
        private IEnumerable<string> occurrences;

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

        public IEnumerable<string> Occurrences
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
                this.Occurrences = this.keywordOccurrences[this.selectedKeywordIndex].Occurrences;
            }
        }

        public void SetTypoAnalyzerResult(TypoAnalyzerResult result)
        {
            this.keywordOccurrences = result.Keywords.ToArray();
            this.occurrences = this.keywordOccurrences[0].Occurrences;
        }
    }
}
