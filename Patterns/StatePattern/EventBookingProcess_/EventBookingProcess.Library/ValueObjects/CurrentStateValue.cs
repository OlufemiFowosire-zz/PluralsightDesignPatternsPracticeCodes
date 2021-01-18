using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBookingProcess.Library.ValueObjects
{
    public enum CurrentStateValue
    {
        New,
        Closed,
        Booked,
        Pending,
        Failed,
        No_Booking
    }
}
