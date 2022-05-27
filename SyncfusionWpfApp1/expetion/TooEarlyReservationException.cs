using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncfusionWpfApp1.expetion
{
    public class TooEarlyReservationException : Exception
    {
        public TooEarlyReservationException(string message)
        : base(message)
        {
        }
    }
}
