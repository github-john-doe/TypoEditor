namespace TypoEditor
{
    using System.Collections.Generic;
    using System.Linq;

    public class TypoAnalyzerResult
    {
        private SortedDictionary<string, HashSet<string>> keywordOccurrence;
        private BkTree tree;

        public TypoAnalyzerResult()
        {
            this.keywordOccurrence = new SortedDictionary<string, HashSet<string>>();
        }

        public IEnumerable<KeywordOccurrences> Keywords
        {
            get
            {
                return this.keywordOccurrence.Select(k => new KeywordOccurrences { Keyword = k.Key, Occurrences = k.Value });
            }
        }

        public IEnumerable<string> GetRecommendedCorrection(string typo)
        {
            return this.tree.Query(typo, 2);
        }

        public void SetTree(BkTree tree)
        {
            this.tree = tree;
        }

        public void AddOccurrence(string keyword, string file)
        {
            HashSet<string> occurrences;
            if (!this.keywordOccurrence.TryGetValue(keyword, out occurrences))
            {
                occurrences = new HashSet<string>();
                this.keywordOccurrence.Add(keyword, occurrences);
            }

            occurrences.Add(file);
        }
    }
}
