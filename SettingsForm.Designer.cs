namespace WindowsAutoLockUnlock
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            label1 = new Label();
            UseLastPluggedInDeviceBtn = new Button();
            label2 = new Label();
            current_device_label = new Label();
            label3 = new Label();
            ShowBlackScreenWhenLockedCheckBox = new CheckBox();
            BlackScreenText = new TextBox();
            label4 = new Label();
            UseLastDeviceErrorLabel = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(100, 38);
            label1.TabIndex = 0;
            label1.Text = "Device";
            // 
            // UseLastPluggedInDeviceBtn
            // 
            UseLastPluggedInDeviceBtn.Location = new Point(17, 79);
            UseLastPluggedInDeviceBtn.Name = "UseLastPluggedInDeviceBtn";
            UseLastPluggedInDeviceBtn.Size = new Size(251, 52);
            UseLastPluggedInDeviceBtn.TabIndex = 1;
            UseLastPluggedInDeviceBtn.Text = "Use last plugged in device";
            UseLastPluggedInDeviceBtn.UseVisualStyleBackColor = true;
            UseLastPluggedInDeviceBtn.Click += UseLastPluggedInDeviceBtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 47);
            label2.Name = "label2";
            label2.Size = new Size(107, 20);
            label2.TabIndex = 2;
            label2.Text = "Current device:";
            // 
            // current_device_label
            // 
            current_device_label.AutoSize = true;
            current_device_label.Location = new Point(127, 47);
            current_device_label.Name = "current_device_label";
            current_device_label.Size = new Size(42, 20);
            current_device_label.TabIndex = 3;
            current_device_label.Text = "none";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(11, 174);
            label3.Name = "label3";
            label3.Size = new Size(165, 38);
            label3.TabIndex = 4;
            label3.Text = "Lock Screen";
            // 
            // ShowBlackScreenWhenLockedCheckBox
            // 
            ShowBlackScreenWhenLockedCheckBox.AutoSize = true;
            ShowBlackScreenWhenLockedCheckBox.Location = new Point(16, 215);
            ShowBlackScreenWhenLockedCheckBox.Name = "ShowBlackScreenWhenLockedCheckBox";
            ShowBlackScreenWhenLockedCheckBox.Size = new Size(239, 24);
            ShowBlackScreenWhenLockedCheckBox.TabIndex = 5;
            ShowBlackScreenWhenLockedCheckBox.Text = "Show black screen when locked";
            ShowBlackScreenWhenLockedCheckBox.UseVisualStyleBackColor = true;
            ShowBlackScreenWhenLockedCheckBox.CheckedChanged += ShowBlackScreenWhenLockedCheckBox_CheckedChanged;
            // 
            // BlackScreenText
            // 
            BlackScreenText.Location = new Point(16, 282);
            BlackScreenText.Name = "BlackScreenText";
            BlackScreenText.Size = new Size(410, 27);
            BlackScreenText.TabIndex = 6;
            BlackScreenText.TextChanged += BlackScreenText_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 259);
            label4.Name = "label4";
            label4.Size = new Size(123, 20);
            label4.TabIndex = 7;
            label4.Text = "Black Screen Text";
            // 
            // UseLastDeviceErrorLabel
            // 
            UseLastDeviceErrorLabel.AutoSize = true;
            UseLastDeviceErrorLabel.ForeColor = Color.Red;
            UseLastDeviceErrorLabel.Location = new Point(16, 132);
            UseLastDeviceErrorLabel.Name = "UseLastDeviceErrorLabel";
            UseLastDeviceErrorLabel.Size = new Size(42, 20);
            UseLastDeviceErrorLabel.TabIndex = 8;
            UseLastDeviceErrorLabel.Text = "none";
            UseLastDeviceErrorLabel.Visible = false;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 330);
            Controls.Add(UseLastDeviceErrorLabel);
            Controls.Add(label4);
            Controls.Add(BlackScreenText);
            Controls.Add(ShowBlackScreenWhenLockedCheckBox);
            Controls.Add(label3);
            Controls.Add(current_device_label);
            Controls.Add(label2);
            Controls.Add(UseLastPluggedInDeviceBtn);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SettingsForm";
            Text = "Settings - Windows Auto Lock & Unlock";
            FormClosing += SettingsForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button UseLastPluggedInDeviceBtn;
        private Label label2;
        private Label current_device_label;
        private Label label3;
        private CheckBox ShowBlackScreenWhenLockedCheckBox;
        private TextBox BlackScreenText;
        private Label label4;
        private Label UseLastDeviceErrorLabel;
    }
}