using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTracker2.Printing
{
    public interface IPrintJob
    {
        bool Print();
        string DisplayText { get; }
    }
}
