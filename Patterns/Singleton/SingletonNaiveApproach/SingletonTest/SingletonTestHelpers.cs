using SingletonNaiveApproach;
using System;
using System.Reflection;

namespace SingletonTest
{
    internal static class SingletonTestHelpers
    {
        internal static void Reset(Type type)
        {
            FieldInfo info = type.GetField("instance",
                BindingFlags.NonPublic | BindingFlags.Static);
            info.SetValue(null, null);
        }

        internal static T GetPrivateStaticInstance<T>() where T:class
        {
            Type type = typeof(T);
            FieldInfo info = type.GetField("instance",
                BindingFlags.NonPublic | BindingFlags.Static);
            info.SetValue(null, null);
            return info.GetValue(null) as T;
        }
    }
}