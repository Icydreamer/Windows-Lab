using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C5;
namespace EventHandle
{
    public class FireWatcher
    {
        private C5_SY1 parent;
        public FireWatcher(C5_SY1 _parent, FireAlarm fireAlarm)
        {
            parent = _parent;
            fireAlarm.FireEvent += new FireAlarm.FireEventHandler(WatchFire);
        }
        void WatchFire(object sender, FireEventArgs fe)
        {
            OutStr.sw.WriteLine(" {0} 对象调用，群众发现火情WatchFire 函数.", sender.ToString());
            parent.showComment(sender.ToString() + " 对象调用，群众发现火情WatchFire 函数.");
            if (fe.ferocity < 2)
            {
                OutStr.sw.WriteLine(" 群众察到火情发生在{0}，主人浇水后火情被扑灭了", fe.room);
                parent.showComment(" 群众察到火情发生在 " + fe.room + "，主人浇水后火情被扑灭了");
            }
            else
            {
                OutStr.sw.WriteLine(" 群众无法控制{0} 的火情，消防官兵来到!", fe.room);
                parent.showComment(" 群众无法控制 " + fe.room + " 的火情，消防官兵来到!");
            }
        }

    }
}
