namespace GlobalHotkeys
{
    partial class SimpleHotkeySelectionForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            usernameButton1 = new Button();
            usernameButton2 = new Button();
            passwordButton1 = new Button();
            passwordButton2 = new Button();
            label1 = new Label();
            label2 = new Label();
            cancelButton = new Button();
            SuspendLayout();
            // 
            // usernameButton1
            // 
            usernameButton1.Location = new Point(100, 40);
            usernameButton1.Name = "usernameButton1";
            usernameButton1.Size = new Size(100, 30);
            usernameButton1.TabIndex = 0;
            usernameButton1.Text = "Username 1";
            usernameButton1.UseVisualStyleBackColor = true;
            usernameButton1.Click += usernameButton1_Click;
            // 
            // usernameButton2
            // 
            usernameButton2.Location = new Point(100, 120);
            usernameButton2.Name = "usernameButton2";
            usernameButton2.Size = new Size(100, 30);
            usernameButton2.TabIndex = 2;
            usernameButton2.Text = "Username 2";
            usernameButton2.UseVisualStyleBackColor = true;
            usernameButton2.Click += usernameButton2_Click;
            // 
            // passwordButton1
            // 
            passwordButton1.Location = new Point(240, 40);
            passwordButton1.Name = "passwordButton1";
            passwordButton1.Size = new Size(100, 30);
            passwordButton1.TabIndex = 1;
            passwordButton1.Text = "Password 1";
            passwordButton1.UseVisualStyleBackColor = true;
            passwordButton1.Click += passwordButton1_Click;
            // 
            // passwordButton2
            // 
            passwordButton2.Location = new Point(240, 120);
            passwordButton2.Name = "passwordButton2";
            passwordButton2.Size = new Size(100, 30);
            passwordButton2.TabIndex = 3;
            passwordButton2.Text = "Password 2";
            passwordButton2.UseVisualStyleBackColor = true;
            passwordButton2.Click += passwordButton2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 48);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 4;
            label1.Text = "Account 1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 128);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 5;
            label2.Text = "Account 2";
            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.None;
            cancelButton.Location = new Point(142, 220);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(100, 30);
            cancelButton.TabIndex = 4;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // SimpleHotkeySelectionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 261);
            Controls.Add(cancelButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(passwordButton2);
            Controls.Add(passwordButton1);
            Controls.Add(usernameButton2);
            Controls.Add(usernameButton1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SimpleHotkeySelectionForm";
            Text = "Simple Selection Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button usernameButton1;
        private Button usernameButton2;
        private Button passwordButton1;
        private Button passwordButton2;
        private Label label1;
        private Label label2;
        private Button cancelButton;
    }
}
