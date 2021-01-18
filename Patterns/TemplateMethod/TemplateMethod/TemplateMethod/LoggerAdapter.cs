using System;
using System.Collections.Generic;

namespace TemplateMethod
{
    public class LoggerAdapter
    {
        private List<string> messages = new List<string>();

        public void Log(string message) => messages.Add(message);

        public string Dump() => string.Join(Environment.NewLine, messages);
    }
}