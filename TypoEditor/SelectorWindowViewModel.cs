namespace TypoEditor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public class SelectorWindowViewModel : INotifyPropertyChanged
    {
        private ISelectorWindow view;
        private TypoAnalyzerResult result;

        public SelectorWindowViewModel(ISelectorWindow view)
        {
            this.view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public IEnumerable<string> Keywords
        {
            get
            {
                return this.result.Keywords;
            }
        }

        public void SetTypoAnalyzerResult(TypoAnalyzerResult result)
        {
            this.result = result;
        }
    }
}
