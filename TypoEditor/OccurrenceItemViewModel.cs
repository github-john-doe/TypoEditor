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
            private EventHandler canExecuteChanged;

            public ViewFileCommand(OccurrenceItemViewModel item)
            {
                this.item = item;
            }

            public event EventHandler CanExecuteChanged
            {
                add { this.canExecuteChanged += value; }
                remove { this.canExecuteChanged -= value; }
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                Process process = new Process
                {
                    StartInfo = new ProcessStartInfo()
                    {
                        FileName = @"C:\windows\system32\notepad.exe",
                        Arguments = this.item.Name
                    }
                };
                process.Start();
            }
        }
    }
}
