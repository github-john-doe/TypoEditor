namespace TypoEditor.UnitTests
{
    public class FakeFileSystem : IFileSystem
    {
        public string[] EnumerateFiles(string directory, string searchPattern)
        {
            return null;
        }
    }
}
