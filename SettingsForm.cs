using WindowsAutoLockUnlock.Events;

namespace WindowsAutoLockUnlock
{

    partial class SettingsForm : Form
    {
        private USBManager? usbManager;

        public SettingsForm()
        {
            InitializeComponent();


            String DeviceID = Properties.Settings.Default.CurrentDeviceId;
            String Description = Properties.Settings.Default.CurrentDeviceDesc;

            if (DeviceID != null && Description != null)
            {
                current_device_label.Text = DeviceID + " (" + Description + ")";
            }
            current_device_label.Text = "None";
        }

        public void SetUsbManager(USBManager manager)
        {
            this.usbManager = manager;
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown) return;
            e.Cancel = true;

            this.Hide();
        }

        private void UseLastPluggedInDeviceBtn_Click(object sender, EventArgs e)
        {
            USBDeviceInfo lastDevice = usbManager.GetLastPluggedInDevice();

            if (lastDevice == null)
            {
                current_device_label.Text = "None";
                UseLastDeviceErrorLabel.Text = "No device detected";
                UseLastDeviceErrorLabel.Visible = true;
                UseLastDeviceErrorLabel.ForeColor = Color.Red;
            }
            else
            {
                UseLastDeviceErrorLabel.Text = "Device detected";
                UseLastDeviceErrorLabel.Visible = true;
                UseLastDeviceErrorLabel.ForeColor = Color.Green;

                current_device_label.Text = lastDevice.DeviceID + " (" + lastDevice.Description + ")";

                Properties.Settings.Default.CurrentDeviceId = lastDevice.DeviceID;
                Properties.Settings.Default.CurrentDeviceDesc = lastDevice.Description;
                Properties.Settings.Default.Save();
            }
        }

        private void ShowBlackScreenWhenLockedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShowBlackScreenWhenLocked = ShowBlackScreenWhenLockedCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        private void BlackScreenText_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.BlackScreenText = BlackScreenText.Text;
            Properties.Settings.Default.Save();
        }
    }
}