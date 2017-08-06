namespace TypoEditor
{
    using System;
    using System.Windows.Forms;
    using System.Windows.Interop;

    // https://stackoverflow.com/questions/315164/how-to-use-a-folderbrowserdialog-from-a-wpf-application
    internal static class WpfHelpers
    {
        internal static string ShowSelectfFolderDialog(HwndSource source)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog(new WindowAdapter(source.Handle)) == DialogResult.OK)
            {
                return dlg.SelectedPath;
            }
            else
            {
                return null;
            }
        }

        internal class WindowAdapter : System.Windows.Forms.IWin32Window
        {
            private IntPtr handle;

            public WindowAdapter(IntPtr handle)
            {
                this.handle = handle;
            }

            public IntPtr Handle
            {
                get
                {
                    return this.handle;
                }
            }
        }
    }
}
