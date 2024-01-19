using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Management;
using WindowsAutoLockUnlock.Events;

namespace WindowsAutoLockUnlock
{
    internal partial class WindowsAutoLockUnlock: ApplicationContext
    {

        private readonly SettingsForm settingsForm;
        private readonly LockScreenForm lockScreenForm;
        private readonly NotifyIcon trayIcon;
        private readonly USBManager usbManager;
        private bool cancelLock = false;

        public WindowsAutoLockUnlock() {
            //SystemManager.CheckIfRunningAsAdmin();

            trayIcon = new()
            {
                Icon = new Icon("Resources/lock.ico"),
                Text = "Windows Auto Lock & Unlock",
                Visible = true
            };

            ContextMenuStrip contextMenu = new();

            ToolStripMenuItem openSettings = new()
            {
                Text = "Settings"
            };
            openSettings.Click += new EventHandler(openSettingsMenu);
            contextMenu.Items.Add(openSettings);

            ToolStripMenuItem exitApplication = new()
            {
                Text = "Close"
            };
            exitApplication.Click += new EventHandler(closeApplication);
            contextMenu.Items.Add(exitApplication);

            trayIcon.ContextMenuStrip = contextMenu;


            // Setup settings form
            settingsForm = new SettingsForm();

            // Setup lock screen form
            lockScreenForm = new LockScreenForm();

            // Setup usb manager
            usbManager = new USBManager();
            settingsForm.SetUsbManager(usbManager);

            // Register events
            usbManager.systemLockRequestEvent.OnSystemLockRequest += usbManager_OnSystemLockRequest;
            usbManager.systemUnLockRequestEvent.OnSystemUnLockRequest += usbManager_OnSystemUnLockRequest;
        }

        public void usbManager_OnSystemLockRequest(object sender, EventArgs e)
        {
            Debug.WriteLine("ShowBlackScreenWhenLocked: " + Properties.Settings.Default.ShowBlackScreenWhenLocked.ToString());

            if (Properties.Settings.Default.ShowBlackScreenWhenLocked)
            {
                Debug.WriteLine("Showing Black Screen");
                lockScreenForm.Show();
            }

            UserInteractController userInteractController = new UserInteractController();
            if (
                userInteractController.userHasInteracted &&
                !cancelLock
            )
            {
                SystemManager.Lock();
            }
            cancelLock = false;
        }
        public void usbManager_OnSystemUnLockRequest(object sender, EventArgs e)
        {
            Debug.WriteLine("Lock Cancelled");

            if (Properties.Settings.Default.ShowBlackScreenWhenLocked)
            {
                lockScreenForm.Hide();
            }
            cancelLock = true;
            SystemManager.Unlock();
        }

        public void openSettingsMenu(object sender, EventArgs e)
        {
            settingsForm.Show();
        }

        public void closeApplication(object sender, EventArgs e)
        {
            DialogResult messageBox = MessageBox.Show("Are you sure you want to close Windows Auto Lock & Unlock", "Close App?", MessageBoxButtons.YesNo);
            if(messageBox.Equals(DialogResult.Yes))
            {
                settingsForm.Dispose();
                this.Dispose();
                System.Environment.Exit(1);
                Application.Exit();
            }
        }
        

    }
}
