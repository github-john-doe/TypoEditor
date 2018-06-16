namespace TypoEditor
{
    using System.Diagnostics;

    public class ProcessLauncher : IProcessLauncher
    {
        public void LaunchProcess(string processName, string arg)
        {
            Process process = new Process
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = processName,
                    Arguments = arg
                }
            };
            process.Start();
        }
    }
}
