using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threads.Models
{
    public static class ExtendMethod
    {
        public static ThreadState SimpleState(this ThreadState th)
        {
            return th&(ThreadState.Running|ThreadState.Wait|ThreadState.Standby);
        }
    }
}
