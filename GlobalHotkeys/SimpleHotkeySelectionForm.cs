namespace GlobalHotkeys
{
    public partial class SimpleHotkeySelectionForm : Form
    {
        private readonly IntPtr previousWindow;

        public SimpleHotkeySelectionForm(IntPtr previousWindow)
        {
            InitializeComponent();

            this.previousWindow = previousWindow;
        }

        private void usernameButton1_Click(object sender, EventArgs e)
        {

        }

        private void usernameButton2_Click(object sender, EventArgs e)
        {

        }

        private void passwordButton1_Click(object sender, EventArgs e)
        {

        }

        private void passwordButton2_Click(object sender, EventArgs e)
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {

        }
    }
}
