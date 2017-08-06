namespace TypoEditor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public class SelectorWindowViewModel : INotifyPropertyChanged
    {
        private ISelectorWindow view;
        private TypoAnalyzerResult result;
        private int selectedKeywordIndex;

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
                return this.result.Keywords;
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
            }
        }

        public void SetTypoAnalyzerResult(TypoAnalyzerResult result)
        {
            this.result = result;
        }
    }
}
