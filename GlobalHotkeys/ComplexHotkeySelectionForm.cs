namespace GlobalHotkeys
{
    public partial class ComplexHotkeySelectionForm : Form
    {
        private readonly List<(string, string, string)> accounts;

        public ComplexHotkeySelectionForm()
        {
            InitializeComponent();

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
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PopulateAccounts()
        {
            // Add a row in the FlowLayoutPanel per account
            foreach (var account in accounts)
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
                rowPanel.Controls.Add(new Button() { Text = account.Item2, Width = 100, AutoEllipsis = true });
                rowPanel.Controls.Add(new Button() { Text = account.Item3, Width = 100, AutoEllipsis = true });

                flowLayoutPanel.Controls.Add(rowPanel);
            }
        }
    }
}
