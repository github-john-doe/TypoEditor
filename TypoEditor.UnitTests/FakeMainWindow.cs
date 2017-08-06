namespace TypoEditor.UnitTests
{
    public class FakeMainWindow : IMainWindow
    {
        public string SelectFolder()
        {
            return Constants.UserSelectedPath;
        }
    }
}
