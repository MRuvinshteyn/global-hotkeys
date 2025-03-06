using System.Runtime.InteropServices;

namespace GlobalHotkeys
{
    public partial class ComplexHotkeySelectionForm : Form
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private readonly IntPtr previousWindow;
        private readonly List<(string, string, string)> accounts;

        public ComplexHotkeySelectionForm(IntPtr previousWindow)
        {
            InitializeComponent();

            this.previousWindow = previousWindow;

            PositionNearCursor();

            // Hardcode accounts for demo purposes
            accounts = [
                ("Account 1", "Username 1", "Password 1"),
                ("Account 2", "Username 2", "Password 2"),
                ("Account 3", "Username 3", "Password 3"),
                ("Account 4", "Username 4", "Password 4"),
                ("Account 5", "Username 5", "Password 5"),
                ("Account 6", "Username 6", "Password 6"),
                ("Account 7", "Username 7", "Password 7"),
                ("Account 8", "Username 8", "Password 8"),
                ("Account 9", "Username 9", "Password 9"),
                ("Account 10", "Username 10", "Password 10"),
            ];

            PopulateAccounts();

            Deactivate += (sender, e) => { Close(); };
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PopulateAccounts(string query = "")
        {
            flowLayoutPanel.Controls.Clear();

            List<(string, string, string)> filteredAccounts;
            if (!string.IsNullOrEmpty(query))
            {
                filteredAccounts = accounts
                    .Where(account => 
                        account.Item1.Contains(query, StringComparison.CurrentCultureIgnoreCase) || 
                        account.Item2.Contains(query, StringComparison.CurrentCultureIgnoreCase) || 
                        account.Item3.Contains(query, StringComparison.CurrentCultureIgnoreCase))
                    .ToList();
            }
            else
            {
                filteredAccounts = new List<(string, string, string)>(accounts);
            }

            // Add a row in the FlowLayoutPanel per account
            foreach (var account in filteredAccounts)
            {
                var rowPanel = new FlowLayoutPanel()
                {
                    AutoSize = true,
                    Dock = DockStyle.Top,
                    FlowDirection = FlowDirection.LeftToRight,
                    Padding = new Padding(5),
                    Height = 30
                };

                // Add a label and two buttons for each account
                rowPanel.Controls.Add(new Label()
                {
                    Text = account.Item1,
                    TextAlign = ContentAlignment.MiddleLeft,
                    AutoEllipsis = true,
                    Size = new Size(100, 23),
                    Margin = new Padding(3)
                });

                var usernameButton = new Button()
                {
                    Text = account.Item2,
                    Width = 100,
                    AutoEllipsis = true
                };
                usernameButton.Click += (sender, e) =>
                {
                    PasteText(account.Item2);
                    Close();
                };
                rowPanel.Controls.Add(usernameButton);

                var passwordButton = new Button()
                {
                    Text = account.Item3,
                    Width = 100,
                    AutoEllipsis = true
                };
                passwordButton.Click += (sender, e) =>
                {
                    PasteText(account.Item3);
                    Close();
                };
                rowPanel.Controls.Add(passwordButton);

                flowLayoutPanel.Controls.Add(rowPanel);
            }
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

        private void PositionNearCursor()
        {
            var cursorPosition = Cursor.Position;
            var screen = Screen.FromPoint(cursorPosition).WorkingArea;

            int popupWidth = Width;
            int popupHeight = Height;
            int padding = 10;

            // Start with position next to cursor
            int newX = cursorPosition.X + padding;
            int newY = cursorPosition.Y + padding;

            // Check bounds to prevent overflow
            if (newX + popupWidth > screen.Right) newX = screen.Right - popupWidth - padding;
            if (newY + popupHeight > screen.Bottom) newY = screen.Bottom - popupHeight - padding;

            StartPosition = FormStartPosition.Manual;
            Location = new Point(newX, newY);
        }

        private void searchBar_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox search)
            {
                PopulateAccounts(search.Text);
            }
        }
    }
}
