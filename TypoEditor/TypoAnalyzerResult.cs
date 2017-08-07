namespace TypoEditor
{
    using System.Collections.Generic;
    using System.Linq;

    public class TypoAnalyzerResult
    {
        private SortedDictionary<string, HashSet<string>> keywordOccurrence;

        public TypoAnalyzerResult()
        {
            this.keywordOccurrence = new SortedDictionary<string, HashSet<string>>();
        }

        public IEnumerable<KeywordOccurrences> Keywords
        {
            get
            {
                return this.keywordOccurrence.Select(k => new KeywordOccurrences { Keyword = k.Key });
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
