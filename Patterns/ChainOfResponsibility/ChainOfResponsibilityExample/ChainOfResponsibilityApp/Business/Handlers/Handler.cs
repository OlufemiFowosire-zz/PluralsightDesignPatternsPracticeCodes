using System;

namespace ChainOfResponsibilityApp.Business.Handlers
{
    public abstract class Handler<T> : IHandler<T> where T : class
    {
        private IHandler<T> Next { get; set; }
        protected T request;

        public void Handle()
        {
            Next?.Handle();
            if (hook())
            {
                throwException();
            }
        }

        protected abstract void throwException();
        protected virtual bool hook()
        {
            return true;
        }
        public IHandler<T> SetNext(IHandler<T> next)
        {
            Next = next;
            return Next;
        }
    }
}
