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
        private readonly Dictionary<Guid, (string, string, string)> accounts;

        public ComplexHotkeySelectionForm(IntPtr previousWindow)
        {
            InitializeComponent();

            this.previousWindow = previousWindow;

            PositionNearCursor();

            // Hardcode accounts for demo purposes
            accounts = new Dictionary<Guid, (string, string, string)>() {
                { Guid.NewGuid(), ("Account 1", "Username 1", "Password 1") },
                { Guid.NewGuid(), ("Account 2", "Username 2", "Password 2") },
                { Guid.NewGuid(), ("Account 3", "Username 3", "Password 3") },
                { Guid.NewGuid(), ("Account 4", "Username 4", "Password 4") },
                { Guid.NewGuid(), ("Account 5", "Username 5", "Password 5") },
                { Guid.NewGuid(), ("Account 6", "Username 6", "Password 6") },
                { Guid.NewGuid(), ("Account 7", "Username 7", "Password 7") },
                { Guid.NewGuid(), ("Account 8", "Username 8", "Password 8") },
                { Guid.NewGuid(), ("Account 9", "Username 9", "Password 9") },
                { Guid.NewGuid(), ("Account 10", "Username 10", "Password 10") }
            };

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

            Dictionary<Guid, (string, string, string)> filteredAccounts;
            if (!string.IsNullOrEmpty(query))
            {
                filteredAccounts = accounts
                    .Where(kvp => 
                        kvp.Value.Item1.Contains(query, StringComparison.CurrentCultureIgnoreCase) || 
                        kvp.Value.Item2.Contains(query, StringComparison.CurrentCultureIgnoreCase) || 
                        kvp.Value.Item3.Contains(query, StringComparison.CurrentCultureIgnoreCase))
                    .ToDictionary();
            }
            else
            {
                filteredAccounts = new Dictionary<Guid, (string, string, string)>(accounts);
            }

            // Add a row in the FlowLayoutPanel per account
            foreach (var id in filteredAccounts.Keys)
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
                    Text = filteredAccounts[id].Item1,
                    TextAlign = ContentAlignment.MiddleLeft,
                    AutoEllipsis = true,
                    Size = new Size(100, 23),
                    Margin = new Padding(3)
                });

                var usernameButton = new Button()
                {
                    Text = filteredAccounts[id].Item2,
                    Width = 100,
                    AutoEllipsis = true
                };
                usernameButton.Click += (sender, e) =>
                {
                    PasteText(filteredAccounts[id].Item2);
                    Close();
                };
                rowPanel.Controls.Add(usernameButton);

                var passwordButton = new Button()
                {
                    Text = filteredAccounts[id].Item3,
                    Width = 100,
                    AutoEllipsis = true
                };
                passwordButton.Click += (sender, e) =>
                {
                    PasteText(filteredAccounts[id].Item3);
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
