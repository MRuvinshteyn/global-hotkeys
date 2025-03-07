using System.Runtime.InteropServices;
using WindowsInput;

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

        private static Guid? LastUsedAccount { get; set; } = null;

        public ComplexHotkeySelectionForm(IntPtr previousWindow)
        {
            InitializeComponent();

            this.previousWindow = previousWindow;

            PositionNearCursor();

            // Hardcode accounts for demo purposes
            accounts = new Dictionary<Guid, (string, string, string)>() {
                { new Guid("65a91760-f177-49f8-a13f-bace2ba19ba2"), ("Account 1", "Username 1", "Password 1") },
                { new Guid("4b2f0ef1-002c-4b1d-9004-52c91d27462e"), ("Account 2", "Username 2", "Password 2") },
                { new Guid("e19a0cf4-635d-4401-8371-2c40494c46f9"), ("Account 3", "Username 3", "Password 3") },
                { new Guid("34d7f81c-d7db-4756-b254-b121f5cd32be"), ("Account 4", "Username 4", "Password 4") },
                { new Guid("b1f9837e-5072-4252-9a69-dce72bfe08c0"), ("Account 5", "Username 5", "Password 5") },
                { new Guid("853dcbe5-71bd-4c87-a495-8de56dd52f45"), ("Account 6", "Username 6", "Password 6") },
                { new Guid("841466a8-9a2e-4013-90a0-f5f03f81ce05"), ("Account 7", "Username 7", "Password 7") },
                { new Guid("9195ee4e-089b-4fd0-a59f-88119b0faab6"), ("Account 8", "Username 8", "Password 8") },
                { new Guid("4c9080da-107b-4695-a787-5bbbee88ece4"), ("Account 9", "Username 9", "Password 9") },
                { new Guid("f9f8121c-cb42-484b-9f44-ee6e70660c55"), ("Account 10", "Username 10", "Password 10") }
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

            if (string.IsNullOrEmpty(query) && LastUsedAccount != null && 
                accounts.TryGetValue(LastUsedAccount.Value, out (string, string, string) account))
            {
                flowLayoutPanel.Controls.Add(new Label
                {
                    Text = "Recently used:",
                });
                AddAccount(LastUsedAccount.Value, account);
                flowLayoutPanel.Controls.Add(new Label
                {
                    BorderStyle = BorderStyle.Fixed3D,
                    Height = 2,
                    Dock = DockStyle.Top,
                    Margin = new Padding(5, 2, 5, 2)
                });
            }

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
                AddAccount(id, filteredAccounts[id]);
            }
        }

        private void AddAccount(Guid id, (string, string, string) account)
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
                LastUsedAccount = id;
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
                LastUsedAccount = id;
                Close();
            };
            rowPanel.Controls.Add(passwordButton);

            flowLayoutPanel.Controls.Add(rowPanel);
        }

        private void PasteText(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return;
            }

            SetForegroundWindow(previousWindow);
            for (int i = 0; GetForegroundWindow() != previousWindow && i < 20; ++i)
            {
                Thread.Sleep(100); // Wait up to 2 seconds for previous window to be in focus
            }

            var sim = new InputSimulator();
            sim.Keyboard.TextEntry(text);
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
