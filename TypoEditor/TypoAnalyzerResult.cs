namespace TypoEditor
{
    using System;
    using System.Collections.Generic;

    public class TypoAnalyzerResult
    {
        private SortedDictionary<string, HashSet<string>> keywordOccurrence;

        public TypoAnalyzerResult()
        {
            this.keywordOccurrence = new SortedDictionary<string, HashSet<string>>();
        }

        public IEnumerable<string> Keywords
        {
            get
            {
                return this.keywordOccurrence.Keys;
            }
        }

        public void AddOccurrence(string keyword, string file)
        {
            HashSet<string> occurences;
            if (!this.keywordOccurrence.TryGetValue(keyword, out occurences))
            {
                occurences = new HashSet<string>();
                this.keywordOccurrence.Add(keyword, occurences);
            }

            occurences.Add(file);
        }
    }
}
