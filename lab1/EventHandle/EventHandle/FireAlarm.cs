using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandle
{
    public class FireAlarm
    {
        public delegate void FireEventHandler(object sender, FireEventArgs fe);
        public event FireEventHandler FireEvent;
        public void ActivateFireAlarm(string room, int ferocity)
        {
            FireEventArgs fireArgs = new FireEventArgs(room, ferocity);
            FireEvent(this, fireArgs);
        }
    }
}
