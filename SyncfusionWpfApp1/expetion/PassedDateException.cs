using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncfusionWpfApp1.expetion
{
    public class PassedDateException :Exception
    {
        public PassedDateException(string message)
        : base(message)
        {
        }
    }
}
