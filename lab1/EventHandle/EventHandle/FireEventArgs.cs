using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandle
{
    public class FireEventArgs : EventArgs
    {
        public FireEventArgs(string room, int ferocity)
        {
            this.room = room;
            this.ferocity = ferocity;
        }
        public string room;
        public int ferocity;
    }
}
