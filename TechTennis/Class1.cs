using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KinectSkeletonApplication2
{
    public static class MoveEventClass
    {
        public static event EventHandler MyEvent;
        public static EventArgs eventArgs;

        public static void FireMyEvent(EventArgs args)
        {
            var evt = MyEvent;
            eventArgs = args;
        }
    }
}
