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
            listView = new ListView();
            cancelButton = new Button();
            SuspendLayout();
            // 
            // searchBar
            // 
            searchBar.Anchor = AnchorStyles.None;
            searchBar.Location = new Point(92, 12);
            searchBar.Name = "searchBar";
            searchBar.Size = new Size(200, 23);
            searchBar.TabIndex = 0;
            // 
            // listView
            // 
            listView.Location = new Point(42, 49);
            listView.Name = "listView";
            listView.Size = new Size(300, 156);
            listView.TabIndex = 1;
            listView.UseCompatibleStateImageBehavior = false;
            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.None;
            cancelButton.Location = new Point(142, 220);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(100, 30);
            cancelButton.TabIndex = 5;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // ComplexHotkeySelectionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 261);
            Controls.Add(cancelButton);
            Controls.Add(listView);
            Controls.Add(searchBar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ComplexHotkeySelectionForm";
            Text = "ComplexHotkeySelectionForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox searchBar;
        private ListView listView;
        private Button cancelButton;
    }
}