namespace TypoEditor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class TypoAnalyzer : ITypoAnalyzer
    {
        private IFileSystem fileSystem;
        private MainWindowViewModel vm;

        public TypoAnalyzer(IFileSystem fileSystem)
        {
            this.fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
        }

        public void SetMainWindowViewModel(MainWindowViewModel vm)
        {
            this.vm = vm;
        }

        public TypoAnalyzerResult Analyze(string folder, string pattern)
        {
            var result = new TypoAnalyzerResult();
            string[] files = this.fileSystem.EnumerateFiles(folder, pattern).ToArray();
            vm.Maximum = files.Length;
            foreach (var file in files)
            {
                vm.Current++;
                this.AnalyzeFile(file, result);
            }

            return result;
        }

        private void AnalyzeFile(string file, TypoAnalyzerResult result)
        {
            string content = this.fileSystem.ReadFile(file);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < content.Length; i++)
            {
                char c = content[i];
                if (char.IsLetter(c))
                {
                    if (char.IsUpper(c))
                    {
                        if (builder.Length > 0)
                        {
                            result.AddOccurrence(builder.ToString(), file);
                            builder.Clear();
                        }

                        c = char.ToLower(c);
                    }

                    builder.Append(c);
                }
                else
                {
                    if (builder.Length > 0)
                    {
                        result.AddOccurrence(builder.ToString(), file);
                        builder.Clear();
                    }
                }
            }

            if (builder.Length > 0)
            {
                result.AddOccurrence(builder.ToString(), file);
                builder.Clear();
            }
        }
    }
}
