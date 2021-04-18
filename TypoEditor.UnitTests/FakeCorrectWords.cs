using System.Collections.Generic;

namespace TypoEditor.UnitTests
{
    internal class FakeCorrectWords : ICorrectWords
    {
        public IEnumerable<string> GetRecommendCorrections(string typo)
        {
            return new string[0];
        }

        public bool IsWordCorrect(string s)
        {
            return false;
        }
    }
}
