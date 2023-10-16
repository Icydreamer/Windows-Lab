using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using C5;
namespace EventHandle
{
    public class FireHandler
    {
        private C5_SY1 parent;
        private FireAlarm fireAlarm;
        public FireHandler(C5_SY1 _parent, FireAlarm _fireAlarm)
        {
            parent = _parent;
            fireAlarm = _fireAlarm;
            fireAlarm.FireEvent += new FireAlarm.FireEventHandler(ExtinguishFire);
            fireAlarm.FireEvent += new FireAlarm.FireEventHandler(ExtinguishFire2);

        }
        void ExtinguishFire(object sender, FireEventArgs fe)
        {
            OutStr.sw.WriteLine(" {0} 对象调用，灭火事件ExtinguishFire 函数.", sender.ToString());
            parent.showComment(sender.ToString() + " 对象调用，灭火事件ExtinguishFire 函数.");
            //根据火情状况，输出不同的信息.
            if (fe.ferocity < 2)
            {
                OutStr.sw.WriteLine(" 火情发生在{0}，主人浇水后火情被扑灭了", fe.room);
                parent.showComment(" 火情发生在 " + fe.room + "，主人浇水后火情被扑灭了");
            }
            else
            {
                OutStr.sw.WriteLine("{0} 的火情无法控制，主人打119!", fe.room);
                parent.showComment(fe.room + " 的火情无法控制，主人打119!");
            }
        }
        void ExtinguishFire2(object sender, FireEventArgs fe)
        {
            OutStr.sw.WriteLine(" {0} 对象调用，灭火事件ExtinguishFire2 函数，I don't care.", sender.ToString());
            parent.showComment(sender.ToString() + " 对象调用，灭火事件ExtinguishFire2 函数，，I don't care.");
        }

    }
}
