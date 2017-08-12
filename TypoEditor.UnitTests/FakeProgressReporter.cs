namespace TypoEditor.UnitTests
{
    public class FakeProgressReporter : IProgressReporter
    {
        public int Current { get; set; }
        public int Maximum { get; set; }
    }
}
