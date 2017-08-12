namespace TypoEditor
{
    public interface IProgressReporter
    {
        int Current { get; set; }

        int Maximum { get; set; }
    }
}
