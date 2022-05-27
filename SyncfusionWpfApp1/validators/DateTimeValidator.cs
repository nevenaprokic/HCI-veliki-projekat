using SyncfusionWpfApp1.expetion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncfusionWpfApp1.validators
{
    public class DateTimeValidator
    {
        public static bool isBackDateTimeAfterStartDateTime(DateTime start, DateTime back, int travelDuration)
        {
            return (back.Date - start.Date).TotalMinutes > travelDuration;
        }

        public static bool isBackDateAfterStartDate (DateTime start, DateTime back)
        {
            return back >= start;
        }

        public static bool validateDates(DateTime start, DateTime back, int travelDuration)
        {
            if(!isBackDateTimeAfterStartDateTime(start, back, travelDuration))
            {
                if (!isBackDateAfterStartDate(start, back)) throw new StartDateAfterBackDateException("Datum povratka ne može biti pre datuma polaska");
            }
            return true;
        }
    }
}
