using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsAutoLockUnlock.Events
{

    class SystemLockRequestEvent
    {
        public event EventHandler OnSystemLockRequest;

        public void Trigger()
        {
            OnSystemLockRequest?.Invoke(this, new EventArgs());
        }

    }
}
