namespace TypoEditor
{
    using System.Collections.Generic;

    public interface ICorrectWords
    {
        bool IsWordCorrect(string s);

        IEnumerable<string> GetRecommendCorrections(string typo);
    }
}
