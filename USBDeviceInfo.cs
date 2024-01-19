using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsAutoLockUnlock
{
    internal class USBDeviceInfo
    {
        public USBDeviceInfo(string deviceID, string description)
        {
            this.DeviceID = deviceID;
            this.Description = description;
        }
        public string DeviceID { get; private set; }
        public string Description { get; private set; }
    }
}
