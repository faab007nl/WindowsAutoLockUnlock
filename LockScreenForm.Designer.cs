namespace WindowsAutoLockUnlock
{
    partial class LockScreenForm
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
            LockScreenLabel = new Label();
            SuspendLayout();
            // 
            // LockScreenLabel
            // 
            LockScreenLabel.AutoSize = true;
            LockScreenLabel.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            LockScreenLabel.ForeColor = Color.White;
            LockScreenLabel.Location = new Point(332, 180);
            LockScreenLabel.Name = "LockScreenLabel";
            LockScreenLabel.Size = new Size(130, 54);
            LockScreenLabel.TabIndex = 0;
            LockScreenLabel.Text = "label1";
            LockScreenLabel.TextAlign = ContentAlignment.MiddleCenter;
            LockScreenLabel.Visible = false;
            // 
            // LockScreenForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(800, 450);
            Controls.Add(LockScreenLabel);
            FormBorderStyle = FormBorderStyle.None;
            MinimizeBox = false;
            Name = "LockScreenForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "LockScreenForm";
            FormClosing += LockScreenForm_FormClosing;
            Load += LockScreenForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LockScreenLabel;
    }
}