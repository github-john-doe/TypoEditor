namespace TypoEditor
{
    using System.Collections.Generic;

    public class KeywordOccurrences
    {
        public string Keyword { get; set; }

        public IEnumerable<string> Occurrences { get; set; }
    }
}
