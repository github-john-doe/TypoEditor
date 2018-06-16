namespace TypoEditor
{
    using System;
    using System.Windows.Input;

    public class OccurrenceItemViewModel
    {
        private ISelectorWindow view;

        public OccurrenceItemViewModel(ISelectorWindow view)
        {
            this.view = view ?? throw new ArgumentNullException(nameof(view));
        }

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
                this.item.view.ProcessLauncher.LaunchProcess(@"C:\Program Files\Sublime Text 3\sublime_text.exe", this.item.Name);
            }
        }
    }
}
