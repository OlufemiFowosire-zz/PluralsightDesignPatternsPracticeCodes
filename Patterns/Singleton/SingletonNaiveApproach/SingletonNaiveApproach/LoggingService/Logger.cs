using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SingletonExample.LoggingService
{
    public static class Logger
    {
        private static ConcurrentQueue<string> log = new ConcurrentQueue<string>();
        public static int DelayMilliseconds { get; set; } = 0;
        public static void Log(string message)
        {
            //Thread.Sleep(DelayMilliseconds);
            Task.Delay(DelayMilliseconds);
            log.Enqueue(message);
        }
        public static void Clear()
        {
            log.Clear();
        }
        public static string StringDump()
        {
            return string.Join(Environment.NewLine, log);
        }
        public static List<string> Output()
        {
            return log.ToList();
        }
    }
}
