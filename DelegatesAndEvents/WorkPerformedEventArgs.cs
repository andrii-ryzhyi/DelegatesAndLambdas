using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    public class WorkPerformedEventArgs : EventArgs
    {
        public WorkPerformedEventArgs(int hours, WorkType workType)
        {
            Hours = hours;
            this.workType = workType;
        }
        public int Hours { get; set; }
        public WorkType workType { get; set; }
    }
}
