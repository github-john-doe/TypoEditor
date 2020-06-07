namespace TypoEditor
{
    public interface ISelectorWindow
    {
        IProcessLauncher ProcessLauncher { get; }

        IConfiguration Configuration { get; }

        IFileSystem FileSystem { get; }

        IErrorReporter ErrorReporter { get; }
    }
}