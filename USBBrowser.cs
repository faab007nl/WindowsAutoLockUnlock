using System;
using System.Diagnostics;
using System.Management;

namespace WindowsAutoLockUnlock
{
    internal class UsbBrowser
    {
        public static void PrintUsbDevices()
        {
            IList<ManagementBaseObject> usbDevices = GetUsbDevices();

            foreach (ManagementBaseObject usbDevice in usbDevices)
            {
                String deviceId = GetDeviceProperty(usbDevice.Properties, "DeviceID");
                String deviceDescription = GetDeviceProperty(usbDevice.Properties, "Description");

                if (deviceDescription.Contains("Bluetooth")) continue;

                Debug.WriteLine("----- DEVICE -----");
                Debug.WriteLine("Id: " + deviceId);
                Debug.WriteLine("Description: " + deviceDescription);
                Debug.WriteLine("------------------");
            }
        }

        public static String? GetDeviceProperty(PropertyDataCollection properties, String key)
        {
            String? value = null;
            foreach (var property in properties)
            {
                //Debug.WriteLine(string.Format("{0}: {1}", property.Name, property.Value));
                if (property.Name == key)
                {
                    value = property.Value.ToString();
                    break;
                }
            }
            return value;
        }

        public static IList<ManagementBaseObject> GetUsbDevices()
        {
            IList<string> usbDeviceAddresses = LookUpUsbDeviceAddresses();

            List<ManagementBaseObject> usbDevices = new List<ManagementBaseObject>();

            foreach (string usbDeviceAddress in usbDeviceAddresses)
            {
                // query MI for the PNP device info
                // address must be escaped to be used in the query; luckily, the form we extracted previously is already escaped
                ManagementObjectCollection curMoc = QueryMi("Select * from Win32_PnPEntity where PNPDeviceID = " + usbDeviceAddress);
                foreach (ManagementBaseObject device in curMoc)
                {
                    usbDevices.Add(device);
                }
            }

            return usbDevices;
        }

        public static IList<string> LookUpUsbDeviceAddresses()
        {
            // this query gets the addressing information for connected USB devices
            ManagementObjectCollection usbDeviceAddressInfo = QueryMi(@"Select * from Win32_USBControllerDevice");

            List<string> usbDeviceAddresses = new List<string>();

            foreach (var device in usbDeviceAddressInfo)
            {
                string curPnpAddress = (string)device.GetPropertyValue("Dependent");
                // split out the address portion of the data; note that this includes escaped backslashes and quotes
                curPnpAddress = curPnpAddress.Split(new String[] { "DeviceID=" }, 2, StringSplitOptions.None)[1];

                usbDeviceAddresses.Add(curPnpAddress);
            }

            return usbDeviceAddresses;
        }

        // run a query against Windows Management Infrastructure (MI) and return the resulting collection
        public static ManagementObjectCollection QueryMi(string query)
        {
            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(query);
            ManagementObjectCollection result = managementObjectSearcher.Get();

            managementObjectSearcher.Dispose();
            return result;
        }

    }
}
