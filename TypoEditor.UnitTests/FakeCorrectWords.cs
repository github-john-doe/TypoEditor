namespace TypoEditor.UnitTests
{
    internal class FakeCorrectWords : ICorrectWords
    {
        public bool IsWordCorrect(string s)
        {
            return false;
        }
    }
}
