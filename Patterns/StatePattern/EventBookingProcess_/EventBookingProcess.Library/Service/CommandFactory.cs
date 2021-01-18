using EventBookingProcess.Library.Command;
using EventBookingProcess.Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBookingProcess.Library.Service
{
    public sealed class CommandFactory
    {
        public static T1 CreateCommand<T1, T2>(T2 t2) where T1:BookingCommand, new() where T2: Booking
        {
            var command = new T1();
            return command;
        }
    }
}
