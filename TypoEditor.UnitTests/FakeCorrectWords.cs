using System.Collections.Generic;

namespace TypoEditor.UnitTests
{
    internal class FakeCorrectWords : ICorrectWords
    {
        public bool IsWordCorrect(string s)
        {
            return false;
        }

        public ISet<string> Words
        {
            get
            {
                return null;
            }
        }
    }
}
