using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsAutoLockUnlock.Events
{

    class FormOpenedEvent
    {
        public event EventHandler OnFormOpened;

        public void Trigger()
        {
            OnFormOpened?.Invoke(this, new EventArgs());
        }

    }
}
