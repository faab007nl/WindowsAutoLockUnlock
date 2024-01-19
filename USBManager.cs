using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using WindowsAutoLockUnlock.Events;

namespace WindowsAutoLockUnlock
{
    internal class USBManager
    {
        public SystemLockRequestEvent systemLockRequestEvent = new SystemLockRequestEvent();
        public SystemUnLockRequestEvent systemUnLockRequestEvent = new SystemUnLockRequestEvent();

        private ManagementEventWatcher? w;
        private USBDeviceInfo? lastPluggedInDevice;

        public USBManager()
        {
            AddInsetUSBHandler();
            AddRemoveUSBHandler();
        }

        public void AddRemoveUSBHandler()
        {
            WqlEventQuery q;
            ManagementScope scope = new ManagementScope("root\\CIMV2");
            scope.Options.EnablePrivileges = true;

            try
            {
                q = new WqlEventQuery();
                q.EventClassName = "__InstanceDeletionEvent";
                q.WithinInterval = new TimeSpan(0, 0, 3);
                q.Condition = @"TargetInstance ISA 'Win32_USBHub'";
                w = new ManagementEventWatcher(scope, q);
                w.EventArrived += new EventArrivedEventHandler(USBRemoved);
                w.Start();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                if (w != null)
                    w.Stop();
            }
        }

        void AddInsetUSBHandler()

        {
            WqlEventQuery q;
            ManagementScope scope = new ManagementScope("root\\CIMV2");
            scope.Options.EnablePrivileges = true;

            try
            {
                q = new WqlEventQuery();
                q.EventClassName = "__InstanceCreationEvent";
                q.WithinInterval = new TimeSpan(0, 0, 3);
                q.Condition = @"TargetInstance ISA 'Win32_USBHub'";
                w = new ManagementEventWatcher(scope, q);
                w.EventArrived += new EventArrivedEventHandler(USBAdded);
                w.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                if (w != null)
                    w.Stop();
            }
        }
        public void USBAdded(object sender, EventArrivedEventArgs e)
        {
            ManagementBaseObject instance = (ManagementBaseObject)e.NewEvent["TargetInstance"];
            String deviceId = UsbBrowser.GetDeviceProperty(instance.Properties, "DeviceID");
            String deviceDescription = UsbBrowser.GetDeviceProperty(instance.Properties, "Description");

            lastPluggedInDevice = new USBDeviceInfo(deviceId, deviceDescription);
            systemUnLockRequestEvent.Trigger();

            Debug.WriteLine("A USB device inserted");
            Debug.WriteLine("Id: " + deviceId);
            Debug.WriteLine("Description: " + deviceDescription);
        }

        public void USBRemoved(object sender, EventArrivedEventArgs e)
        {
            ManagementBaseObject instance = (ManagementBaseObject)e.NewEvent["TargetInstance"];
            String deviceId = UsbBrowser.GetDeviceProperty(instance.Properties, "DeviceID");
            String deviceDescription = UsbBrowser.GetDeviceProperty(instance.Properties, "Description");

            if(Properties.Settings.Default.CurrentDeviceId == deviceId)
            {
                systemLockRequestEvent.Trigger();
            }

            Debug.WriteLine("A USB device removed");
            Debug.WriteLine("Id: " + deviceId);
            Debug.WriteLine("Description: " + deviceDescription);
        }

        public USBDeviceInfo? GetLastPluggedInDevice()
        {
            return lastPluggedInDevice;
        }

    }
}
