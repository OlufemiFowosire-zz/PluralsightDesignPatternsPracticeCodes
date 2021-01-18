using System.Collections.Generic;

namespace VirtualProxy
{
    public abstract class BaseClassWithHistory
    {
        public List<string> History { get; } = new List<string>();
    }
}