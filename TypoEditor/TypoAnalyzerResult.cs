namespace TypoEditor
{
    using System.Collections.Generic;

    public class TypoAnalyzerResult
    {
        public IEnumerable<string> Keywords
        {
            get
            {
                yield return "Cruel";
                yield return "Hello";
                yield return "World";
            }
        }
    }
}
