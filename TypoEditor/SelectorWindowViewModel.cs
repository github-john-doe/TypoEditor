namespace TypoEditor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;

    public class SelectorWindowViewModel : INotifyPropertyChanged
    {
        private ISelectorWindow view;
        private int selectedKeywordIndex;
        private TypoAnalyzerResult result;
        private KeywordOccurrences[] keywordOccurrences;
        private IEnumerable<OccurrenceItemViewModel> occurrences;

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

        public IEnumerable<OccurrenceItemViewModel> Occurrences
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
                string typo = this.keywordOccurrences[value].Keyword;
                foreach (var correction in this.result.GetRecommendedCorrection(typo))
                {
                    Debug.WriteLine(typo + " -> " + correction);
                }

                this.selectedKeywordIndex = value;
                this.Occurrences = this.keywordOccurrences[this.selectedKeywordIndex].Occurrences.Select(o => new OccurrenceItemViewModel(this.view) { Name = o });
            }
        }

        public void SetTypoAnalyzerResult(TypoAnalyzerResult result)
        {
            this.result = result;
            this.keywordOccurrences = result.Keywords.OrderBy(t => t.Occurrences.Count()).ToArray();
            this.occurrences = this.keywordOccurrences[0].Occurrences.Select(o => new OccurrenceItemViewModel(this.view) { Name = o });
        }
    }
}
