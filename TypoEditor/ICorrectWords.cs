namespace TypoEditor
{
    using System.Collections.Generic;

    public interface ICorrectWords
    {
        ISet<string> Words { get; }

        bool IsWordCorrect(string s);
    }
}
