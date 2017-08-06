namespace TypoEditor
{
    public interface ITypoAnalyzer
    {
        TypoAnalyzerResult Analyze(string folder, string pattern);
    }
}