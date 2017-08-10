namespace TypoEditor
{
    using System;
    using System.Diagnostics;
    using System.Windows.Input;

    public class OccurrenceItemViewModel
    {
        public string Name { get; set; }

        public ICommand DoubleClickCommand
        {
            get
            {
                return new ViewFileCommand(this);
            }
        }

        private class ViewFileCommand : ICommand
        {
            private OccurrenceItemViewModel item;

            public ViewFileCommand(OccurrenceItemViewModel item)
            {
                this.item = item;
            }

            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                Process process = new Process();
                ProcessStartInfo processStartInfo = new ProcessStartInfo();
                processStartInfo.FileName = @"C:\windows\system32\notepad.exe";
                processStartInfo.Arguments = this.item.Name;
                process.StartInfo = processStartInfo;
                process.Start();
            }
        }
    }
}
