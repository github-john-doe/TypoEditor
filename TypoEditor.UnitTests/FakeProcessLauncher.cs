namespace TypoEditor.UnitTests
{
    public class FakeProcessLauncher : IProcessLauncher
    {
        public string Executable { get; private set; }

        public string Argument { get; private set; }

        public void LaunchProcess(string processName, string arg)
        {
            this.Executable = processName;
            this.Argument = arg;
        }
    }
}
