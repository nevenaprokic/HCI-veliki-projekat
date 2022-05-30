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
        public static bool isBackDateTimeAfterStartDateTime(DateTime start, DateTime back)
        {
            return back > start;
        }

        public static bool isBackDateAfterStartDate (DateTime start, DateTime back)
        {
            return back.Date >= start.Date;
        }

        public static bool isTooEarlyReservation(DateTime start)
        {
            return (start.Date - DateTime.Now.Date).TotalDays > 5;
        }

        public static bool validateDates(DateTime start, DateTime back)
        {
            if (start < DateTime.Today) throw new PassedDateException("Izabrano vreme putovanja je prošlo");
            if (!isBackDateTimeAfterStartDateTime(start, back))
            {
                if (!isBackDateAfterStartDate(start, back)) throw new StartDateAfterBackDateException("Datum povratka ne može biti pre datuma polaska");
                else throw new StartTimeAfterBackTimeException("Vreme povratka u istom danu mora biti nakon dolaska");
            }
            else if (isTooEarlyReservation(start)) throw new TooEarlyReservationException("Najranije možete da rezervišete/kupite kartu 5 dana pred polazak");
            return true;
        }
    }
}
