using System.Runtime.InteropServices;

namespace GlobalHotkeys
{
    public partial class SimpleHotkeySelectionForm : Form
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private readonly IntPtr previousWindow;

        public SimpleHotkeySelectionForm(IntPtr previousWindow)
        {
            InitializeComponent();

            this.previousWindow = previousWindow;
        }

        private void usernameButton1_Click(object sender, EventArgs e)
        {
            PasteText("Username 1");
            Close();
        }

        private void usernameButton2_Click(object sender, EventArgs e)
        {
            PasteText("Username 2");
            Close();
        }

        private void passwordButton1_Click(object sender, EventArgs e)
        {
            PasteText("Password 1");
            Close();
        }

        private void passwordButton2_Click(object sender, EventArgs e)
        {
            PasteText("Password 2");
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PasteText(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return;
            }

            Clipboard.SetText(text);
            SetForegroundWindow(previousWindow);
            for (int i = 0; GetForegroundWindow() != previousWindow && i < 20; ++i)
            {
                Thread.Sleep(100); // Wait up to 2 seconds for previous window to be in focus
            }
            SendKeys.SendWait("^v");
        }
    }
}
