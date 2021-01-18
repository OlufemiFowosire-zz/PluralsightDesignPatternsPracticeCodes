using SingletonExample.LoggingService;
using System;

#nullable enable
namespace SingletonNaiveApproach
{
    public sealed class Singleton
    {
        #region check example
        private static Singleton? instance;
        public static Singleton Instance
        {
            get
            {
                Logger.Log("Instance called");
                return instance ??= new Singleton();
            }
        }
        private Singleton()
        {
            Logger.Log("Constructor invoked");
        }
        #endregion

        #region Using eager loading against lazy loading
        //private static readonly Singleton instance = new Singleton();
        //public static Singleton Instance => instance;
        //private Singleton()
        //{
        //}
        #endregion

        #region double-check lock example
        //private static readonly object padlock = new object();
        //private static readonly Singleton instance;
        //public static Singleton Instance
        //{
        //    get
        //    {
        //        if (instance == null)
        //        {
        //            lock (padlock)
        //            {
        //                if (instance == null)
        //                    instance = new Singleton();
        //            }
        //        }
        //        return instance;
        //    }
        //}
        //private Singleton()
        //{
        //}
        #endregion

        #region Declaring static constructor to override c# compiler behaviour of marking type initializers beforefieldinit
        //private static readonly Singleton instance = new Singleton();
        //static Singleton()
        //{
        //}
        //public static Singleton Instance => instance;
        //private Singleton()
        //{
        //}
        #endregion

        #region Using static constructor in a nested class
        //public static Singleton Instance => Nested.instance;
        //private sealed class Nested
        //{
        //    internal static readonly Singleton instance = new Singleton();
        //    static Nested()
        //    {
        //    }
        //}
        //private Singleton() 
        //{
        //}
        #endregion

        #region Using Lazy<T> type which provides a built-in support for lazy initialization
        /**
         * When you create a Lazy<T>, you specify the type
         * And a function that returns an instance of the type
         */
        //private static readonly Lazy<Singleton> instance = new Lazy<Singleton>(() => new Singleton());
        //public static Singleton Instance => instance.Value;
        //private Singleton()
        //{
        //}
        #endregion

        #region .NET Core in-built support for IOC Containers:
        /**
         * Services Collection whicj can equally be used to create
         * Singletons asides other things like Dependency injections
         */
        #endregion
    }
}
