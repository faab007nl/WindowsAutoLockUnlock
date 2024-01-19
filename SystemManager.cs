using System;
using System.Runtime.InteropServices;
using System.Management;
using System.Diagnostics;
using Microsoft.Win32;

namespace WindowsAutoLockUnlock
{
    internal class SystemManager
    {

        public static void Lock()
        {
            LockWorkStation();
        }

        public static void Unlock()
        {
            ManagementPath path = new ManagementPath();
            path.NamespacePath = "\\ROOT\\CIMV2\\Security\\MicrosoftVolumeEncryption"; path.ClassName = "Win32_EncryptableVolume";

            ManagementScope scope = new ManagementScope(path, new ConnectionOptions() { Impersonation = ImpersonationLevel.Impersonate });

            ManagementClass management = new ManagementClass(scope, path, new ObjectGetOptions());

            foreach (ManagementObject vol in management.GetInstances())
            {
                Debug.WriteLine("----" + vol["DriveLetter"]);
                switch ((uint)vol["ProtectionStatus"])
                {
                    case 0:
                        Debug.WriteLine("not protected by bitlocker");
                        break;
                    case 1:
                        Debug.WriteLine("unlocked");
                        break;
                    case 2:
                        Debug.WriteLine("locked");
                        break;
                }

                if ((uint)vol["ProtectionStatus"] == 2)
                {
                    Debug.WriteLine("unlock this driver ...");

                    vol.InvokeMethod("UnlockWithPassphrase", new object[] { "Stroom22)v" });

                    Debug.WriteLine("unlock done.");
                }
            }
        }

        public static void CheckIfRunningAsAdmin()
        {
            RegistryKey rk;
            string registryPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon\";

            try
            {
                if (Environment.Is64BitOperatingSystem)
                {
                    rk = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
                }
                else
                {
                    rk = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry32);
                }

                rk = rk.OpenSubKey(registryPath, true);
            }
            catch (System.Security.SecurityException ex)
            {
                MessageBox.Show("Please run as administrator");
                System.Environment.Exit(1);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


        // External functions

        [DllImport("user32.dll")]
        private static extern bool LockWorkStation();

        

    }
}
