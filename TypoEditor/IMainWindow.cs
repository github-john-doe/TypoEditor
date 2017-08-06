namespace TypoEditor
{
    public interface IMainWindow
    {
        string SelectFolder();

        void ShowAnalyzeResult(TypoAnalyzerResult result);
    }
}
