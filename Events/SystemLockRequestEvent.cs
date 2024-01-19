using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsAutoLockUnlock.Events
{

    class SystemUnLockRequestEvent
    {
        public event EventHandler OnSystemUnLockRequest;

        public void Trigger()
        {
            OnSystemUnLockRequest?.Invoke(this, new EventArgs());
        }

    }
}
