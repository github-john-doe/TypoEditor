namespace TypoEditor.UnitTests
{
    public class FakeErrorReporter : IErrorReporter
    {
        private string reportedError;

        public void ReportError(string error)
        {
            this.reportedError = error;
        }

        public string ReportedError
        {
            get
            {
                return this.reportedError;
            }
        }
    }
}