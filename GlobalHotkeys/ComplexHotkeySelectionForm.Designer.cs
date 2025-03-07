namespace GlobalHotkeys
{
    partial class ComplexHotkeySelectionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            searchBar = new TextBox();
            cancelButton = new Button();
            flowLayoutPanel = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // searchBar
            // 
            searchBar.Anchor = AnchorStyles.None;
            searchBar.BackColor = Color.FromArgb(52, 52, 52);
            searchBar.BorderStyle = BorderStyle.FixedSingle;
            searchBar.ForeColor = Color.White;
            searchBar.Location = new Point(92, 12);
            searchBar.Name = "searchBar";
            searchBar.Size = new Size(200, 23);
            searchBar.TabIndex = 0;
            searchBar.TextChanged += searchBar_TextChanged;
            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.None;
            cancelButton.BackColor = Color.FromArgb(52, 52, 52);
            cancelButton.FlatAppearance.BorderSize = 0;
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.ForeColor = Color.White;
            cancelButton.Location = new Point(142, 220);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(100, 30);
            cancelButton.TabIndex = 5;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Click += cancelButton_Click;
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.BackColor = Color.FromArgb(39, 39, 39);
            flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel.Location = new Point(12, 41);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(360, 173);
            flowLayoutPanel.TabIndex = 6;
            flowLayoutPanel.WrapContents = false;
            // 
            // ComplexHotkeySelectionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 32, 32);
            ClientSize = new Size(384, 261);
            Controls.Add(flowLayoutPanel);
            Controls.Add(cancelButton);
            Controls.Add(searchBar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ComplexHotkeySelectionForm";
            Text = "ComplexHotkeySelectionForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox searchBar;
        private Button cancelButton;
        private FlowLayoutPanel flowLayoutPanel;
    }
}