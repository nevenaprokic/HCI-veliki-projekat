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
       
        public static bool isTooEarlyReservation(DateTime start)
        {
            return (start.Date - DateTime.Now.Date).TotalDays > 5;
        }

        public static bool validateDates(DateTime start)
        {
            if (start < DateTime.Today) throw new PassedDateException("Izabrano vreme putovanja je prošlo");
            else if (isTooEarlyReservation(start)) throw new TooEarlyReservationException("Najranije možete da rezervišete/kupite kartu 5 dana pred polazak");
            return true;
        }
    }
}
