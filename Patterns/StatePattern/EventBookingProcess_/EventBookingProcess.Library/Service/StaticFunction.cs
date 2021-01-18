using EventBookingProcess.Library.Model;
using EventBookingProcess.Library.ValueObjects;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EventBookingProcess.Library.Service
{
    public class StaticFunction<TResult>
    {
        public static async Task<TResult> ProcessBooking(Booking booking,
            Func<Booking, ProcessingResult, TResult> callback,
            CancellationToken token
        )
        {
            try
            {
                await Task.Run(async delegate
                {
                    await Task.Delay(new TimeSpan(0, 0, 3), token);
                });
            }
            catch (OperationCanceledException)
            {
                return callback(booking, ProcessingResult.Cancel);
            }

            ProcessingResult result = new Random().Next(0, 2) == 0 ? ProcessingResult.Success : ProcessingResult.Fail;
            return callback(booking, result);
        }
    }
}
