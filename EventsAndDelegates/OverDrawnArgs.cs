﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegates
{
    public class OverDrawnArgs : EventArgs
    {
        public decimal DebitAmount;

        public bool allow = false;
    }
}
