using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncfusionWpfApp1.expetion
{
    public class StartDateAfterBackDateException : Exception
    {
        public StartDateAfterBackDateException(string message)
        : base(message)
        {
        }
    }
}
