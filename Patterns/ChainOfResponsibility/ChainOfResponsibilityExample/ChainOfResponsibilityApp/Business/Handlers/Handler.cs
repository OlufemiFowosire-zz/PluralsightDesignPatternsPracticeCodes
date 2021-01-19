using System;

namespace ChainOfResponsibilityApp.Business.Handlers
{
    public abstract class Handler<T> : IHandler<T> where T : class
    {
        private IHandler<T> Next { get; set; }
        protected T request;
        protected Predicate<T> predicate;

        public void Handle()
        {
            Next?.Handle();
            if (predicate(request))
            {
                hookException();
            }
        }

        protected abstract void hookException();
        public IHandler<T> SetNext(IHandler<T> next)
        {
            Next = next;
            return Next;
        }
    }
}
